namespace TicTacChess {

    enum State {
        Setup,
        Playing,
        Waiting,
        Finished,
    }

    internal class Game : Panel {
        Main main;
        Arduino arduino;

        readonly int squareSize = 100;
        readonly int legalMoveDotSize = 25;

        //dictonary to store the piece with its location
        Dictionary<int, IPiece> pieces = new();

        //a hash set for easy lookup to check if a position is in the legal moves
        HashSet<int> legalMoves = new();

        IPiece? currentPiece = null;
        int currentPosition = -1;


        //if the game has won this is set and used in the drawing of the squares to make them green
        HashSet<int>? stripe;
        Dictionary<int, IPiece> whiteStart = new();
        Dictionary<int, IPiece> blackStart = new();

        State state = State.Setup;
        PieceColor currentColor = PieceColor.White;
        int totalMoves;

        public Game() : base() {
            DoubleBuffered = true;
            Size = new Size(squareSize * 3, squareSize * 3);
        }


        public void Reset() {
            if (state == State.Playing || state == State.Finished) {
                arduino.Reset();
                pieces = whiteStart.Union(blackStart).ToDictionary(pair => pair.Key, pair => pair.Value);
            } else {
                pieces.Clear();
            }
            
            whiteStart.Clear();
            blackStart.Clear();
            legalMoves.Clear();

            currentPiece = null;
            currentPosition = -1;

            stripe = null;
            totalMoves = 0;
            currentColor = PieceColor.White;
            state = State.Setup;

            Invalidate();
        }

        //the control has to be redrawn so it draws the selected piece
        protected override void OnMouseMove(MouseEventArgs e) {
            Invalidate();
            base.OnMouseMove(e);
        }

        public void DrawCursor(Graphics graphics) {
            if (currentPiece == null) {
                return;
            }

            Image image = currentPiece.Image();

            int w = image.Width / 3;
            int h = image.Height / 3;

            Point point = PointToClient(MousePosition);
            //attempt to draw image on mouse pointer
            graphics.DrawImage(image, point.X - w / 2, point.Y - h / 2, w, h);
            image.Dispose();

        }

        public void DrawBoard(Graphics graphics) {
            int x = 0;
            int y = 0;

            for (int i = 0; i < 9; i++) {
                int actualX = x * squareSize;
                int actualY = y * squareSize;


                Pen pen = new(i % 2 == 0 ? Color.LightBlue : Color.White);

                graphics.FillRectangle(pen.Brush, actualX, actualY, squareSize, squareSize);


                if (stripe != null && stripe.Contains(i)) {
                    Pen stripePen = new(Color.LightSeaGreen);
                    graphics.FillRectangle(stripePen.Brush, actualX + 10, actualY + 10, squareSize - 20, squareSize - 20);
                    stripePen.Dispose();
                }



                pen.Dispose();

                if (pieces.ContainsKey(i) && currentPosition != i) {
                    Image image = pieces[i].Image();

                    //attempt to draw image in center
                    graphics.DrawImage(image, actualX + squareSize / 4, actualY, image.Width / 3, image.Height / 3);
                    image.Dispose();
                }

                if (legalMoves.Contains(i)) {
                    //attempt to to draw a circle in the center
                    int centerOffset = (squareSize / 2 + legalMoveDotSize) / 2;
                    Pen legalMovePen = new(pieces.ContainsKey(i) ? Color.BlueViolet : Color.Gray);

                    graphics.FillEllipse(
                        legalMovePen.Brush,
                        actualX + centerOffset, actualY + centerOffset,
                        legalMoveDotSize, legalMoveDotSize);

                    legalMovePen.Dispose();
                }

                if (x > 1) {
                    x = 0;
                    y++;
                } else {
                    x++;
                }
            }
        }

        int BoardPositionCursor() {
            int position = 0;

            Point point = PointToClient(MousePosition);

            for (int i = 0; i < 3; i++) {
                if (point.Y > squareSize * (i + 1) == false) {
                    position = i * 3;
                    break;
                }
            }

            for (int i = 0; i < 3; i++) {
                if (point.X > squareSize * (i + 1) == false) {
                    position += i;
                    break;
                }
            }

            return position;
        }

        public void Start() {
            state = State.Playing;

            foreach (var piece in pieces) {
                if (piece.Value.Color() == PieceColor.Black) {
                    blackStart.Add(piece.Key, piece.Value);
                    continue;
                }

                whiteStart.Add(piece.Key, piece.Value);
            }

            main.UpdateColor(PieceColor.White);
        }

        #region check board
        //returns a bool for the win, and a list of the positions that makes the stripe of the winning pieces
        public (bool, List<int>) Check(int postion) {

            var cords = PieceUtils.IntToCordinates(postion);

            int x = cords.Item1;
            int y = cords.Item2;

            var stripe = new List<int>();

            //check col
            for (int i = 0; i < 3; i++) {

                int p = PieceUtils.CordinatesToInt(x, i);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }

                stripe.Add(PieceUtils.CordinatesToInt(x, i));
                if (i == 2) {
                    return (true, stripe);
                }
            }

            //check row
            stripe.Clear();
            for (int i = 0; i < 3; i++) {

                int p = PieceUtils.CordinatesToInt(i, y);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }

                stripe.Add(PieceUtils.CordinatesToInt(i, y));
                if (i == 2) {
                    return (true, stripe);
                }
            }

            //check diag
            stripe.Clear();
            for (int c = 0, r = 0; c < 3; c++) {

                int p = PieceUtils.CordinatesToInt(r, c);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }
                stripe.Add(PieceUtils.CordinatesToInt(r, c));
                if (c == 2) {
                    return (true, stripe);
                }
                r++;
            }

            //check anti diag
            stripe.Clear();
            for (int c = 0, r = 2; c < 3; c++) {

                int p = PieceUtils.CordinatesToInt(r, c);
                if (!pieces.ContainsKey(p) || pieces[p].Color() != currentColor) {
                    break;
                }

                stripe.Add(PieceUtils.CordinatesToInt(r, c));
                if (c == 2) {
                    return (true, stripe);
                }
                r--;
            }

            stripe.Clear();
            return (false, stripe);
        }
        #endregion

        #region event handlers
        protected override void OnPaint(PaintEventArgs e) {
            DrawBoard(e.Graphics);
            DrawCursor(e.Graphics);

            base.OnPaint(e);
        }

        //this is used becase to keep it always square on diff screens
        protected override void OnSizeChanged(EventArgs e) {
            Size size = new(squareSize * 3, squareSize * 3);

            if (!Size.Equals(size)) {
                Size = size;
            }

            base.OnSizeChanged(e);
        }
        protected override void OnClick(EventArgs e) {
            MouseEventArgs args = (MouseEventArgs)e;


            if (args.Button == MouseButtons.Right) {
                legalMoves.Clear();
                currentPosition = -1;
                currentPiece = null;

                base.OnClick(args);
                return;
            }

            int position = BoardPositionCursor();

            if (state == State.Playing) {
                if (currentPiece == null && pieces.ContainsKey(position) && pieces[position].Color() == currentColor) {
                    currentPosition = position;
                    currentPiece = pieces[position];

                    legalMoves = currentPiece.LegalMoves(pieces, position, totalMoves).ToHashSet();
                } else if (currentPiece != null && legalMoves.Contains(position)) {

                    //wizard swap
                    if (currentPiece.GetType() == typeof(Wizard) && pieces.ContainsKey(position)) {
                        pieces.Remove(currentPosition);

                        var swap = pieces[position];
                        pieces.Remove(position);

                        pieces.Add(currentPosition, swap);
                        pieces.Add(position, currentPiece);
                            
                        //swap pieces arduino;
                        arduino.Swap(currentPosition, position);
                        arduino.Zero();
                    } else {
                        pieces.Remove(currentPosition);
                        pieces.Add(position, currentPiece);

                        //move pieces arduino
                        arduino.Move(currentPosition, position);
                        arduino.Zero();
                    }

                    currentPosition = -1;
                    currentPiece = null;
                    legalMoves.Clear();

                    var start = currentColor == PieceColor.White ? whiteStart : blackStart;
                    int count = 0;

                    foreach (var piece in start) {
                        if (pieces.ContainsKey(piece.Key) && pieces[piece.Key] == piece.Value) {
                            count++;
                            continue;
                        }
                    }

                    bool won = false;
                    List<int>? stripe = null;

                    if (count != 3) {
                        (won, stripe) = Check(position);
                    }

                    if (won) {
                        main.GameWin(currentColor);
                        this.stripe = stripe?.ToHashSet();
                        Invalidate();
                    } else {
                        totalMoves++;
                        currentColor = currentColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
                        main.UpdateColor(currentColor);
                    }
                }

            } else if (state == State.Setup && legalMoves.Contains(position)) {
                main.GameClick(position);
            }

            Invalidate();

            base.OnClick(e);
        }
        #endregion

        #region getters & setters
        public void SetMain(Main main) {
            this.main = main;
        }
        public void SetLegalMoves(List<int> moves) {
            legalMoves = moves.ToHashSet();
            Invalidate();
        }
        public Dictionary<int, IPiece> GetPieces() {
            return pieces;
        }

        public void SetState(State state) {
            this.state = state;
        }

        public State GetState() {
            return state;
        }

        public (bool, int) GetEmptyPosition() {
            for (int i = 0; i < 9; i++) {
                if (!pieces.ContainsKey(i)) {
                    return (true, i);
                }
            }

            return (false, -1);
        }

        public (Dictionary<int, IPiece>, Dictionary<int, IPiece>) GetStartPositions() {
            return (whiteStart, blackStart);
        }

        public int GetPieceLocation(PieceColor color, Type type) {
            foreach (var piece in pieces) {
                if (piece.Value.GetType() == type && piece.Value.Color() == color) {
                    return piece.Key;
                }
            }
            return -1;
        }
        public void SetArduino(Arduino arduino) {
            this.arduino = arduino;
        }

        #endregion
    }
}

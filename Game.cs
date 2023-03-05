namespace TicTacChess {
    internal class Game : Panel {
        int squareSize = 100;


        Dictionary<int, IPiece> pieces = new Dictionary<int, IPiece>();
        HashSet<int> legalMoves = new HashSet<int>();
        IPiece? currentPiece = null;
        int currentPosition = -1;

        public Game() : base() {
            DoubleBuffered = true;
            Size = new Size(squareSize * 3, squareSize * 3);

            pieces.Add(6, new Pawn(PieceColor.White));
            pieces.Add(8, new Pawn(PieceColor.Black));
        }

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

            graphics.DrawImage(image, point.X - w / 2, point.Y - h / 2, w, h);
        }

        public void DrawBoard(Graphics graphics) {
            int x = 0;
            int y = 0;

            for (int i = 0; i < 9; i++) {
                Pen pen = new(i % 2 == 0 ? Color.LightBlue : Color.White);

                int actualX = x * squareSize;
                int actualY = y * squareSize;

                graphics.FillRectangle(pen.Brush, actualX, actualY, squareSize, squareSize);
                pen.Dispose();

                if (pieces.ContainsKey(i) && currentPosition != i) {
                    Image image = pieces[i].Image();
                    graphics.DrawImage(image, actualX + 25, actualY, image.Width / 3, image.Height / 3);
                } else if (currentPiece != null && legalMoves.Contains(i)) {
                    Pen legalMovePen = new(Color.Gray);
                    graphics.DrawEllipse(legalMovePen, actualX + 25, actualY, 10, 10);
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

        protected override void OnPaint(PaintEventArgs e) {
            DrawBoard(e.Graphics);
            DrawCursor(e.Graphics);
            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e) {
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

            if (currentPiece == null && pieces.ContainsKey(position)) {
                currentPosition = position;
                currentPiece = pieces[position];

                legalMoves = currentPiece.LegalMoves(pieces, position).ToHashSet();

            } else if (currentPiece != null && !pieces.ContainsKey(position)) {
                pieces.Remove(currentPosition);
                pieces.Add(position, currentPiece);

                currentPosition = -1;
                currentPiece = null;
            }

            Invalidate();

            base.OnClick(e); 
        }
    }
}

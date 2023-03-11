namespace TicTacChess {
    internal class Game : Panel {
        int squareSize = 100;
        int legalMoveDotSize;


        Dictionary<int, IPiece> pieces = new Dictionary<int, IPiece>();
        HashSet<int> legalMoves = new HashSet<int>();
        IPiece? currentPiece = null;
        int currentPosition = -1;
        PieceColor currentColor = PieceColor.White;

        public Game() : base() {
            DoubleBuffered = true;
            legalMoveDotSize = squareSize / 4;
            Size = new Size(squareSize * 3, squareSize * 3);

            pieces.Add(8, new Queen(PieceColor.White));
            pieces.Add(6, new Knight(PieceColor.White));
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
                pen.Dispose();

                if (pieces.ContainsKey(i) && currentPosition != i) {
                    Image image = pieces[i].Image();
                    graphics.DrawImage(image, actualX + squareSize / 4, actualY, image.Width / 3, image.Height / 3);
                    image.Dispose();
                } else if (currentPiece != null && legalMoves.Contains(i)) {
                    
                    int centerOffset = (squareSize / 2 + legalMoveDotSize) / 2;
                    Pen legalMovePen = new(Color.Gray);
                    
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

        protected override void OnPaint(PaintEventArgs e) {
           DrawBoard(e.Graphics);
           DrawCursor(e.Graphics);

            base.OnPaint(e);
        }

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
                currentPosition = -1;
                currentPiece = null;

                base.OnClick(args);
                return;
            }

            int position = BoardPositionCursor(); 

            if (currentPiece == null && pieces.ContainsKey(position)) {
                currentPosition = position;
                currentPiece = pieces[position];

                legalMoves = currentPiece.LegalMoves(pieces, position).ToHashSet();

            } else if (currentPiece != null 
                && !pieces.ContainsKey(position) 
                && legalMoves.Contains(position)) 
           {
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

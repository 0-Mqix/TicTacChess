namespace TicTacChess {
    using Cordinates = Tuple<int, int>;
    enum PieceColor {
        White,
        Black
    }
    enum Direction {
        Left,
        Right,
        Up,
        Down,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight,
    }
    

    interface IPiece {
        public PieceColor Color();
        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position);
        public Image Image();
    }

    static class PieceUtils {
        //Math.Truncate cuts the decimal value from a double -> 3,2 or 3,6 becomes 3
        //this turns a position into x and y
        public static Cordinates IntToCordinates(int position) { 
            return new Cordinates(position % 3, (int)Math.Truncate((double)position / 3)); 
        }

        public static int CordinatesToInt(Cordinates cordinates) { 
            return cordinates.Item1 + (cordinates.Item2 * 3);
        }
        public static int CordinatesToInt(int x, int y) {
            if (x > 2 || y > 2 || x < 0 || y < 0) {
                return -1;
            }
            return x + (y * 3);
        }

        public static void CheckDirection(
             List<int> legalMoves,
             Dictionary<int, IPiece> pieces,
             Direction direction,
             int position
         ) {
            
            Cordinates cords = IntToCordinates(position);
            int pX = cords.Item1;
            int pY = cords.Item2;

            int mX, mY;
            switch (direction) {
                case Direction.Left:        mX = -1; mY = 0; break;
                case Direction.Right:       mX = 1;  mY = 0; break;
                case Direction.Up:          mX = 0;  mY = -1; break;
                case Direction.Down:        mX = 0;  mY = 1; break;
                case Direction.UpLeft:      mX = -1; mY = -1; break;   
                case Direction.UpRight:     mX = 1;  mY = -1; break;    
                case Direction.DownLeft:    mX = -1; mY = 1; break;
                case Direction.DownRight:   mX = 1;  mY = 1; break;
                
                default : mX = 0; mY = 0; break;
            }

            int p = position;

            while (p == position || !pieces.ContainsKey(p) && pX < 3 && pY < 3 && pY >= 0 && pX >= 0) {

                if (p != position) { 
                   legalMoves.Add(p);
                }
                
                pX += mX;
                pY += mY;

                p = CordinatesToInt(new Cordinates(pX, pY));
            }
        }
    }
}
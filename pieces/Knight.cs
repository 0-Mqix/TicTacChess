namespace TicTacChess {
    using Cordinates = Tuple<int, int>;
    internal class Knight : IPiece {
        readonly PieceColor color;

        private readonly int[,] moves = {
          {-1, -2}, {1, -2},
          {-2, -1}, {2, -1},
          {-2, 1},  {2, 1},
          {-1, 2},  {1, 2},
        };

        public Knight(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position, int totalMoves) {  
            List<int> legalMoves = new();

            Cordinates cords = PieceUtils.IntToCordinates(position);
            
            int pX = cords.Item1;
            int pY = cords.Item2;

            for (int i = 0; i < 8; i++) {

                int tX = pX + moves[i, 1];
                int tY = pY + moves[i, 0];
                
                int pos = PieceUtils.CordinatesToInt(tX, tY);
                
                if (!pieces.ContainsKey(pos) && pos >= 0) {
                    legalMoves.Add(pos);
                }
            }

            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_k;
            }
            
            return Properties.Resources.w_k;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

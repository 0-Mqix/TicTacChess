namespace TicTacChess {
    using Cordinates = Tuple<int, int>;
    internal class King : IPiece {
        readonly PieceColor color;
        public King(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position, int totalMoves) {
            List<int> legalMoves = new();

            Cordinates cords = PieceUtils.IntToCordinates(position);

            int pX = cords.Item1;
            int pY = cords.Item2;
                    
            for (int y = pY - 1; y <= (pY + 1); y++) {
                for (int x = pX - 1; x <= (pX + 1); x++) {

                    if (pX == x && pY == y) {
                        continue;
                    }

                    int pos = PieceUtils.CordinatesToInt(x, y);
                    
                    if (!pieces.ContainsKey(pos)) { 
                        legalMoves.Add(pos);   
                    }
                }
            }


            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_king;
            }
            
            return Properties.Resources.w_king;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

namespace TicTacChess {
    internal class Wizard : IPiece {
        readonly PieceColor color;

        public Wizard(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position, int totalMoves) {  
            List<int> legalMoves = new();

            for (int i = 0; i < 9; i++) {
                bool contains = pieces.ContainsKey(i);
                if (contains && pieces[i].Color() != color 
                    || position == i 
                    || contains && totalMoves < 2
                ) {
                    continue;
                }
                legalMoves.Add(i);  
            }

            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_w;
            }
            
            return Properties.Resources.w_w;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

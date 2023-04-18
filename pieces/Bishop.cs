namespace TicTacChess {
    internal class Bishop : IPiece {
        readonly PieceColor color;

        public Bishop(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position, int totalMoves) {  
            List<int> legalMoves = new();
            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_b;
            }
            
            return Properties.Resources.w_b;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

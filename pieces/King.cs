namespace TicTacChess {
    internal class King : IPiece {
        readonly PieceColor color;

        public King(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position) {  
            List<int> legalMoves = new();
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

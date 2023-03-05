namespace TicTacChess {
    internal class Knight : IPiece {
        readonly PieceColor color;

        public Knight(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position) {  
            List<int> legalMoves = new();
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

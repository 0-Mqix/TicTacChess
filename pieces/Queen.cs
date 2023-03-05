namespace TicTacChess {
    internal class Queen : IPiece {
        readonly PieceColor color;

        public Queen(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position) {  
            List<int> legalMoves = new();

            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_q;
            }
            
            return Properties.Resources.w_q;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

namespace TicTacChess {
    internal class Rook : IPiece {
        readonly PieceColor color;

        public Rook(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position) {  
            List<int> legalMoves = new();
            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_p;
            }
            
            return Properties.Resources.w_p;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

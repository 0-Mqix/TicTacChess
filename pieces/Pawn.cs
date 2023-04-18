namespace TicTacChess {
    internal class Pawn : IPiece {
        readonly PieceColor color;

        public Pawn(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position, int totalMoves) {  
            List<int> legalMoves = new();
            
            int newPosition = position + (color == PieceColor.Black ? 3 : -3);

            if (!pieces.ContainsKey(newPosition)) {
                legalMoves.Add(newPosition);
            }
            
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

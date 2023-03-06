namespace TicTacChess {
    internal class Rook : IPiece {
        readonly PieceColor color;

        public Rook(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position) {  
            List<int> legalMoves = new();

            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Left, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Right, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Up, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Down, position);

            return legalMoves;
        }

        public Image Image() {
            if (color == PieceColor.Black) {
                return Properties.Resources.b_r;
            }
            
            return Properties.Resources.w_r;        
        }

        public PieceColor Color() {
            return color;
        }
    }
}

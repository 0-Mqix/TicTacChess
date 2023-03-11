namespace TicTacChess {
    internal class Queen : IPiece {
        readonly PieceColor color;

        public Queen(PieceColor color) {
            this.color = color;
        }

        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position) {  
            List<int> legalMoves = new();

            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Left, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Right, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Up, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.Down, position);

            PieceUtils.CheckDirection(legalMoves, pieces, Direction.UpLeft, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.UpRight, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.DownLeft, position);
            PieceUtils.CheckDirection(legalMoves, pieces, Direction.DownRight, position);


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

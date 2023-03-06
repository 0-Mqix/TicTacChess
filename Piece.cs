namespace TicTacChess {

    enum PieceColor {
        White,
        Black
    }
    enum Direction {
        Left,
        Right,
        Up,
        Down,
    }

    interface IPiece {
        public PieceColor Color();
        public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position);
        public Image Image();
    }

    static class PieceUtils {
        public static bool IsEdge(Direction direction, int position) {

            if (direction == Direction.Up || direction == Direction.Down) {
                return (position + 3 > 8 || position - 3 < 0);
            }

            for (int i = 0; i < 3; i++) {
                if (position == i * 3 || position == 2 + i * 3) {
                    return true;
                }
            }

            return false;
        }

        //0 1 2
        //3 4 5
        //6 7 8

        public static void CheckDirection(
            List<int> legalMoves,
            Dictionary<int, IPiece> pieces,
            Direction direction,
            int position
        ) {
            int move = 0;

            switch (direction) {
                case Direction.Left: move = -1; break;
                case Direction.Right: move = 1; break;
                case Direction.Up: move = -3; break;
                case Direction.Down: move = 3; break;
            }

            int p = position;

            bool IsLegal() {
                return (p == position || !pieces.ContainsKey(p)) && p >= 0 && p <= 8;
            }

            if (direction == Direction.Up || direction == Direction.Down) {
                while (IsLegal()) {
                   if (p != position) {
                        legalMoves.Add(p);
                    } 
                    p += move;
                }
                return;
            }

            if (direction == Direction.Left || direction == Direction.Right) {
                while (IsLegal()) {

                    if (IsEdge(direction, p) && IsEdge(direction, p + move)) {
                        if (p != position) {
                            legalMoves.Add(p);
                        }
                    
                        break;

                    } else if (p != position) {
                        legalMoves.Add(p);
                    }
                    p += move;
                }
            }
        }
    }
}

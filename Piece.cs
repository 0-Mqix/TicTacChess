namespace TicTacChess {

    enum PieceColor {
        White,
        Black
    }


    interface IPiece {
       public PieceColor Color();
       public List<int> LegalMoves(Dictionary<int, IPiece> pieces, int position);
       public Image Image();
    }
}

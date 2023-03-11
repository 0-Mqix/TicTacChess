
namespace TicTacChess {
    public partial class Main : Form {
        PieceColor currentColor = PieceColor.White;
        int currentPieceIndex = -1;
        
        public Main() {
            InitializeComponent();
            DoubleBuffered = true;

            Update();
        }

        void Update() {
            pieceSelectorKnight.Image = new Knight(currentColor).Image();
            pieceSelectorRook.Image = new Rook(currentColor).Image();
            pieceSelectorQueen.Image = new Queen(currentColor).Image();

            if (currentColor == PieceColor.White) {
                checkBoxWhite.Checked = true;
                checkBoxBlack.Checked = false;
            } else {
                checkBoxWhite.Checked = false;
                checkBoxBlack.Checked = true;
            }
        }




        void PieceSelector_Click(object sender, EventArgs e) {

        }

        void CheckBox_OnClick(object sender, EventArgs e) {
            currentColor = currentColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
            Update();
        }
    }
}
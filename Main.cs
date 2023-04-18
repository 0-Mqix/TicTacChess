
namespace TicTacChess {
    public partial class Main : Form {
        PieceColor currentColor = PieceColor.White;

        PictureBox[] pieceSelectors;

        Dictionary<string, IPiece> whitePieces = new();
        Dictionary<string, IPiece> blackPieces = new();

        string? currentPiece;

        public Main() {
            InitializeComponent();
            DoubleBuffered = true;

            pieceSelectors = new[]{
                pieceSelectorPawn,
                pieceSelectorKnight,
                pieceSelectorRook,
                pieceSelectorQueen,
                pieceSelectorKing,
                pieceSelectorWizard
            };

            game.SetMain(this);

            Reset();
        }

        void UpdateMenu() {
            game.SetLegalMoves(new List<int>());

            if (currentColor == PieceColor.White) {
                checkBoxWhite.Checked = true;
                checkBoxBlack.Checked = false;


            } else {
                checkBoxWhite.Checked = false;
                checkBoxBlack.Checked = true;
            }

            var pieces = currentColor == PieceColor.White ? whitePieces : blackPieces;

            foreach (var selector in pieceSelectors) {

                if (selector.Image != null) {
                    selector.Image.Dispose();
                }

                selector.Image = null;

                string? tag = selector.Tag.ToString();

                if (tag == null) {
                    continue;
                }

                if (pieces.ContainsKey(tag)) {
                    selector.Image = pieces[tag].Image();
                }
            }
        }


        void PieceSelector_Click(object sender, EventArgs e) {
            if (game.GetState() != State.Setup) {
                return;
            }

            PictureBox selector = (PictureBox)sender;
            string? tag = selector.Tag.ToString();
            if (tag == null) {
                return;
            }

            var setupPieces = currentColor == PieceColor.White ? whitePieces : blackPieces;
            if (!setupPieces.ContainsKey(tag)) {
                return;
            }

            currentPiece = tag;

            game.SetLegalMoves(currentColor == PieceColor.White
                ? new List<int> { 6, 7, 8 }
                : new List<int> { 0, 1, 2 }
            );
        }

        void CheckBox_OnClick(object sender, EventArgs e) {
            if (game.GetState() != State.Setup) {
                return;
            }

            currentColor = currentColor == PieceColor.White ? PieceColor.Black : PieceColor.White;
            UpdateMenu();
        }

        private void UseArduino_Changed(object sender, EventArgs e) {

        }

        public void UpdateColor(PieceColor color) {
            statusLabel.Text = $"State: {(color == PieceColor.White ? "White's" : "Black's")} turn";
            currentColor = color;
            UpdateMenu();
        }

        public void GameClick(int position) {
            if (currentPiece == null) {
                return;
            }

            var pieces = game.GetPieces();
            var setupPieces = currentColor == PieceColor.White ? whitePieces : blackPieces;

            if (pieces.ContainsKey(position)) {
                setupPieces.Add(pieces[position].GetType().ToString().Replace("TicTacChess.", "").ToLower(), pieces[position]);
                pieces.Remove(position);
            }


            if (setupPieces.ContainsKey(currentPiece)) {
                pieces.Add(position, setupPieces[currentPiece]);
                setupPieces.Remove(currentPiece);
            }

            currentPiece = null;

            UpdateMenu();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if (game.GetState() == State.Setup) {
                if (game.GetPieces().Count != 6) {
                    return;
                }

                game.Start();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e) {
            Reset();
        }

        private void Reset() {
            statusLabel.Text = "State: Setup";

            game.SetState(State.Setup);
            game.Reset();
            game.Invalidate();

            whitePieces.Clear();
            whitePieces.Add("pawn", new Pawn(PieceColor.White));
            whitePieces.Add("knight", new Knight(PieceColor.White));
            whitePieces.Add("rook", new Rook(PieceColor.White));
            whitePieces.Add("queen", new Queen(PieceColor.White));
            whitePieces.Add("king", new King(PieceColor.White));
            whitePieces.Add("wizard", new Wizard(PieceColor.White));

            blackPieces.Clear();
            blackPieces.Add("pawn", new Pawn(PieceColor.Black));
            blackPieces.Add("knight", new Knight(PieceColor.Black));
            blackPieces.Add("rook", new Rook(PieceColor.Black));
            blackPieces.Add("queen", new Queen(PieceColor.Black));
            blackPieces.Add("king", new King(PieceColor.Black));
            blackPieces.Add("wizard", new Wizard(PieceColor.Black));

            UpdateMenu();
        }

        internal void GameWin(PieceColor currentColor) {

            statusLabel.Text = $"State: {(currentColor == PieceColor.White ? "White" : "Black")} won the game";
            game.SetState(State.Finished);
        }
    }
}
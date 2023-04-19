namespace TicTacChess
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.game = new TicTacChess.Game();
            this.checkBoxWhite = new System.Windows.Forms.CheckBox();
            this.checkBoxBlack = new System.Windows.Forms.CheckBox();
            this.pieceSelectorKnight = new System.Windows.Forms.PictureBox();
            this.pieceSelectorRook = new System.Windows.Forms.PictureBox();
            this.pieceSelectorPawn = new System.Windows.Forms.PictureBox();
            this.pieceSelectorQueen = new System.Windows.Forms.PictureBox();
            this.pieceSelectorWizard = new System.Windows.Forms.PictureBox();
            this.pieceSelectorKing = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.useArduinoCheckBox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.arduinoGroupBox = new System.Windows.Forms.GroupBox();
            this.portsComboBox = new System.Windows.Forms.ComboBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.portsLabel = new System.Windows.Forms.Label();
            this.adruinoStatusLabel = new System.Windows.Forms.Label();
            this.prefixArduinoStatusLabel = new System.Windows.Forms.Label();
            this.enableArduinoLabel = new System.Windows.Forms.Label();
            this.arduinoQueueLabel = new System.Windows.Forms.Label();
            this.arduinoQueueProgressBar = new System.Windows.Forms.ProgressBar();
            this.pieceSelectorGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorPawn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorWizard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorKing)).BeginInit();
            this.arduinoGroupBox.SuspendLayout();
            this.pieceSelectorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // game
            // 
            this.game.BackColor = System.Drawing.Color.White;
            this.game.Location = new System.Drawing.Point(12, 88);
            this.game.Margin = new System.Windows.Forms.Padding(2);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(300, 300);
            this.game.TabIndex = 0;
            // 
            // checkBoxWhite
            // 
            this.checkBoxWhite.AutoCheck = false;
            this.checkBoxWhite.AutoSize = true;
            this.checkBoxWhite.Location = new System.Drawing.Point(22, 27);
            this.checkBoxWhite.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxWhite.Name = "checkBoxWhite";
            this.checkBoxWhite.Size = new System.Drawing.Size(80, 29);
            this.checkBoxWhite.TabIndex = 1;
            this.checkBoxWhite.Text = "white";
            this.checkBoxWhite.UseVisualStyleBackColor = true;
            this.checkBoxWhite.Click += new System.EventHandler(this.CheckBox_OnClick);
            // 
            // checkBoxBlack
            // 
            this.checkBoxBlack.AutoCheck = false;
            this.checkBoxBlack.AutoSize = true;
            this.checkBoxBlack.Location = new System.Drawing.Point(23, 56);
            this.checkBoxBlack.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxBlack.Name = "checkBoxBlack";
            this.checkBoxBlack.Size = new System.Drawing.Size(79, 29);
            this.checkBoxBlack.TabIndex = 8;
            this.checkBoxBlack.Text = "black";
            this.checkBoxBlack.UseVisualStyleBackColor = true;
            this.checkBoxBlack.Click += new System.EventHandler(this.CheckBox_OnClick);
            // 
            // pieceSelectorKnight
            // 
            this.pieceSelectorKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorKnight.Location = new System.Drawing.Point(22, 191);
            this.pieceSelectorKnight.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorKnight.Name = "pieceSelectorKnight";
            this.pieceSelectorKnight.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorKnight.TabIndex = 9;
            this.pieceSelectorKnight.TabStop = false;
            this.pieceSelectorKnight.Tag = "knight";
            this.pieceSelectorKnight.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorRook
            // 
            this.pieceSelectorRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorRook.Location = new System.Drawing.Point(22, 295);
            this.pieceSelectorRook.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorRook.Name = "pieceSelectorRook";
            this.pieceSelectorRook.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorRook.TabIndex = 10;
            this.pieceSelectorRook.TabStop = false;
            this.pieceSelectorRook.Tag = "rook";
            this.pieceSelectorRook.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorPawn
            // 
            this.pieceSelectorPawn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorPawn.Location = new System.Drawing.Point(22, 87);
            this.pieceSelectorPawn.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorPawn.Name = "pieceSelectorPawn";
            this.pieceSelectorPawn.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorPawn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorPawn.TabIndex = 11;
            this.pieceSelectorPawn.TabStop = false;
            this.pieceSelectorPawn.Tag = "pawn";
            this.pieceSelectorPawn.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorQueen
            // 
            this.pieceSelectorQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorQueen.Location = new System.Drawing.Point(126, 87);
            this.pieceSelectorQueen.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorQueen.Name = "pieceSelectorQueen";
            this.pieceSelectorQueen.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorQueen.TabIndex = 12;
            this.pieceSelectorQueen.TabStop = false;
            this.pieceSelectorQueen.Tag = "queen";
            this.pieceSelectorQueen.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorWizard
            // 
            this.pieceSelectorWizard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorWizard.Location = new System.Drawing.Point(126, 295);
            this.pieceSelectorWizard.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorWizard.Name = "pieceSelectorWizard";
            this.pieceSelectorWizard.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorWizard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorWizard.TabIndex = 13;
            this.pieceSelectorWizard.TabStop = false;
            this.pieceSelectorWizard.Tag = "wizard";
            this.pieceSelectorWizard.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorKing
            // 
            this.pieceSelectorKing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorKing.Location = new System.Drawing.Point(126, 191);
            this.pieceSelectorKing.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorKing.Name = "pieceSelectorKing";
            this.pieceSelectorKing.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorKing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorKing.TabIndex = 14;
            this.pieceSelectorKing.TabStop = false;
            this.pieceSelectorKing.Tag = "king";
            this.pieceSelectorKing.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.Location = new System.Drawing.Point(12, 24);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(176, 41);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.Text = "State: Setup";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(167, 393);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(145, 42);
            this.resetButton.TabIndex = 16;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // useArduinoCheckBox
            // 
            this.useArduinoCheckBox.AutoCheck = false;
            this.useArduinoCheckBox.AutoSize = true;
            this.useArduinoCheckBox.Location = new System.Drawing.Point(155, 25);
            this.useArduinoCheckBox.Name = "useArduinoCheckBox";
            this.useArduinoCheckBox.Size = new System.Drawing.Size(22, 21);
            this.useArduinoCheckBox.TabIndex = 17;
            this.useArduinoCheckBox.UseVisualStyleBackColor = true;
            this.useArduinoCheckBox.Click += new System.EventHandler(this.UseArduino_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 393);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(149, 42);
            this.startButton.TabIndex = 18;
            this.startButton.Text = "start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // arduinoGroupBox
            // 
            this.arduinoGroupBox.Controls.Add(this.portsComboBox);
            this.arduinoGroupBox.Controls.Add(this.scanButton);
            this.arduinoGroupBox.Controls.Add(this.portsLabel);
            this.arduinoGroupBox.Controls.Add(this.adruinoStatusLabel);
            this.arduinoGroupBox.Controls.Add(this.prefixArduinoStatusLabel);
            this.arduinoGroupBox.Controls.Add(this.enableArduinoLabel);
            this.arduinoGroupBox.Controls.Add(this.arduinoQueueLabel);
            this.arduinoGroupBox.Controls.Add(this.arduinoQueueProgressBar);
            this.arduinoGroupBox.Controls.Add(this.useArduinoCheckBox);
            this.arduinoGroupBox.Location = new System.Drawing.Point(12, 494);
            this.arduinoGroupBox.Name = "arduinoGroupBox";
            this.arduinoGroupBox.Size = new System.Drawing.Size(558, 155);
            this.arduinoGroupBox.TabIndex = 19;
            this.arduinoGroupBox.TabStop = false;
            this.arduinoGroupBox.Text = "Arduino";
            // 
            // portsComboBox
            // 
            this.portsComboBox.FormattingEnabled = true;
            this.portsComboBox.Location = new System.Drawing.Point(210, 108);
            this.portsComboBox.Name = "portsComboBox";
            this.portsComboBox.Size = new System.Drawing.Size(182, 33);
            this.portsComboBox.TabIndex = 25;
            this.portsComboBox.SelectedIndexChanged += new System.EventHandler(this.PortsComboBox_SelectedIndexChanged);
            // 
            // scanButton
            // 
            this.scanButton.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scanButton.Location = new System.Drawing.Point(155, 108);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(49, 33);
            this.scanButton.TabIndex = 24;
            this.scanButton.Text = "scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // portsLabel
            // 
            this.portsLabel.AutoSize = true;
            this.portsLabel.Location = new System.Drawing.Point(6, 111);
            this.portsLabel.Name = "portsLabel";
            this.portsLabel.Size = new System.Drawing.Size(54, 25);
            this.portsLabel.TabIndex = 23;
            this.portsLabel.Text = "ports";
            // 
            // adruinoStatusLabel
            // 
            this.adruinoStatusLabel.AutoSize = true;
            this.adruinoStatusLabel.Location = new System.Drawing.Point(155, 80);
            this.adruinoStatusLabel.Name = "adruinoStatusLabel";
            this.adruinoStatusLabel.Size = new System.Drawing.Size(0, 25);
            this.adruinoStatusLabel.TabIndex = 22;
            // 
            // prefixArduinoStatusLabel
            // 
            this.prefixArduinoStatusLabel.AutoSize = true;
            this.prefixArduinoStatusLabel.Location = new System.Drawing.Point(6, 80);
            this.prefixArduinoStatusLabel.Name = "prefixArduinoStatusLabel";
            this.prefixArduinoStatusLabel.Size = new System.Drawing.Size(59, 25);
            this.prefixArduinoStatusLabel.TabIndex = 21;
            this.prefixArduinoStatusLabel.Text = "status";
            // 
            // enableArduinoLabel
            // 
            this.enableArduinoLabel.AutoSize = true;
            this.enableArduinoLabel.Location = new System.Drawing.Point(6, 22);
            this.enableArduinoLabel.Name = "enableArduinoLabel";
            this.enableArduinoLabel.Size = new System.Drawing.Size(64, 25);
            this.enableArduinoLabel.TabIndex = 20;
            this.enableArduinoLabel.Text = "enable";
            // 
            // arduinoProgress
            // 
            this.arduinoQueueLabel.AutoSize = true;
            this.arduinoQueueLabel.Location = new System.Drawing.Point(6, 52);
            this.arduinoQueueLabel.Name = "arduinoProgress";
            this.arduinoQueueLabel.Size = new System.Drawing.Size(103, 25);
            this.arduinoQueueLabel.TabIndex = 19;
            this.arduinoQueueLabel.Text = "queue (0/0)";
            // 
            // arduinoQueueProgressBar
            // 
            this.arduinoQueueProgressBar.Location = new System.Drawing.Point(155, 52);
            this.arduinoQueueProgressBar.Name = "arduinoQueueProgressBar";
            this.arduinoQueueProgressBar.Size = new System.Drawing.Size(372, 25);
            this.arduinoQueueProgressBar.TabIndex = 18;
            // 
            // pieceSelectorGroupBox
            // 
            this.pieceSelectorGroupBox.Controls.Add(this.checkBoxWhite);
            this.pieceSelectorGroupBox.Controls.Add(this.pieceSelectorKnight);
            this.pieceSelectorGroupBox.Controls.Add(this.pieceSelectorRook);
            this.pieceSelectorGroupBox.Controls.Add(this.checkBoxBlack);
            this.pieceSelectorGroupBox.Controls.Add(this.pieceSelectorPawn);
            this.pieceSelectorGroupBox.Controls.Add(this.pieceSelectorKing);
            this.pieceSelectorGroupBox.Controls.Add(this.pieceSelectorQueen);
            this.pieceSelectorGroupBox.Controls.Add(this.pieceSelectorWizard);
            this.pieceSelectorGroupBox.Location = new System.Drawing.Point(319, 76);
            this.pieceSelectorGroupBox.Name = "pieceSelectorGroupBox";
            this.pieceSelectorGroupBox.Size = new System.Drawing.Size(251, 412);
            this.pieceSelectorGroupBox.TabIndex = 20;
            this.pieceSelectorGroupBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(582, 675);
            this.Controls.Add(this.pieceSelectorGroupBox);
            this.Controls.Add(this.arduinoGroupBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.game);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "TicTacChess";
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorPawn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorWizard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorKing)).EndInit();
            this.arduinoGroupBox.ResumeLayout(false);
            this.arduinoGroupBox.PerformLayout();
            this.pieceSelectorGroupBox.ResumeLayout(false);
            this.pieceSelectorGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Game game;
        private CheckBox checkBoxWhite;
        private CheckBox checkBoxBlack;
        private PictureBox pieceSelectorKnight;
        private PictureBox pieceSelectorRook;
        private PictureBox pieceSelectorPawn;
        private PictureBox pieceSelectorQueen;
        private PictureBox pieceSelectorWizard;
        private PictureBox pieceSelectorKing;
        private Label statusLabel;
        private Button resetButton;
        private CheckBox useArduinoCheckBox;
        private Button startButton;
        private GroupBox arduinoGroupBox;
        private GroupBox pieceSelectorGroupBox;
        private Label arduinoQueueLabel;
        private ProgressBar arduinoQueueProgressBar;
        private Label enableArduinoLabel;
        private Label prefixArduinoStatusLabel;
        private Label adruinoStatusLabel;
        private ComboBox portsComboBox;
        private Button scanButton;
        private Label portsLabel;
    }
}
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
            this.pieceSelectorQueen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorQueen)).BeginInit();
            this.SuspendLayout();
            // 
            // game
            // 
            this.game.BackColor = System.Drawing.Color.White;
            this.game.Location = new System.Drawing.Point(10, 9);
            this.game.Margin = new System.Windows.Forms.Padding(2);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(300, 300);
            this.game.TabIndex = 0;
            // 
            // checkBoxWhite
            // 
            this.checkBoxWhite.AutoSize = true;
            this.checkBoxWhite.Location = new System.Drawing.Point(335, 9);
            this.checkBoxWhite.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxWhite.Name = "checkBoxWhite";
            this.checkBoxWhite.Size = new System.Drawing.Size(55, 19);
            this.checkBoxWhite.TabIndex = 1;
            this.checkBoxWhite.Text = "white";
            this.checkBoxWhite.UseVisualStyleBackColor = true;
            this.checkBoxWhite.Click += new System.EventHandler(this.CheckBox_OnClick);
            // 
            // checkBoxBlack
            // 
            this.checkBoxBlack.AutoSize = true;
            this.checkBoxBlack.Location = new System.Drawing.Point(335, 28);
            this.checkBoxBlack.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxBlack.Name = "checkBoxBlack";
            this.checkBoxBlack.Size = new System.Drawing.Size(54, 19);
            this.checkBoxBlack.TabIndex = 8;
            this.checkBoxBlack.Text = "black";
            this.checkBoxBlack.UseVisualStyleBackColor = true;
            this.checkBoxBlack.Click += new System.EventHandler(this.CheckBox_OnClick);
            // 
            // pieceSelectorKnight
            // 
            this.pieceSelectorKnight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorKnight.Location = new System.Drawing.Point(335, 153);
            this.pieceSelectorKnight.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorKnight.Name = "pieceSelectorKnight";
            this.pieceSelectorKnight.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorKnight.TabIndex = 9;
            this.pieceSelectorKnight.TabStop = false;
            this.pieceSelectorKnight.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorRook
            // 
            this.pieceSelectorRook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorRook.Location = new System.Drawing.Point(335, 257);
            this.pieceSelectorRook.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorRook.Name = "pieceSelectorRook";
            this.pieceSelectorRook.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorRook.TabIndex = 10;
            this.pieceSelectorRook.TabStop = false;
            this.pieceSelectorRook.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // pieceSelectorQueen
            // 
            this.pieceSelectorQueen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieceSelectorQueen.Location = new System.Drawing.Point(335, 49);
            this.pieceSelectorQueen.Margin = new System.Windows.Forms.Padding(2);
            this.pieceSelectorQueen.Name = "pieceSelectorQueen";
            this.pieceSelectorQueen.Size = new System.Drawing.Size(100, 100);
            this.pieceSelectorQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pieceSelectorQueen.TabIndex = 11;
            this.pieceSelectorQueen.TabStop = false;
            this.pieceSelectorQueen.Click += new System.EventHandler(this.PieceSelector_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(954, 466);
            this.Controls.Add(this.checkBoxWhite);
            this.Controls.Add(this.pieceSelectorQueen);
            this.Controls.Add(this.checkBoxBlack);
            this.Controls.Add(this.game);
            this.Controls.Add(this.pieceSelectorRook);
            this.Controls.Add(this.pieceSelectorKnight);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSelectorQueen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Game game;
        private CheckBox checkBoxWhite;
        private CheckBox checkBoxBlack;
        private PictureBox pieceSelectorKnight;
        private PictureBox pieceSelectorRook;
        private PictureBox pieceSelectorQueen;
    }
}
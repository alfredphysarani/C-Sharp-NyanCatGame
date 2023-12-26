
namespace CIS329_NyanCatAdv
{
    partial class gameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scoreDisplay = new System.Windows.Forms.Label();
            this.nyanCat = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.debug = new System.Windows.Forms.Label();
            this.pauseMsg = new System.Windows.Forms.Label();
            this.gameTitle = new System.Windows.Forms.Label();
            this.menuTimer = new System.Windows.Forms.Timer(this.components);
            this.startMenu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nyanCat)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreDisplay
            // 
            this.scoreDisplay.AutoSize = true;
            this.scoreDisplay.BackColor = System.Drawing.Color.Black;
            this.scoreDisplay.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreDisplay.ForeColor = System.Drawing.Color.Gold;
            this.scoreDisplay.Location = new System.Drawing.Point(12, 9);
            this.scoreDisplay.Name = "scoreDisplay";
            this.scoreDisplay.Size = new System.Drawing.Size(72, 28);
            this.scoreDisplay.TabIndex = 0;
            this.scoreDisplay.Text = "Score:";
            // 
            // nyanCat
            // 
            this.nyanCat.BackColor = System.Drawing.Color.Transparent;
            this.nyanCat.Image = global::CIS329_NyanCatAdv.Properties.Resources.nyanCatChar;
            this.nyanCat.Location = new System.Drawing.Point(145, 213);
            this.nyanCat.Name = "nyanCat";
            this.nyanCat.Size = new System.Drawing.Size(118, 62);
            this.nyanCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.nyanCat.TabIndex = 1;
            this.nyanCat.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 50;
            this.gameTimer.Tick += new System.EventHandler(this.timerEvent);
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.BackColor = System.Drawing.Color.Transparent;
            this.debug.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.debug.Location = new System.Drawing.Point(23, 463);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(55, 13);
            this.debug.TabIndex = 6;
            this.debug.Text = "debugInfo";
            // 
            // pauseMsg
            // 
            this.pauseMsg.AutoSize = true;
            this.pauseMsg.Font = new System.Drawing.Font("MV Boli", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pauseMsg.ForeColor = System.Drawing.Color.Yellow;
            this.pauseMsg.Location = new System.Drawing.Point(258, 358);
            this.pauseMsg.Name = "pauseMsg";
            this.pauseMsg.Size = new System.Drawing.Size(432, 22);
            this.pauseMsg.TabIndex = 7;
            this.pauseMsg.Text = "Game Paused! Press \"Space\" Key to resume!";
            // 
            // gameTitle
            // 
            this.gameTitle.AutoSize = true;
            this.gameTitle.BackColor = System.Drawing.Color.Black;
            this.gameTitle.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameTitle.ForeColor = System.Drawing.Color.Gold;
            this.gameTitle.Location = new System.Drawing.Point(324, 121);
            this.gameTitle.Name = "gameTitle";
            this.gameTitle.Size = new System.Drawing.Size(382, 49);
            this.gameTitle.TabIndex = 8;
            this.gameTitle.Text = "Nyan Cat Adventure";
            // 
            // menuTimer
            // 
            this.menuTimer.Enabled = true;
            this.menuTimer.Tick += new System.EventHandler(this.menuTimer_Tick);
            // 
            // startMenu
            // 
            this.startMenu.AutoSize = true;
            this.startMenu.BackColor = System.Drawing.Color.Black;
            this.startMenu.Font = new System.Drawing.Font("MV Boli", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startMenu.ForeColor = System.Drawing.Color.Gold;
            this.startMenu.Location = new System.Drawing.Point(282, 329);
            this.startMenu.Name = "startMenu";
            this.startMenu.Size = new System.Drawing.Size(464, 98);
            this.startMenu.TabIndex = 9;
            this.startMenu.Text = "Press \"Enter\" to Start\r\nPress \"T\" to see tutorial";
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::CIS329_NyanCatAdv.Properties.Resources.bpg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(944, 542);
            this.Controls.Add(this.startMenu);
            this.Controls.Add(this.gameTitle);
            this.Controls.Add(this.pauseMsg);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.nyanCat);
            this.Controls.Add(this.scoreDisplay);
            this.DoubleBuffered = true;
            this.Name = "gameScreen";
            this.Text = "NyanCat | Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.controlKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.controlKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.nyanCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreDisplay;
        private System.Windows.Forms.PictureBox nyanCat;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.Label pauseMsg;
        private System.Windows.Forms.Label gameTitle;
        private System.Windows.Forms.Timer menuTimer;
        private System.Windows.Forms.Label startMenu;
    }
}


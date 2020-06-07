namespace Main_project_of_the_game_Battle_City
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.new_Game = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.oneTank = new System.Windows.Forms.Button();
            this.battleCity = new System.Windows.Forms.PictureBox();
            this.twoTank = new System.Windows.Forms.Button();
            this.game_over = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.battleCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_over)).BeginInit();
            this.SuspendLayout();
            // 
            // new_Game
            // 
            this.new_Game.Location = new System.Drawing.Point(374, 454);
            this.new_Game.Name = "new_Game";
            this.new_Game.Size = new System.Drawing.Size(75, 23);
            this.new_Game.TabIndex = 4;
            this.new_Game.Text = "New Game";
            this.new_Game.UseVisualStyleBackColor = true;
            this.new_Game.Click += new System.EventHandler(this.New_Game_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(103, 454);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 5;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.Back_Click);
            // 
            // oneTank
            // 
            this.oneTank.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("oneTank.BackgroundImage")));
            this.oneTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.oneTank.CausesValidation = false;
            this.oneTank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oneTank.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.oneTank.Location = new System.Drawing.Point(183, 339);
            this.oneTank.Name = "oneTank";
            this.oneTank.Size = new System.Drawing.Size(200, 25);
            this.oneTank.TabIndex = 1;
            this.oneTank.TabStop = false;
            this.oneTank.UseMnemonic = false;
            this.oneTank.UseVisualStyleBackColor = true;
            this.oneTank.Click += new System.EventHandler(this.OneTank_Click);
            // 
            // battleCity
            // 
            this.battleCity.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.battleCity.Image = global::Main_project_of_the_game_Battle_City.Properties.Resources.Battle_City;
            this.battleCity.Location = new System.Drawing.Point(28, 28);
            this.battleCity.Name = "battleCity";
            this.battleCity.Size = new System.Drawing.Size(486, 293);
            this.battleCity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.battleCity.TabIndex = 0;
            this.battleCity.TabStop = false;
            // 
            // twoTank
            // 
            this.twoTank.BackgroundImage = global::Main_project_of_the_game_Battle_City.Properties.Resources._2_players;
            this.twoTank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.twoTank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.twoTank.Location = new System.Drawing.Point(183, 385);
            this.twoTank.Name = "twoTank";
            this.twoTank.Size = new System.Drawing.Size(200, 25);
            this.twoTank.TabIndex = 2;
            this.twoTank.UseVisualStyleBackColor = true;
            this.twoTank.Click += new System.EventHandler(this.TwoTank_Click);
            // 
            // game_over
            // 
            this.game_over.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.game_over.BackgroundImage = global::Main_project_of_the_game_Battle_City.Properties.Resources.game_over;
            this.game_over.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.game_over.Location = new System.Drawing.Point(57, 87);
            this.game_over.Name = "game_over";
            this.game_over.Size = new System.Drawing.Size(434, 277);
            this.game_over.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.game_over.TabIndex = 3;
            this.game_over.TabStop = false;
            this.game_over.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(546, 546);
            this.Controls.Add(this.game_over);
            this.Controls.Add(this.back);
            this.Controls.Add(this.twoTank);
            this.Controls.Add(this.new_Game);
            this.Controls.Add(this.oneTank);
            this.Controls.Add(this.battleCity);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.MaximumSize = new System.Drawing.Size(614, 637);
            this.MinimumSize = new System.Drawing.Size(354, 377);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battle City";
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainWindow_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.battleCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.game_over)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button new_Game;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button oneTank;
        private System.Windows.Forms.PictureBox battleCity;
        private System.Windows.Forms.Button twoTank;
        private System.Windows.Forms.PictureBox game_over;
    }
}


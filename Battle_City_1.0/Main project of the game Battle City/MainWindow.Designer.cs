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
            this.BattleCity = new System.Windows.Forms.PictureBox();
            this.OneTank = new System.Windows.Forms.Button();
            this.TwoTank = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.BattleCity)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BattleCity
            // 
            this.BattleCity.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BattleCity.Image = global::Main_project_of_the_game_Battle_City.Properties.Resources.Battle_City;
            this.BattleCity.Location = new System.Drawing.Point(40, 19);
            this.BattleCity.Name = "BattleCity";
            this.BattleCity.Size = new System.Drawing.Size(442, 251);
            this.BattleCity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BattleCity.TabIndex = 0;
            this.BattleCity.TabStop = false;
            // 
            // OneTank
            // 
            this.OneTank.CausesValidation = false;
            this.OneTank.Location = new System.Drawing.Point(172, 289);
            this.OneTank.Name = "OneTank";
            this.OneTank.Size = new System.Drawing.Size(164, 23);
            this.OneTank.TabIndex = 1;
            this.OneTank.TabStop = false;
            this.OneTank.Text = "1 танк";
            this.OneTank.UseMnemonic = false;
            this.OneTank.UseVisualStyleBackColor = true;
            this.OneTank.Click += new System.EventHandler(this.button1_Click);
            // 
            // TwoTank
            // 
            this.TwoTank.Location = new System.Drawing.Point(172, 343);
            this.TwoTank.Name = "TwoTank";
            this.TwoTank.Size = new System.Drawing.Size(164, 23);
            this.TwoTank.TabIndex = 2;
            this.TwoTank.Text = "2 танка";
            this.TwoTank.UseVisualStyleBackColor = true;
            this.TwoTank.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.TwoTank);
            this.panel.Controls.Add(this.BattleCity);
            this.panel.Controls.Add(this.OneTank);
            this.panel.Location = new System.Drawing.Point(12, 33);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(522, 384);
            this.panel.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(546, 546);
            this.Controls.Add(this.panel);
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
            ((System.ComponentModel.ISupportInitialize)(this.BattleCity)).EndInit();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BattleCity;
        private System.Windows.Forms.Button OneTank;
        private System.Windows.Forms.Button TwoTank;
        private System.Windows.Forms.Panel panel;
    }
}


namespace PolishBrickBreaker
{
    partial class PolishBrickBreaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolishBrickBreaker));
            this.picBall = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).BeginInit();
            this.SuspendLayout();
            // 
            // picBall
            // 
            this.picBall.BackColor = System.Drawing.Color.Transparent;
            this.picBall.Image = ((System.Drawing.Image)(resources.GetObject("picBall.Image")));
            this.picBall.Location = new System.Drawing.Point(63, 145);
            this.picBall.Name = "picBall";
            this.picBall.Size = new System.Drawing.Size(15, 15);
            this.picBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBall.TabIndex = 0;
            this.picBall.TabStop = false;
            this.picBall.Visible = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(8, 26);
            this.textBox1.TabIndex = 1;
            // 
            // PolishBrickBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 844);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picBall);
            this.Name = "PolishBrickBreaker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PolishBrickBreaker";
            this.Load += new System.EventHandler(this.PolishBrickBreaker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBall;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBox1;
    }
}


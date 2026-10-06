namespace POE_Rich_Mtk_Asiphe_Louw
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDisplay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHeroStats = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(16, 15);
            this.lblDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(560, 554);
            this.lblDisplay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(382, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 440);
            this.label1.TabIndex = 1;
            this.label1.Text = "MOVE\r\nW\r\nA S D\r\n\r\nATTACK\r\n↑\r\n← ↓ →\r\n\r\nPlayer\r\nAlive: ▼\r\nDead: x\r\n\r\nGrunt\r\nAlive: ϫ\r\nDead: x\r\n\r\nExit: ░\r\nHealth: +";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // lblHeroStats
            //
            this.lblHeroStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeroStats.Location = new System.Drawing.Point(382, 488);
            this.lblHeroStats.Name = "lblHeroStats";
            this.lblHeroStats.Size = new System.Drawing.Size(194, 48);
            this.lblHeroStats.TabIndex = 2;
            this.lblHeroStats.Text = "Hero HP: 40/40";
            this.lblHeroStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 583);
            this.Controls.Add(this.lblHeroStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDisplay);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Adventure Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHeroStats;
    }
}

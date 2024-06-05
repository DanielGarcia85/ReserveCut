namespace ReserveCut
{
    partial class FrmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoading));
            pct_loading_rl = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pct_loading_rl).BeginInit();
            SuspendLayout();
            // 
            // pct_loading_rl
            // 
            pct_loading_rl.BackColor = Color.Transparent;
            pct_loading_rl.InitialImage = Properties.Resources.loading;
            pct_loading_rl.Location = new Point(12, 12);
            pct_loading_rl.Name = "pct_loading_rl";
            pct_loading_rl.Size = new Size(355, 100);
            pct_loading_rl.SizeMode = PictureBoxSizeMode.CenterImage;
            pct_loading_rl.TabIndex = 0;
            pct_loading_rl.TabStop = false;
            // 
            // FrmLoading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 124);
            Controls.Add(pct_loading_rl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(397, 171);
            MinimizeBox = false;
            MinimumSize = new Size(397, 171);
            Name = "FrmLoading";
            Text = "Chargement en cours";
            ((System.ComponentModel.ISupportInitialize)pct_loading_rl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pct_loading_rl;
    }
}
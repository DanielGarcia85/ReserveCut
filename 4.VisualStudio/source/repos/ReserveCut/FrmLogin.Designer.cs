namespace ReserveCut
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lbl_username_lo = new Label();
            lbl_password_lo = new Label();
            txb_username_lo = new TextBox();
            txb_password_lo = new TextBox();
            btn_login_lo = new Button();
            btn_cancel_lo = new Button();
            pic_reservecut_lo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pic_reservecut_lo).BeginInit();
            SuspendLayout();
            // 
            // lbl_username_lo
            // 
            lbl_username_lo.AutoSize = true;
            lbl_username_lo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_username_lo.Location = new Point(33, 88);
            lbl_username_lo.Margin = new Padding(4, 0, 4, 0);
            lbl_username_lo.MaximumSize = new Size(118, 21);
            lbl_username_lo.MinimumSize = new Size(118, 21);
            lbl_username_lo.Name = "lbl_username_lo";
            lbl_username_lo.Size = new Size(118, 21);
            lbl_username_lo.TabIndex = 0;
            lbl_username_lo.Text = "Nom d'utiliseur";
            // 
            // lbl_password_lo
            // 
            lbl_password_lo.AutoSize = true;
            lbl_password_lo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_password_lo.Location = new Point(33, 140);
            lbl_password_lo.Margin = new Padding(4, 0, 4, 0);
            lbl_password_lo.MaximumSize = new Size(102, 21);
            lbl_password_lo.MinimumSize = new Size(102, 21);
            lbl_password_lo.Name = "lbl_password_lo";
            lbl_password_lo.Size = new Size(102, 21);
            lbl_password_lo.TabIndex = 1;
            lbl_password_lo.Text = "Mot de passe";
            // 
            // txb_username_lo
            // 
            txb_username_lo.Font = new Font("Segoe UI", 12F);
            txb_username_lo.Location = new Point(181, 86);
            txb_username_lo.Margin = new Padding(4, 2, 4, 2);
            txb_username_lo.MaximumSize = new Size(210, 29);
            txb_username_lo.MinimumSize = new Size(210, 29);
            txb_username_lo.Name = "txb_username_lo";
            txb_username_lo.Size = new Size(210, 29);
            txb_username_lo.TabIndex = 1;
            // 
            // txb_password_lo
            // 
            txb_password_lo.Font = new Font("Segoe UI", 12F);
            txb_password_lo.Location = new Point(181, 138);
            txb_password_lo.Margin = new Padding(4, 2, 4, 2);
            txb_password_lo.MaximumSize = new Size(210, 29);
            txb_password_lo.MinimumSize = new Size(210, 29);
            txb_password_lo.Name = "txb_password_lo";
            txb_password_lo.Size = new Size(210, 29);
            txb_password_lo.TabIndex = 2;
            txb_password_lo.UseSystemPasswordChar = true;
            // 
            // btn_login_lo
            // 
            btn_login_lo.BackColor = SystemColors.Window;
            btn_login_lo.Font = new Font("Segoe UI", 9.75F);
            btn_login_lo.Location = new Point(181, 190);
            btn_login_lo.Margin = new Padding(4, 2, 4, 2);
            btn_login_lo.MaximumSize = new Size(100, 30);
            btn_login_lo.MinimumSize = new Size(100, 30);
            btn_login_lo.Name = "btn_login_lo";
            btn_login_lo.Size = new Size(100, 30);
            btn_login_lo.TabIndex = 3;
            btn_login_lo.Text = "Login";
            btn_login_lo.UseVisualStyleBackColor = false;
            btn_login_lo.Click += btn_login_lo_Click;
            // 
            // btn_cancel_lo
            // 
            btn_cancel_lo.BackColor = SystemColors.Window;
            btn_cancel_lo.Font = new Font("Segoe UI", 9.75F);
            btn_cancel_lo.Location = new Point(295, 190);
            btn_cancel_lo.Margin = new Padding(4, 2, 4, 2);
            btn_cancel_lo.MaximumSize = new Size(100, 30);
            btn_cancel_lo.MinimumSize = new Size(100, 30);
            btn_cancel_lo.Name = "btn_cancel_lo";
            btn_cancel_lo.Size = new Size(100, 30);
            btn_cancel_lo.TabIndex = 4;
            btn_cancel_lo.Text = "Annuler";
            btn_cancel_lo.UseVisualStyleBackColor = false;
            btn_cancel_lo.Click += bnt_cancel_lo_Click;
            // 
            // pic_reservecut_lo
            // 
            pic_reservecut_lo.Image = Properties.Resources.ReserveCut_Titre;
            pic_reservecut_lo.Location = new Point(13, 6);
            pic_reservecut_lo.Margin = new Padding(4, 2, 4, 2);
            pic_reservecut_lo.MaximumSize = new Size(398, 70);
            pic_reservecut_lo.MinimumSize = new Size(398, 70);
            pic_reservecut_lo.Name = "pic_reservecut_lo";
            pic_reservecut_lo.Size = new Size(398, 70);
            pic_reservecut_lo.TabIndex = 6;
            pic_reservecut_lo.TabStop = false;
            // 
            // FrmLogin
            // 
            AcceptButton = btn_login_lo;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_cancel_lo;
            ClientSize = new Size(424, 239);
            Controls.Add(pic_reservecut_lo);
            Controls.Add(btn_cancel_lo);
            Controls.Add(btn_login_lo);
            Controls.Add(txb_password_lo);
            Controls.Add(txb_username_lo);
            Controls.Add(lbl_password_lo);
            Controls.Add(lbl_username_lo);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            MaximizeBox = false;
            MaximumSize = new Size(440, 278);
            MinimizeBox = false;
            MinimumSize = new Size(440, 278);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pic_reservecut_lo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_username_lo;
        private Label lbl_password_lo;
        private TextBox txb_username_lo;
        private TextBox txb_password_lo;
        private Button btn_login_lo;
        private Button btn_cancel_lo;
        private PictureBox pic_reservecut_lo;
    }
}
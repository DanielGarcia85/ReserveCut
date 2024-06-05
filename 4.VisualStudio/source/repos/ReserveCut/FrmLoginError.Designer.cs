namespace ReserveCut
{
    partial class FrmLoginError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginError));
            lbl_loginerror_le = new Label();
            btn_ok_le = new Button();
            SuspendLayout();
            // 
            // lbl_loginerror_le
            // 
            lbl_loginerror_le.AutoSize = true;
            lbl_loginerror_le.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_loginerror_le.Location = new Point(46, 27);
            lbl_loginerror_le.MaximumSize = new Size(291, 23);
            lbl_loginerror_le.MinimumSize = new Size(291, 23);
            lbl_loginerror_le.Name = "lbl_loginerror_le";
            lbl_loginerror_le.Size = new Size(291, 23);
            lbl_loginerror_le.TabIndex = 0;
            lbl_loginerror_le.Text = "Nom d'utilisateur et/ou mot de passe faux";
            // 
            // btn_ok_le
            // 
            btn_ok_le.BackColor = SystemColors.Window;
            btn_ok_le.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_ok_le.Location = new Point(134, 67);
            btn_ok_le.MaximumSize = new Size(114, 40);
            btn_ok_le.MinimumSize = new Size(114, 40);
            btn_ok_le.Name = "btn_ok_le";
            btn_ok_le.Size = new Size(114, 40);
            btn_ok_le.TabIndex = 1;
            btn_ok_le.Text = "OK";
            btn_ok_le.UseVisualStyleBackColor = false;
            btn_ok_le.Click += btn_ok_le_Click;
            // 
            // FrmLoginError
            // 
            AcceptButton = btn_ok_le;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_ok_le;
            ClientSize = new Size(379, 124);
            Controls.Add(btn_ok_le);
            Controls.Add(lbl_loginerror_le);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(397, 171);
            MinimizeBox = false;
            MinimumSize = new Size(397, 171);
            Name = "FrmLoginError";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Erreur";
            Load += FrmLoginError_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_loginerror_le;
        private Button btn_ok_le;
    }
}
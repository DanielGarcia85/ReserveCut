namespace ReserveCut
{
    partial class FrmPasswordConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPasswordConfirmation));
            lbl_confirmation_pc = new Label();
            txb_password_pc = new TextBox();
            btn_confirm_pc = new Button();
            btn_cancel_pc = new Button();
            SuspendLayout();
            // 
            // lbl_confirmation_pc
            // 
            lbl_confirmation_pc.AutoSize = true;
            lbl_confirmation_pc.Font = new Font("Segoe UI", 9.75F);
            lbl_confirmation_pc.Location = new Point(101, 27);
            lbl_confirmation_pc.MaximumSize = new Size(239, 23);
            lbl_confirmation_pc.MinimumSize = new Size(239, 23);
            lbl_confirmation_pc.Name = "lbl_confirmation_pc";
            lbl_confirmation_pc.Size = new Size(239, 23);
            lbl_confirmation_pc.TabIndex = 0;
            lbl_confirmation_pc.Text = "Veuillez confirmer le mot de passe";
            // 
            // txb_password_pc
            // 
            txb_password_pc.Location = new Point(83, 63);
            txb_password_pc.MaximumSize = new Size(271, 23);
            txb_password_pc.MinimumSize = new Size(271, 23);
            txb_password_pc.Name = "txb_password_pc";
            txb_password_pc.Size = new Size(271, 27);
            txb_password_pc.TabIndex = 1;
            txb_password_pc.UseSystemPasswordChar = true;
            // 
            // btn_confirm_pc
            // 
            btn_confirm_pc.BackColor = Color.Honeydew;
            btn_confirm_pc.Location = new Point(83, 108);
            btn_confirm_pc.MaximumSize = new Size(114, 40);
            btn_confirm_pc.MinimumSize = new Size(114, 40);
            btn_confirm_pc.Name = "btn_confirm_pc";
            btn_confirm_pc.Size = new Size(114, 40);
            btn_confirm_pc.TabIndex = 2;
            btn_confirm_pc.Text = "Confirmer";
            btn_confirm_pc.UseVisualStyleBackColor = false;
            btn_confirm_pc.Click += btn_confirm_pc_Click;
            // 
            // btn_cancel_pc
            // 
            btn_cancel_pc.BackColor = Color.MistyRose;
            btn_cancel_pc.Location = new Point(241, 108);
            btn_cancel_pc.MaximumSize = new Size(114, 40);
            btn_cancel_pc.MinimumSize = new Size(114, 40);
            btn_cancel_pc.Name = "btn_cancel_pc";
            btn_cancel_pc.Size = new Size(114, 40);
            btn_cancel_pc.TabIndex = 3;
            btn_cancel_pc.Text = "Annuler";
            btn_cancel_pc.UseVisualStyleBackColor = false;
            btn_cancel_pc.Click += btn_cancel_pc_Click;
            // 
            // FrmPasswordConfirmation
            // 
            AcceptButton = btn_confirm_pc;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_cancel_pc;
            ClientSize = new Size(437, 164);
            Controls.Add(btn_cancel_pc);
            Controls.Add(btn_confirm_pc);
            Controls.Add(txb_password_pc);
            Controls.Add(lbl_confirmation_pc);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(455, 211);
            MinimizeBox = false;
            MinimumSize = new Size(455, 211);
            Name = "FrmPasswordConfirmation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Mot de passe";
            Load += FrmPasswordConfirmation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_confirmation_pc;
        private TextBox txb_password_pc;
        private Button btn_confirm_pc;
        private Button btn_cancel_pc;
    }
}
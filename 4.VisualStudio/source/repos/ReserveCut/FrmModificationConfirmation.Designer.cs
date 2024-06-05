namespace ReserveCut
{
    partial class FrmModificationConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificationConfirmation));
            btn_ok_mc = new Button();
            lbl_confirmation_mc = new Label();
            SuspendLayout();
            // 
            // btn_ok_mc
            // 
            btn_ok_mc.BackColor = SystemColors.Window;
            btn_ok_mc.Font = new Font("Segoe UI", 9.75F);
            btn_ok_mc.Location = new Point(117, 44);
            btn_ok_mc.MaximumSize = new Size(100, 26);
            btn_ok_mc.MinimumSize = new Size(100, 26);
            btn_ok_mc.Name = "btn_ok_mc";
            btn_ok_mc.Size = new Size(100, 26);
            btn_ok_mc.TabIndex = 1;
            btn_ok_mc.Text = "OK";
            btn_ok_mc.UseVisualStyleBackColor = false;
            btn_ok_mc.Click += btn_ok_mc_Click;
            // 
            // lbl_confirmation_mc
            // 
            lbl_confirmation_mc.AutoSize = true;
            lbl_confirmation_mc.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_confirmation_mc.Location = new Point(81, 18);
            lbl_confirmation_mc.MaximumSize = new Size(173, 15);
            lbl_confirmation_mc.MinimumSize = new Size(173, 15);
            lbl_confirmation_mc.Name = "lbl_confirmation_mc";
            lbl_confirmation_mc.Size = new Size(173, 15);
            lbl_confirmation_mc.TabIndex = 0;
            lbl_confirmation_mc.Text = "L'élément a bien été modifié";
            // 
            // FrmModificationConfirmation
            // 
            AcceptButton = btn_ok_mc;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_ok_mc;
            ClientSize = new Size(334, 89);
            Controls.Add(btn_ok_mc);
            Controls.Add(lbl_confirmation_mc);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(350, 128);
            MinimizeBox = false;
            MinimumSize = new Size(350, 128);
            Name = "FrmModificationConfirmation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Modification";
            Load += FrmModificationConfirmation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_ok_mc;
        private Label lbl_confirmation_mc;
    }
}
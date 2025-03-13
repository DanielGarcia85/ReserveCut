namespace ReserveCut
{
    partial class FrmDeleteConfirmationRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeleteConfirmationRequest));
            lbl_confirmation_dcr = new Label();
            btn_confirm_dcr = new Button();
            btn_cancel_dcr = new Button();
            SuspendLayout();
            // 
            // lbl_confirmation_dcr
            // 
            lbl_confirmation_dcr.AutoSize = true;
            lbl_confirmation_dcr.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_confirmation_dcr.Location = new Point(62, 27);
            lbl_confirmation_dcr.MaximumSize = new Size(317, 23);
            lbl_confirmation_dcr.MinimumSize = new Size(317, 23);
            lbl_confirmation_dcr.Name = "lbl_confirmation_dcr";
            lbl_confirmation_dcr.Size = new Size(317, 23);
            lbl_confirmation_dcr.TabIndex = 0;
            lbl_confirmation_dcr.Text = "Voulez-vous vraiment supprimer cet élément ?";
            // 
            // btn_confirm_dcr
            // 
            btn_confirm_dcr.BackColor = SystemColors.Window;
            btn_confirm_dcr.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_confirm_dcr.Location = new Point(82, 67);
            btn_confirm_dcr.Margin = new Padding(3, 4, 3, 4);
            btn_confirm_dcr.MaximumSize = new Size(114, 40);
            btn_confirm_dcr.MinimumSize = new Size(114, 40);
            btn_confirm_dcr.Name = "btn_confirm_dcr";
            btn_confirm_dcr.Size = new Size(114, 40);
            btn_confirm_dcr.TabIndex = 2;
            btn_confirm_dcr.Text = "Confirmer";
            btn_confirm_dcr.UseVisualStyleBackColor = false;
            btn_confirm_dcr.Click += btn_confirm_dcr_Click;
            // 
            // btn_cancel_dcr
            // 
            btn_cancel_dcr.BackColor = SystemColors.Window;
            btn_cancel_dcr.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel_dcr.Location = new Point(248, 67);
            btn_cancel_dcr.Margin = new Padding(3, 4, 3, 4);
            btn_cancel_dcr.MaximumSize = new Size(114, 40);
            btn_cancel_dcr.MinimumSize = new Size(114, 40);
            btn_cancel_dcr.Name = "btn_cancel_dcr";
            btn_cancel_dcr.Size = new Size(114, 40);
            btn_cancel_dcr.TabIndex = 1;
            btn_cancel_dcr.Text = "Annuler";
            btn_cancel_dcr.UseVisualStyleBackColor = false;
            btn_cancel_dcr.Click += btn_cancel_dcr_Click;
            // 
            // FrmDeleteConfirmationRequest
            // 
            AcceptButton = btn_confirm_dcr;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_cancel_dcr;
            ClientSize = new Size(437, 124);
            Controls.Add(btn_cancel_dcr);
            Controls.Add(btn_confirm_dcr);
            Controls.Add(lbl_confirmation_dcr);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(455, 171);
            MinimizeBox = false;
            MinimumSize = new Size(455, 171);
            Name = "FrmDeleteConfirmationRequest";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Suppression";
            Load += FrmDeleteConfirmationRequest_Load;
            Shown += deleteConfirmationFom_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btn_confirm_dcr;
        private Button btn_cancel_dcr;
        public Label lbl_confirmation_dcr;
    }
}
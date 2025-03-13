namespace ReserveCut
{
    partial class FrmDeleteConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeleteConfirmation));
            btn_ok_dc = new Button();
            lbl_confirmation_dc = new Label();
            SuspendLayout();
            // 
            // btn_ok_dc
            // 
            btn_ok_dc.BackColor = SystemColors.Window;
            btn_ok_dc.Font = new Font("Segoe UI", 9.75F);
            btn_ok_dc.Location = new Point(134, 67);
            btn_ok_dc.Margin = new Padding(3, 4, 3, 4);
            btn_ok_dc.MaximumSize = new Size(114, 40);
            btn_ok_dc.MinimumSize = new Size(114, 40);
            btn_ok_dc.Name = "btn_ok_dc";
            btn_ok_dc.Size = new Size(114, 40);
            btn_ok_dc.TabIndex = 1;
            btn_ok_dc.Text = "OK";
            btn_ok_dc.UseVisualStyleBackColor = false;
            btn_ok_dc.Click += btn_ok_dc_Click;
            // 
            // lbl_confirmation_dc
            // 
            lbl_confirmation_dc.AutoSize = true;
            lbl_confirmation_dc.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_confirmation_dc.Location = new Point(86, 27);
            lbl_confirmation_dc.MaximumSize = new Size(210, 23);
            lbl_confirmation_dc.MinimumSize = new Size(210, 23);
            lbl_confirmation_dc.Name = "lbl_confirmation_dc";
            lbl_confirmation_dc.Size = new Size(210, 23);
            lbl_confirmation_dc.TabIndex = 0;
            lbl_confirmation_dc.Text = "L'élément a bien été supprimé";
            // 
            // FrmDeleteConfirmation
            // 
            AcceptButton = btn_ok_dc;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_ok_dc;
            ClientSize = new Size(379, 124);
            Controls.Add(btn_ok_dc);
            Controls.Add(lbl_confirmation_dc);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(397, 171);
            MinimizeBox = false;
            MinimumSize = new Size(397, 171);
            Name = "FrmDeleteConfirmation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Suppression";
            Load += FrmDeleteConfirmation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_ok_dc;
        private Label lbl_confirmation_dc;
    }
}
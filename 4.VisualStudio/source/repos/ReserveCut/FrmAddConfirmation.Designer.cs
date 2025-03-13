namespace ReserveCut
{
    partial class FrmAddConfirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddConfirmation));
            lbl_confirmation_ac = new Label();
            btn_ok_ac = new Button();
            SuspendLayout();
            // 
            // lbl_confirmation_ac
            // 
            lbl_confirmation_ac.AutoSize = true;
            lbl_confirmation_ac.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_confirmation_ac.Location = new Point(85, 20);
            lbl_confirmation_ac.Margin = new Padding(4, 0, 4, 0);
            lbl_confirmation_ac.MaximumSize = new Size(164, 18);
            lbl_confirmation_ac.MinimumSize = new Size(164, 18);
            lbl_confirmation_ac.Name = "lbl_confirmation_ac";
            lbl_confirmation_ac.Size = new Size(164, 18);
            lbl_confirmation_ac.TabIndex = 0;
            lbl_confirmation_ac.Text = "L'élément a bien été ajouté";
            // 
            // btn_ok_ac
            // 
            btn_ok_ac.BackColor = SystemColors.Window;
            btn_ok_ac.Font = new Font("Segoe UI", 9.75F);
            btn_ok_ac.Location = new Point(117, 50);
            btn_ok_ac.Margin = new Padding(4, 2, 4, 2);
            btn_ok_ac.MaximumSize = new Size(100, 30);
            btn_ok_ac.MinimumSize = new Size(100, 30);
            btn_ok_ac.Name = "btn_ok_ac";
            btn_ok_ac.Size = new Size(100, 30);
            btn_ok_ac.TabIndex = 1;
            btn_ok_ac.Text = "OK";
            btn_ok_ac.UseVisualStyleBackColor = false;
            btn_ok_ac.Click += btn_ok_ac_Click;
            // 
            // FrmAddConfirmation
            // 
            AcceptButton = btn_ok_ac;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_ok_ac;
            ClientSize = new Size(332, 99);
            Controls.Add(btn_ok_ac);
            Controls.Add(lbl_confirmation_ac);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            MaximizeBox = false;
            MaximumSize = new Size(348, 138);
            MinimizeBox = false;
            MinimumSize = new Size(348, 138);
            Name = "FrmAddConfirmation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ajout";
            Load += FrmAddConfirmation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_confirmation_ac;
        private Button btn_ok_ac;
    }
}
namespace ReserveCut
{
    partial class FrmNewAbsence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewAbsence));
            lbl_begindate_na = new Label();
            lbl_enddate_na = new Label();
            dtp_begindate_na = new DateTimePicker();
            dtp_enddate_na = new DateTimePicker();
            lbl_newabsence_na = new Label();
            btn_close_na = new Button();
            btn_add_na = new Button();
            SuspendLayout();
            // 
            // lbl_begindate_na
            // 
            lbl_begindate_na.AutoSize = true;
            lbl_begindate_na.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_begindate_na.Location = new Point(35, 85);
            lbl_begindate_na.MaximumSize = new Size(168, 32);
            lbl_begindate_na.MinimumSize = new Size(168, 32);
            lbl_begindate_na.Name = "lbl_begindate_na";
            lbl_begindate_na.Size = new Size(168, 32);
            lbl_begindate_na.TabIndex = 0;
            lbl_begindate_na.Text = "Date de début";
            // 
            // lbl_enddate_na
            // 
            lbl_enddate_na.AutoSize = true;
            lbl_enddate_na.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_enddate_na.Location = new Point(35, 129);
            lbl_enddate_na.MaximumSize = new Size(133, 32);
            lbl_enddate_na.MinimumSize = new Size(133, 32);
            lbl_enddate_na.Name = "lbl_enddate_na";
            lbl_enddate_na.Size = new Size(133, 32);
            lbl_enddate_na.TabIndex = 0;
            lbl_enddate_na.Text = "Date de fin";
            // 
            // dtp_begindate_na
            // 
            dtp_begindate_na.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_begindate_na.Format = DateTimePickerFormat.Short;
            dtp_begindate_na.Location = new Point(217, 85);
            dtp_begindate_na.MaximumSize = new Size(302, 40);
            dtp_begindate_na.MinimumSize = new Size(302, 40);
            dtp_begindate_na.Name = "dtp_begindate_na";
            dtp_begindate_na.Size = new Size(302, 40);
            dtp_begindate_na.TabIndex = 1;
            // 
            // dtp_enddate_na
            // 
            dtp_enddate_na.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_enddate_na.Format = DateTimePickerFormat.Short;
            dtp_enddate_na.Location = new Point(217, 129);
            dtp_enddate_na.MaximumSize = new Size(302, 40);
            dtp_enddate_na.MinimumSize = new Size(302, 40);
            dtp_enddate_na.Name = "dtp_enddate_na";
            dtp_enddate_na.Size = new Size(302, 40);
            dtp_enddate_na.TabIndex = 2;
            // 
            // lbl_newabsence_na
            // 
            lbl_newabsence_na.AutoSize = true;
            lbl_newabsence_na.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newabsence_na.Location = new Point(241, 11);
            lbl_newabsence_na.MaximumSize = new Size(271, 45);
            lbl_newabsence_na.MinimumSize = new Size(271, 45);
            lbl_newabsence_na.Name = "lbl_newabsence_na";
            lbl_newabsence_na.Size = new Size(271, 45);
            lbl_newabsence_na.TabIndex = 0;
            lbl_newabsence_na.Text = "Nouvelle absence";
            // 
            // btn_close_na
            // 
            btn_close_na.BackColor = SystemColors.Window;
            btn_close_na.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_close_na.Location = new Point(562, 134);
            btn_close_na.MaximumSize = new Size(147, 35);
            btn_close_na.MinimumSize = new Size(147, 35);
            btn_close_na.Name = "btn_close_na";
            btn_close_na.Size = new Size(147, 35);
            btn_close_na.TabIndex = 4;
            btn_close_na.Text = "Fermer";
            btn_close_na.UseVisualStyleBackColor = false;
            // 
            // btn_add_na
            // 
            btn_add_na.BackColor = Color.Honeydew;
            btn_add_na.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_add_na.Location = new Point(562, 90);
            btn_add_na.MaximumSize = new Size(147, 35);
            btn_add_na.MinimumSize = new Size(147, 35);
            btn_add_na.Name = "btn_add_na";
            btn_add_na.Size = new Size(147, 35);
            btn_add_na.TabIndex = 3;
            btn_add_na.Text = "Ajouter";
            btn_add_na.UseVisualStyleBackColor = false;
            btn_add_na.Click += btn_add_na_Click;
            // 
            // FrmNewAbsence
            // 
            AcceptButton = btn_close_na;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_close_na;
            ClientSize = new Size(744, 211);
            Controls.Add(btn_close_na);
            Controls.Add(btn_add_na);
            Controls.Add(lbl_newabsence_na);
            Controls.Add(dtp_enddate_na);
            Controls.Add(dtp_begindate_na);
            Controls.Add(lbl_enddate_na);
            Controls.Add(lbl_begindate_na);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(760, 250);
            MinimizeBox = false;
            MinimumSize = new Size(760, 250);
            Name = "FrmNewAbsence";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nouvelle Absence";
            Load += FrmNewAbsence_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_begindate_na;
        private Label lbl_enddate_na;
        private DateTimePicker dtp_begindate_na;
        private DateTimePicker dtp_enddate_na;
        private Label lbl_newabsence_na;
        private Button btn_close_na;
        private Button btn_add_na;
    }
}
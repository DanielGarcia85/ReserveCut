namespace ReserveCut
{
    partial class FrmNewStylist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewStylist));
            lbl_newstylist_ns = new Label();
            txb_firstname_ns = new TextBox();
            txb_name_ns = new TextBox();
            lbl_firstname_ns = new Label();
            lbl_name_ns = new Label();
            btn_quite_ns = new Button();
            btn_add_ns = new Button();
            btn_photo_ns = new Button();
            lbl_speciality_ns = new Label();
            lst_speciality_ns = new ListBox();
            btn_addspeciality_ns = new Button();
            cmb_speciality_ns = new ComboBox();
            SuspendLayout();
            // 
            // lbl_newstylist_ns
            // 
            lbl_newstylist_ns.AutoSize = true;
            lbl_newstylist_ns.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newstylist_ns.Location = new Point(240, 16);
            lbl_newstylist_ns.MaximumSize = new Size(264, 45);
            lbl_newstylist_ns.MinimumSize = new Size(264, 45);
            lbl_newstylist_ns.Name = "lbl_newstylist_ns";
            lbl_newstylist_ns.Size = new Size(264, 45);
            lbl_newstylist_ns.TabIndex = 0;
            lbl_newstylist_ns.Text = "Nouveau coiffeur";
            // 
            // txb_firstname_ns
            // 
            txb_firstname_ns.Font = new Font("Segoe UI", 18F);
            txb_firstname_ns.Location = new Point(217, 129);
            txb_firstname_ns.MaximumSize = new Size(302, 40);
            txb_firstname_ns.MinimumSize = new Size(302, 40);
            txb_firstname_ns.Name = "txb_firstname_ns";
            txb_firstname_ns.Size = new Size(302, 39);
            txb_firstname_ns.TabIndex = 2;
            // 
            // txb_name_ns
            // 
            txb_name_ns.Font = new Font("Segoe UI", 18F);
            txb_name_ns.Location = new Point(217, 85);
            txb_name_ns.MaximumSize = new Size(302, 40);
            txb_name_ns.MinimumSize = new Size(302, 40);
            txb_name_ns.Name = "txb_name_ns";
            txb_name_ns.Size = new Size(302, 39);
            txb_name_ns.TabIndex = 1;
            // 
            // lbl_firstname_ns
            // 
            lbl_firstname_ns.AutoSize = true;
            lbl_firstname_ns.Font = new Font("Segoe UI", 18F);
            lbl_firstname_ns.Location = new Point(35, 129);
            lbl_firstname_ns.MaximumSize = new Size(97, 32);
            lbl_firstname_ns.MinimumSize = new Size(97, 32);
            lbl_firstname_ns.Name = "lbl_firstname_ns";
            lbl_firstname_ns.Size = new Size(97, 32);
            lbl_firstname_ns.TabIndex = 0;
            lbl_firstname_ns.Text = "Prénom";
            // 
            // lbl_name_ns
            // 
            lbl_name_ns.AutoSize = true;
            lbl_name_ns.Font = new Font("Segoe UI", 18F);
            lbl_name_ns.Location = new Point(35, 85);
            lbl_name_ns.MaximumSize = new Size(67, 32);
            lbl_name_ns.MinimumSize = new Size(67, 32);
            lbl_name_ns.Name = "lbl_name_ns";
            lbl_name_ns.Size = new Size(67, 32);
            lbl_name_ns.TabIndex = 0;
            lbl_name_ns.Text = "Nom";
            // 
            // btn_quite_ns
            // 
            btn_quite_ns.BackColor = Color.Transparent;
            btn_quite_ns.Font = new Font("Segoe UI", 13.8F);
            btn_quite_ns.Location = new Point(562, 448);
            btn_quite_ns.MaximumSize = new Size(147, 35);
            btn_quite_ns.MinimumSize = new Size(147, 35);
            btn_quite_ns.Name = "btn_quite_ns";
            btn_quite_ns.Size = new Size(147, 35);
            btn_quite_ns.TabIndex = 8;
            btn_quite_ns.Text = "Fermer";
            btn_quite_ns.UseVisualStyleBackColor = false;
            btn_quite_ns.Click += btn_cancel_ns_Click;
            // 
            // btn_add_ns
            // 
            btn_add_ns.BackColor = Color.Honeydew;
            btn_add_ns.Font = new Font("Segoe UI", 13.8F);
            btn_add_ns.Location = new Point(562, 403);
            btn_add_ns.MaximumSize = new Size(147, 35);
            btn_add_ns.MinimumSize = new Size(147, 35);
            btn_add_ns.Name = "btn_add_ns";
            btn_add_ns.Size = new Size(147, 35);
            btn_add_ns.TabIndex = 7;
            btn_add_ns.Text = "Ajouter";
            btn_add_ns.UseVisualStyleBackColor = false;
            btn_add_ns.Click += btn_add_ns_Click;
            // 
            // btn_photo_ns
            // 
            btn_photo_ns.BackColor = SystemColors.Window;
            btn_photo_ns.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_photo_ns.Location = new Point(562, 86);
            btn_photo_ns.MaximumSize = new Size(147, 84);
            btn_photo_ns.MinimumSize = new Size(147, 84);
            btn_photo_ns.Name = "btn_photo_ns";
            btn_photo_ns.Size = new Size(147, 84);
            btn_photo_ns.TabIndex = 6;
            btn_photo_ns.Text = "Ajouter une photo";
            btn_photo_ns.UseVisualStyleBackColor = false;
            btn_photo_ns.Click += bnt_photo_ns_Click;
            // 
            // lbl_speciality_ns
            // 
            lbl_speciality_ns.AutoSize = true;
            lbl_speciality_ns.Font = new Font("Segoe UI", 18F);
            lbl_speciality_ns.Location = new Point(35, 175);
            lbl_speciality_ns.MaximumSize = new Size(116, 32);
            lbl_speciality_ns.MinimumSize = new Size(116, 32);
            lbl_speciality_ns.Name = "lbl_speciality_ns";
            lbl_speciality_ns.Size = new Size(116, 32);
            lbl_speciality_ns.TabIndex = 0;
            lbl_speciality_ns.Text = "Spécialité";
            // 
            // lst_speciality_ns
            // 
            lst_speciality_ns.BackColor = SystemColors.Window;
            lst_speciality_ns.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lst_speciality_ns.FormattingEnabled = true;
            lst_speciality_ns.ItemHeight = 25;
            lst_speciality_ns.Location = new Point(217, 221);
            lst_speciality_ns.MaximumSize = new Size(302, 254);
            lst_speciality_ns.MinimumSize = new Size(302, 254);
            lst_speciality_ns.Name = "lst_speciality_ns";
            lst_speciality_ns.Size = new Size(302, 254);
            lst_speciality_ns.TabIndex = 5;
            // 
            // btn_addspeciality_ns
            // 
            btn_addspeciality_ns.BackColor = SystemColors.Window;
            btn_addspeciality_ns.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_addspeciality_ns.Location = new Point(451, 175);
            btn_addspeciality_ns.MaximumSize = new Size(68, 40);
            btn_addspeciality_ns.MinimumSize = new Size(68, 40);
            btn_addspeciality_ns.Name = "btn_addspeciality_ns";
            btn_addspeciality_ns.Size = new Size(68, 40);
            btn_addspeciality_ns.TabIndex = 4;
            btn_addspeciality_ns.Text = "Ajouter";
            btn_addspeciality_ns.UseVisualStyleBackColor = false;
            btn_addspeciality_ns.Click += btn_addspeciality_ns_Click;
            // 
            // cmb_speciality_ns
            // 
            cmb_speciality_ns.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_speciality_ns.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_speciality_ns.FormattingEnabled = true;
            cmb_speciality_ns.Location = new Point(217, 175);
            cmb_speciality_ns.MaximumSize = new Size(228, 0);
            cmb_speciality_ns.MinimumSize = new Size(228, 0);
            cmb_speciality_ns.Name = "cmb_speciality_ns";
            cmb_speciality_ns.Size = new Size(228, 40);
            cmb_speciality_ns.TabIndex = 3;
            // 
            // FrmNewStylist
            // 
            AcceptButton = btn_add_ns;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_quite_ns;
            ClientSize = new Size(744, 499);
            Controls.Add(cmb_speciality_ns);
            Controls.Add(btn_addspeciality_ns);
            Controls.Add(lst_speciality_ns);
            Controls.Add(lbl_speciality_ns);
            Controls.Add(btn_photo_ns);
            Controls.Add(btn_quite_ns);
            Controls.Add(btn_add_ns);
            Controls.Add(txb_firstname_ns);
            Controls.Add(txb_name_ns);
            Controls.Add(lbl_firstname_ns);
            Controls.Add(lbl_name_ns);
            Controls.Add(lbl_newstylist_ns);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(760, 538);
            MinimizeBox = false;
            MinimumSize = new Size(760, 538);
            Name = "FrmNewStylist";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nouveau coiffeur";
            Load += FrmNewStylist_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_newstylist_ns;
        private TextBox txb_firstname_ns;
        private TextBox txb_name_ns;
        private Label lbl_firstname_ns;
        private Label lbl_name_ns;
        private Button btn_quite_ns;
        private Button btn_add_ns;
        private Button btn_photo_ns;
        private Label lbl_speciality_ns;
        private ListBox lst_speciality_ns;
        private Button btn_addspeciality_ns;
        private ComboBox cmb_speciality_ns;
    }
}
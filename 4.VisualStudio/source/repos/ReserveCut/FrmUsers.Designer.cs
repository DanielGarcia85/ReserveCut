namespace ReserveCut
{
    partial class FrmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            lbl_name_us = new Label();
            lbl_firstname_us = new Label();
            lbl_username_us = new Label();
            lbl_password_us = new Label();
            lbl_role_us = new Label();
            txb_name_us = new TextBox();
            txb_firstname_us = new TextBox();
            txb_username_us = new TextBox();
            txb_password_us = new TextBox();
            txb_role_us = new TextBox();
            cmb_username_us = new ComboBox();
            btn_previous_us = new Button();
            btn_next_us = new Button();
            btn_add_us = new Button();
            btn_modify_us = new Button();
            btn_delete_us = new Button();
            btn_confirm_us = new Button();
            btn_cancel_us = new Button();
            cmb_role_us = new ComboBox();
            btn_close_us = new Button();
            lbl_password_minlength_us = new Label();
            SuspendLayout();
            // 
            // lbl_name_us
            // 
            lbl_name_us.AutoSize = true;
            lbl_name_us.Font = new Font("Segoe UI", 12F);
            lbl_name_us.Location = new Point(42, 46);
            lbl_name_us.MaximumSize = new Size(45, 21);
            lbl_name_us.MinimumSize = new Size(45, 21);
            lbl_name_us.Name = "lbl_name_us";
            lbl_name_us.Size = new Size(45, 21);
            lbl_name_us.TabIndex = 0;
            lbl_name_us.Text = "Nom";
            // 
            // lbl_firstname_us
            // 
            lbl_firstname_us.AutoSize = true;
            lbl_firstname_us.Font = new Font("Segoe UI", 12F);
            lbl_firstname_us.Location = new Point(42, 76);
            lbl_firstname_us.MaximumSize = new Size(65, 21);
            lbl_firstname_us.MinimumSize = new Size(65, 21);
            lbl_firstname_us.Name = "lbl_firstname_us";
            lbl_firstname_us.RightToLeft = RightToLeft.Yes;
            lbl_firstname_us.Size = new Size(65, 21);
            lbl_firstname_us.TabIndex = 0;
            lbl_firstname_us.Text = "Prénom";
            // 
            // lbl_username_us
            // 
            lbl_username_us.AutoSize = true;
            lbl_username_us.Font = new Font("Segoe UI", 12F);
            lbl_username_us.Location = new Point(42, 106);
            lbl_username_us.MaximumSize = new Size(131, 21);
            lbl_username_us.MinimumSize = new Size(131, 21);
            lbl_username_us.Name = "lbl_username_us";
            lbl_username_us.Size = new Size(131, 21);
            lbl_username_us.TabIndex = 0;
            lbl_username_us.Text = "Nom d'utilisateur";
            // 
            // lbl_password_us
            // 
            lbl_password_us.AutoSize = true;
            lbl_password_us.Font = new Font("Segoe UI", 12F);
            lbl_password_us.Location = new Point(42, 136);
            lbl_password_us.MaximumSize = new Size(102, 21);
            lbl_password_us.MinimumSize = new Size(102, 21);
            lbl_password_us.Name = "lbl_password_us";
            lbl_password_us.Size = new Size(102, 21);
            lbl_password_us.TabIndex = 0;
            lbl_password_us.Text = "Mot de passe";
            // 
            // lbl_role_us
            // 
            lbl_role_us.AutoSize = true;
            lbl_role_us.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_role_us.Location = new Point(42, 166);
            lbl_role_us.MaximumSize = new Size(41, 21);
            lbl_role_us.MinimumSize = new Size(41, 21);
            lbl_role_us.Name = "lbl_role_us";
            lbl_role_us.Size = new Size(41, 21);
            lbl_role_us.TabIndex = 0;
            lbl_role_us.Text = "Rôle";
            // 
            // txb_name_us
            // 
            txb_name_us.BackColor = SystemColors.Window;
            txb_name_us.Location = new Point(196, 44);
            txb_name_us.MaximumSize = new Size(167, 23);
            txb_name_us.MinimumSize = new Size(167, 23);
            txb_name_us.Name = "txb_name_us";
            txb_name_us.ReadOnly = true;
            txb_name_us.Size = new Size(167, 23);
            txb_name_us.TabIndex = 1;
            // 
            // txb_firstname_us
            // 
            txb_firstname_us.BackColor = SystemColors.Window;
            txb_firstname_us.Location = new Point(196, 74);
            txb_firstname_us.MaximumSize = new Size(167, 23);
            txb_firstname_us.MinimumSize = new Size(167, 23);
            txb_firstname_us.Name = "txb_firstname_us";
            txb_firstname_us.ReadOnly = true;
            txb_firstname_us.Size = new Size(167, 23);
            txb_firstname_us.TabIndex = 2;
            // 
            // txb_username_us
            // 
            txb_username_us.BackColor = SystemColors.Window;
            txb_username_us.Location = new Point(196, 104);
            txb_username_us.MaximumSize = new Size(167, 23);
            txb_username_us.MinimumSize = new Size(167, 23);
            txb_username_us.Name = "txb_username_us";
            txb_username_us.ReadOnly = true;
            txb_username_us.Size = new Size(167, 23);
            txb_username_us.TabIndex = 3;
            txb_username_us.Visible = false;
            // 
            // txb_password_us
            // 
            txb_password_us.BackColor = SystemColors.Window;
            txb_password_us.Location = new Point(196, 134);
            txb_password_us.MaximumSize = new Size(167, 23);
            txb_password_us.MinimumSize = new Size(167, 23);
            txb_password_us.Name = "txb_password_us";
            txb_password_us.ReadOnly = true;
            txb_password_us.Size = new Size(167, 23);
            txb_password_us.TabIndex = 5;
            txb_password_us.UseSystemPasswordChar = true;
            // 
            // txb_role_us
            // 
            txb_role_us.BackColor = SystemColors.Window;
            txb_role_us.Location = new Point(196, 164);
            txb_role_us.MaximumSize = new Size(167, 23);
            txb_role_us.MinimumSize = new Size(167, 23);
            txb_role_us.Name = "txb_role_us";
            txb_role_us.ReadOnly = true;
            txb_role_us.Size = new Size(167, 23);
            txb_role_us.TabIndex = 6;
            // 
            // cmb_username_us
            // 
            cmb_username_us.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_username_us.ForeColor = SystemColors.WindowText;
            cmb_username_us.FormattingEnabled = true;
            cmb_username_us.Location = new Point(196, 104);
            cmb_username_us.MaximumSize = new Size(167, 0);
            cmb_username_us.MinimumSize = new Size(167, 0);
            cmb_username_us.Name = "cmb_username_us";
            cmb_username_us.Size = new Size(167, 23);
            cmb_username_us.TabIndex = 4;
            cmb_username_us.SelectedIndexChanged += cmb_username_us_SelectedIndexChanged;
            // 
            // btn_previous_us
            // 
            btn_previous_us.Image = (Image)resources.GetObject("btn_previous_us.Image");
            btn_previous_us.Location = new Point(267, 20);
            btn_previous_us.MaximumSize = new Size(47, 19);
            btn_previous_us.MinimumSize = new Size(47, 19);
            btn_previous_us.Name = "btn_previous_us";
            btn_previous_us.Size = new Size(47, 19);
            btn_previous_us.TabIndex = 14;
            btn_previous_us.UseVisualStyleBackColor = true;
            btn_previous_us.Click += btn_previous_us_Click;
            // 
            // btn_next_us
            // 
            btn_next_us.Image = (Image)resources.GetObject("btn_next_us.Image");
            btn_next_us.Location = new Point(316, 20);
            btn_next_us.MaximumSize = new Size(47, 19);
            btn_next_us.MinimumSize = new Size(47, 19);
            btn_next_us.Name = "btn_next_us";
            btn_next_us.Size = new Size(47, 19);
            btn_next_us.TabIndex = 15;
            btn_next_us.UseVisualStyleBackColor = true;
            btn_next_us.Click += btn_next_us_Click;
            // 
            // btn_add_us
            // 
            btn_add_us.BackColor = Color.Honeydew;
            btn_add_us.Location = new Point(41, 214);
            btn_add_us.MaximumSize = new Size(100, 30);
            btn_add_us.MinimumSize = new Size(100, 30);
            btn_add_us.Name = "btn_add_us";
            btn_add_us.Size = new Size(100, 30);
            btn_add_us.TabIndex = 8;
            btn_add_us.Text = "Ajouter";
            btn_add_us.UseVisualStyleBackColor = false;
            btn_add_us.Click += btn_add_us_Click;
            // 
            // btn_modify_us
            // 
            btn_modify_us.BackColor = Color.Linen;
            btn_modify_us.Location = new Point(153, 214);
            btn_modify_us.MaximumSize = new Size(100, 30);
            btn_modify_us.MinimumSize = new Size(100, 30);
            btn_modify_us.Name = "btn_modify_us";
            btn_modify_us.Size = new Size(100, 30);
            btn_modify_us.TabIndex = 9;
            btn_modify_us.Text = "Modifier";
            btn_modify_us.UseVisualStyleBackColor = false;
            btn_modify_us.Click += btn_modify_Click;
            // 
            // btn_delete_us
            // 
            btn_delete_us.BackColor = Color.MistyRose;
            btn_delete_us.Location = new Point(262, 214);
            btn_delete_us.MaximumSize = new Size(100, 30);
            btn_delete_us.MinimumSize = new Size(100, 30);
            btn_delete_us.Name = "btn_delete_us";
            btn_delete_us.Size = new Size(100, 30);
            btn_delete_us.TabIndex = 11;
            btn_delete_us.Text = "Supprimer";
            btn_delete_us.UseVisualStyleBackColor = false;
            btn_delete_us.Click += btn_delete_us_Click;
            // 
            // btn_confirm_us
            // 
            btn_confirm_us.BackColor = Color.Honeydew;
            btn_confirm_us.Font = new Font("Segoe UI", 9F);
            btn_confirm_us.ForeColor = SystemColors.ControlText;
            btn_confirm_us.Location = new Point(153, 214);
            btn_confirm_us.MaximumSize = new Size(100, 30);
            btn_confirm_us.MinimumSize = new Size(100, 30);
            btn_confirm_us.Name = "btn_confirm_us";
            btn_confirm_us.Size = new Size(100, 30);
            btn_confirm_us.TabIndex = 10;
            btn_confirm_us.Text = "Confirmer";
            btn_confirm_us.UseVisualStyleBackColor = false;
            btn_confirm_us.Visible = false;
            btn_confirm_us.Click += btn_confirm_Click;
            // 
            // btn_cancel_us
            // 
            btn_cancel_us.BackColor = Color.MistyRose;
            btn_cancel_us.Font = new Font("Segoe UI", 9F);
            btn_cancel_us.ForeColor = SystemColors.ControlText;
            btn_cancel_us.Location = new Point(262, 214);
            btn_cancel_us.MaximumSize = new Size(100, 30);
            btn_cancel_us.MinimumSize = new Size(100, 30);
            btn_cancel_us.Name = "btn_cancel_us";
            btn_cancel_us.Size = new Size(100, 30);
            btn_cancel_us.TabIndex = 12;
            btn_cancel_us.Text = "Annuler";
            btn_cancel_us.UseVisualStyleBackColor = false;
            btn_cancel_us.Visible = false;
            btn_cancel_us.Click += btn_cancel_Click;
            // 
            // cmb_role_us
            // 
            cmb_role_us.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_role_us.ForeColor = SystemColors.WindowText;
            cmb_role_us.FormattingEnabled = true;
            cmb_role_us.Items.AddRange(new object[] { "admin", "user" });
            cmb_role_us.Location = new Point(196, 164);
            cmb_role_us.MaximumSize = new Size(167, 0);
            cmb_role_us.MinimumSize = new Size(167, 0);
            cmb_role_us.Name = "cmb_role_us";
            cmb_role_us.Size = new Size(167, 23);
            cmb_role_us.TabIndex = 7;
            cmb_role_us.Visible = false;
            // 
            // btn_close_us
            // 
            btn_close_us.BackColor = SystemColors.Window;
            btn_close_us.Location = new Point(263, 256);
            btn_close_us.MaximumSize = new Size(100, 30);
            btn_close_us.MinimumSize = new Size(100, 30);
            btn_close_us.Name = "btn_close_us";
            btn_close_us.Size = new Size(100, 30);
            btn_close_us.TabIndex = 13;
            btn_close_us.Text = "Fermer";
            btn_close_us.UseVisualStyleBackColor = false;
            btn_close_us.Click += btn_close_us_Click;
            // 
            // lbl_password_minlength_us
            // 
            lbl_password_minlength_us.AutoSize = true;
            lbl_password_minlength_us.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_password_minlength_us.ForeColor = Color.LightCoral;
            lbl_password_minlength_us.Location = new Point(56, 273);
            lbl_password_minlength_us.Name = "lbl_password_minlength_us";
            lbl_password_minlength_us.Size = new Size(287, 13);
            lbl_password_minlength_us.TabIndex = 16;
            lbl_password_minlength_us.Text = "*le mot de passe doit comporter au moins 8 charactère";
            lbl_password_minlength_us.Visible = false;
            // 
            // FrmUsers
            // 
            AcceptButton = btn_close_us;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_close_us;
            ClientSize = new Size(403, 309);
            Controls.Add(lbl_password_minlength_us);
            Controls.Add(btn_close_us);
            Controls.Add(cmb_role_us);
            Controls.Add(btn_cancel_us);
            Controls.Add(btn_confirm_us);
            Controls.Add(cmb_username_us);
            Controls.Add(txb_role_us);
            Controls.Add(txb_password_us);
            Controls.Add(txb_username_us);
            Controls.Add(txb_firstname_us);
            Controls.Add(txb_name_us);
            Controls.Add(btn_next_us);
            Controls.Add(btn_previous_us);
            Controls.Add(lbl_role_us);
            Controls.Add(btn_delete_us);
            Controls.Add(lbl_password_us);
            Controls.Add(btn_modify_us);
            Controls.Add(btn_add_us);
            Controls.Add(lbl_username_us);
            Controls.Add(lbl_firstname_us);
            Controls.Add(lbl_name_us);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(419, 348);
            MinimizeBox = false;
            MinimumSize = new Size(419, 348);
            Name = "FrmUsers";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Utilisateurs";
            Load += FrmUsers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_name_us;
        private Label lbl_firstname_us;
        private Label lbl_username_us;
        private Label lbl_password_us;
        private Label lbl_role_us;
        private TextBox txb_name_us;
        private TextBox txb_firstname_us;
        private TextBox txb_username_us;
        private TextBox txb_password_us;
        private TextBox txb_role_us;
        private ComboBox cmb_username_us;
        private ComboBox cmb_role_us;
        private Button btn_previous_us;
        private Button btn_next_us;
        private Button btn_add_us;
        private Button btn_modify_us;
        private Button btn_delete_us;
        private Button btn_confirm_us;
        private Button btn_cancel_us;
        private Button btn_close_us;

        public void Set_btn_add_us_Visible(bool visible)
        {
            btn_add_us.Visible = visible;
        }

        public void Set_btn_delete_us_Visible(bool visible)
        {
            btn_delete_us.Visible = visible;
        }

        public void Set_btn_modify_us_Visible(bool visible)
        {
            btn_modify_us.Visible = visible;
        }

        public void Set_btn_validate_us_Visible(bool visible)
        {
            btn_confirm_us.Visible = visible;
        }

        public void Set_btn_cancel_us_Visible(bool visible)
        {
            btn_cancel_us.Visible = visible;
        }

        public void Set_btn_close_us_Visible(bool visible)
        {
            btn_close_us.Visible = visible;
        }

        public void Set_btn_previous_us_Visible(bool visible)
        {
            btn_previous_us.Visible = visible;
        }

        public void Set_btn_next_us_Visible(bool visible)
        {
            btn_next_us.Visible = visible;
        }

        public void Set_cmb_username_us_Visible(bool visible)
        {
            cmb_username_us.Visible = visible;
        }

        public void Set_cmb_role_us_Visible(bool visible)
        {
            cmb_role_us.Visible = visible;
        }

        public void Set_txb_username_us_Visible(bool visible)
        {
            txb_username_us.Visible = visible;
        }

        public void Set_txb_role_us_Enable(bool enable)
        {
            txb_role_us.Enabled = enable;
        }

        public void Set_txb_name_us_ReadOnly(bool readonlyy)
        {
            txb_name_us.ReadOnly = readonlyy;
        }

        public void Set_txb_firstname_us_ReadOnly(bool readonlyy)
        {
            txb_firstname_us.ReadOnly = readonlyy;
        }

        public void Set_txb_username_us_ReadOnly(bool readonlyy)
        {
            txb_username_us.ReadOnly = readonlyy;
        }

        public void Set_txb_password_us_ReadOnly(bool readonlyy)
        {
            txb_password_us.ReadOnly = readonlyy;
        }

        private Label lbl_password_minlength_us;
    }
}
namespace ReserveCut
{
    partial class FrmNewHaircut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewHaircut));
            lbl_newhaircut_nh = new Label();
            btn_quite_nh = new Button();
            btn_add_nh = new Button();
            btn_photo_nh = new Button();
            txb_name_nh = new TextBox();
            lbl_name_nh = new Label();
            lbl_description_nh = new Label();
            txb_description_nh = new RichTextBox();
            lbl_cutingtime_nh = new Label();
            lbl_shortlong_nh = new Label();
            lbl_price_nh = new Label();
            cmb_shortlong_nh = new ComboBox();
            txb_price_nh = new TextBox();
            cmb_cutingtime_nh = new ComboBox();
            SuspendLayout();
            // 
            // lbl_newhaircut_nh
            // 
            lbl_newhaircut_nh.AutoSize = true;
            lbl_newhaircut_nh.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newhaircut_nh.Location = new Point(166, 16);
            lbl_newhaircut_nh.MaximumSize = new Size(412, 45);
            lbl_newhaircut_nh.MinimumSize = new Size(412, 45);
            lbl_newhaircut_nh.Name = "lbl_newhaircut_nh";
            lbl_newhaircut_nh.Size = new Size(412, 45);
            lbl_newhaircut_nh.TabIndex = 0;
            lbl_newhaircut_nh.Text = "Nouvelle coupe de cheveux";
            // 
            // btn_quite_nh
            // 
            btn_quite_nh.BackColor = SystemColors.Window;
            btn_quite_nh.Font = new Font("Segoe UI", 13.8F);
            btn_quite_nh.Location = new Point(562, 448);
            btn_quite_nh.MaximumSize = new Size(147, 35);
            btn_quite_nh.MinimumSize = new Size(147, 35);
            btn_quite_nh.Name = "btn_quite_nh";
            btn_quite_nh.Size = new Size(147, 35);
            btn_quite_nh.TabIndex = 8;
            btn_quite_nh.Text = "Fermer";
            btn_quite_nh.UseVisualStyleBackColor = false;
            btn_quite_nh.Click += btn_cancel_nh_Click;
            // 
            // btn_add_nh
            // 
            btn_add_nh.BackColor = Color.Honeydew;
            btn_add_nh.Font = new Font("Segoe UI", 13.8F);
            btn_add_nh.Location = new Point(562, 403);
            btn_add_nh.MaximumSize = new Size(147, 35);
            btn_add_nh.MinimumSize = new Size(147, 35);
            btn_add_nh.Name = "btn_add_nh";
            btn_add_nh.Size = new Size(147, 35);
            btn_add_nh.TabIndex = 7;
            btn_add_nh.Text = "Ajouter";
            btn_add_nh.UseVisualStyleBackColor = false;
            btn_add_nh.Click += btn_add_nh_Click;
            // 
            // btn_photo_nh
            // 
            btn_photo_nh.BackColor = SystemColors.Window;
            btn_photo_nh.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_photo_nh.Location = new Point(562, 85);
            btn_photo_nh.MaximumSize = new Size(147, 84);
            btn_photo_nh.MinimumSize = new Size(147, 84);
            btn_photo_nh.Name = "btn_photo_nh";
            btn_photo_nh.Size = new Size(147, 84);
            btn_photo_nh.TabIndex = 6;
            btn_photo_nh.Text = "Ajouter une photo";
            btn_photo_nh.UseVisualStyleBackColor = false;
            btn_photo_nh.Click += bnt_photo_nh_Click;
            // 
            // txb_name_nh
            // 
            txb_name_nh.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_name_nh.Location = new Point(217, 85);
            txb_name_nh.MaximumSize = new Size(302, 40);
            txb_name_nh.MinimumSize = new Size(302, 40);
            txb_name_nh.Name = "txb_name_nh";
            txb_name_nh.Size = new Size(302, 39);
            txb_name_nh.TabIndex = 1;
            // 
            // lbl_name_nh
            // 
            lbl_name_nh.AutoSize = true;
            lbl_name_nh.Font = new Font("Segoe UI", 18F);
            lbl_name_nh.Location = new Point(35, 85);
            lbl_name_nh.MaximumSize = new Size(67, 32);
            lbl_name_nh.MinimumSize = new Size(67, 32);
            lbl_name_nh.Name = "lbl_name_nh";
            lbl_name_nh.Size = new Size(67, 32);
            lbl_name_nh.TabIndex = 0;
            lbl_name_nh.Text = "Nom";
            // 
            // lbl_description_nh
            // 
            lbl_description_nh.AutoSize = true;
            lbl_description_nh.Font = new Font("Segoe UI", 18F);
            lbl_description_nh.Location = new Point(35, 129);
            lbl_description_nh.MaximumSize = new Size(135, 32);
            lbl_description_nh.MinimumSize = new Size(135, 32);
            lbl_description_nh.Name = "lbl_description_nh";
            lbl_description_nh.Size = new Size(135, 32);
            lbl_description_nh.TabIndex = 0;
            lbl_description_nh.Text = "Description";
            // 
            // txb_description_nh
            // 
            txb_description_nh.BackColor = SystemColors.Window;
            txb_description_nh.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_description_nh.Location = new Point(217, 129);
            txb_description_nh.MaximumSize = new Size(302, 220);
            txb_description_nh.MinimumSize = new Size(302, 220);
            txb_description_nh.Name = "txb_description_nh";
            txb_description_nh.Size = new Size(302, 220);
            txb_description_nh.TabIndex = 2;
            txb_description_nh.Text = "";
            // 
            // lbl_cutingtime_nh
            // 
            lbl_cutingtime_nh.AutoSize = true;
            lbl_cutingtime_nh.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_cutingtime_nh.Location = new Point(35, 355);
            lbl_cutingtime_nh.MaximumSize = new Size(164, 30);
            lbl_cutingtime_nh.MinimumSize = new Size(164, 30);
            lbl_cutingtime_nh.Name = "lbl_cutingtime_nh";
            lbl_cutingtime_nh.Size = new Size(164, 30);
            lbl_cutingtime_nh.TabIndex = 0;
            lbl_cutingtime_nh.Text = "Temps de coupe";
            // 
            // lbl_shortlong_nh
            // 
            lbl_shortlong_nh.AutoSize = true;
            lbl_shortlong_nh.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_shortlong_nh.Location = new Point(35, 399);
            lbl_shortlong_nh.MaximumSize = new Size(130, 30);
            lbl_shortlong_nh.MinimumSize = new Size(130, 30);
            lbl_shortlong_nh.Name = "lbl_shortlong_nh";
            lbl_shortlong_nh.Size = new Size(130, 30);
            lbl_shortlong_nh.TabIndex = 0;
            lbl_shortlong_nh.Text = "Court / Long";
            // 
            // lbl_price_nh
            // 
            lbl_price_nh.AutoSize = true;
            lbl_price_nh.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_price_nh.Location = new Point(35, 445);
            lbl_price_nh.MaximumSize = new Size(47, 30);
            lbl_price_nh.MinimumSize = new Size(47, 30);
            lbl_price_nh.Name = "lbl_price_nh";
            lbl_price_nh.Size = new Size(47, 30);
            lbl_price_nh.TabIndex = 0;
            lbl_price_nh.Text = "Prix";
            // 
            // cmb_shortlong_nh
            // 
            cmb_shortlong_nh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_shortlong_nh.Font = new Font("Segoe UI", 18F);
            cmb_shortlong_nh.FormattingEnabled = true;
            cmb_shortlong_nh.Items.AddRange(new object[] { "Cheveux court", "Cheveux long" });
            cmb_shortlong_nh.Location = new Point(217, 399);
            cmb_shortlong_nh.MaximumSize = new Size(302, 0);
            cmb_shortlong_nh.MinimumSize = new Size(302, 0);
            cmb_shortlong_nh.Name = "cmb_shortlong_nh";
            cmb_shortlong_nh.Size = new Size(302, 40);
            cmb_shortlong_nh.TabIndex = 4;
            // 
            // txb_price_nh
            // 
            txb_price_nh.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_price_nh.Location = new Point(217, 445);
            txb_price_nh.MaximumSize = new Size(302, 40);
            txb_price_nh.MinimumSize = new Size(302, 40);
            txb_price_nh.Name = "txb_price_nh";
            txb_price_nh.Size = new Size(302, 39);
            txb_price_nh.TabIndex = 5;
            // 
            // cmb_cutingtime_nh
            // 
            cmb_cutingtime_nh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_cutingtime_nh.Font = new Font("Segoe UI", 18F);
            cmb_cutingtime_nh.FormattingEnabled = true;
            cmb_cutingtime_nh.Items.AddRange(new object[] { "  30 min" });
            cmb_cutingtime_nh.Location = new Point(217, 355);
            cmb_cutingtime_nh.MaximumSize = new Size(302, 0);
            cmb_cutingtime_nh.MinimumSize = new Size(302, 0);
            cmb_cutingtime_nh.Name = "cmb_cutingtime_nh";
            cmb_cutingtime_nh.Size = new Size(302, 40);
            cmb_cutingtime_nh.TabIndex = 3;
            // 
            // FrmNewHaircut
            // 
            AcceptButton = btn_add_nh;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_quite_nh;
            ClientSize = new Size(744, 499);
            Controls.Add(cmb_cutingtime_nh);
            Controls.Add(txb_price_nh);
            Controls.Add(cmb_shortlong_nh);
            Controls.Add(lbl_price_nh);
            Controls.Add(lbl_shortlong_nh);
            Controls.Add(lbl_cutingtime_nh);
            Controls.Add(txb_description_nh);
            Controls.Add(lbl_description_nh);
            Controls.Add(txb_name_nh);
            Controls.Add(lbl_name_nh);
            Controls.Add(btn_photo_nh);
            Controls.Add(btn_quite_nh);
            Controls.Add(btn_add_nh);
            Controls.Add(lbl_newhaircut_nh);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(760, 538);
            MinimizeBox = false;
            MinimumSize = new Size(760, 538);
            Name = "FrmNewHaircut";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nouvelle coupe de cheveux";
            Load += FrmNewHaircut_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_newhaircut_nh;
        private Button btn_quite_nh;
        private Button btn_add_nh;
        private Button btn_photo_nh;
        private TextBox txb_name_nh;
        private Label lbl_name_nh;
        private Label lbl_description_nh;
        private RichTextBox txb_description_nh;
        private Label lbl_cutingtime_nh;
        private Label lbl_shortlong_nh;
        private Label lbl_price_nh;
        private ComboBox cmb_shortlong_nh;
        private TextBox txb_price_nh;
        private ComboBox cmb_cutingtime_nh;
    }
}
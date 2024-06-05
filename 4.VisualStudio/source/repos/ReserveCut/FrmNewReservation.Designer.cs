namespace ReserveCut
{
    partial class FrmNewReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewReservation));
            btn_quite_nr = new Button();
            btn_add_nr = new Button();
            lbl_newreservation_nr = new Label();
            dtp_reservationdate_nr = new DateTimePicker();
            lbl_reservationdate_nr = new Label();
            lbl_time_nr = new Label();
            lbl_customer_nr = new Label();
            lbl_stylist_nr = new Label();
            lbl_comments_nr = new Label();
            lbl_beard_nr = new Label();
            lbl_shampoo_nr = new Label();
            cmb_time_nr = new ComboBox();
            cmb_customer_nr = new ComboBox();
            cmb_styliste_nr = new ComboBox();
            rdo_yes_shampoo_nr = new RadioButton();
            rdo_no_shampoo_nr = new RadioButton();
            btn_addcustomer_nr = new Button();
            txb_comments_nr = new RichTextBox();
            pnl_shampoo_nr = new Panel();
            pnl_beard_nr = new Panel();
            rdo_no_beard_nr = new RadioButton();
            rdo_yes_beard_nr = new RadioButton();
            pnl_shampoo_nr.SuspendLayout();
            pnl_beard_nr.SuspendLayout();
            SuspendLayout();
            // 
            // btn_quite_nr
            // 
            btn_quite_nr.BackColor = SystemColors.Window;
            btn_quite_nr.Font = new Font("Segoe UI", 13.8F);
            btn_quite_nr.Location = new Point(562, 448);
            btn_quite_nr.MaximumSize = new Size(147, 35);
            btn_quite_nr.MinimumSize = new Size(147, 35);
            btn_quite_nr.Name = "btn_quite_nr";
            btn_quite_nr.Size = new Size(147, 35);
            btn_quite_nr.TabIndex = 14;
            btn_quite_nr.Text = "Fermer";
            btn_quite_nr.UseVisualStyleBackColor = false;
            btn_quite_nr.Click += btn_cancel_nr_Click;
            // 
            // btn_add_nr
            // 
            btn_add_nr.BackColor = Color.Honeydew;
            btn_add_nr.Font = new Font("Segoe UI", 13.8F);
            btn_add_nr.Location = new Point(562, 403);
            btn_add_nr.MaximumSize = new Size(147, 35);
            btn_add_nr.MinimumSize = new Size(147, 35);
            btn_add_nr.Name = "btn_add_nr";
            btn_add_nr.Size = new Size(147, 35);
            btn_add_nr.TabIndex = 13;
            btn_add_nr.Text = "Ajouter";
            btn_add_nr.UseVisualStyleBackColor = false;
            btn_add_nr.Click += btn_add_nr_Click;
            // 
            // lbl_newreservation_nr
            // 
            lbl_newreservation_nr.AutoSize = true;
            lbl_newreservation_nr.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newreservation_nr.Location = new Point(216, 16);
            lbl_newreservation_nr.MaximumSize = new Size(312, 45);
            lbl_newreservation_nr.MinimumSize = new Size(312, 45);
            lbl_newreservation_nr.Name = "lbl_newreservation_nr";
            lbl_newreservation_nr.Size = new Size(312, 45);
            lbl_newreservation_nr.TabIndex = 0;
            lbl_newreservation_nr.Text = "Nouvelle réservation";
            // 
            // dtp_reservationdate_nr
            // 
            dtp_reservationdate_nr.CalendarFont = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_reservationdate_nr.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_reservationdate_nr.Format = DateTimePickerFormat.Short;
            dtp_reservationdate_nr.Location = new Point(217, 85);
            dtp_reservationdate_nr.Margin = new Padding(3, 2, 3, 2);
            dtp_reservationdate_nr.MaximumSize = new Size(302, 40);
            dtp_reservationdate_nr.MinimumSize = new Size(302, 40);
            dtp_reservationdate_nr.Name = "dtp_reservationdate_nr";
            dtp_reservationdate_nr.Size = new Size(302, 40);
            dtp_reservationdate_nr.TabIndex = 1;
            // 
            // lbl_reservationdate_nr
            // 
            lbl_reservationdate_nr.AutoSize = true;
            lbl_reservationdate_nr.Font = new Font("Segoe UI", 18F);
            lbl_reservationdate_nr.Location = new Point(35, 85);
            lbl_reservationdate_nr.MaximumSize = new Size(64, 32);
            lbl_reservationdate_nr.MinimumSize = new Size(64, 32);
            lbl_reservationdate_nr.Name = "lbl_reservationdate_nr";
            lbl_reservationdate_nr.Size = new Size(64, 32);
            lbl_reservationdate_nr.TabIndex = 0;
            lbl_reservationdate_nr.Text = "Date";
            // 
            // lbl_time_nr
            // 
            lbl_time_nr.AutoSize = true;
            lbl_time_nr.Font = new Font("Segoe UI", 18F);
            lbl_time_nr.Location = new Point(35, 129);
            lbl_time_nr.MaximumSize = new Size(79, 32);
            lbl_time_nr.MinimumSize = new Size(79, 32);
            lbl_time_nr.Name = "lbl_time_nr";
            lbl_time_nr.Size = new Size(79, 32);
            lbl_time_nr.TabIndex = 0;
            lbl_time_nr.Text = "Heure";
            // 
            // lbl_customer_nr
            // 
            lbl_customer_nr.AutoSize = true;
            lbl_customer_nr.Font = new Font("Segoe UI", 18F);
            lbl_customer_nr.Location = new Point(35, 175);
            lbl_customer_nr.MaximumSize = new Size(76, 32);
            lbl_customer_nr.MinimumSize = new Size(76, 32);
            lbl_customer_nr.Name = "lbl_customer_nr";
            lbl_customer_nr.Size = new Size(76, 32);
            lbl_customer_nr.TabIndex = 0;
            lbl_customer_nr.Text = "Client";
            // 
            // lbl_stylist_nr
            // 
            lbl_stylist_nr.AutoSize = true;
            lbl_stylist_nr.Font = new Font("Segoe UI", 18F);
            lbl_stylist_nr.Location = new Point(35, 219);
            lbl_stylist_nr.MaximumSize = new Size(100, 32);
            lbl_stylist_nr.MinimumSize = new Size(100, 32);
            lbl_stylist_nr.Name = "lbl_stylist_nr";
            lbl_stylist_nr.Size = new Size(100, 32);
            lbl_stylist_nr.TabIndex = 0;
            lbl_stylist_nr.Text = "Coiffeur";
            // 
            // lbl_comments_nr
            // 
            lbl_comments_nr.AutoSize = true;
            lbl_comments_nr.Font = new Font("Segoe UI", 18F);
            lbl_comments_nr.Location = new Point(35, 355);
            lbl_comments_nr.MaximumSize = new Size(159, 32);
            lbl_comments_nr.MinimumSize = new Size(159, 32);
            lbl_comments_nr.Name = "lbl_comments_nr";
            lbl_comments_nr.Size = new Size(159, 32);
            lbl_comments_nr.TabIndex = 0;
            lbl_comments_nr.Text = "Commentaire";
            // 
            // lbl_beard_nr
            // 
            lbl_beard_nr.AutoSize = true;
            lbl_beard_nr.Font = new Font("Segoe UI", 18F);
            lbl_beard_nr.Location = new Point(35, 309);
            lbl_beard_nr.MaximumSize = new Size(75, 32);
            lbl_beard_nr.MinimumSize = new Size(75, 32);
            lbl_beard_nr.Name = "lbl_beard_nr";
            lbl_beard_nr.Size = new Size(75, 32);
            lbl_beard_nr.TabIndex = 0;
            lbl_beard_nr.Text = "Barbe";
            // 
            // lbl_shampoo_nr
            // 
            lbl_shampoo_nr.AutoSize = true;
            lbl_shampoo_nr.Font = new Font("Segoe UI", 18F);
            lbl_shampoo_nr.Location = new Point(35, 265);
            lbl_shampoo_nr.MaximumSize = new Size(136, 32);
            lbl_shampoo_nr.MinimumSize = new Size(136, 32);
            lbl_shampoo_nr.Name = "lbl_shampoo_nr";
            lbl_shampoo_nr.Size = new Size(136, 32);
            lbl_shampoo_nr.TabIndex = 0;
            lbl_shampoo_nr.Text = "Shampoing";
            // 
            // cmb_time_nr
            // 
            cmb_time_nr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_time_nr.Font = new Font("Segoe UI", 18F);
            cmb_time_nr.FormattingEnabled = true;
            cmb_time_nr.Items.AddRange(new object[] { "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30" });
            cmb_time_nr.Location = new Point(217, 129);
            cmb_time_nr.Margin = new Padding(3, 2, 3, 2);
            cmb_time_nr.MaximumSize = new Size(302, 0);
            cmb_time_nr.MinimumSize = new Size(302, 0);
            cmb_time_nr.Name = "cmb_time_nr";
            cmb_time_nr.Size = new Size(302, 40);
            cmb_time_nr.TabIndex = 2;
            // 
            // cmb_customer_nr
            // 
            cmb_customer_nr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_customer_nr.Font = new Font("Segoe UI", 18F);
            cmb_customer_nr.FormattingEnabled = true;
            cmb_customer_nr.Location = new Point(217, 175);
            cmb_customer_nr.Margin = new Padding(3, 2, 3, 2);
            cmb_customer_nr.MaximumSize = new Size(302, 0);
            cmb_customer_nr.MinimumSize = new Size(302, 0);
            cmb_customer_nr.Name = "cmb_customer_nr";
            cmb_customer_nr.Size = new Size(302, 40);
            cmb_customer_nr.TabIndex = 3;
            // 
            // cmb_styliste_nr
            // 
            cmb_styliste_nr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_styliste_nr.Font = new Font("Segoe UI", 18F);
            cmb_styliste_nr.FormattingEnabled = true;
            cmb_styliste_nr.Location = new Point(217, 219);
            cmb_styliste_nr.Margin = new Padding(3, 2, 3, 2);
            cmb_styliste_nr.MaximumSize = new Size(302, 0);
            cmb_styliste_nr.MinimumSize = new Size(302, 0);
            cmb_styliste_nr.Name = "cmb_styliste_nr";
            cmb_styliste_nr.Size = new Size(302, 40);
            cmb_styliste_nr.TabIndex = 4;
            // 
            // rdo_yes_shampoo_nr
            // 
            rdo_yes_shampoo_nr.AutoSize = true;
            rdo_yes_shampoo_nr.Font = new Font("Segoe UI", 13.8F);
            rdo_yes_shampoo_nr.Location = new Point(5, 0);
            rdo_yes_shampoo_nr.Margin = new Padding(3, 2, 3, 2);
            rdo_yes_shampoo_nr.MaximumSize = new Size(66, 29);
            rdo_yes_shampoo_nr.MinimumSize = new Size(66, 29);
            rdo_yes_shampoo_nr.Name = "rdo_yes_shampoo_nr";
            rdo_yes_shampoo_nr.Size = new Size(66, 29);
            rdo_yes_shampoo_nr.TabIndex = 6;
            rdo_yes_shampoo_nr.TabStop = true;
            rdo_yes_shampoo_nr.Tag = "";
            rdo_yes_shampoo_nr.Text = "Oui";
            rdo_yes_shampoo_nr.UseVisualStyleBackColor = true;
            // 
            // rdo_no_shampoo_nr
            // 
            rdo_no_shampoo_nr.AutoSize = true;
            rdo_no_shampoo_nr.Font = new Font("Segoe UI", 13.8F);
            rdo_no_shampoo_nr.Location = new Point(77, 0);
            rdo_no_shampoo_nr.Margin = new Padding(3, 2, 3, 2);
            rdo_no_shampoo_nr.MaximumSize = new Size(66, 29);
            rdo_no_shampoo_nr.MinimumSize = new Size(66, 29);
            rdo_no_shampoo_nr.Name = "rdo_no_shampoo_nr";
            rdo_no_shampoo_nr.Size = new Size(66, 29);
            rdo_no_shampoo_nr.TabIndex = 7;
            rdo_no_shampoo_nr.TabStop = true;
            rdo_no_shampoo_nr.Tag = "";
            rdo_no_shampoo_nr.Text = "Non";
            rdo_no_shampoo_nr.UseVisualStyleBackColor = true;
            // 
            // btn_addcustomer_nr
            // 
            btn_addcustomer_nr.BackColor = SystemColors.Window;
            btn_addcustomer_nr.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_addcustomer_nr.ForeColor = SystemColors.ControlText;
            btn_addcustomer_nr.Location = new Point(562, 177);
            btn_addcustomer_nr.Margin = new Padding(3, 2, 3, 2);
            btn_addcustomer_nr.MaximumSize = new Size(147, 35);
            btn_addcustomer_nr.MinimumSize = new Size(147, 35);
            btn_addcustomer_nr.Name = "btn_addcustomer_nr";
            btn_addcustomer_nr.Size = new Size(147, 35);
            btn_addcustomer_nr.TabIndex = 12;
            btn_addcustomer_nr.Text = "Nouveau client";
            btn_addcustomer_nr.UseVisualStyleBackColor = false;
            btn_addcustomer_nr.Click += btn_addcustomer_nr_Click;
            // 
            // txb_comments_nr
            // 
            txb_comments_nr.BackColor = SystemColors.Window;
            txb_comments_nr.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_comments_nr.Location = new Point(217, 355);
            txb_comments_nr.MaximumSize = new Size(302, 126);
            txb_comments_nr.MinimumSize = new Size(302, 126);
            txb_comments_nr.Name = "txb_comments_nr";
            txb_comments_nr.Size = new Size(302, 126);
            txb_comments_nr.TabIndex = 11;
            txb_comments_nr.Text = "";
            // 
            // pnl_shampoo_nr
            // 
            pnl_shampoo_nr.Controls.Add(rdo_yes_shampoo_nr);
            pnl_shampoo_nr.Controls.Add(rdo_no_shampoo_nr);
            pnl_shampoo_nr.Location = new Point(217, 265);
            pnl_shampoo_nr.Margin = new Padding(3, 2, 3, 2);
            pnl_shampoo_nr.MaximumSize = new Size(150, 32);
            pnl_shampoo_nr.MinimumSize = new Size(150, 32);
            pnl_shampoo_nr.Name = "pnl_shampoo_nr";
            pnl_shampoo_nr.Size = new Size(150, 32);
            pnl_shampoo_nr.TabIndex = 5;
            // 
            // pnl_beard_nr
            // 
            pnl_beard_nr.Controls.Add(rdo_no_beard_nr);
            pnl_beard_nr.Controls.Add(rdo_yes_beard_nr);
            pnl_beard_nr.Location = new Point(217, 309);
            pnl_beard_nr.Margin = new Padding(3, 2, 3, 2);
            pnl_beard_nr.MaximumSize = new Size(150, 30);
            pnl_beard_nr.MinimumSize = new Size(150, 30);
            pnl_beard_nr.Name = "pnl_beard_nr";
            pnl_beard_nr.Size = new Size(150, 30);
            pnl_beard_nr.TabIndex = 8;
            // 
            // rdo_no_beard_nr
            // 
            rdo_no_beard_nr.AutoSize = true;
            rdo_no_beard_nr.Font = new Font("Segoe UI", 13.8F);
            rdo_no_beard_nr.Location = new Point(77, 0);
            rdo_no_beard_nr.Margin = new Padding(3, 2, 3, 2);
            rdo_no_beard_nr.MaximumSize = new Size(66, 29);
            rdo_no_beard_nr.MinimumSize = new Size(66, 29);
            rdo_no_beard_nr.Name = "rdo_no_beard_nr";
            rdo_no_beard_nr.Size = new Size(66, 29);
            rdo_no_beard_nr.TabIndex = 10;
            rdo_no_beard_nr.TabStop = true;
            rdo_no_beard_nr.Tag = "";
            rdo_no_beard_nr.Text = "Non";
            rdo_no_beard_nr.UseVisualStyleBackColor = true;
            // 
            // rdo_yes_beard_nr
            // 
            rdo_yes_beard_nr.AutoSize = true;
            rdo_yes_beard_nr.Font = new Font("Segoe UI", 13.8F);
            rdo_yes_beard_nr.Location = new Point(5, 0);
            rdo_yes_beard_nr.Margin = new Padding(3, 2, 3, 2);
            rdo_yes_beard_nr.MaximumSize = new Size(66, 29);
            rdo_yes_beard_nr.MinimumSize = new Size(66, 29);
            rdo_yes_beard_nr.Name = "rdo_yes_beard_nr";
            rdo_yes_beard_nr.Size = new Size(66, 29);
            rdo_yes_beard_nr.TabIndex = 9;
            rdo_yes_beard_nr.TabStop = true;
            rdo_yes_beard_nr.Tag = "";
            rdo_yes_beard_nr.Text = "Oui";
            rdo_yes_beard_nr.UseVisualStyleBackColor = true;
            // 
            // FrmNewReservation
            // 
            AcceptButton = btn_add_nr;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = btn_quite_nr;
            ClientSize = new Size(744, 499);
            Controls.Add(pnl_beard_nr);
            Controls.Add(pnl_shampoo_nr);
            Controls.Add(txb_comments_nr);
            Controls.Add(btn_addcustomer_nr);
            Controls.Add(cmb_styliste_nr);
            Controls.Add(cmb_customer_nr);
            Controls.Add(cmb_time_nr);
            Controls.Add(lbl_shampoo_nr);
            Controls.Add(lbl_beard_nr);
            Controls.Add(lbl_comments_nr);
            Controls.Add(lbl_stylist_nr);
            Controls.Add(lbl_customer_nr);
            Controls.Add(lbl_time_nr);
            Controls.Add(lbl_reservationdate_nr);
            Controls.Add(dtp_reservationdate_nr);
            Controls.Add(lbl_newreservation_nr);
            Controls.Add(btn_quite_nr);
            Controls.Add(btn_add_nr);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(760, 538);
            MinimizeBox = false;
            MinimumSize = new Size(760, 538);
            Name = "FrmNewReservation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nouvelle réservation";
            Load += FrmNewReservation_Load;
            pnl_shampoo_nr.ResumeLayout(false);
            pnl_shampoo_nr.PerformLayout();
            pnl_beard_nr.ResumeLayout(false);
            pnl_beard_nr.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_quite_nr;
        private Button btn_add_nr;
        private Label lbl_newreservation_nr;
        private DateTimePicker dtp_reservationdate_nr;
        private Label lbl_reservationdate_nr;
        private Label lbl_time_nr;
        private Label lbl_customer_nr;
        private Label lbl_stylist_nr;
        private Label lbl_comments_nr;
        private Label lbl_beard_nr;
        private Label lbl_shampoo_nr;
        private ComboBox cmb_time_nr;
        private ComboBox cmb_customer_nr;
        private ComboBox cmb_styliste_nr;
        private RadioButton rdo_yes_shampoo_nr;
        private RadioButton rdo_no_shampoo_nr;
        private Button btn_addcustomer_nr;
        private RichTextBox txb_comments_nr;
        private Panel pnl_shampoo_nr;
        private Panel pnl_beard_nr;
        private RadioButton rdo_no_beard_nr;
        private RadioButton rdo_yes_beard_nr;
    }
}
namespace Agenda.WinForms
{
    partial class Insert
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
            btnInsert = new Button();
            btnCancel = new Button();
            txtComment = new TextBox();
            lblComment = new Label();
            lblType = new Label();
            cmbType = new ComboBox();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            SuspendLayout();
            // 
            // btnInsert
            // 
            btnInsert.Anchor = AnchorStyles.Bottom;
            btnInsert.BackColor = Color.WhiteSmoke;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Location = new Point(42, 284);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(125, 40);
            btnInsert.TabIndex = 0;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(173, 284);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Location = new Point(12, 82);
            txtComment.MaxLength = 50;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(314, 27);
            txtComment.TabIndex = 2;
            // 
            // lblComment
            // 
            lblComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComment.Location = new Point(12, 59);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(78, 20);
            lblComment.TabIndex = 3;
            lblComment.Text = "Comment";
            // 
            // lblType
            // 
            lblType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblType.Location = new Point(12, 132);
            lblType.Name = "lblType";
            lblType.Size = new Size(42, 20);
            lblType.TabIndex = 4;
            lblType.Text = "Type";
            // 
            // cmbType
            // 
            cmbType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(12, 155);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(314, 28);
            cmbType.TabIndex = 5;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDate.Location = new Point(12, 206);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(42, 20);
            lblDate.TabIndex = 6;
            lblDate.Text = "Date";
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(12, 229);
            dtpDate.MaxDate = new DateTime(2035, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(314, 27);
            dtpDate.TabIndex = 7;
            dtpDate.Value = new DateTime(2026, 3, 11, 8, 59, 29, 0);
            // 
            // Insert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(338, 377);
            ControlBox = false;
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(lblComment);
            Controls.Add(txtComment);
            Controls.Add(btnCancel);
            Controls.Add(btnInsert);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Insert";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsert;
        private Button btnCancel;
        private TextBox txtComment;
        private Label lblComment;
        private Label lblType;
        private ComboBox cmbType;
        private Label lblDate;
        private DateTimePicker dtpDate;
    }
}
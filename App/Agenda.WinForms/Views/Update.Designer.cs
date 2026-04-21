namespace Agenda.WinForms
{
    partial class Update
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
            dtpDate = new DateTimePicker();
            lblDate = new Label();
            cmbType = new ComboBox();
            lblType = new Label();
            lblId = new Label();
            txtId = new TextBox();
            btnCancel = new Button();
            btnUpdate = new Button();
            lblComment = new Label();
            txtComment = new TextBox();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(12, 294);
            dtpDate.MaxDate = new DateTime(2035, 12, 31, 0, 0, 0, 0);
            dtpDate.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(314, 27);
            dtpDate.TabIndex = 15;
            dtpDate.Value = new DateTime(2026, 3, 11, 8, 59, 29, 0);
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDate.Location = new Point(12, 271);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(42, 20);
            lblDate.TabIndex = 14;
            lblDate.Text = "Date";
            // 
            // cmbType
            // 
            cmbType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(12, 220);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(314, 28);
            cmbType.TabIndex = 13;
            // 
            // lblType
            // 
            lblType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblType.Location = new Point(12, 197);
            lblType.Name = "lblType";
            lblType.Size = new Size(42, 20);
            lblType.TabIndex = 12;
            lblType.Text = "Type";
            // 
            // lblId
            // 
            lblId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblId.Location = new Point(12, 51);
            lblId.Name = "lblId";
            lblId.Size = new Size(23, 20);
            lblId.TabIndex = 11;
            lblId.Text = "Id";
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(12, 74);
            txtId.MaxLength = 100;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(314, 27);
            txtId.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(173, 351);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 40);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Bottom;
            btnUpdate.BackColor = Color.WhiteSmoke;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(42, 351);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(125, 40);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // lblComment
            // 
            lblComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblComment.AutoSize = true;
            lblComment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblComment.Location = new Point(12, 124);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(78, 20);
            lblComment.TabIndex = 17;
            lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            txtComment.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            txtComment.Location = new Point(12, 147);
            txtComment.MaxLength = 50;
            txtComment.Name = "txtComment";
            txtComment.Size = new Size(314, 27);
            txtComment.TabIndex = 16;
            // 
            // Update
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(338, 444);
            ControlBox = false;
            Controls.Add(lblComment);
            Controls.Add(txtComment);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Update";
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Label lblDate;
        private ComboBox cmbType;
        private Label lblType;
        private Label lblId;
        private TextBox txtId;
        private Button btnCancel;
        private Button btnUpdate;
        private Label lblComment;
        private TextBox txtComment;
    }
}
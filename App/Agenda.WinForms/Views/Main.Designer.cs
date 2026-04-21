namespace Agenda.WinForms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlActions = new Panel();
            btnCancel = new Button();
            btnExit = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            btnDelete = new Button();
            btnGet = new Button();
            dgvAll = new DataGridView();
            tacAppointments = new TabControl();
            tapAll = new TabPage();
            tapCurrent = new TabPage();
            dgvCurrent = new DataGridView();
            tapExpired = new TabPage();
            dgvExpired = new DataGridView();
            pnlActions.SuspendLayout();
            ((ISupportInitialize)dgvAll).BeginInit();
            tacAppointments.SuspendLayout();
            tapAll.SuspendLayout();
            tapCurrent.SuspendLayout();
            ((ISupportInitialize)dgvCurrent).BeginInit();
            tapExpired.SuspendLayout();
            ((ISupportInitialize)dgvExpired).BeginInit();
            SuspendLayout();
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.LightGray;
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Controls.Add(btnExit);
            pnlActions.Controls.Add(btnUpdate);
            pnlActions.Controls.Add(btnInsert);
            pnlActions.Controls.Add(btnDelete);
            pnlActions.Controls.Add(btnGet);
            pnlActions.Dock = DockStyle.Right;
            pnlActions.Location = new Point(1076, 0);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(186, 673);
            pnlActions.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(6, 616);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 45);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnExit.BackColor = Color.WhiteSmoke;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(6, 216);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(175, 45);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnUpdate.BackColor = Color.WhiteSmoke;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(6, 165);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(175, 45);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnInsert
            // 
            btnInsert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInsert.BackColor = Color.WhiteSmoke;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Location = new Point(6, 114);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(175, 45);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDelete.BackColor = Color.WhiteSmoke;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(6, 63);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(175, 45);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnGet
            // 
            btnGet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGet.BackColor = Color.WhiteSmoke;
            btnGet.FlatStyle = FlatStyle.Flat;
            btnGet.Location = new Point(6, 12);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(175, 45);
            btnGet.TabIndex = 0;
            btnGet.Text = "Get";
            btnGet.UseVisualStyleBackColor = false;
            btnGet.Click += btnGet_Click;
            // 
            // dgvAll
            // 
            dgvAll.AllowUserToAddRows = false;
            dgvAll.AllowUserToDeleteRows = false;
            dgvAll.AllowUserToResizeColumns = false;
            dgvAll.AllowUserToResizeRows = false;
            dgvAll.BackgroundColor = Color.WhiteSmoke;
            dgvAll.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvAll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAll.Dock = DockStyle.Fill;
            dgvAll.Location = new Point(3, 3);
            dgvAll.MultiSelect = false;
            dgvAll.Name = "dgvAll";
            dgvAll.RightToLeft = RightToLeft.No;
            dgvAll.RowHeadersWidth = 51;
            dgvAll.Size = new Size(1062, 634);
            dgvAll.TabIndex = 1;
            // 
            // tacAppointments
            // 
            tacAppointments.Controls.Add(tapAll);
            tacAppointments.Controls.Add(tapCurrent);
            tacAppointments.Controls.Add(tapExpired);
            tacAppointments.Dock = DockStyle.Fill;
            tacAppointments.Location = new Point(0, 0);
            tacAppointments.Name = "tacAppointments";
            tacAppointments.SelectedIndex = 0;
            tacAppointments.Size = new Size(1076, 673);
            tacAppointments.TabIndex = 2;
            tacAppointments.SelectedIndexChanged += tacAppointments_SelectedIndexChanged;
            // 
            // tapAll
            // 
            tapAll.Controls.Add(dgvAll);
            tapAll.Location = new Point(4, 29);
            tapAll.Name = "tapAll";
            tapAll.Padding = new Padding(3);
            tapAll.Size = new Size(1068, 640);
            tapAll.TabIndex = 0;
            tapAll.Text = "All";
            tapAll.UseVisualStyleBackColor = true;
            // 
            // tapCurrent
            // 
            tapCurrent.Controls.Add(dgvCurrent);
            tapCurrent.Location = new Point(4, 29);
            tapCurrent.Name = "tapCurrent";
            tapCurrent.Padding = new Padding(3);
            tapCurrent.Size = new Size(1068, 640);
            tapCurrent.TabIndex = 1;
            tapCurrent.Text = "Current";
            tapCurrent.UseVisualStyleBackColor = true;
            // 
            // dgvCurrent
            // 
            dgvCurrent.AllowUserToAddRows = false;
            dgvCurrent.AllowUserToDeleteRows = false;
            dgvCurrent.AllowUserToResizeColumns = false;
            dgvCurrent.AllowUserToResizeRows = false;
            dgvCurrent.BackgroundColor = Color.WhiteSmoke;
            dgvCurrent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvCurrent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrent.Dock = DockStyle.Fill;
            dgvCurrent.Location = new Point(3, 3);
            dgvCurrent.MultiSelect = false;
            dgvCurrent.Name = "dgvCurrent";
            dgvCurrent.RightToLeft = RightToLeft.No;
            dgvCurrent.RowHeadersWidth = 51;
            dgvCurrent.Size = new Size(1062, 634);
            dgvCurrent.TabIndex = 2;
            // 
            // tapExpired
            // 
            tapExpired.Controls.Add(dgvExpired);
            tapExpired.Location = new Point(4, 29);
            tapExpired.Name = "tapExpired";
            tapExpired.Padding = new Padding(3);
            tapExpired.Size = new Size(1068, 640);
            tapExpired.TabIndex = 2;
            tapExpired.Text = "Expired";
            tapExpired.UseVisualStyleBackColor = true;
            // 
            // dgvExpired
            // 
            dgvExpired.AllowUserToAddRows = false;
            dgvExpired.AllowUserToDeleteRows = false;
            dgvExpired.AllowUserToResizeColumns = false;
            dgvExpired.AllowUserToResizeRows = false;
            dgvExpired.BackgroundColor = Color.WhiteSmoke;
            dgvExpired.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvExpired.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExpired.Dock = DockStyle.Fill;
            dgvExpired.Location = new Point(3, 3);
            dgvExpired.MultiSelect = false;
            dgvExpired.Name = "dgvExpired";
            dgvExpired.RightToLeft = RightToLeft.No;
            dgvExpired.RowHeadersWidth = 51;
            dgvExpired.Size = new Size(1062, 634);
            dgvExpired.TabIndex = 3;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1262, 673);
            Controls.Add(tacAppointments);
            Controls.Add(pnlActions);
            Name = "Main";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            WindowState = FormWindowState.Maximized;
            pnlActions.ResumeLayout(false);
            ((ISupportInitialize)dgvAll).EndInit();
            tacAppointments.ResumeLayout(false);
            tapAll.ResumeLayout(false);
            tapCurrent.ResumeLayout(false);
            ((ISupportInitialize)dgvCurrent).EndInit();
            tapExpired.ResumeLayout(false);
            ((ISupportInitialize)dgvExpired).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlActions;
        private DataGridView dgvAll;
        private Button btnGet;
        private Button btnDelete;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnExit;
        private TabControl tacAppointments;
        private TabPage tapAll;
        private TabPage tapCurrent;
        private TabPage tapExpired;
        private DataGridView dgvCurrent;
        private DataGridView dgvExpired;
        private Button btnCancel;
    }
}

namespace Agenda.WinForms
{
    partial class CustomDialog
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
            btnOk = new Button();
            btnCancel = new Button();
            rtbMessage = new RichTextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.BackColor = Color.WhiteSmoke;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Location = new Point(91, 197);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(125, 40);
            btnOk.TabIndex = 0;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom;
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(222, 197);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // rtbMessage
            // 
            rtbMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbMessage.BackColor = Color.WhiteSmoke;
            rtbMessage.BorderStyle = BorderStyle.FixedSingle;
            rtbMessage.Location = new Point(12, 12);
            rtbMessage.Name = "rtbMessage";
            rtbMessage.ReadOnly = true;
            rtbMessage.Size = new Size(415, 179);
            rtbMessage.TabIndex = 2;
            rtbMessage.Text = "";
            // 
            // CustomDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(439, 239);
            ControlBox = false;
            Controls.Add(rtbMessage);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomDialog";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
        }

        #endregion

        private Button btnOk;
        private Button btnCancel;
        private RichTextBox rtbMessage;
    }
}
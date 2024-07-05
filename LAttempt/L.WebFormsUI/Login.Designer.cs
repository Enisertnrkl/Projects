namespace L.WebFormsUI
{
    partial class Login
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
            label4 = new Label();
            tBPass = new TextBox();
            label1 = new Label();
            btnLog = new Button();
            tBUser = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(208, 130);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 17;
            label4.Text = "Password";
            // 
            // tBPass
            // 
            tBPass.Location = new Point(288, 130);
            tBPass.Name = "tBPass";
            tBPass.Size = new Size(195, 23);
            tBPass.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 69);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 12;
            label1.Text = "Username";
            // 
            // btnLog
            // 
            btnLog.Location = new Point(317, 213);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(147, 23);
            btnLog.TabIndex = 11;
            btnLog.Text = "Login";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += btnLog_Click;
            // 
            // tBUser
            // 
            tBUser.Location = new Point(288, 61);
            tBUser.Name = "tBUser";
            tBUser.Size = new Size(195, 23);
            tBUser.TabIndex = 9;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(tBPass);
            Controls.Add(label1);
            Controls.Add(btnLog);
            Controls.Add(tBUser);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox tBPass;
        private Label label1;
        private Button btnLog;
        private TextBox tBUser;
    }
}
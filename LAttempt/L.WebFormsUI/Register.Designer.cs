namespace L.WebFormsUI
{
    partial class Register
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
            tBUser = new TextBox();
            tBEmail = new TextBox();
            btnReg = new Button();
            label1 = new Label();
            label2 = new Label();
            tBPhone = new TextBox();
            tBPass = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btnGologin = new Button();
            SuspendLayout();
            // 
            // tBUser
            // 
            tBUser.Location = new Point(426, 36);
            tBUser.Name = "tBUser";
            tBUser.Size = new Size(195, 23);
            tBUser.TabIndex = 0;
            // 
            // tBEmail
            // 
            tBEmail.Location = new Point(426, 76);
            tBEmail.Name = "tBEmail";
            tBEmail.Size = new Size(195, 23);
            tBEmail.TabIndex = 1;
            // 
            // btnReg
            // 
            btnReg.Location = new Point(445, 233);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(147, 23);
            btnReg.TabIndex = 2;
            btnReg.Text = "Register";
            btnReg.UseVisualStyleBackColor = true;
            btnReg.Click += btnReg_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(343, 44);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(367, 84);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Email";
            // 
            // tBPhone
            // 
            tBPhone.Location = new Point(426, 122);
            tBPhone.Name = "tBPhone";
            tBPhone.Size = new Size(195, 23);
            tBPhone.TabIndex = 5;
            // 
            // tBPass
            // 
            tBPass.Location = new Point(426, 170);
            tBPass.Name = "tBPass";
            tBPass.Size = new Size(195, 23);
            tBPass.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 130);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 7;
            label3.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(346, 173);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 8;
            label4.Text = "Password";
            // 
            // btnGologin
            // 
            btnGologin.Location = new Point(932, 575);
            btnGologin.Name = "btnGologin";
            btnGologin.Size = new Size(239, 34);
            btnGologin.TabIndex = 9;
            btnGologin.Text = "I already have an account";
            btnGologin.UseVisualStyleBackColor = true;
            btnGologin.Click += btnGologin_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1207, 643);
            Controls.Add(btnGologin);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tBPass);
            Controls.Add(tBPhone);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnReg);
            Controls.Add(tBEmail);
            Controls.Add(tBUser);
            Name = "Register";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tBUser;
        private TextBox tBEmail;
        private Button btnReg;
        private Label label1;
        private Label label2;
        private TextBox tBPhone;
        private TextBox tBPass;
        private Label label3;
        private Label label4;
        private Button btnGologin;
    }
}
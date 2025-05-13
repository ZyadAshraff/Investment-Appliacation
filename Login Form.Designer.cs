namespace InvestApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.rb_Signup = new System.Windows.Forms.RadioButton();
            this.rb_Login = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_Login = new System.Windows.Forms.GroupBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.lb_Password = new System.Windows.Forms.Label();
            this.lb_Username = new System.Windows.Forms.Label();
            this.tb_Password_Login = new System.Windows.Forms.TextBox();
            this.tb_Username_Login = new System.Windows.Forms.TextBox();
            this.gb_Signup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Email_Signup = new System.Windows.Forms.TextBox();
            this.bt_Signup = new System.Windows.Forms.Button();
            this.tb_Username_Signup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Password_Signup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gb_Login.SuspendLayout();
            this.gb_Signup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To InvestApp";
            // 
            // rb_Signup
            // 
            this.rb_Signup.AutoSize = true;
            this.rb_Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Signup.Location = new System.Drawing.Point(37, 34);
            this.rb_Signup.Name = "rb_Signup";
            this.rb_Signup.Size = new System.Drawing.Size(100, 29);
            this.rb_Signup.TabIndex = 4;
            this.rb_Signup.TabStop = true;
            this.rb_Signup.Text = "Sign up";
            this.rb_Signup.UseVisualStyleBackColor = true;
            this.rb_Signup.CheckedChanged += new System.EventHandler(this.rb_Signup_CheckedChanged);
            // 
            // rb_Login
            // 
            this.rb_Login.AutoSize = true;
            this.rb_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Login.Location = new System.Drawing.Point(37, 78);
            this.rb_Login.Name = "rb_Login";
            this.rb_Login.Size = new System.Drawing.Size(86, 29);
            this.rb_Login.TabIndex = 5;
            this.rb_Login.TabStop = true;
            this.rb_Login.Text = "Log in";
            this.rb_Login.UseVisualStyleBackColor = true;
            this.rb_Login.CheckedChanged += new System.EventHandler(this.rb_Login_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Signup);
            this.groupBox1.Controls.Add(this.rb_Login);
            this.groupBox1.Location = new System.Drawing.Point(28, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 124);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login/SignUp";
            // 
            // gb_Login
            // 
            this.gb_Login.Controls.Add(this.bt_login);
            this.gb_Login.Controls.Add(this.lb_Password);
            this.gb_Login.Controls.Add(this.lb_Username);
            this.gb_Login.Controls.Add(this.tb_Password_Login);
            this.gb_Login.Controls.Add(this.tb_Username_Login);
            this.gb_Login.Enabled = false;
            this.gb_Login.Location = new System.Drawing.Point(496, 188);
            this.gb_Login.Name = "gb_Login";
            this.gb_Login.Size = new System.Drawing.Size(212, 243);
            this.gb_Login.TabIndex = 7;
            this.gb_Login.TabStop = false;
            this.gb_Login.Text = "Login";
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(67, 203);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(84, 34);
            this.bt_login.TabIndex = 4;
            this.bt_login.Text = "Login";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // lb_Password
            // 
            this.lb_Password.AutoSize = true;
            this.lb_Password.Location = new System.Drawing.Point(35, 108);
            this.lb_Password.Name = "lb_Password";
            this.lb_Password.Size = new System.Drawing.Size(67, 16);
            this.lb_Password.TabIndex = 3;
            this.lb_Password.Text = "Password";
            // 
            // lb_Username
            // 
            this.lb_Username.AutoSize = true;
            this.lb_Username.Location = new System.Drawing.Point(35, 47);
            this.lb_Username.Name = "lb_Username";
            this.lb_Username.Size = new System.Drawing.Size(76, 16);
            this.lb_Username.TabIndex = 2;
            this.lb_Username.Text = "User Name";
            // 
            // tb_Password_Login
            // 
            this.tb_Password_Login.Location = new System.Drawing.Point(35, 129);
            this.tb_Password_Login.Name = "tb_Password_Login";
            this.tb_Password_Login.Size = new System.Drawing.Size(153, 22);
            this.tb_Password_Login.TabIndex = 1;
            // 
            // tb_Username_Login
            // 
            this.tb_Username_Login.Location = new System.Drawing.Point(35, 69);
            this.tb_Username_Login.Name = "tb_Username_Login";
            this.tb_Username_Login.Size = new System.Drawing.Size(153, 22);
            this.tb_Username_Login.TabIndex = 0;
            // 
            // gb_Signup
            // 
            this.gb_Signup.Controls.Add(this.label4);
            this.gb_Signup.Controls.Add(this.tb_Email_Signup);
            this.gb_Signup.Controls.Add(this.bt_Signup);
            this.gb_Signup.Controls.Add(this.tb_Username_Signup);
            this.gb_Signup.Controls.Add(this.label2);
            this.gb_Signup.Controls.Add(this.tb_Password_Signup);
            this.gb_Signup.Controls.Add(this.label3);
            this.gb_Signup.Enabled = false;
            this.gb_Signup.Location = new System.Drawing.Point(295, 184);
            this.gb_Signup.Name = "gb_Signup";
            this.gb_Signup.Size = new System.Drawing.Size(218, 249);
            this.gb_Signup.TabIndex = 8;
            this.gb_Signup.TabStop = false;
            this.gb_Signup.Text = "Sign Up";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email";
            // 
            // tb_Email_Signup
            // 
            this.tb_Email_Signup.Location = new System.Drawing.Point(24, 165);
            this.tb_Email_Signup.Name = "tb_Email_Signup";
            this.tb_Email_Signup.Size = new System.Drawing.Size(153, 22);
            this.tb_Email_Signup.TabIndex = 10;
            // 
            // bt_Signup
            // 
            this.bt_Signup.Location = new System.Drawing.Point(54, 203);
            this.bt_Signup.Name = "bt_Signup";
            this.bt_Signup.Size = new System.Drawing.Size(84, 34);
            this.bt_Signup.TabIndex = 9;
            this.bt_Signup.Text = "Sign Up";
            this.bt_Signup.UseVisualStyleBackColor = true;
            this.bt_Signup.Click += new System.EventHandler(this.bt_Signup_Click);
            // 
            // tb_Username_Signup
            // 
            this.tb_Username_Signup.Location = new System.Drawing.Point(24, 53);
            this.tb_Username_Signup.Name = "tb_Username_Signup";
            this.tb_Username_Signup.Size = new System.Drawing.Size(153, 22);
            this.tb_Username_Signup.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // tb_Password_Signup
            // 
            this.tb_Password_Signup.Location = new System.Drawing.Point(24, 110);
            this.tb_Password_Signup.Name = "tb_Password_Signup";
            this.tb_Password_Signup.Size = new System.Drawing.Size(153, 22);
            this.tb_Password_Signup.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "User Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 531);
            this.Controls.Add(this.gb_Login);
            this.Controls.Add(this.gb_Signup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_Login.ResumeLayout(false);
            this.gb_Login.PerformLayout();
            this.gb_Signup.ResumeLayout(false);
            this.gb_Signup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_Signup;
        private System.Windows.Forms.RadioButton rb_Login;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gb_Login;
        private System.Windows.Forms.GroupBox gb_Signup;
        private System.Windows.Forms.TextBox tb_Username_Login;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Label lb_Password;
        private System.Windows.Forms.Label lb_Username;
        private System.Windows.Forms.TextBox tb_Password_Login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Email_Signup;
        private System.Windows.Forms.Button bt_Signup;
        private System.Windows.Forms.TextBox tb_Username_Signup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Password_Signup;
        private System.Windows.Forms.Label label3;
    }
}


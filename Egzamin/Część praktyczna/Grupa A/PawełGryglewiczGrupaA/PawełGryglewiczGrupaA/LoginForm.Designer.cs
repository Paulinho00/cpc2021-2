
namespace PawełGryglewiczGrupaA
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.LoginFieldLabel = new System.Windows.Forms.Label();
            this.PasswordFieldLabel = new System.Windows.Forms.Label();
            this.TimerInitButton = new System.Windows.Forms.Button();
            this.buttonTimer = new System.Windows.Forms.Timer(this.components);
            this.MovingButton = new System.Windows.Forms.Button();
            this.showRecordsButton = new System.Windows.Forms.Button();
            this.DataFromDBDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataFromDBDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(242, 111);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(100, 20);
            this.LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(242, 150);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextBox.TabIndex = 1;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(242, 204);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "A1 login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Location = new System.Drawing.Point(239, 259);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(66, 13);
            this.LoginLabel.TabIndex = 3;
            this.LoginLabel.Text = "Zalogowano";
            this.LoginLabel.Visible = false;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(327, 259);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(147, 13);
            this.ErrorLabel.TabIndex = 4;
            this.ErrorLabel.Text = "Wykorzystano limit liczby prób";
            this.ErrorLabel.Visible = false;
            // 
            // LoginFieldLabel
            // 
            this.LoginFieldLabel.AutoSize = true;
            this.LoginFieldLabel.Location = new System.Drawing.Point(203, 114);
            this.LoginFieldLabel.Name = "LoginFieldLabel";
            this.LoginFieldLabel.Size = new System.Drawing.Size(33, 13);
            this.LoginFieldLabel.TabIndex = 5;
            this.LoginFieldLabel.Text = "Login";
            // 
            // PasswordFieldLabel
            // 
            this.PasswordFieldLabel.AutoSize = true;
            this.PasswordFieldLabel.Location = new System.Drawing.Point(201, 153);
            this.PasswordFieldLabel.Name = "PasswordFieldLabel";
            this.PasswordFieldLabel.Size = new System.Drawing.Size(36, 13);
            this.PasswordFieldLabel.TabIndex = 6;
            this.PasswordFieldLabel.Text = "Hasło";
            // 
            // TimerInitButton
            // 
            this.TimerInitButton.Location = new System.Drawing.Point(242, 305);
            this.TimerInitButton.Name = "TimerInitButton";
            this.TimerInitButton.Size = new System.Drawing.Size(75, 23);
            this.TimerInitButton.TabIndex = 7;
            this.TimerInitButton.Text = "A2 Timer";
            this.TimerInitButton.UseVisualStyleBackColor = true;
            this.TimerInitButton.Click += new System.EventHandler(this.TimerInitButton_Click);
            // 
            // buttonTimer
            // 
            this.buttonTimer.Interval = 1500;
            this.buttonTimer.Tick += new System.EventHandler(this.buttonTimer_Tick);
            // 
            // MovingButton
            // 
            this.MovingButton.Location = new System.Drawing.Point(242, 346);
            this.MovingButton.Name = "MovingButton";
            this.MovingButton.Size = new System.Drawing.Size(75, 23);
            this.MovingButton.TabIndex = 8;
            this.MovingButton.Text = "Timer";
            this.MovingButton.UseVisualStyleBackColor = true;
            // 
            // showRecordsButton
            // 
            this.showRecordsButton.Location = new System.Drawing.Point(554, 346);
            this.showRecordsButton.Name = "showRecordsButton";
            this.showRecordsButton.Size = new System.Drawing.Size(122, 23);
            this.showRecordsButton.TabIndex = 9;
            this.showRecordsButton.Text = " A4 Get Clients";
            this.showRecordsButton.UseVisualStyleBackColor = true;
            this.showRecordsButton.Click += new System.EventHandler(this.showRecordsButton_Click);
            // 
            // DataFromDBDataGridView
            // 
            this.DataFromDBDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataFromDBDataGridView.Location = new System.Drawing.Point(520, 153);
            this.DataFromDBDataGridView.Name = "DataFromDBDataGridView";
            this.DataFromDBDataGridView.Size = new System.Drawing.Size(240, 150);
            this.DataFromDBDataGridView.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataFromDBDataGridView);
            this.Controls.Add(this.showRecordsButton);
            this.Controls.Add(this.MovingButton);
            this.Controls.Add(this.TimerInitButton);
            this.Controls.Add(this.PasswordFieldLabel);
            this.Controls.Add(this.LoginFieldLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.Name = "LoginForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataFromDBDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label LoginFieldLabel;
        private System.Windows.Forms.Label PasswordFieldLabel;
        private System.Windows.Forms.Button TimerInitButton;
        private System.Windows.Forms.Timer buttonTimer;
        private System.Windows.Forms.Button MovingButton;
        private System.Windows.Forms.Button showRecordsButton;
        private System.Windows.Forms.DataGridView DataFromDBDataGridView;
    }
}


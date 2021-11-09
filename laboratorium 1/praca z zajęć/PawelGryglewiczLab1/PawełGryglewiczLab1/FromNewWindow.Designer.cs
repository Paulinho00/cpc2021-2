
namespace PawełGryglewiczLab1
{
    partial class FromNewWindow
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
            this.buttonShowValue = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonShowValue
            // 
            this.buttonShowValue.Location = new System.Drawing.Point(204, 84);
            this.buttonShowValue.Name = "buttonShowValue";
            this.buttonShowValue.Size = new System.Drawing.Size(94, 39);
            this.buttonShowValue.TabIndex = 0;
            this.buttonShowValue.Text = "Wyświetl wartość";
            this.buttonShowValue.UseVisualStyleBackColor = true;
            this.buttonShowValue.Click += new System.EventHandler(this.buttonShowValue_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(208, 68);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(71, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Brak wartości";
            this.label.Click += new System.EventHandler(this.label1_Click);
            // 
            // FromNewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonShowValue);
            this.Name = "FromNewWindow";
            this.Text = "FormNewWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrommNewWindow_FromClosing);
            this.Load += new System.EventHandler(this.FormNewWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowValue;
        private System.Windows.Forms.Label label;
    }
}
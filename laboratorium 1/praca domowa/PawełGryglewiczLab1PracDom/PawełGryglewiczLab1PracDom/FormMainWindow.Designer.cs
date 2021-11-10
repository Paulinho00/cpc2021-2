
namespace PawełGryglewiczLab1PracDom
{
    partial class FormMainWindow
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
            this.groupBoxResources = new System.Windows.Forms.GroupBox();
            this.groupBoxWeapons = new System.Windows.Forms.GroupBox();
            this.groupBoxArmy = new System.Windows.Forms.GroupBox();
            this.groupBoxBuildings = new System.Windows.Forms.GroupBox();
            this.labelGoldAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupBoxResources
            // 
            this.groupBoxResources.Location = new System.Drawing.Point(12, 39);
            this.groupBoxResources.Name = "groupBoxResources";
            this.groupBoxResources.Size = new System.Drawing.Size(228, 97);
            this.groupBoxResources.TabIndex = 0;
            this.groupBoxResources.TabStop = false;
            this.groupBoxResources.Text = "Surowce";
            // 
            // groupBoxWeapons
            // 
            this.groupBoxWeapons.Location = new System.Drawing.Point(12, 160);
            this.groupBoxWeapons.Name = "groupBoxWeapons";
            this.groupBoxWeapons.Size = new System.Drawing.Size(228, 88);
            this.groupBoxWeapons.TabIndex = 0;
            this.groupBoxWeapons.TabStop = false;
            this.groupBoxWeapons.Text = "Broń";
            // 
            // groupBoxArmy
            // 
            this.groupBoxArmy.Location = new System.Drawing.Point(12, 265);
            this.groupBoxArmy.Name = "groupBoxArmy";
            this.groupBoxArmy.Size = new System.Drawing.Size(228, 91);
            this.groupBoxArmy.TabIndex = 0;
            this.groupBoxArmy.TabStop = false;
            this.groupBoxArmy.Text = "Wojsko";
            // 
            // groupBoxBuildings
            // 
            this.groupBoxBuildings.Location = new System.Drawing.Point(276, 87);
            this.groupBoxBuildings.Name = "groupBoxBuildings";
            this.groupBoxBuildings.Size = new System.Drawing.Size(512, 282);
            this.groupBoxBuildings.TabIndex = 1;
            this.groupBoxBuildings.TabStop = false;
            this.groupBoxBuildings.Text = "Budynki";
            // 
            // labelGoldAmount
            // 
            this.labelGoldAmount.AutoSize = true;
            this.labelGoldAmount.Location = new System.Drawing.Point(273, 21);
            this.labelGoldAmount.Name = "labelGoldAmount";
            this.labelGoldAmount.Size = new System.Drawing.Size(111, 13);
            this.labelGoldAmount.TabIndex = 0;
            this.labelGoldAmount.Text = "Ilość złota w skarbcu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelGoldAmount);
            this.Controls.Add(this.groupBoxBuildings);
            this.Controls.Add(this.groupBoxArmy);
            this.Controls.Add(this.groupBoxWeapons);
            this.Controls.Add(this.groupBoxResources);
            this.Name = "FormMainWindow";
            this.Text = "Twierdza";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxResources;
        private System.Windows.Forms.GroupBox groupBoxWeapons;
        private System.Windows.Forms.GroupBox groupBoxArmy;
        private System.Windows.Forms.GroupBox groupBoxBuildings;
        private System.Windows.Forms.Label labelGoldAmount;
        private System.Windows.Forms.Label label1;
    }
}


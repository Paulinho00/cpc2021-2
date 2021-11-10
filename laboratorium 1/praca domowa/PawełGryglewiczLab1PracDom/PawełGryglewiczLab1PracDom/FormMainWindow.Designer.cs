
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainWindow));
            this.groupBoxResources = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxStoneImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxWoodImage = new System.Windows.Forms.PictureBox();
            this.labelIronAmount = new System.Windows.Forms.Label();
            this.labelStoneAmount = new System.Windows.Forms.Label();
            this.labelWoodAmount = new System.Windows.Forms.Label();
            this.labelIron = new System.Windows.Forms.Label();
            this.labelStone = new System.Windows.Forms.Label();
            this.labelWood = new System.Windows.Forms.Label();
            this.groupBoxWeapons = new System.Windows.Forms.GroupBox();
            this.groupBoxArmy = new System.Windows.Forms.GroupBox();
            this.groupBoxBuildings = new System.Windows.Forms.GroupBox();
            this.labelGoldAmount = new System.Windows.Forms.Label();
            this.groupBoxResources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStoneImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWoodImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxResources
            // 
            this.groupBoxResources.Controls.Add(this.pictureBox1);
            this.groupBoxResources.Controls.Add(this.pictureBoxStoneImage);
            this.groupBoxResources.Controls.Add(this.pictureBoxWoodImage);
            this.groupBoxResources.Controls.Add(this.labelIronAmount);
            this.groupBoxResources.Controls.Add(this.labelStoneAmount);
            this.groupBoxResources.Controls.Add(this.labelWoodAmount);
            this.groupBoxResources.Controls.Add(this.labelIron);
            this.groupBoxResources.Controls.Add(this.labelStone);
            this.groupBoxResources.Controls.Add(this.labelWood);
            this.groupBoxResources.Location = new System.Drawing.Point(12, 37);
            this.groupBoxResources.Name = "groupBoxResources";
            this.groupBoxResources.Size = new System.Drawing.Size(228, 99);
            this.groupBoxResources.TabIndex = 0;
            this.groupBoxResources.TabStop = false;
            this.groupBoxResources.Text = "Surowce";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.iron;
            this.pictureBox1.Location = new System.Drawing.Point(171, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxStoneImage
            // 
            this.pictureBoxStoneImage.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.stone;
            this.pictureBoxStoneImage.Location = new System.Drawing.Point(96, 19);
            this.pictureBoxStoneImage.Name = "pictureBoxStoneImage";
            this.pictureBoxStoneImage.Size = new System.Drawing.Size(45, 37);
            this.pictureBoxStoneImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStoneImage.TabIndex = 9;
            this.pictureBoxStoneImage.TabStop = false;
            // 
            // pictureBoxWoodImage
            // 
            this.pictureBoxWoodImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxWoodImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWoodImage.Image")));
            this.pictureBoxWoodImage.Location = new System.Drawing.Point(20, 19);
            this.pictureBoxWoodImage.Name = "pictureBoxWoodImage";
            this.pictureBoxWoodImage.Size = new System.Drawing.Size(42, 37);
            this.pictureBoxWoodImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWoodImage.TabIndex = 3;
            this.pictureBoxWoodImage.TabStop = false;
            // 
            // labelIronAmount
            // 
            this.labelIronAmount.AutoSize = true;
            this.labelIronAmount.Location = new System.Drawing.Point(184, 74);
            this.labelIronAmount.Name = "labelIronAmount";
            this.labelIronAmount.Size = new System.Drawing.Size(13, 13);
            this.labelIronAmount.TabIndex = 8;
            this.labelIronAmount.Text = "0";
            // 
            // labelStoneAmount
            // 
            this.labelStoneAmount.AutoSize = true;
            this.labelStoneAmount.Location = new System.Drawing.Point(113, 74);
            this.labelStoneAmount.Name = "labelStoneAmount";
            this.labelStoneAmount.Size = new System.Drawing.Size(13, 13);
            this.labelStoneAmount.TabIndex = 7;
            this.labelStoneAmount.Text = "0";
            // 
            // labelWoodAmount
            // 
            this.labelWoodAmount.AutoSize = true;
            this.labelWoodAmount.Location = new System.Drawing.Point(37, 74);
            this.labelWoodAmount.Name = "labelWoodAmount";
            this.labelWoodAmount.Size = new System.Drawing.Size(13, 13);
            this.labelWoodAmount.TabIndex = 6;
            this.labelWoodAmount.Text = "0";
            // 
            // labelIron
            // 
            this.labelIron.AutoSize = true;
            this.labelIron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIron.Location = new System.Drawing.Point(168, 59);
            this.labelIron.Name = "labelIron";
            this.labelIron.Size = new System.Drawing.Size(50, 15);
            this.labelIron.TabIndex = 5;
            this.labelIron.Text = "Żelazo";
            this.labelIron.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelStone
            // 
            this.labelStone.AutoSize = true;
            this.labelStone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStone.Location = new System.Drawing.Point(93, 59);
            this.labelStone.Name = "labelStone";
            this.labelStone.Size = new System.Drawing.Size(56, 15);
            this.labelStone.TabIndex = 4;
            this.labelStone.Text = "Kamień";
            // 
            // labelWood
            // 
            this.labelWood.AutoSize = true;
            this.labelWood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWood.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelWood.Location = new System.Drawing.Point(17, 59);
            this.labelWood.Name = "labelWood";
            this.labelWood.Size = new System.Drawing.Size(56, 15);
            this.labelWood.TabIndex = 3;
            this.labelWood.Text = "Drewno";
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
            // FormMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelGoldAmount);
            this.Controls.Add(this.groupBoxBuildings);
            this.Controls.Add(this.groupBoxArmy);
            this.Controls.Add(this.groupBoxWeapons);
            this.Controls.Add(this.groupBoxResources);
            this.Name = "FormMainWindow";
            this.Text = "Twierdza";
            this.Load += new System.EventHandler(this.FormMainWindow_Load);
            this.groupBoxResources.ResumeLayout(false);
            this.groupBoxResources.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStoneImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWoodImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxResources;
        private System.Windows.Forms.GroupBox groupBoxWeapons;
        private System.Windows.Forms.GroupBox groupBoxArmy;
        private System.Windows.Forms.GroupBox groupBoxBuildings;
        private System.Windows.Forms.Label labelGoldAmount;
        private System.Windows.Forms.Label labelIronAmount;
        private System.Windows.Forms.Label labelStoneAmount;
        private System.Windows.Forms.Label labelWoodAmount;
        private System.Windows.Forms.Label labelIron;
        private System.Windows.Forms.Label labelStone;
        private System.Windows.Forms.Label labelWood;
        private System.Windows.Forms.PictureBox pictureBoxWoodImage;
        private System.Windows.Forms.PictureBox pictureBoxStoneImage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}




using System.Windows.Forms;

namespace PawełGryglewiczLab1PracDom
{
    partial class FormRecruitmentWindow
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
            this.labelArchers = new System.Windows.Forms.Label();
            this.labelPikemen = new System.Windows.Forms.Label();
            this.labelSwordsmen = new System.Windows.Forms.Label();
            this.trackBarArchers = new System.Windows.Forms.TrackBar();
            this.trackBarPikemen = new System.Windows.Forms.TrackBar();
            this.trackBarSwordsmen = new System.Windows.Forms.TrackBar();
            this.labelArchersTrackBarValue = new System.Windows.Forms.Label();
            this.labelPikemenTrackBarValue = new System.Windows.Forms.Label();
            this.labelSwordmenTrackBarValue = new System.Windows.Forms.Label();
            this.buttonRecruit = new System.Windows.Forms.Button();
            this.pictureBoxGold = new System.Windows.Forms.PictureBox();
            this.pictureBoxSwordsmen = new System.Windows.Forms.PictureBox();
            this.pictureBoxPikemen = new System.Windows.Forms.PictureBox();
            this.pictureBoxArchers = new System.Windows.Forms.PictureBox();
            this.labelGoldAmount = new System.Windows.Forms.Label();
            this.pictureBoxBow = new System.Windows.Forms.PictureBox();
            this.labelBowsAmount = new System.Windows.Forms.Label();
            this.pictureBoxPike = new System.Windows.Forms.PictureBox();
            this.labelPikesAmount = new System.Windows.Forms.Label();
            this.pictureBoxSword = new System.Windows.Forms.PictureBox();
            this.labelSwordsAmount = new System.Windows.Forms.Label();
            this.buttonRecruitPikemen = new System.Windows.Forms.Button();
            this.buttonRecruitSwordsmen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarArchers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPikemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSwordsmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSwordsmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPikemen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArchers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSword)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArchers
            // 
            this.labelArchers.AutoSize = true;
            this.labelArchers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelArchers.Location = new System.Drawing.Point(122, 249);
            this.labelArchers.Name = "labelArchers";
            this.labelArchers.Size = new System.Drawing.Size(105, 25);
            this.labelArchers.TabIndex = 0;
            this.labelArchers.Text = "Łucznicy";
            // 
            // labelPikemen
            // 
            this.labelPikemen.AutoSize = true;
            this.labelPikemen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPikemen.Location = new System.Drawing.Point(349, 249);
            this.labelPikemen.Name = "labelPikemen";
            this.labelPikemen.Size = new System.Drawing.Size(115, 25);
            this.labelPikemen.TabIndex = 1;
            this.labelPikemen.Text = "Pikinierzy";
            // 
            // labelSwordsmen
            // 
            this.labelSwordsmen.AutoSize = true;
            this.labelSwordsmen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSwordsmen.Location = new System.Drawing.Point(596, 249);
            this.labelSwordsmen.Name = "labelSwordsmen";
            this.labelSwordsmen.Size = new System.Drawing.Size(103, 24);
            this.labelSwordsmen.TabIndex = 2;
            this.labelSwordsmen.Text = "Miecznicy";
            // 
            // trackBarArchers
            // 
            this.trackBarArchers.Location = new System.Drawing.Point(115, 286);
            this.trackBarArchers.Maximum = 25;
            this.trackBarArchers.Name = "trackBarArchers";
            this.trackBarArchers.Size = new System.Drawing.Size(112, 45);
            this.trackBarArchers.TabIndex = 6;
            this.trackBarArchers.Scroll += new System.EventHandler(this.TrackBarArchers_Scroll);
            // 
            // trackBarPikemen
            // 
            this.trackBarPikemen.Location = new System.Drawing.Point(354, 286);
            this.trackBarPikemen.Name = "trackBarPikemen";
            this.trackBarPikemen.Size = new System.Drawing.Size(110, 45);
            this.trackBarPikemen.TabIndex = 7;
            this.trackBarPikemen.Scroll += new System.EventHandler(this.TrackBarPikemen_Scroll);
            // 
            // trackBarSwordsmen
            // 
            this.trackBarSwordsmen.Location = new System.Drawing.Point(589, 286);
            this.trackBarSwordsmen.Name = "trackBarSwordsmen";
            this.trackBarSwordsmen.Size = new System.Drawing.Size(110, 45);
            this.trackBarSwordsmen.TabIndex = 8;
            this.trackBarSwordsmen.Scroll += new System.EventHandler(this.TrackBarSwordsmen_Scroll);
            // 
            // labelArchersTrackBarValue
            // 
            this.labelArchersTrackBarValue.AutoSize = true;
            this.labelArchersTrackBarValue.Location = new System.Drawing.Point(159, 334);
            this.labelArchersTrackBarValue.Name = "labelArchersTrackBarValue";
            this.labelArchersTrackBarValue.Size = new System.Drawing.Size(13, 13);
            this.labelArchersTrackBarValue.TabIndex = 9;
            this.labelArchersTrackBarValue.Text = "0";
            // 
            // labelPikemenTrackBarValue
            // 
            this.labelPikemenTrackBarValue.AutoSize = true;
            this.labelPikemenTrackBarValue.Location = new System.Drawing.Point(398, 334);
            this.labelPikemenTrackBarValue.Name = "labelPikemenTrackBarValue";
            this.labelPikemenTrackBarValue.Size = new System.Drawing.Size(13, 13);
            this.labelPikemenTrackBarValue.TabIndex = 10;
            this.labelPikemenTrackBarValue.Text = "0";
            // 
            // labelSwordmenTrackBarValue
            // 
            this.labelSwordmenTrackBarValue.AutoSize = true;
            this.labelSwordmenTrackBarValue.Location = new System.Drawing.Point(640, 334);
            this.labelSwordmenTrackBarValue.Name = "labelSwordmenTrackBarValue";
            this.labelSwordmenTrackBarValue.Size = new System.Drawing.Size(13, 13);
            this.labelSwordmenTrackBarValue.TabIndex = 11;
            this.labelSwordmenTrackBarValue.Text = "0";
            // 
            // buttonRecruit
            // 
            this.buttonRecruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRecruit.Location = new System.Drawing.Point(115, 366);
            this.buttonRecruit.Name = "buttonRecruit";
            this.buttonRecruit.Size = new System.Drawing.Size(110, 32);
            this.buttonRecruit.TabIndex = 12;
            this.buttonRecruit.Text = "Rekrutuj";
            this.buttonRecruit.UseVisualStyleBackColor = true;
            this.buttonRecruit.Click += new System.EventHandler(this.ButtonRecruitArchers_Click);
            // 
            // pictureBoxGold
            // 
            this.pictureBoxGold.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Gold;
            this.pictureBoxGold.Location = new System.Drawing.Point(23, 12);
            this.pictureBoxGold.Name = "pictureBoxGold";
            this.pictureBoxGold.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxGold.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGold.TabIndex = 13;
            this.pictureBoxGold.TabStop = false;
            // 
            // pictureBoxSwordsmen
            // 
            this.pictureBoxSwordsmen.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Swordsman;
            this.pictureBoxSwordsmen.Location = new System.Drawing.Point(589, 64);
            this.pictureBoxSwordsmen.Name = "pictureBoxSwordsmen";
            this.pictureBoxSwordsmen.Size = new System.Drawing.Size(110, 183);
            this.pictureBoxSwordsmen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSwordsmen.TabIndex = 5;
            this.pictureBoxSwordsmen.TabStop = false;
            // 
            // pictureBoxPikemen
            // 
            this.pictureBoxPikemen.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Pikeman;
            this.pictureBoxPikemen.Location = new System.Drawing.Point(354, 63);
            this.pictureBoxPikemen.Name = "pictureBoxPikemen";
            this.pictureBoxPikemen.Size = new System.Drawing.Size(110, 183);
            this.pictureBoxPikemen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPikemen.TabIndex = 4;
            this.pictureBoxPikemen.TabStop = false;
            // 
            // pictureBoxArchers
            // 
            this.pictureBoxArchers.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Archer;
            this.pictureBoxArchers.Location = new System.Drawing.Point(115, 63);
            this.pictureBoxArchers.Name = "pictureBoxArchers";
            this.pictureBoxArchers.Size = new System.Drawing.Size(110, 183);
            this.pictureBoxArchers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxArchers.TabIndex = 3;
            this.pictureBoxArchers.TabStop = false;
            // 
            // labelGoldAmount
            // 
            this.labelGoldAmount.AutoSize = true;
            this.labelGoldAmount.Location = new System.Drawing.Point(67, 26);
            this.labelGoldAmount.Name = "labelGoldAmount";
            this.labelGoldAmount.Size = new System.Drawing.Size(13, 13);
            this.labelGoldAmount.TabIndex = 14;
            this.labelGoldAmount.Text = "0";
            // 
            // pictureBoxBow
            // 
            this.pictureBoxBow.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Bow;
            this.pictureBoxBow.Location = new System.Drawing.Point(127, 12);
            this.pictureBoxBow.Name = "pictureBoxBow";
            this.pictureBoxBow.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxBow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBow.TabIndex = 15;
            this.pictureBoxBow.TabStop = false;
            // 
            // labelBowsAmount
            // 
            this.labelBowsAmount.AutoSize = true;
            this.labelBowsAmount.Location = new System.Drawing.Point(171, 26);
            this.labelBowsAmount.Name = "labelBowsAmount";
            this.labelBowsAmount.Size = new System.Drawing.Size(13, 13);
            this.labelBowsAmount.TabIndex = 16;
            this.labelBowsAmount.Text = "0";
            // 
            // pictureBoxPike
            // 
            this.pictureBoxPike.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Pike;
            this.pictureBoxPike.Location = new System.Drawing.Point(219, 12);
            this.pictureBoxPike.Name = "pictureBoxPike";
            this.pictureBoxPike.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxPike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPike.TabIndex = 17;
            this.pictureBoxPike.TabStop = false;
            // 
            // labelPikesAmount
            // 
            this.labelPikesAmount.AutoSize = true;
            this.labelPikesAmount.Location = new System.Drawing.Point(263, 26);
            this.labelPikesAmount.Name = "labelPikesAmount";
            this.labelPikesAmount.Size = new System.Drawing.Size(13, 13);
            this.labelPikesAmount.TabIndex = 18;
            this.labelPikesAmount.Text = "0";
            // 
            // pictureBoxSword
            // 
            this.pictureBoxSword.Image = global::PawełGryglewiczLab1PracDom.Properties.Resources.Sword;
            this.pictureBoxSword.Location = new System.Drawing.Point(306, 12);
            this.pictureBoxSword.Name = "pictureBoxSword";
            this.pictureBoxSword.Size = new System.Drawing.Size(38, 36);
            this.pictureBoxSword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSword.TabIndex = 19;
            this.pictureBoxSword.TabStop = false;
            // 
            // labelSwordsAmount
            // 
            this.labelSwordsAmount.AutoSize = true;
            this.labelSwordsAmount.Location = new System.Drawing.Point(350, 26);
            this.labelSwordsAmount.Name = "labelSwordsAmount";
            this.labelSwordsAmount.Size = new System.Drawing.Size(13, 13);
            this.labelSwordsAmount.TabIndex = 20;
            this.labelSwordsAmount.Text = "0";
            // 
            // buttonRecruitPikemen
            // 
            this.buttonRecruitPikemen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRecruitPikemen.Location = new System.Drawing.Point(353, 366);
            this.buttonRecruitPikemen.Name = "buttonRecruitPikemen";
            this.buttonRecruitPikemen.Size = new System.Drawing.Size(110, 32);
            this.buttonRecruitPikemen.TabIndex = 21;
            this.buttonRecruitPikemen.Text = "Rekrutuj";
            this.buttonRecruitPikemen.UseVisualStyleBackColor = true;
            this.buttonRecruitPikemen.Click += new System.EventHandler(this.ButtonRecruitPikemen_Click);
            // 
            // buttonRecruitSwordsmen
            // 
            this.buttonRecruitSwordsmen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRecruitSwordsmen.Location = new System.Drawing.Point(589, 366);
            this.buttonRecruitSwordsmen.Name = "buttonRecruitSwordsmen";
            this.buttonRecruitSwordsmen.Size = new System.Drawing.Size(110, 32);
            this.buttonRecruitSwordsmen.TabIndex = 22;
            this.buttonRecruitSwordsmen.Text = "Rekrutuj";
            this.buttonRecruitSwordsmen.UseVisualStyleBackColor = true;
            this.buttonRecruitSwordsmen.Click += new System.EventHandler(this.buttonRecruitSwordsmen_Click);
            // 
            // FormRecruitmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRecruitSwordsmen);
            this.Controls.Add(this.buttonRecruitPikemen);
            this.Controls.Add(this.labelSwordsAmount);
            this.Controls.Add(this.pictureBoxSword);
            this.Controls.Add(this.labelPikesAmount);
            this.Controls.Add(this.pictureBoxPike);
            this.Controls.Add(this.labelBowsAmount);
            this.Controls.Add(this.pictureBoxBow);
            this.Controls.Add(this.labelGoldAmount);
            this.Controls.Add(this.pictureBoxGold);
            this.Controls.Add(this.buttonRecruit);
            this.Controls.Add(this.labelSwordmenTrackBarValue);
            this.Controls.Add(this.labelPikemenTrackBarValue);
            this.Controls.Add(this.labelArchersTrackBarValue);
            this.Controls.Add(this.trackBarSwordsmen);
            this.Controls.Add(this.trackBarPikemen);
            this.Controls.Add(this.trackBarArchers);
            this.Controls.Add(this.pictureBoxSwordsmen);
            this.Controls.Add(this.pictureBoxPikemen);
            this.Controls.Add(this.pictureBoxArchers);
            this.Controls.Add(this.labelSwordsmen);
            this.Controls.Add(this.labelPikemen);
            this.Controls.Add(this.labelArchers);
            this.Name = "FormRecruitmentWindow";
            this.Text = "Rekrutacja wojska";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRecruitmentWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarArchers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPikemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSwordsmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSwordsmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPikemen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArchers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelArchers;
        private Label labelPikemen;
        private Label labelSwordsmen;
        private PictureBox pictureBoxArchers;
        private PictureBox pictureBoxPikemen;
        private PictureBox pictureBoxSwordsmen;
        private TrackBar trackBarArchers;
        private TrackBar trackBarPikemen;
        private TrackBar trackBarSwordsmen;
        private Label labelArchersTrackBarValue;
        private Label labelPikemenTrackBarValue;
        private Label labelSwordmenTrackBarValue;
        private Button buttonRecruit;
        private PictureBox pictureBoxGold;
        private Label labelGoldAmount;
        private PictureBox pictureBoxBow;
        private Label labelBowsAmount;
        private PictureBox pictureBoxPike;
        private Label labelPikesAmount;
        private PictureBox pictureBoxSword;
        private Label labelSwordsAmount;
        private Button buttonRecruitPikemen;
        private Button buttonRecruitSwordsmen;
    }
}
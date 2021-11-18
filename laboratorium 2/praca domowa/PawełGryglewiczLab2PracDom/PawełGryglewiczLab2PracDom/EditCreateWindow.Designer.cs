
namespace PawełGryglewiczLab2PracDom
{
    partial class EditCreateWindow
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
            this.labelCarName = new System.Windows.Forms.Label();
            this.labelYearOfReveal = new System.Windows.Forms.Label();
            this.labelDesigner = new System.Windows.Forms.Label();
            this.labelBrakes = new System.Windows.Forms.Label();
            this.labelGearbox = new System.Windows.Forms.Label();
            this.labelTyres = new System.Windows.Forms.Label();
            this.labelLength = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelTeam = new System.Windows.Forms.Label();
            this.labelEngine = new System.Windows.Forms.Label();
            this.textBoxCarName = new System.Windows.Forms.TextBox();
            this.numericUpDownYearOfReveal = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDesigners = new System.Windows.Forms.ComboBox();
            this.comboBoxBrakes = new System.Windows.Forms.ComboBox();
            this.comboBoxGearboxes = new System.Windows.Forms.ComboBox();
            this.comboBoxTyres = new System.Windows.Forms.ComboBox();
            this.comboBoxTeams = new System.Windows.Forms.ComboBox();
            this.comboBoxEngines = new System.Windows.Forms.ComboBox();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearOfReveal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCarName
            // 
            this.labelCarName.AutoSize = true;
            this.labelCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCarName.Location = new System.Drawing.Point(26, 43);
            this.labelCarName.Name = "labelCarName";
            this.labelCarName.Size = new System.Drawing.Size(130, 20);
            this.labelCarName.TabIndex = 0;
            this.labelCarName.Text = "Nazwa modelu:";
            // 
            // labelYearOfReveal
            // 
            this.labelYearOfReveal.AutoSize = true;
            this.labelYearOfReveal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelYearOfReveal.Location = new System.Drawing.Point(45, 84);
            this.labelYearOfReveal.Name = "labelYearOfReveal";
            this.labelYearOfReveal.Size = new System.Drawing.Size(111, 20);
            this.labelYearOfReveal.TabIndex = 1;
            this.labelYearOfReveal.Text = "Rok debiutu:";
            // 
            // labelDesigner
            // 
            this.labelDesigner.AutoSize = true;
            this.labelDesigner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDesigner.Location = new System.Drawing.Point(60, 163);
            this.labelDesigner.Name = "labelDesigner";
            this.labelDesigner.Size = new System.Drawing.Size(96, 20);
            this.labelDesigner.TabIndex = 2;
            this.labelDesigner.Text = "Projektant:";
            // 
            // labelBrakes
            // 
            this.labelBrakes.AutoSize = true;
            this.labelBrakes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBrakes.Location = new System.Drawing.Point(72, 350);
            this.labelBrakes.Name = "labelBrakes";
            this.labelBrakes.Size = new System.Drawing.Size(84, 20);
            this.labelBrakes.TabIndex = 3;
            this.labelBrakes.Text = "Hamulce:";
            // 
            // labelGearbox
            // 
            this.labelGearbox.AutoSize = true;
            this.labelGearbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGearbox.Location = new System.Drawing.Point(13, 206);
            this.labelGearbox.Name = "labelGearbox";
            this.labelGearbox.Size = new System.Drawing.Size(143, 20);
            this.labelGearbox.TabIndex = 4;
            this.labelGearbox.Text = "Skrzynia biegów:";
            // 
            // labelTyres
            // 
            this.labelTyres.AutoSize = true;
            this.labelTyres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTyres.Location = new System.Drawing.Point(91, 244);
            this.labelTyres.Name = "labelTyres";
            this.labelTyres.Size = new System.Drawing.Size(65, 20);
            this.labelTyres.TabIndex = 5;
            this.labelTyres.Text = "Opony:";
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLength.Location = new System.Drawing.Point(76, 280);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(80, 20);
            this.labelLength.TabIndex = 6;
            this.labelLength.Text = "Długość:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWidth.Location = new System.Drawing.Point(58, 313);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(98, 20);
            this.labelWidth.TabIndex = 7;
            this.labelWidth.Text = "Szerokość:";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(177, 423);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(87, 38);
            this.buttonConfirm.TabIndex = 8;
            this.buttonConfirm.Text = "Zatwierdź";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(286, 423);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 38);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTeam.Location = new System.Drawing.Point(87, 126);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(69, 20);
            this.labelTeam.TabIndex = 10;
            this.labelTeam.Text = "Zespół:";
            // 
            // labelEngine
            // 
            this.labelEngine.AutoSize = true;
            this.labelEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEngine.Location = new System.Drawing.Point(99, 380);
            this.labelEngine.Name = "labelEngine";
            this.labelEngine.Size = new System.Drawing.Size(57, 20);
            this.labelEngine.TabIndex = 11;
            this.labelEngine.Text = "Silnik:";
            // 
            // textBoxCarName
            // 
            this.textBoxCarName.Location = new System.Drawing.Point(162, 45);
            this.textBoxCarName.Name = "textBoxCarName";
            this.textBoxCarName.Size = new System.Drawing.Size(211, 20);
            this.textBoxCarName.TabIndex = 12;
            // 
            // numericUpDownYearOfReveal
            // 
            this.numericUpDownYearOfReveal.Location = new System.Drawing.Point(162, 87);
            this.numericUpDownYearOfReveal.Maximum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.numericUpDownYearOfReveal.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.numericUpDownYearOfReveal.Name = "numericUpDownYearOfReveal";
            this.numericUpDownYearOfReveal.Size = new System.Drawing.Size(211, 20);
            this.numericUpDownYearOfReveal.TabIndex = 13;
            this.numericUpDownYearOfReveal.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // comboBoxDesigners
            // 
            this.comboBoxDesigners.FormattingEnabled = true;
            this.comboBoxDesigners.Location = new System.Drawing.Point(162, 165);
            this.comboBoxDesigners.Name = "comboBoxDesigners";
            this.comboBoxDesigners.Size = new System.Drawing.Size(211, 21);
            this.comboBoxDesigners.TabIndex = 14;
            // 
            // comboBoxBrakes
            // 
            this.comboBoxBrakes.FormattingEnabled = true;
            this.comboBoxBrakes.Location = new System.Drawing.Point(162, 352);
            this.comboBoxBrakes.Name = "comboBoxBrakes";
            this.comboBoxBrakes.Size = new System.Drawing.Size(211, 21);
            this.comboBoxBrakes.TabIndex = 15;
            // 
            // comboBoxGearboxes
            // 
            this.comboBoxGearboxes.FormattingEnabled = true;
            this.comboBoxGearboxes.Location = new System.Drawing.Point(162, 205);
            this.comboBoxGearboxes.Name = "comboBoxGearboxes";
            this.comboBoxGearboxes.Size = new System.Drawing.Size(211, 21);
            this.comboBoxGearboxes.TabIndex = 16;
            // 
            // comboBoxTyres
            // 
            this.comboBoxTyres.FormattingEnabled = true;
            this.comboBoxTyres.Location = new System.Drawing.Point(162, 246);
            this.comboBoxTyres.Name = "comboBoxTyres";
            this.comboBoxTyres.Size = new System.Drawing.Size(211, 21);
            this.comboBoxTyres.TabIndex = 17;
            // 
            // comboBoxTeams
            // 
            this.comboBoxTeams.FormattingEnabled = true;
            this.comboBoxTeams.Location = new System.Drawing.Point(162, 125);
            this.comboBoxTeams.Name = "comboBoxTeams";
            this.comboBoxTeams.Size = new System.Drawing.Size(211, 21);
            this.comboBoxTeams.TabIndex = 20;
            // 
            // comboBoxEngines
            // 
            this.comboBoxEngines.FormattingEnabled = true;
            this.comboBoxEngines.Location = new System.Drawing.Point(162, 382);
            this.comboBoxEngines.Name = "comboBoxEngines";
            this.comboBoxEngines.Size = new System.Drawing.Size(211, 21);
            this.comboBoxEngines.TabIndex = 21;
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(162, 283);
            this.numericUpDownLength.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDownLength.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(211, 20);
            this.numericUpDownLength.TabIndex = 22;
            this.numericUpDownLength.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(162, 316);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(211, 20);
            this.numericUpDownWidth.TabIndex = 23;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // EditCreateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 473);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.numericUpDownLength);
            this.Controls.Add(this.comboBoxEngines);
            this.Controls.Add(this.comboBoxTeams);
            this.Controls.Add(this.comboBoxTyres);
            this.Controls.Add(this.comboBoxGearboxes);
            this.Controls.Add(this.comboBoxBrakes);
            this.Controls.Add(this.comboBoxDesigners);
            this.Controls.Add(this.numericUpDownYearOfReveal);
            this.Controls.Add(this.textBoxCarName);
            this.Controls.Add(this.labelEngine);
            this.Controls.Add(this.labelTeam);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.labelTyres);
            this.Controls.Add(this.labelGearbox);
            this.Controls.Add(this.labelBrakes);
            this.Controls.Add(this.labelDesigner);
            this.Controls.Add(this.labelYearOfReveal);
            this.Controls.Add(this.labelCarName);
            this.Name = "EditCreateWindow";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYearOfReveal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCarName;
        private System.Windows.Forms.Label labelYearOfReveal;
        private System.Windows.Forms.Label labelDesigner;
        private System.Windows.Forms.Label labelBrakes;
        private System.Windows.Forms.Label labelGearbox;
        private System.Windows.Forms.Label labelTyres;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label labelEngine;
        private System.Windows.Forms.TextBox textBoxCarName;
        private System.Windows.Forms.NumericUpDown numericUpDownYearOfReveal;
        private System.Windows.Forms.ComboBox comboBoxDesigners;
        private System.Windows.Forms.ComboBox comboBoxBrakes;
        private System.Windows.Forms.ComboBox comboBoxGearboxes;
        private System.Windows.Forms.ComboBox comboBoxTyres;
        private System.Windows.Forms.ComboBox comboBoxTeams;
        private System.Windows.Forms.ComboBox comboBoxEngines;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
    }
}
﻿namespace MugPlugin.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MugParameters = new System.Windows.Forms.GroupBox();
            this.pocketHeightRangeLabel = new System.Windows.Forms.Label();
            this.pocketHeightLabel = new System.Windows.Forms.Label();
            this.pocketHeight = new System.Windows.Forms.TextBox();
            this.heightRangeLabel = new System.Windows.Forms.Label();
            this.handleLengthRangeLabel = new System.Windows.Forms.Label();
            this.handleDiameterRangeLabel = new System.Windows.Forms.Label();
            this.thicknessRangeLabel = new System.Windows.Forms.Label();
            this.handleLengthLabel = new System.Windows.Forms.Label();
            this.handleDiameterLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.thicknessLabel = new System.Windows.Forms.Label();
            this.diameterRangeLabel = new System.Windows.Forms.Label();
            this.diameterLabel = new System.Windows.Forms.Label();
            this.handleDiameter = new System.Windows.Forms.TextBox();
            this.handleLength = new System.Windows.Forms.TextBox();
            this.thickness = new System.Windows.Forms.TextBox();
            this.height = new System.Windows.Forms.TextBox();
            this.diameter = new System.Windows.Forms.TextBox();
            this.DefaultParameters = new System.Windows.Forms.GroupBox();
            this.setParametersAvg = new System.Windows.Forms.Button();
            this.setParametersMax = new System.Windows.Forms.Button();
            this.setParametersMin = new System.Windows.Forms.Button();
            this.mugScheme = new System.Windows.Forms.PictureBox();
            this.build = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.MugParameters.SuspendLayout();
            this.DefaultParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mugScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // MugParameters
            // 
            this.MugParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MugParameters.Controls.Add(this.pocketHeightRangeLabel);
            this.MugParameters.Controls.Add(this.pocketHeightLabel);
            this.MugParameters.Controls.Add(this.pocketHeight);
            this.MugParameters.Controls.Add(this.heightRangeLabel);
            this.MugParameters.Controls.Add(this.handleLengthRangeLabel);
            this.MugParameters.Controls.Add(this.handleDiameterRangeLabel);
            this.MugParameters.Controls.Add(this.thicknessRangeLabel);
            this.MugParameters.Controls.Add(this.handleLengthLabel);
            this.MugParameters.Controls.Add(this.handleDiameterLabel);
            this.MugParameters.Controls.Add(this.heightLabel);
            this.MugParameters.Controls.Add(this.thicknessLabel);
            this.MugParameters.Controls.Add(this.diameterRangeLabel);
            this.MugParameters.Controls.Add(this.diameterLabel);
            this.MugParameters.Controls.Add(this.handleDiameter);
            this.MugParameters.Controls.Add(this.handleLength);
            this.MugParameters.Controls.Add(this.thickness);
            this.MugParameters.Controls.Add(this.height);
            this.MugParameters.Controls.Add(this.diameter);
            this.MugParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MugParameters.Location = new System.Drawing.Point(12, 12);
            this.MugParameters.Name = "MugParameters";
            this.MugParameters.Size = new System.Drawing.Size(300, 269);
            this.MugParameters.TabIndex = 0;
            this.MugParameters.TabStop = false;
            this.MugParameters.Text = "Mug Parameters";
            // 
            // pocketHeightRangeLabel
            // 
            this.pocketHeightRangeLabel.AutoSize = true;
            this.pocketHeightRangeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pocketHeightRangeLabel.Location = new System.Drawing.Point(109, 242);
            this.pocketHeightRangeLabel.Name = "pocketHeightRangeLabel";
            this.pocketHeightRangeLabel.Size = new System.Drawing.Size(155, 15);
            this.pocketHeightRangeLabel.TabIndex = 26;
            this.pocketHeightRangeLabel.Text = "(min -26mm, max - 39mm)";
            // 
            // pocketHeightLabel
            // 
            this.pocketHeightLabel.AutoSize = true;
            this.pocketHeightLabel.Location = new System.Drawing.Point(6, 221);
            this.pocketHeightLabel.Name = "pocketHeightLabel";
            this.pocketHeightLabel.Size = new System.Drawing.Size(81, 15);
            this.pocketHeightLabel.TabIndex = 25;
            this.pocketHeightLabel.Text = "Pocket height";
            // 
            // pocketHeight
            // 
            this.pocketHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pocketHeight.Location = new System.Drawing.Point(3, 239);
            this.pocketHeight.Name = "pocketHeight";
            this.pocketHeight.Size = new System.Drawing.Size(98, 20);
            this.pocketHeight.TabIndex = 24;
            this.pocketHeight.Click += new System.EventHandler(this.ClearField);
            this.pocketHeight.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // heightRangeLabel
            // 
            this.heightRangeLabel.AutoSize = true;
            this.heightRangeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.heightRangeLabel.Location = new System.Drawing.Point(109, 78);
            this.heightRangeLabel.Name = "heightRangeLabel";
            this.heightRangeLabel.Size = new System.Drawing.Size(165, 15);
            this.heightRangeLabel.TabIndex = 23;
            this.heightRangeLabel.Text = "(min - 85mm, max - 130mm)";
            // 
            // handleLengthRangeLabel
            // 
            this.handleLengthRangeLabel.AutoSize = true;
            this.handleLengthRangeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.handleLengthRangeLabel.Location = new System.Drawing.Point(109, 160);
            this.handleLengthRangeLabel.Name = "handleLengthRangeLabel";
            this.handleLengthRangeLabel.Size = new System.Drawing.Size(185, 15);
            this.handleLengthRangeLabel.TabIndex = 21;
            this.handleLengthRangeLabel.Text = "(min - 29.75mm, max - 45.5mm)";
            // 
            // handleDiameterRangeLabel
            // 
            this.handleDiameterRangeLabel.AutoSize = true;
            this.handleDiameterRangeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.handleDiameterRangeLabel.Location = new System.Drawing.Point(109, 199);
            this.handleDiameterRangeLabel.Name = "handleDiameterRangeLabel";
            this.handleDiameterRangeLabel.Size = new System.Drawing.Size(168, 15);
            this.handleDiameterRangeLabel.TabIndex = 19;
            this.handleDiameterRangeLabel.Text = "(min - 59.5mm, max - 91mm)";
            // 
            // thicknessRangeLabel
            // 
            this.thicknessRangeLabel.AutoSize = true;
            this.thicknessRangeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.thicknessRangeLabel.Location = new System.Drawing.Point(109, 119);
            this.thicknessRangeLabel.Name = "thicknessRangeLabel";
            this.thicknessRangeLabel.Size = new System.Drawing.Size(151, 15);
            this.thicknessRangeLabel.TabIndex = 17;
            this.thicknessRangeLabel.Text = "(min - 5mm, max - 10mm)";
            // 
            // handleLengthLabel
            // 
            this.handleLengthLabel.AutoSize = true;
            this.handleLengthLabel.Location = new System.Drawing.Point(6, 139);
            this.handleLengthLabel.Name = "handleLengthLabel";
            this.handleLengthLabel.Size = new System.Drawing.Size(84, 15);
            this.handleLengthLabel.TabIndex = 15;
            this.handleLengthLabel.Text = "Handle length";
            // 
            // handleDiameterLabel
            // 
            this.handleDiameterLabel.AutoSize = true;
            this.handleDiameterLabel.Location = new System.Drawing.Point(6, 178);
            this.handleDiameterLabel.Name = "handleDiameterLabel";
            this.handleDiameterLabel.Size = new System.Drawing.Size(99, 15);
            this.handleDiameterLabel.TabIndex = 13;
            this.handleDiameterLabel.Text = "Handle diameter";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(6, 57);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(43, 15);
            this.heightLabel.TabIndex = 11;
            this.heightLabel.Text = "Height";
            // 
            // thicknessLabel
            // 
            this.thicknessLabel.AutoSize = true;
            this.thicknessLabel.Location = new System.Drawing.Point(6, 98);
            this.thicknessLabel.Name = "thicknessLabel";
            this.thicknessLabel.Size = new System.Drawing.Size(62, 15);
            this.thicknessLabel.TabIndex = 9;
            this.thicknessLabel.Text = "Thickness";
            // 
            // diameterRangeLabel
            // 
            this.diameterRangeLabel.AutoSize = true;
            this.diameterRangeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.diameterRangeLabel.Location = new System.Drawing.Point(109, 37);
            this.diameterRangeLabel.Name = "diameterRangeLabel";
            this.diameterRangeLabel.Size = new System.Drawing.Size(165, 15);
            this.diameterRangeLabel.TabIndex = 7;
            this.diameterRangeLabel.Text = "(min - 70mm, max - 105mm)";
            // 
            // diameterLabel
            // 
            this.diameterLabel.AutoSize = true;
            this.diameterLabel.Location = new System.Drawing.Point(6, 16);
            this.diameterLabel.Name = "diameterLabel";
            this.diameterLabel.Size = new System.Drawing.Size(58, 15);
            this.diameterLabel.TabIndex = 5;
            this.diameterLabel.Text = "Diameter";
            // 
            // handleDiameter
            // 
            this.handleDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.handleDiameter.Location = new System.Drawing.Point(3, 196);
            this.handleDiameter.Name = "handleDiameter";
            this.handleDiameter.Size = new System.Drawing.Size(98, 20);
            this.handleDiameter.TabIndex = 4;
            this.handleDiameter.Click += new System.EventHandler(this.ClearField);
            this.handleDiameter.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // handleLength
            // 
            this.handleLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.handleLength.Location = new System.Drawing.Point(3, 157);
            this.handleLength.Name = "handleLength";
            this.handleLength.Size = new System.Drawing.Size(98, 20);
            this.handleLength.TabIndex = 3;
            this.handleLength.Click += new System.EventHandler(this.ClearField);
            this.handleLength.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // thickness
            // 
            this.thickness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.thickness.Location = new System.Drawing.Point(3, 116);
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(98, 20);
            this.thickness.TabIndex = 2;
            this.thickness.Click += new System.EventHandler(this.ClearField);
            this.thickness.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // height
            // 
            this.height.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.height.Location = new System.Drawing.Point(3, 75);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(98, 20);
            this.height.TabIndex = 1;
            this.height.Click += new System.EventHandler(this.ClearField);
            this.height.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // diameter
            // 
            this.diameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diameter.Location = new System.Drawing.Point(3, 34);
            this.diameter.Name = "diameter";
            this.diameter.Size = new System.Drawing.Size(98, 20);
            this.diameter.TabIndex = 0;
            this.diameter.Click += new System.EventHandler(this.ClearField);
            this.diameter.TextChanged += new System.EventHandler(this.SetParameter);
            // 
            // DefaultParameters
            // 
            this.DefaultParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DefaultParameters.Controls.Add(this.setParametersAvg);
            this.DefaultParameters.Controls.Add(this.setParametersMax);
            this.DefaultParameters.Controls.Add(this.setParametersMin);
            this.DefaultParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DefaultParameters.Location = new System.Drawing.Point(12, 287);
            this.DefaultParameters.Name = "DefaultParameters";
            this.DefaultParameters.Size = new System.Drawing.Size(300, 145);
            this.DefaultParameters.TabIndex = 1;
            this.DefaultParameters.TabStop = false;
            this.DefaultParameters.Text = "Default Parameters";
            // 
            // setParametersAvg
            // 
            this.setParametersAvg.Location = new System.Drawing.Point(6, 58);
            this.setParametersAvg.Name = "setParametersAvg";
            this.setParametersAvg.Size = new System.Drawing.Size(276, 33);
            this.setParametersAvg.TabIndex = 24;
            this.setParametersAvg.Text = "Average";
            this.setParametersAvg.UseVisualStyleBackColor = true;
            this.setParametersAvg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetDefaultParameters);
            // 
            // setParametersMax
            // 
            this.setParametersMax.Location = new System.Drawing.Point(6, 97);
            this.setParametersMax.Name = "setParametersMax";
            this.setParametersMax.Size = new System.Drawing.Size(276, 33);
            this.setParametersMax.TabIndex = 3;
            this.setParametersMax.Text = "Maximum";
            this.setParametersMax.UseVisualStyleBackColor = true;
            this.setParametersMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetDefaultParameters);
            // 
            // setParametersMin
            // 
            this.setParametersMin.Location = new System.Drawing.Point(6, 19);
            this.setParametersMin.Name = "setParametersMin";
            this.setParametersMin.Size = new System.Drawing.Size(276, 33);
            this.setParametersMin.TabIndex = 25;
            this.setParametersMin.Text = "Minimum";
            this.setParametersMin.UseVisualStyleBackColor = true;
            this.setParametersMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SetDefaultParameters);
            // 
            // mugScheme
            // 
            this.mugScheme.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mugScheme.BackgroundImage")));
            this.mugScheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mugScheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mugScheme.InitialImage = null;
            this.mugScheme.Location = new System.Drawing.Point(322, 12);
            this.mugScheme.Name = "mugScheme";
            this.mugScheme.Size = new System.Drawing.Size(319, 327);
            this.mugScheme.TabIndex = 2;
            this.mugScheme.TabStop = false;
            // 
            // build
            // 
            this.build.Location = new System.Drawing.Point(322, 384);
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(319, 33);
            this.build.TabIndex = 26;
            this.build.Text = "Build";
            this.build.UseVisualStyleBackColor = true;
            this.build.Click += new System.EventHandler(this.Build);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 444);
            this.Controls.Add(this.build);
            this.Controls.Add(this.mugScheme);
            this.Controls.Add(this.DefaultParameters);
            this.Controls.Add(this.MugParameters);
            this.MaximumSize = new System.Drawing.Size(669, 483);
            this.MinimumSize = new System.Drawing.Size(669, 483);
            this.Name = "MainForm";
            this.Text = "MugPlugin";
            this.Load += new System.EventHandler(this.SetDefaultParameters);
            this.MugParameters.ResumeLayout(false);
            this.MugParameters.PerformLayout();
            this.DefaultParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mugScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MugParameters;
        private System.Windows.Forms.Label heightRangeLabel;
        private System.Windows.Forms.Label handleLengthRangeLabel;
        private System.Windows.Forms.Label handleDiameterRangeLabel;
        private System.Windows.Forms.Label thicknessRangeLabel;
        private System.Windows.Forms.Label handleLengthLabel;
        private System.Windows.Forms.Label handleDiameterLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label thicknessLabel;
        private System.Windows.Forms.Label diameterRangeLabel;
        private System.Windows.Forms.Label diameterLabel;
        private System.Windows.Forms.TextBox handleDiameter;
        private System.Windows.Forms.TextBox handleLength;
        private System.Windows.Forms.TextBox thickness;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox diameter;
        private System.Windows.Forms.GroupBox DefaultParameters;
        private System.Windows.Forms.Button setParametersAvg;
        private System.Windows.Forms.Button setParametersMin;
        private System.Windows.Forms.Button setParametersMax;
        private System.Windows.Forms.PictureBox mugScheme;
        private System.Windows.Forms.Button build;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label pocketHeightRangeLabel;
        private System.Windows.Forms.Label pocketHeightLabel;
        private System.Windows.Forms.TextBox pocketHeight;
    }
}


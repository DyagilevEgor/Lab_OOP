namespace View
{
    partial class SearchFigureForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBoxRectangle = new System.Windows.Forms.CheckBox();
            this.CheckBoxTriangle = new System.Windows.Forms.CheckBox();
            this.CheckBoxCircle = new System.Windows.Forms.CheckBox();
            this.CheckBoxVolume = new System.Windows.Forms.CheckBox();
            this.TextBoxVolume = new System.Windows.Forms.TextBox();
            this.ButtonShowFigure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxVolume);
            this.groupBox1.Controls.Add(this.CheckBoxVolume);
            this.groupBox1.Controls.Add(this.CheckBoxCircle);
            this.groupBox1.Controls.Add(this.CheckBoxTriangle);
            this.groupBox1.Controls.Add(this.CheckBoxRectangle);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Найти фигуру";
            // 
            // CheckBoxRectangle
            // 
            this.CheckBoxRectangle.AutoSize = true;
            this.CheckBoxRectangle.Location = new System.Drawing.Point(7, 20);
            this.CheckBoxRectangle.Name = "CheckBoxRectangle";
            this.CheckBoxRectangle.Size = new System.Drawing.Size(106, 17);
            this.CheckBoxRectangle.TabIndex = 0;
            this.CheckBoxRectangle.Text = "Прямоугольник";
            this.CheckBoxRectangle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxTriangle
            // 
            this.CheckBoxTriangle.AutoSize = true;
            this.CheckBoxTriangle.Location = new System.Drawing.Point(6, 43);
            this.CheckBoxTriangle.Name = "CheckBoxTriangle";
            this.CheckBoxTriangle.Size = new System.Drawing.Size(91, 17);
            this.CheckBoxTriangle.TabIndex = 0;
            this.CheckBoxTriangle.Text = "Треугольник";
            this.CheckBoxTriangle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxCircle
            // 
            this.CheckBoxCircle.AutoSize = true;
            this.CheckBoxCircle.Location = new System.Drawing.Point(6, 66);
            this.CheckBoxCircle.Name = "CheckBoxCircle";
            this.CheckBoxCircle.Size = new System.Drawing.Size(49, 17);
            this.CheckBoxCircle.TabIndex = 0;
            this.CheckBoxCircle.Text = "Круг";
            this.CheckBoxCircle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxVolume
            // 
            this.CheckBoxVolume.AutoSize = true;
            this.CheckBoxVolume.Location = new System.Drawing.Point(6, 89);
            this.CheckBoxVolume.Name = "CheckBoxVolume";
            this.CheckBoxVolume.Size = new System.Drawing.Size(89, 17);
            this.CheckBoxVolume.TabIndex = 0;
            this.CheckBoxVolume.Text = "С площадью";
            this.CheckBoxVolume.UseVisualStyleBackColor = true;
            // 
            // TextBoxVolume
            // 
            this.TextBoxVolume.Location = new System.Drawing.Point(102, 89);
            this.TextBoxVolume.Name = "TextBoxVolume";
            this.TextBoxVolume.Size = new System.Drawing.Size(56, 20);
            this.TextBoxVolume.TabIndex = 1;
            // 
            // ButtonShowFigure
            // 
            this.ButtonShowFigure.Location = new System.Drawing.Point(12, 142);
            this.ButtonShowFigure.Name = "ButtonShowFigure";
            this.ButtonShowFigure.Size = new System.Drawing.Size(164, 23);
            this.ButtonShowFigure.TabIndex = 1;
            this.ButtonShowFigure.Text = "Показать";
            this.ButtonShowFigure.UseVisualStyleBackColor = true;
            this.ButtonShowFigure.Click += new System.EventHandler(this.ButtonShowFigure_Click);
            // 
            // SearchFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 173);
            this.Controls.Add(this.ButtonShowFigure);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchFigureForm";
            this.Text = "Поиск";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckBoxVolume;
        private System.Windows.Forms.CheckBox CheckBoxCircle;
        private System.Windows.Forms.CheckBox CheckBoxTriangle;
        private System.Windows.Forms.CheckBox CheckBoxRectangle;
        private System.Windows.Forms.TextBox TextBoxVolume;
        private System.Windows.Forms.Button ButtonShowFigure;
    }
}
namespace View
{
    partial class MainForm
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
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.comboBoxFigure = new System.Windows.Forms.ComboBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.flowLayoutPanelInputs = new System.Windows.Forms.FlowLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(17, 101);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 3;
            this.buttonCalculate.Text = "Рассчитать";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            // 
            // comboBoxFigure
            // 
            this.comboBoxFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFigure.FormattingEnabled = true;
            this.comboBoxFigure.Location = new System.Drawing.Point(21, 22);
            this.comboBoxFigure.Name = "comboBoxFigure";
            this.comboBoxFigure.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFigure.TabIndex = 0;
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(129, 106);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(57, 13);
            this.labelResult.TabIndex = 5;
            this.labelResult.Text = "Площадь:";
            // 
            // flowLayoutPanelInputs
            // 
            this.flowLayoutPanelInputs.Location = new System.Drawing.Point(188, 22);
            this.flowLayoutPanelInputs.Name = "flowLayoutPanelInputs";
            this.flowLayoutPanelInputs.Size = new System.Drawing.Size(196, 79);
            this.flowLayoutPanelInputs.TabIndex = 6;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 128);
            this.Controls.Add(this.flowLayoutPanelInputs);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.comboBoxFigure);
            this.Controls.Add(this.buttonCalculate);
            this.Name = "MainForm";
            this.Text = "Расчет площади фигур";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.ComboBox comboBoxFigure;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInputs;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
namespace View
{
    partial class Main
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripDropDownButtonFile = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataFigureView = new System.Windows.Forms.DataGridView();
            this.AddFigureButton = new System.Windows.Forms.Button();
            this.DeleteFugureButton = new System.Windows.Forms.Button();
            this.RandomFigureButton = new System.Windows.Forms.Button();
            this.SearchFigureButton = new System.Windows.Forms.Button();
            this.DropFilterButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataFigureView)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripDropDownButtonFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(396, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripDropDownButtonFile
            // 
            this.ToolStripDropDownButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.ToolStripDropDownButtonFile.Name = "ToolStripDropDownButtonFile";
            this.ToolStripDropDownButtonFile.Size = new System.Drawing.Size(48, 20);
            this.ToolStripDropDownButtonFile.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataFigureView);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 189);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список фигур";
            // 
            // DataFigureView
            // 
            this.DataFigureView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataFigureView.Location = new System.Drawing.Point(6, 21);
            this.DataFigureView.Name = "DataFigureView";
            this.DataFigureView.Size = new System.Drawing.Size(360, 150);
            this.DataFigureView.TabIndex = 0;
            // 
            // AddFigureButton
            // 
            this.AddFigureButton.Location = new System.Drawing.Point(18, 224);
            this.AddFigureButton.Name = "AddFigureButton";
            this.AddFigureButton.Size = new System.Drawing.Size(117, 23);
            this.AddFigureButton.TabIndex = 3;
            this.AddFigureButton.Text = "Добавить";
            this.AddFigureButton.UseVisualStyleBackColor = true;
            // 
            // DeleteFugureButton
            // 
            this.DeleteFugureButton.Location = new System.Drawing.Point(141, 224);
            this.DeleteFugureButton.Name = "DeleteFugureButton";
            this.DeleteFugureButton.Size = new System.Drawing.Size(117, 23);
            this.DeleteFugureButton.TabIndex = 3;
            this.DeleteFugureButton.Text = "Удалить";
            this.DeleteFugureButton.UseVisualStyleBackColor = true;
            // 
            // RandomFigureButton
            // 
            this.RandomFigureButton.Location = new System.Drawing.Point(264, 224);
            this.RandomFigureButton.Name = "RandomFigureButton";
            this.RandomFigureButton.Size = new System.Drawing.Size(117, 23);
            this.RandomFigureButton.TabIndex = 3;
            this.RandomFigureButton.Text = "Случайная фигура";
            this.RandomFigureButton.UseVisualStyleBackColor = true;
            // 
            // SearchFigureButton
            // 
            this.SearchFigureButton.Location = new System.Drawing.Point(18, 253);
            this.SearchFigureButton.Name = "SearchFigureButton";
            this.SearchFigureButton.Size = new System.Drawing.Size(117, 23);
            this.SearchFigureButton.TabIndex = 3;
            this.SearchFigureButton.Text = "Найти";
            this.SearchFigureButton.UseVisualStyleBackColor = true;
            // 
            // DropFilterButton
            // 
            this.DropFilterButton.Location = new System.Drawing.Point(141, 253);
            this.DropFilterButton.Name = "DropFilterButton";
            this.DropFilterButton.Size = new System.Drawing.Size(117, 23);
            this.DropFilterButton.TabIndex = 3;
            this.DropFilterButton.Text = "Сбросить фильтр";
            this.DropFilterButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 285);
            this.Controls.Add(this.DropFilterButton);
            this.Controls.Add(this.SearchFigureButton);
            this.Controls.Add(this.RandomFigureButton);
            this.Controls.Add(this.DeleteFugureButton);
            this.Controls.Add(this.AddFigureButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataFigureView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripDropDownButtonFile;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DataFigureView;
        private System.Windows.Forms.Button AddFigureButton;
        private System.Windows.Forms.Button DeleteFugureButton;
        private System.Windows.Forms.Button RandomFigureButton;
        private System.Windows.Forms.Button SearchFigureButton;
        private System.Windows.Forms.Button DropFilterButton;
    }
}
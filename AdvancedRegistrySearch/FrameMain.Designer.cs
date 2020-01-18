namespace AdvancedRegistrySearch
{
    partial class FrameMain
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
            this.listSearch = new System.Windows.Forms.ListView();
            this.columnKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listSearch
            // 
            this.listSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnKey,
            this.columnValue});
            this.listSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSearch.FullRowSelect = true;
            this.listSearch.GridLines = true;
            this.listSearch.HideSelection = false;
            this.listSearch.Location = new System.Drawing.Point(0, 90);
            this.listSearch.Name = "listSearch";
            this.listSearch.Size = new System.Drawing.Size(2222, 1290);
            this.listSearch.TabIndex = 2;
            this.listSearch.UseCompatibleStateImageBehavior = false;
            this.listSearch.View = System.Windows.Forms.View.Details;
            this.listSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listSearch_MouseDoubleClick);
            // 
            // columnKey
            // 
            this.columnKey.Text = "Key";
            this.columnKey.Width = 1006;
            // 
            // columnValue
            // 
            this.columnValue.Text = "Value";
            this.columnValue.Width = 1057;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.textSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2222, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Query";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(2101, 28);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(109, 39);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(12, 34);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(2071, 26);
            this.textSearch.TabIndex = 5;
            // 
            // FrameMain
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2222, 1380);
            this.Controls.Add(this.listSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrameMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Registry Search";
            this.Shown += new System.EventHandler(this.FrameMain_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listSearch;
        private System.Windows.Forms.ColumnHeader columnKey;
        private System.Windows.Forms.ColumnHeader columnValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textSearch;
    }
}


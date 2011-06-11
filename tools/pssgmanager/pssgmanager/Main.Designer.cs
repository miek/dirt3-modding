namespace PSSGManager {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitAllVertical = new System.Windows.Forms.SplitContainer();
			this.treeView = new System.Windows.Forms.TreeView();
			this.dataGridViewAttributes = new System.Windows.Forms.DataGridView();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabAll = new System.Windows.Forms.TabPage();
			this.splitAllHorizontal = new System.Windows.Forms.SplitContainer();
			this.buttonExportAll = new System.Windows.Forms.Button();
			this.tabModels = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabTextures = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeViewTextures = new System.Windows.Forms.TreeView();
			this.pictureBoxTextures = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.splitAllVertical.Panel1.SuspendLayout();
			this.splitAllVertical.Panel2.SuspendLayout();
			this.splitAllVertical.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabAll.SuspendLayout();
			this.splitAllHorizontal.Panel1.SuspendLayout();
			this.splitAllHorizontal.Panel2.SuspendLayout();
			this.splitAllHorizontal.SuspendLayout();
			this.tabModels.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabTextures.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTextures)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(724, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.openToolStripMenuItem,
			this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// splitAllVertical
			// 
			this.splitAllVertical.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitAllVertical.Location = new System.Drawing.Point(0, 0);
			this.splitAllVertical.Name = "splitAllVertical";
			// 
			// splitAllVertical.Panel1
			// 
			this.splitAllVertical.Panel1.Controls.Add(this.treeView);
			// 
			// splitAllVertical.Panel2
			// 
			this.splitAllVertical.Panel2.Controls.Add(this.dataGridViewAttributes);
			this.splitAllVertical.Size = new System.Drawing.Size(710, 309);
			this.splitAllVertical.SplitterDistance = 235;
			this.splitAllVertical.TabIndex = 1;
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.Size = new System.Drawing.Size(235, 309);
			this.treeView.TabIndex = 0;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
			// 
			// dataGridViewAttributes
			// 
			this.dataGridViewAttributes.AllowUserToAddRows = false;
			this.dataGridViewAttributes.AllowUserToDeleteRows = false;
			this.dataGridViewAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ColumnName,
			this.ColumnValue});
			this.dataGridViewAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewAttributes.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewAttributes.Name = "dataGridViewAttributes";
			this.dataGridViewAttributes.ReadOnly = true;
			this.dataGridViewAttributes.Size = new System.Drawing.Size(471, 309);
			this.dataGridViewAttributes.TabIndex = 0;
			// 
			// ColumnName
			// 
			this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnName.HeaderText = "Name";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.ReadOnly = true;
			// 
			// ColumnValue
			// 
			this.ColumnValue.HeaderText = "Value";
			this.ColumnValue.Name = "ColumnValue";
			this.ColumnValue.ReadOnly = true;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabAll);
			this.tabControl.Controls.Add(this.tabModels);
			this.tabControl.Controls.Add(this.tabTextures);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 24);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(724, 376);
			this.tabControl.TabIndex = 2;
			// 
			// tabAll
			// 
			this.tabAll.Controls.Add(this.splitAllHorizontal);
			this.tabAll.Location = new System.Drawing.Point(4, 22);
			this.tabAll.Name = "tabAll";
			this.tabAll.Padding = new System.Windows.Forms.Padding(3);
			this.tabAll.Size = new System.Drawing.Size(716, 350);
			this.tabAll.TabIndex = 0;
			this.tabAll.Text = "All";
			this.tabAll.UseVisualStyleBackColor = true;
			// 
			// splitAllHorizontal
			// 
			this.splitAllHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitAllHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitAllHorizontal.IsSplitterFixed = true;
			this.splitAllHorizontal.Location = new System.Drawing.Point(3, 3);
			this.splitAllHorizontal.Name = "splitAllHorizontal";
			this.splitAllHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitAllHorizontal.Panel1
			// 
			this.splitAllHorizontal.Panel1.Controls.Add(this.splitAllVertical);
			// 
			// splitAllHorizontal.Panel2
			// 
			this.splitAllHorizontal.Panel2.Controls.Add(this.buttonExportAll);
			this.splitAllHorizontal.Size = new System.Drawing.Size(710, 344);
			this.splitAllHorizontal.SplitterDistance = 309;
			this.splitAllHorizontal.TabIndex = 1;
			// 
			// buttonExportAll
			// 
			this.buttonExportAll.Location = new System.Drawing.Point(5, 3);
			this.buttonExportAll.Name = "buttonExportAll";
			this.buttonExportAll.Size = new System.Drawing.Size(88, 23);
			this.buttonExportAll.TabIndex = 2;
			this.buttonExportAll.Text = "Export to XML";
			this.buttonExportAll.UseVisualStyleBackColor = true;
			this.buttonExportAll.Click += new System.EventHandler(this.buttonExportAll_Click);
			// 
			// tabModels
			// 
			this.tabModels.Controls.Add(this.splitContainer2);
			this.tabModels.Location = new System.Drawing.Point(4, 22);
			this.tabModels.Name = "tabModels";
			this.tabModels.Padding = new System.Windows.Forms.Padding(3);
			this.tabModels.Size = new System.Drawing.Size(716, 350);
			this.tabModels.TabIndex = 1;
			this.tabModels.Text = "Models";
			this.tabModels.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listBox1);
			this.splitContainer2.Size = new System.Drawing.Size(710, 344);
			this.splitContainer2.SplitterDistance = 235;
			this.splitContainer2.TabIndex = 0;
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(235, 344);
			this.listBox1.TabIndex = 0;
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// tabTextures
			// 
			this.tabTextures.Controls.Add(this.splitContainer1);
			this.tabTextures.Location = new System.Drawing.Point(4, 22);
			this.tabTextures.Name = "tabTextures";
			this.tabTextures.Padding = new System.Windows.Forms.Padding(3);
			this.tabTextures.Size = new System.Drawing.Size(716, 350);
			this.tabTextures.TabIndex = 2;
			this.tabTextures.Text = "Textures";
			this.tabTextures.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeViewTextures);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pictureBoxTextures);
			this.splitContainer1.Size = new System.Drawing.Size(710, 344);
			this.splitContainer1.SplitterDistance = 235;
			this.splitContainer1.TabIndex = 1;
			// 
			// treeViewTextures
			// 
			this.treeViewTextures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewTextures.Location = new System.Drawing.Point(0, 0);
			this.treeViewTextures.Name = "treeViewTextures";
			this.treeViewTextures.Size = new System.Drawing.Size(235, 344);
			this.treeViewTextures.TabIndex = 0;
			this.treeViewTextures.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTextures_AfterSelect);
			// 
			// pictureBoxTextures
			// 
			this.pictureBoxTextures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxTextures.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxTextures.Name = "pictureBoxTextures";
			this.pictureBoxTextures.Size = new System.Drawing.Size(471, 344);
			this.pictureBoxTextures.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxTextures.TabIndex = 0;
			this.pictureBoxTextures.TabStop = false;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 400);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.Text = "PSSG Manager";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitAllVertical.Panel1.ResumeLayout(false);
			this.splitAllVertical.Panel2.ResumeLayout(false);
			this.splitAllVertical.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttributes)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabAll.ResumeLayout(false);
			this.splitAllHorizontal.Panel1.ResumeLayout(false);
			this.splitAllHorizontal.Panel2.ResumeLayout(false);
			this.splitAllHorizontal.ResumeLayout(false);
			this.tabModels.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.tabTextures.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTextures)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitAllVertical;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.DataGridView dataGridViewAttributes;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabAll;
		private System.Windows.Forms.TabPage tabModels;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
		private System.Windows.Forms.SplitContainer splitAllHorizontal;
		private System.Windows.Forms.Button buttonExportAll;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.TabPage tabTextures;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeViewTextures;
		private System.Windows.Forms.PictureBox pictureBoxTextures;
	}
}


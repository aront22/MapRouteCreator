
namespace MapRouteCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDistance = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txbNodes = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txbLines = new System.Windows.Forms.ToolStripTextBox();
            this.btnRandom = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.btnDistance});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem,
            this.exportToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // btnDistance
            // 
            this.btnDistance.Name = "btnDistance";
            this.btnDistance.Size = new System.Drawing.Size(92, 20);
            this.btnDistance.Text = "Hide Distance";
            this.btnDistance.Click += new System.EventHandler(this.btnDistance_Click);
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.importToolStripMenuItem1.Text = "Import";
            this.importToolStripMenuItem1.Click += new System.EventHandler(this.importToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click_1);
            // 
            // exportToFileToolStripMenuItem
            // 
            this.exportToFileToolStripMenuItem.Name = "exportToFileToolStripMenuItem";
            this.exportToFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportToFileToolStripMenuItem.Text = "Export to File";
            this.exportToFileToolStripMenuItem.Click += new System.EventHandler(this.exportToFileToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txbNodes,
            this.toolStripLabel2,
            this.txbLines,
            this.btnRandom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txbNodes
            // 
            this.txbNodes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbNodes.Name = "txbNodes";
            this.txbNodes.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel1.Text = "Nodes: ";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabel2.Text = "Lines: ";
            // 
            // txbLines
            // 
            this.txbLines.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbLines.Name = "txbLines";
            this.txbLines.Size = new System.Drawing.Size(100, 25);
            // 
            // btnRandom
            // 
            this.btnRandom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRandom.Image = ((System.Drawing.Image)(resources.GetObject("btnRandom.Image")));
            this.btnRandom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(106, 22);
            this.btnRandom.Text = "Generate Random";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Map";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDistance;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txbNodes;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txbLines;
        private System.Windows.Forms.ToolStripButton btnRandom;
    }
}


namespace Timekeeper.Forms.Shared
{
    partial class TreeAttributeManager
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeAttributeManager));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuNew = new System.Windows.Forms.ToolStripButton();
            this.MenuNewFolder = new System.Windows.Forms.ToolStripButton();
            this.MenuEdit = new System.Windows.Forms.ToolStripButton();
            this.MenuOther = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.Tree = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNew,
            this.MenuNewFolder,
            this.MenuEdit,
            this.MenuOther,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(350, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MenuNew
            // 
            this.MenuNew.Image = global::Timekeeper.Properties.Resources.ImageButtonNew;
            this.MenuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuNew.Name = "MenuNew";
            this.MenuNew.Size = new System.Drawing.Size(48, 22);
            this.MenuNew.Text = "New";
            this.MenuNew.Click += new System.EventHandler(this.MenuNew_Click);
            // 
            // MenuNewFolder
            // 
            this.MenuNewFolder.Image = global::Timekeeper.Properties.Resources.ImageIconSmallFolder;
            this.MenuNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuNewFolder.Name = "MenuNewFolder";
            this.MenuNewFolder.Size = new System.Drawing.Size(81, 22);
            this.MenuNewFolder.Text = "New Folder";
            this.MenuNewFolder.Click += new System.EventHandler(this.MenuNewFolder_Click);
            // 
            // MenuEdit
            // 
            this.MenuEdit.Image = global::Timekeeper.Properties.Resources.ImageIconSmallProject;
            this.MenuEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEdit.Name = "MenuEdit";
            this.MenuEdit.Size = new System.Drawing.Size(45, 22);
            this.MenuEdit.Text = "Edit";
            this.MenuEdit.Click += new System.EventHandler(this.MenuEdit_Click);
            // 
            // MenuOther
            // 
            this.MenuOther.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRename,
            this.MenuHide,
            this.MenuUnhide,
            this.MenuMerge,
            this.MenuDelete,
            this.MenuSep1,
            this.MenuProperties});
            this.MenuOther.Image = ((System.Drawing.Image)(resources.GetObject("MenuOther.Image")));
            this.MenuOther.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuOther.Name = "MenuOther";
            this.MenuOther.Size = new System.Drawing.Size(48, 22);
            this.MenuOther.Text = "Other";
            // 
            // MenuRename
            // 
            this.MenuRename.Name = "MenuRename";
            this.MenuRename.Size = new System.Drawing.Size(123, 22);
            this.MenuRename.Text = "Rename";
            this.MenuRename.Click += new System.EventHandler(this.MenuRename_Click);
            // 
            // MenuHide
            // 
            this.MenuHide.Name = "MenuHide";
            this.MenuHide.Size = new System.Drawing.Size(123, 22);
            this.MenuHide.Text = "Hide";
            // 
            // MenuUnhide
            // 
            this.MenuUnhide.Name = "MenuUnhide";
            this.MenuUnhide.Size = new System.Drawing.Size(123, 22);
            this.MenuUnhide.Text = "Unhide";
            // 
            // MenuMerge
            // 
            this.MenuMerge.Name = "MenuMerge";
            this.MenuMerge.Size = new System.Drawing.Size(123, 22);
            this.MenuMerge.Text = "Merge";
            // 
            // MenuDelete
            // 
            this.MenuDelete.Name = "MenuDelete";
            this.MenuDelete.Size = new System.Drawing.Size(123, 22);
            this.MenuDelete.Text = "Delete";
            // 
            // MenuSep1
            // 
            this.MenuSep1.Name = "MenuSep1";
            this.MenuSep1.Size = new System.Drawing.Size(120, 6);
            // 
            // MenuProperties
            // 
            this.MenuProperties.Name = "MenuProperties";
            this.MenuProperties.Size = new System.Drawing.Size(123, 22);
            this.MenuProperties.Text = "Properties";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton1.Text = "Close";
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuNew,
            this.PopupMenuNewFolder,
            this.PopupMenuEdit,
            this.PopupMenuRename,
            this.PopupMenuMerge,
            this.PopupMenuHide,
            this.PopupMenuUnhide,
            this.PopupMenuDelete,
            this.PopupMenuSep1,
            this.PopupMenuProperties});
            this.PopupMenu.Name = "menuTask";
            this.PopupMenu.Size = new System.Drawing.Size(141, 208);
            // 
            // PopupMenuNew
            // 
            this.PopupMenuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PopupMenuNew.Name = "PopupMenuNew";
            this.PopupMenuNew.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuNew.Text = "&New...";
            this.PopupMenuNew.Click += new System.EventHandler(this.MenuNew_Click);
            // 
            // PopupMenuNewFolder
            // 
            this.PopupMenuNewFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PopupMenuNewFolder.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.PopupMenuNewFolder.Name = "PopupMenuNewFolder";
            this.PopupMenuNewFolder.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuNewFolder.Text = "New &Folder...";
            this.PopupMenuNewFolder.Click += new System.EventHandler(this.MenuNewFolder_Click);
            // 
            // PopupMenuEdit
            // 
            this.PopupMenuEdit.Name = "PopupMenuEdit";
            this.PopupMenuEdit.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuEdit.Text = "&Edit...";
            // 
            // PopupMenuRename
            // 
            this.PopupMenuRename.Name = "PopupMenuRename";
            this.PopupMenuRename.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuRename.Text = "&Rename";
            // 
            // PopupMenuMerge
            // 
            this.PopupMenuMerge.Name = "PopupMenuMerge";
            this.PopupMenuMerge.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuMerge.Text = "Merge...";
            // 
            // PopupMenuHide
            // 
            this.PopupMenuHide.Name = "PopupMenuHide";
            this.PopupMenuHide.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuHide.Text = "&Hide";
            // 
            // PopupMenuUnhide
            // 
            this.PopupMenuUnhide.Name = "PopupMenuUnhide";
            this.PopupMenuUnhide.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuUnhide.Text = "Un&hide";
            this.PopupMenuUnhide.Visible = false;
            // 
            // PopupMenuDelete
            // 
            this.PopupMenuDelete.Name = "PopupMenuDelete";
            this.PopupMenuDelete.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuDelete.Text = "&Delete...";
            // 
            // PopupMenuSep1
            // 
            this.PopupMenuSep1.Name = "PopupMenuSep1";
            this.PopupMenuSep1.Size = new System.Drawing.Size(137, 6);
            // 
            // PopupMenuProperties
            // 
            this.PopupMenuProperties.Name = "PopupMenuProperties";
            this.PopupMenuProperties.Size = new System.Drawing.Size(140, 22);
            this.PopupMenuProperties.Text = "&Properties...";
            this.PopupMenuProperties.Click += new System.EventHandler(this.PopupMenuProperties_Click);
            // 
            // TreeImageList
            // 
            this.TreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImageList.ImageStream")));
            this.TreeImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.TreeImageList.Images.SetKeyName(0, "OpenFolder");
            this.TreeImageList.Images.SetKeyName(1, "ClosedFolder");
            this.TreeImageList.Images.SetKeyName(2, "Project");
            this.TreeImageList.Images.SetKeyName(3, "Activity");
            this.TreeImageList.Images.SetKeyName(4, "HiddenItem");
            this.TreeImageList.Images.SetKeyName(5, "HiddenFolder");
            // 
            // Tree
            // 
            this.Tree.AllowDrop = true;
            this.Tree.ContextMenuStrip = this.PopupMenu;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.HideSelection = false;
            this.Tree.ImageIndex = 1;
            this.Tree.ImageList = this.TreeImageList;
            this.Tree.LabelEdit = true;
            this.Tree.Location = new System.Drawing.Point(0, 25);
            this.Tree.Name = "Tree";
            this.Tree.SelectedImageIndex = 0;
            this.Tree.ShowLines = false;
            this.Tree.ShowNodeToolTips = true;
            this.Tree.Size = new System.Drawing.Size(350, 217);
            this.Tree.TabIndex = 3;
            this.Tree.Tag = "Project";
            this.Tree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.Tree_AfterLabelEdit);
            this.Tree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tree_KeyDown);
            // 
            // TreeAttributeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 242);
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.toolStrip1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreeAttributeManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TreeAttributeManager";
            this.Load += new System.EventHandler(this.TreeAttributeManager_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MenuNew;
        private System.Windows.Forms.ToolStripButton MenuNewFolder;
        private System.Windows.Forms.ToolStripButton MenuEdit;
        private System.Windows.Forms.ToolStripDropDownButton MenuOther;
        private System.Windows.Forms.ToolStripMenuItem MenuMerge;
        private System.Windows.Forms.ToolStripMenuItem MenuHide;
        private System.Windows.Forms.ToolStripMenuItem MenuUnhide;
        private System.Windows.Forms.ToolStripMenuItem MenuDelete;
        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuNew;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuNewFolder;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuRename;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuMerge;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuHide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuUnhide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuDelete;
        private System.Windows.Forms.ToolStripSeparator PopupMenuSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuProperties;
        public System.Windows.Forms.ImageList TreeImageList;
        private System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem MenuRename;
        private System.Windows.Forms.ToolStripSeparator MenuSep1;
        private System.Windows.Forms.ToolStripMenuItem MenuProperties;
    }
}
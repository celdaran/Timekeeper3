namespace Timekeeper
{
    partial class fItem
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wGroupAttributes = new System.Windows.Forms.GroupBox();
            this.wParent = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wNodeDescription = new System.Windows.Forms.TextBox();
            this.wNodeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wGroupAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(156, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(237, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wGroupAttributes
            // 
            this.wGroupAttributes.Controls.Add(this.wParent);
            this.wGroupAttributes.Controls.Add(this.label3);
            this.wGroupAttributes.Controls.Add(this.wNodeDescription);
            this.wGroupAttributes.Controls.Add(this.wNodeName);
            this.wGroupAttributes.Controls.Add(this.label2);
            this.wGroupAttributes.Controls.Add(this.label1);
            this.wGroupAttributes.Location = new System.Drawing.Point(12, 12);
            this.wGroupAttributes.Name = "wGroupAttributes";
            this.wGroupAttributes.Size = new System.Drawing.Size(300, 162);
            this.wGroupAttributes.TabIndex = 0;
            this.wGroupAttributes.TabStop = false;
            this.wGroupAttributes.Text = "Attributes";
            this.wGroupAttributes.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wParent
            // 
            this.wParent.FormattingEnabled = true;
            this.wParent.Location = new System.Drawing.Point(85, 85);
            this.wParent.Name = "wParent";
            this.wParent.Size = new System.Drawing.Size(185, 69);
            this.wParent.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "In &Folder";
            // 
            // wNodeDescription
            // 
            this.wNodeDescription.Location = new System.Drawing.Point(85, 55);
            this.wNodeDescription.Name = "wNodeDescription";
            this.wNodeDescription.Size = new System.Drawing.Size(185, 20);
            this.wNodeDescription.TabIndex = 4;
            // 
            // wNodeName
            // 
            this.wNodeName.Location = new System.Drawing.Point(85, 28);
            this.wNodeName.Name = "wNodeName";
            this.wNodeName.Size = new System.Drawing.Size(185, 20);
            this.wNodeName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Name";
            // 
            // fItem
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 215);
            this.Controls.Add(this.wGroupAttributes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Node";
            this.Load += new System.EventHandler(this.fNode_Load);
            this.wGroupAttributes.ResumeLayout(false);
            this.wGroupAttributes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox wGroupAttributes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox wNodeName;
        internal System.Windows.Forms.TextBox wNodeDescription;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ListBox wParent;
    }
}
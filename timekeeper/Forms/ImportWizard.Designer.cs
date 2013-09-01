namespace Timekeeper.Forms
{
    partial class ImportWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWizard));
            this.label1 = new System.Windows.Forms.Label();
            this.ImportFileName = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.ImportProgress = new System.Windows.Forms.ProgressBar();
            this.ImportProjects = new System.Windows.Forms.CheckBox();
            this.ImportEntries = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(236, 168);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // ImportFileName
            // 
            this.ImportFileName.Location = new System.Drawing.Point(254, 12);
            this.ImportFileName.Name = "ImportFileName";
            this.ImportFileName.Size = new System.Drawing.Size(411, 20);
            this.ImportFileName.TabIndex = 1;
            this.ImportFileName.Text = "C:\\Users\\hillsc\\Projects\\timekeeper\\testing\\3.0\\timekeeper";
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(254, 38);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.SystemColors.WindowText;
            this.Console.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Console.ForeColor = System.Drawing.Color.Lime;
            this.Console.Location = new System.Drawing.Point(12, 216);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(777, 247);
            this.Console.TabIndex = 3;
            this.Console.Text = "";
            // 
            // ImportProgress
            // 
            this.ImportProgress.Location = new System.Drawing.Point(304, 154);
            this.ImportProgress.Name = "ImportProgress";
            this.ImportProgress.Size = new System.Drawing.Size(315, 23);
            this.ImportProgress.TabIndex = 4;
            // 
            // ImportProjects
            // 
            this.ImportProjects.AutoSize = true;
            this.ImportProjects.Location = new System.Drawing.Point(273, 82);
            this.ImportProjects.Name = "ImportProjects";
            this.ImportProjects.Size = new System.Drawing.Size(96, 17);
            this.ImportProjects.TabIndex = 5;
            this.ImportProjects.Text = "Import Projects";
            this.ImportProjects.UseVisualStyleBackColor = true;
            // 
            // ImportEntries
            // 
            this.ImportEntries.AutoSize = true;
            this.ImportEntries.Location = new System.Drawing.Point(273, 105);
            this.ImportEntries.Name = "ImportEntries";
            this.ImportEntries.Size = new System.Drawing.Size(90, 17);
            this.ImportEntries.TabIndex = 6;
            this.ImportEntries.Text = "Import Entries";
            this.ImportEntries.UseVisualStyleBackColor = true;
            // 
            // ImportWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 471);
            this.Controls.Add(this.ImportEntries);
            this.Controls.Add(this.ImportProjects);
            this.Controls.Add(this.ImportProgress);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ImportFileName);
            this.Controls.Add(this.label1);
            this.Name = "ImportWizard";
            this.Text = "Import";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImportWizard_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImportFileName;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.ProgressBar ImportProgress;
        private System.Windows.Forms.CheckBox ImportProjects;
        private System.Windows.Forms.CheckBox ImportEntries;
    }
}
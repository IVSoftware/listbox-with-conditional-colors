namespace listbox_with_conditional_colors
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonMockQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 30;
            this.listBox.Location = new System.Drawing.Point(25, 8);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(394, 184);
            this.listBox.TabIndex = 0;
            // 
            // buttonMockQuery
            // 
            this.buttonMockQuery.Location = new System.Drawing.Point(195, 198);
            this.buttonMockQuery.Name = "buttonMockQuery";
            this.buttonMockQuery.Size = new System.Drawing.Size(224, 34);
            this.buttonMockQuery.TabIndex = 1;
            this.buttonMockQuery.Text = "Mock Query";
            this.buttonMockQuery.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 244);
            this.Controls.Add(this.buttonMockQuery);
            this.Controls.Add(this.listBox);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonMockQuery;
    }
}

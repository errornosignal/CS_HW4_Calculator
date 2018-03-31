using System.Windows.Forms;

namespace CS_HW4_Calculator
{
    partial class Form2
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
            this.HistoryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // HistoryRichTextBox
            // 
            this.HistoryRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.HistoryRichTextBox.Name = "HistoryRichTextBox";
            this.HistoryRichTextBox.ReadOnly = true;
            this.HistoryRichTextBox.Size = new System.Drawing.Size(292, 382);
            this.HistoryRichTextBox.TabIndex = 0;
            this.HistoryRichTextBox.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 382);
            this.Controls.Add(this.HistoryRichTextBox);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "History";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox HistoryRichTextBox;
    }
}
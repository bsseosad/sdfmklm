namespace PREINSPECTION
{
    partial class PartSearch
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
            this.CheckButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(351, 373);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(75, 23);
            this.CheckButton.TabIndex = 0;
            this.CheckButton.Text = "확인";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.richTextBox1.Location = new System.Drawing.Point(312, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(167, 30);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // PartSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.CheckButton);
            this.Name = "PartSearch";
            this.Text = "PartSearch";
            this.Load += new System.EventHandler(this.PartSearch_Load);
            this.ResumeLayout(false);

        }

        #endregion

       
        private System.Windows.Forms.RichTextBox[] partRichTextBoxList = new System.Windows.Forms.RichTextBox[5];
        private System.Windows.Forms.TextBox[] parttextBoxList = new System.Windows.Forms.TextBox[5];
        private System.Windows.Forms.CheckBox[] CheckBox = new System.Windows.Forms.CheckBox[5];
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
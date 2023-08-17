namespace PREINSPECTION
{
    partial class UpdatePart
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
            this.partGroupSelect = new System.Windows.Forms.ComboBox();
            this.partText = new System.Windows.Forms.TextBox();
            this.barcodeText = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // partGroupSelect
            // 
            this.partGroupSelect.FormattingEnabled = true;
            this.partGroupSelect.Location = new System.Drawing.Point(86, 155);
            this.partGroupSelect.Name = "partGroupSelect";
            this.partGroupSelect.Size = new System.Drawing.Size(121, 23);
            this.partGroupSelect.TabIndex = 0;
            // 
            // partText
            // 
            this.partText.Location = new System.Drawing.Point(253, 153);
            this.partText.Name = "partText";
            this.partText.Size = new System.Drawing.Size(100, 25);
            this.partText.TabIndex = 1;
            // 
            // barcodeText
            // 
            this.barcodeText.Location = new System.Drawing.Point(462, 156);
            this.barcodeText.Name = "barcodeText";
            this.barcodeText.Size = new System.Drawing.Size(100, 25);
            this.barcodeText.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.searchButton.Location = new System.Drawing.Point(372, 157);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "조회";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(582, 158);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "저장";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "부품이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "바코드";
            // 
            // UpdatePart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.barcodeText);
            this.Controls.Add(this.partText);
            this.Controls.Add(this.partGroupSelect);
            this.Name = "UpdatePart";
            this.Text = "UpdateFormcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox partGroupSelect;
        private System.Windows.Forms.TextBox partText;
        private System.Windows.Forms.TextBox barcodeText;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
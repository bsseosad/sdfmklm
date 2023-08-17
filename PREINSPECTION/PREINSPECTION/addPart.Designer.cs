namespace PREINSPECTION
{
    partial class addPart
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
            this.nameText = new System.Windows.Forms.TextBox();
            this.barcodeText = new System.Windows.Forms.TextBox();
            this.insert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // partGroupSelect
            // 
            this.partGroupSelect.FormattingEnabled = true;
            this.partGroupSelect.Location = new System.Drawing.Point(125, 165);
            this.partGroupSelect.Name = "partGroupSelect";
            this.partGroupSelect.Size = new System.Drawing.Size(121, 23);
            this.partGroupSelect.TabIndex = 0;
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(304, 165);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(153, 25);
            this.nameText.TabIndex = 1;
            // 
            // barcodeText
            // 
            this.barcodeText.Location = new System.Drawing.Point(506, 165);
            this.barcodeText.Name = "barcodeText";
            this.barcodeText.Size = new System.Drawing.Size(153, 25);
            this.barcodeText.TabIndex = 2;
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(382, 319);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 23);
            this.insert.TabIndex = 4;
            this.insert.Text = "저장하기";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "부품이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "바코드이름";
            // 
            // addPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.barcodeText);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.partGroupSelect);
            this.Name = "addPart";
            this.Text = "addPart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox partGroupSelect;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.TextBox barcodeText;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
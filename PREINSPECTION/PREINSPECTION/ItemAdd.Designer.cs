namespace PREINSPECTION
{
    partial class ItemAdd
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
            this.itemSelectCombo = new System.Windows.Forms.ComboBox();
            this.itemTextBox = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemSelectCombo
            // 
            this.itemSelectCombo.FormattingEnabled = true;
            this.itemSelectCombo.Location = new System.Drawing.Point(150, 179);
            this.itemSelectCombo.Name = "itemSelectCombo";
            this.itemSelectCombo.Size = new System.Drawing.Size(121, 23);
            this.itemSelectCombo.TabIndex = 0;
            // 
            // itemTextBox
            // 
            this.itemTextBox.Location = new System.Drawing.Point(326, 177);
            this.itemTextBox.Name = "itemTextBox";
            this.itemTextBox.Size = new System.Drawing.Size(100, 25);
            this.itemTextBox.TabIndex = 1;
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(488, 179);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 23);
            this.InsertButton.TabIndex = 2;
            this.InsertButton.Text = "넣기";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(699, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.itemTextBox);
            this.Controls.Add(this.itemSelectCombo);
            this.Name = "ItemAdd";
            this.Text = "itemAdd";
            this.Load += new System.EventHandler(this.ItemAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox itemSelectCombo;
        private System.Windows.Forms.TextBox itemTextBox;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
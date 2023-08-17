namespace PREINSPECTION
{
    partial class itemSelect
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemGroupBox = new System.Windows.Forms.ComboBox();
            this.itemBox = new System.Windows.Forms.ComboBox();
            this.partAdd = new System.Windows.Forms.Button();
            this.updatePart = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.itemAdd = new System.Windows.Forms.Button();
            this.Mapping = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.FormattingEnabled = true;
            this.itemGroupBox.Location = new System.Drawing.Point(91, 140);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(121, 23);
            this.itemGroupBox.TabIndex = 0;
            this.itemGroupBox.SelectedIndexChanged += new System.EventHandler(this.itemGroupBox_SelectedIndexChanged);
            // 
            // itemBox
            // 
            this.itemBox.FormattingEnabled = true;
            this.itemBox.Location = new System.Drawing.Point(242, 140);
            this.itemBox.Name = "itemBox";
            this.itemBox.Size = new System.Drawing.Size(121, 23);
            this.itemBox.TabIndex = 1;
            // 
            // partAdd
            // 
            this.partAdd.Location = new System.Drawing.Point(41, 299);
            this.partAdd.Name = "partAdd";
            this.partAdd.Size = new System.Drawing.Size(117, 25);
            this.partAdd.TabIndex = 2;
            this.partAdd.Text = "부품추가하기";
            this.partAdd.UseVisualStyleBackColor = true;
            this.partAdd.Click += new System.EventHandler(this.partAdd_Click);
            // 
            // updatePart
            // 
            this.updatePart.Location = new System.Drawing.Point(178, 300);
            this.updatePart.Name = "updatePart";
            this.updatePart.Size = new System.Drawing.Size(131, 23);
            this.updatePart.TabIndex = 0;
            this.updatePart.Text = "부품바코드수정";
            this.updatePart.UseVisualStyleBackColor = true;
            this.updatePart.Click += new System.EventHandler(this.updatePart_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(395, 139);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "조회하기";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.partButton_Click);
            // 
            // itemAdd
            // 
            this.itemAdd.Location = new System.Drawing.Point(338, 301);
            this.itemAdd.Name = "itemAdd";
            this.itemAdd.Size = new System.Drawing.Size(114, 23);
            this.itemAdd.TabIndex = 4;
            this.itemAdd.Text = "제품추가하기";
            this.itemAdd.UseVisualStyleBackColor = true;
            this.itemAdd.Click += new System.EventHandler(this.itemAdd_Click);
            // 
            // Mapping
            // 
            this.Mapping.Location = new System.Drawing.Point(395, 184);
            this.Mapping.Name = "Mapping";
            this.Mapping.Size = new System.Drawing.Size(143, 23);
            this.Mapping.TabIndex = 5;
            this.Mapping.Text = "제품에 부품넣기";
            this.Mapping.UseVisualStyleBackColor = true;
            this.Mapping.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PREINSPECTION.Properties.Resources.LS_ELECTRIC_시그니처_jpg;
            this.pictureBox1.Location = new System.Drawing.Point(693, 312);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // itemSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 364);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Mapping);
            this.Controls.Add(this.itemAdd);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.updatePart);
            this.Controls.Add(this.partAdd);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.itemGroupBox);
            this.Name = "itemSelect";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.itemSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox itemGroupBox;
        private System.Windows.Forms.ComboBox itemBox;
        private System.Windows.Forms.Button partAdd;
        private System.Windows.Forms.Button updatePart;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button itemAdd;
        private System.Windows.Forms.Button Mapping;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


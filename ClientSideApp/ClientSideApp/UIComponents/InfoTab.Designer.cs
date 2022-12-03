namespace ClientSideApp
{
    partial class InfoTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.accountTypeContent = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.accountOwnerContent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ibanContent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AvailabbleAmountContent = new System.Windows.Forms.Label();
            this.shareAccountInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(81, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Type";
            // 
            // accountTypeContent
            // 
            this.accountTypeContent.AutoSize = true;
            this.accountTypeContent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accountTypeContent.Location = new System.Drawing.Point(130, 100);
            this.accountTypeContent.Name = "accountTypeContent";
            this.accountTypeContent.Size = new System.Drawing.Size(76, 25);
            this.accountTypeContent.TabIndex = 1;
            this.accountTypeContent.Text = "content";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(81, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account Owner";
            // 
            // accountOwnerContent
            // 
            this.accountOwnerContent.AutoSize = true;
            this.accountOwnerContent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.accountOwnerContent.Location = new System.Drawing.Point(127, 173);
            this.accountOwnerContent.Name = "accountOwnerContent";
            this.accountOwnerContent.Size = new System.Drawing.Size(132, 25);
            this.accountOwnerContent.TabIndex = 3;
            this.accountOwnerContent.Text = "ownerContent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(81, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "IBAN";
            // 
            // ibanContent
            // 
            this.ibanContent.AutoSize = true;
            this.ibanContent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibanContent.Location = new System.Drawing.Point(127, 245);
            this.ibanContent.Name = "ibanContent";
            this.ibanContent.Size = new System.Drawing.Size(121, 25);
            this.ibanContent.TabIndex = 5;
            this.ibanContent.Text = "IBANContent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(81, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Available amount";
            // 
            // AvailabbleAmountContent
            // 
            this.AvailabbleAmountContent.AutoSize = true;
            this.AvailabbleAmountContent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AvailabbleAmountContent.Location = new System.Drawing.Point(130, 346);
            this.AvailabbleAmountContent.Name = "AvailabbleAmountContent";
            this.AvailabbleAmountContent.Size = new System.Drawing.Size(144, 25);
            this.AvailabbleAmountContent.TabIndex = 7;
            this.AvailabbleAmountContent.Text = "amountContent";
            // 
            // shareAccountInfo
            // 
            this.shareAccountInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shareAccountInfo.Location = new System.Drawing.Point(81, 408);
            this.shareAccountInfo.Name = "shareAccountInfo";
            this.shareAccountInfo.Size = new System.Drawing.Size(206, 30);
            this.shareAccountInfo.TabIndex = 8;
            this.shareAccountInfo.Text = "Share Account Info Via Email";
            this.shareAccountInfo.UseVisualStyleBackColor = true;
            this.shareAccountInfo.Click += new System.EventHandler(this.shareAccountInfo_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(24, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InfoTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shareAccountInfo);
            this.Controls.Add(this.AvailabbleAmountContent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ibanContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accountOwnerContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.accountTypeContent);
            this.Controls.Add(this.label1);
            this.Name = "InfoTab";
            this.Size = new System.Drawing.Size(440, 591);
            this.Load += new System.EventHandler(this.InfoTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label accountTypeContent;
        private Label label2;
        private Label accountOwnerContent;
        private Label label3;
        private Label ibanContent;
        private Label label4;
        private Label AvailabbleAmountContent;
        private Button shareAccountInfo;
        private Button button1;
    }
}

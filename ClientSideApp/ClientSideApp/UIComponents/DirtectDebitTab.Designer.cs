namespace ClientSideApp
{
    partial class DirtectDebitTab
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
            this.amountLbl = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.enterDebitPeriodLbl = new System.Windows.Forms.Label();
            this.StartingDateLbl = new System.Windows.Forms.Label();
            this.startingDateBox = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.nextBtnTwo = new System.Windows.Forms.Button();
            this.nextBtnThree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.companyIBANLbl = new System.Windows.Forms.Label();
            this.CompanyBox = new System.Windows.Forms.ComboBox();
            this.yourAccountBox = new System.Windows.Forms.ComboBox();
            this.selectAccountLbl = new System.Windows.Forms.Label();
            this.ibanCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // amountLbl
            // 
            this.amountLbl.AutoSize = true;
            this.amountLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountLbl.Location = new System.Drawing.Point(120, 113);
            this.amountLbl.Name = "amountLbl";
            this.amountLbl.Size = new System.Drawing.Size(158, 25);
            this.amountLbl.TabIndex = 0;
            this.amountLbl.Text = "Enter the amount";
            // 
            // amountBox
            // 
            this.amountBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountBox.Location = new System.Drawing.Point(159, 199);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(80, 36);
            this.amountBox.TabIndex = 1;
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextBtn.Location = new System.Drawing.Point(144, 296);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(129, 35);
            this.nextBtn.TabIndex = 2;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // enterDebitPeriodLbl
            // 
            this.enterDebitPeriodLbl.AutoSize = true;
            this.enterDebitPeriodLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.enterDebitPeriodLbl.Location = new System.Drawing.Point(120, 113);
            this.enterDebitPeriodLbl.Name = "enterDebitPeriodLbl";
            this.enterDebitPeriodLbl.Size = new System.Drawing.Size(165, 25);
            this.enterDebitPeriodLbl.TabIndex = 5;
            this.enterDebitPeriodLbl.Text = "Enter Debit Period";
            // 
            // StartingDateLbl
            // 
            this.StartingDateLbl.AutoSize = true;
            this.StartingDateLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartingDateLbl.Location = new System.Drawing.Point(144, 146);
            this.StartingDateLbl.Name = "StartingDateLbl";
            this.StartingDateLbl.Size = new System.Drawing.Size(115, 25);
            this.StartingDateLbl.TabIndex = 6;
            this.StartingDateLbl.Text = "Ending Date";
            // 
            // startingDateBox
            // 
            this.startingDateBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startingDateBox.Location = new System.Drawing.Point(158, 199);
            this.startingDateBox.Name = "startingDateBox";
            this.startingDateBox.Size = new System.Drawing.Size(101, 27);
            this.startingDateBox.TabIndex = 8;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backBtn.Location = new System.Drawing.Point(14, 416);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(95, 33);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // nextBtnTwo
            // 
            this.nextBtnTwo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextBtnTwo.Location = new System.Drawing.Point(144, 296);
            this.nextBtnTwo.Name = "nextBtnTwo";
            this.nextBtnTwo.Size = new System.Drawing.Size(129, 35);
            this.nextBtnTwo.TabIndex = 11;
            this.nextBtnTwo.Text = "Next";
            this.nextBtnTwo.UseVisualStyleBackColor = true;
            this.nextBtnTwo.Click += new System.EventHandler(this.nextBtnTwo_Click);
            // 
            // nextBtnThree
            // 
            this.nextBtnThree.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextBtnThree.Location = new System.Drawing.Point(115, 296);
            this.nextBtnThree.Name = "nextBtnThree";
            this.nextBtnThree.Size = new System.Drawing.Size(179, 35);
            this.nextBtnThree.TabIndex = 12;
            this.nextBtnThree.Text = "Commit Debit";
            this.nextBtnThree.UseVisualStyleBackColor = true;
            this.nextBtnThree.Click += new System.EventHandler(this.nextBtnThree_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(141, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "Direct Debit";
            // 
            // companyIBANLbl
            // 
            this.companyIBANLbl.AutoSize = true;
            this.companyIBANLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.companyIBANLbl.Location = new System.Drawing.Point(129, 171);
            this.companyIBANLbl.Name = "companyIBANLbl";
            this.companyIBANLbl.Size = new System.Drawing.Size(165, 25);
            this.companyIBANLbl.TabIndex = 3;
            this.companyIBANLbl.Text = "Choose Company ";
            // 
            // CompanyBox
            // 
            this.CompanyBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(61, 206);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(299, 29);
            this.CompanyBox.TabIndex = 14;
            // 
            // yourAccountBox
            // 
            this.yourAccountBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yourAccountBox.FormattingEnabled = true;
            this.yourAccountBox.Location = new System.Drawing.Point(61, 113);
            this.yourAccountBox.Name = "yourAccountBox";
            this.yourAccountBox.Size = new System.Drawing.Size(299, 29);
            this.yourAccountBox.TabIndex = 15;
            // 
            // selectAccountLbl
            // 
            this.selectAccountLbl.AutoSize = true;
            this.selectAccountLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAccountLbl.Location = new System.Drawing.Point(115, 77);
            this.selectAccountLbl.Name = "selectAccountLbl";
            this.selectAccountLbl.Size = new System.Drawing.Size(179, 25);
            this.selectAccountLbl.TabIndex = 16;
            this.selectAccountLbl.Text = "Select Your Account";
            // 
            // ibanCombo
            // 
            this.ibanCombo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibanCombo.FormattingEnabled = true;
            this.ibanCombo.Location = new System.Drawing.Point(61, 261);
            this.ibanCombo.Name = "ibanCombo";
            this.ibanCombo.Size = new System.Drawing.Size(299, 29);
            this.ibanCombo.TabIndex = 17;
            // 
            // DirtectDebitTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ibanCombo);
            this.Controls.Add(this.selectAccountLbl);
            this.Controls.Add(this.yourAccountBox);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextBtnThree);
            this.Controls.Add(this.nextBtnTwo);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.startingDateBox);
            this.Controls.Add(this.StartingDateLbl);
            this.Controls.Add(this.enterDebitPeriodLbl);
            this.Controls.Add(this.companyIBANLbl);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.amountLbl);
            this.Name = "DirtectDebitTab";
            this.Size = new System.Drawing.Size(440, 591);
            this.Load += new System.EventHandler(this.DirtectDebitTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label amountLbl;
        private TextBox amountBox;
        private Button nextBtn;
        private Label enterDebitPeriodLbl;
        private Label StartingDateLbl;
        private TextBox startingDateBox;
        private Button backBtn;
        private Button nextBtnTwo;
        private Button nextBtnThree;
        private Label label1;
        private Label companyIBANLbl;
        private ComboBox CompanyBox;
        private ComboBox yourAccountBox;
        private Label selectAccountLbl;
        private ComboBox ibanCombo;
    }
}

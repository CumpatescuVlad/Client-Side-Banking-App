namespace ClientSideApp
{
    partial class StandingOrderTab
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
            this.label2 = new System.Windows.Forms.Label();
            this.startingDateLbl = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.startingDateBox = new System.Windows.Forms.TextBox();
            this.IBANLbl = new System.Windows.Forms.Label();
            this.IBANBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.nextBtnTwo = new System.Windows.Forms.Button();
            this.nextBtnThree = new System.Windows.Forms.Button();
            this.selectAccountBox = new System.Windows.Forms.ComboBox();
            this.selectAccountLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // amountLbl
            // 
            this.amountLbl.AutoSize = true;
            this.amountLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountLbl.Location = new System.Drawing.Point(152, 170);
            this.amountLbl.Name = "amountLbl";
            this.amountLbl.Size = new System.Drawing.Size(128, 25);
            this.amountLbl.TabIndex = 0;
            this.amountLbl.Text = "Enter Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(125, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Standing Order";
            // 
            // startingDateLbl
            // 
            this.startingDateLbl.AutoSize = true;
            this.startingDateLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startingDateLbl.Location = new System.Drawing.Point(146, 176);
            this.startingDateLbl.Name = "startingDateLbl";
            this.startingDateLbl.Size = new System.Drawing.Size(115, 25);
            this.startingDateLbl.TabIndex = 2;
            this.startingDateLbl.Text = "Ending Date";
            // 
            // amountBox
            // 
            this.amountBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountBox.Location = new System.Drawing.Point(162, 218);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(93, 29);
            this.amountBox.TabIndex = 4;
            // 
            // startingDateBox
            // 
            this.startingDateBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startingDateBox.Location = new System.Drawing.Point(139, 218);
            this.startingDateBox.Name = "startingDateBox";
            this.startingDateBox.Size = new System.Drawing.Size(137, 29);
            this.startingDateBox.TabIndex = 5;
            // 
            // IBANLbl
            // 
            this.IBANLbl.AutoSize = true;
            this.IBANLbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IBANLbl.Location = new System.Drawing.Point(152, 195);
            this.IBANLbl.Name = "IBANLbl";
            this.IBANLbl.Size = new System.Drawing.Size(103, 25);
            this.IBANLbl.TabIndex = 7;
            this.IBANLbl.Text = "Enter IBAN";
            // 
            // IBANBox
            // 
            this.IBANBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IBANBox.Location = new System.Drawing.Point(57, 243);
            this.IBANBox.Name = "IBANBox";
            this.IBANBox.Size = new System.Drawing.Size(304, 29);
            this.IBANBox.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(146, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backBtn.Location = new System.Drawing.Point(19, 430);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 29);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // nextBtnTwo
            // 
            this.nextBtnTwo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextBtnTwo.Location = new System.Drawing.Point(146, 278);
            this.nextBtnTwo.Name = "nextBtnTwo";
            this.nextBtnTwo.Size = new System.Drawing.Size(136, 29);
            this.nextBtnTwo.TabIndex = 11;
            this.nextBtnTwo.Text = "Next";
            this.nextBtnTwo.UseVisualStyleBackColor = true;
            this.nextBtnTwo.Click += new System.EventHandler(this.nextBtnTwo_Click);
            // 
            // nextBtnThree
            // 
            this.nextBtnThree.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextBtnThree.Location = new System.Drawing.Point(146, 278);
            this.nextBtnThree.Name = "nextBtnThree";
            this.nextBtnThree.Size = new System.Drawing.Size(136, 29);
            this.nextBtnThree.TabIndex = 12;
            this.nextBtnThree.Text = "Commit Order";
            this.nextBtnThree.UseVisualStyleBackColor = true;
            this.nextBtnThree.Click += new System.EventHandler(this.nextBtnThree_Click);
            // 
            // selectAccountBox
            // 
            this.selectAccountBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAccountBox.FormattingEnabled = true;
            this.selectAccountBox.Location = new System.Drawing.Point(57, 144);
            this.selectAccountBox.Name = "selectAccountBox";
            this.selectAccountBox.Size = new System.Drawing.Size(304, 29);
            this.selectAccountBox.TabIndex = 13;
            // 
            // selectAccountLBL
            // 
            this.selectAccountLBL.AutoSize = true;
            this.selectAccountLBL.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectAccountLBL.Location = new System.Drawing.Point(146, 102);
            this.selectAccountLBL.Name = "selectAccountLBL";
            this.selectAccountLBL.Size = new System.Drawing.Size(136, 25);
            this.selectAccountLBL.TabIndex = 14;
            this.selectAccountLBL.Text = "Select Account";
            // 
            // StandingOrderTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectAccountLBL);
            this.Controls.Add(this.selectAccountBox);
            this.Controls.Add(this.nextBtnThree);
            this.Controls.Add(this.nextBtnTwo);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IBANLbl);
            this.Controls.Add(this.startingDateBox);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startingDateLbl);
            this.Controls.Add(this.amountLbl);
            this.Controls.Add(this.IBANBox);
            this.Name = "StandingOrderTab";
            this.Size = new System.Drawing.Size(440, 591);
            this.Load += new System.EventHandler(this.StandingOrderTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label amountLbl;
        private Label label2;
        private Label startingDateLbl;
        private TextBox amountBox;
        private TextBox startingDateBox;
        private Label IBANLbl;
        private TextBox IBANBox;
        private Button button1;
        private Button backBtn;
        private Button nextBtnTwo;
        private Button nextBtnThree;
        private ComboBox selectAccountBox;
        private Label selectAccountLBL;
    }
}

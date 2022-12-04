namespace ClientSideApp
{
    partial class TransactionsLogTab
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.infoBtn = new System.Windows.Forms.Button();
            this.functionsBtn = new System.Windows.Forms.Button();
            this.transactionsBtn = new System.Windows.Forms.Button();
            this.functionsTab1 = new ClientSideApp.FunctionsTab();
            this.infoTab1 = new ClientSideApp.InfoTab();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(0, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(440, 539);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // infoBtn
            // 
            this.infoBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoBtn.Location = new System.Drawing.Point(304, 36);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(122, 29);
            this.infoBtn.TabIndex = 1;
            this.infoBtn.Text = "Info";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // functionsBtn
            // 
            this.functionsBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.functionsBtn.Location = new System.Drawing.Point(159, 36);
            this.functionsBtn.Name = "functionsBtn";
            this.functionsBtn.Size = new System.Drawing.Size(122, 29);
            this.functionsBtn.TabIndex = 2;
            this.functionsBtn.Text = "Functions";
            this.functionsBtn.UseVisualStyleBackColor = true;
            this.functionsBtn.Click += new System.EventHandler(this.functionsBtn_Click);
            // 
            // transactionsBtn
            // 
            this.transactionsBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transactionsBtn.Location = new System.Drawing.Point(12, 36);
            this.transactionsBtn.Name = "transactionsBtn";
            this.transactionsBtn.Size = new System.Drawing.Size(122, 29);
            this.transactionsBtn.TabIndex = 3;
            this.transactionsBtn.Text = "Transactions";
            this.transactionsBtn.UseVisualStyleBackColor = true;
            this.transactionsBtn.Click += new System.EventHandler(this.transactionsBtn_Click);
            // 
            // functionsTab1
            // 
            this.functionsTab1.Location = new System.Drawing.Point(0, 71);
            this.functionsTab1.Name = "functionsTab1";
            this.functionsTab1.Size = new System.Drawing.Size(440, 539);
            this.functionsTab1.TabIndex = 4;
            // 
            // infoTab1
            // 
            this.infoTab1.Location = new System.Drawing.Point(0, 71);
            this.infoTab1.Name = "infoTab1";
            this.infoTab1.Size = new System.Drawing.Size(440, 539);
            this.infoTab1.TabIndex = 5;
            // 
            // TransactionsLogTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.transactionsBtn);
            this.Controls.Add(this.functionsBtn);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.functionsTab1);
            this.Controls.Add(this.infoTab1);
            this.Name = "TransactionsLogTab";
            this.Size = new System.Drawing.Size(440, 639);
            this.Load += new System.EventHandler(this.TransactionsLogTab_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox richTextBox1;
        private Button infoBtn;
        private Button functionsBtn;
        private Button transactionsBtn;
        private FunctionsTab functionsTab1;
        private InfoTab infoTab1;
    }
}

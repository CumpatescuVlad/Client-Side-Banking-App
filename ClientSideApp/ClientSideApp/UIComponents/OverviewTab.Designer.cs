using System.Drawing.Text;

namespace ClientSideApp
{
    partial class OverviewTab
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
            this.label1 = new System.Windows.Forms.Label();
            this.newTransferBtn = new System.Windows.Forms.Button();
            this.transactionsLogTab1 = new ClientSideApp.TransactionsLogTab();
            this.greetMessage = new System.Windows.Forms.Label();
            this.newTransferTab1 = new ClientSideApp.NewTransferTab();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.DodgerBlue;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(3, 109);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(434, 121);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Current Accounts:";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overview";
            // 
            // newTransferBtn
            // 
            this.newTransferBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newTransferBtn.Location = new System.Drawing.Point(159, 236);
            this.newTransferBtn.Name = "newTransferBtn";
            this.newTransferBtn.Size = new System.Drawing.Size(119, 30);
            this.newTransferBtn.TabIndex = 2;
            this.newTransferBtn.Text = "New Transfer";
            this.newTransferBtn.UseVisualStyleBackColor = true;
            this.newTransferBtn.Click += new System.EventHandler(this.newTransferBtn_Click);
            // 
            // transactionsLogTab1
            // 
            this.transactionsLogTab1.Location = new System.Drawing.Point(0, 0);
            this.transactionsLogTab1.Name = "transactionsLogTab1";
            this.transactionsLogTab1.Size = new System.Drawing.Size(440, 548);
            this.transactionsLogTab1.TabIndex = 3;
            this.transactionsLogTab1.Load += new System.EventHandler(this.transactionsLogTab1_Load);
            // 
            // greetMessage
            // 
            this.greetMessage.AutoSize = true;
            this.greetMessage.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.greetMessage.Location = new System.Drawing.Point(97, 0);
            this.greetMessage.Name = "greetMessage";
            this.greetMessage.Size = new System.Drawing.Size(181, 30);
            this.greetMessage.TabIndex = 4;
            this.greetMessage.Text = "Hello _nameHere";
            // 
            // newTransferTab1
            // 
            this.newTransferTab1.Location = new System.Drawing.Point(0, 0);
            this.newTransferTab1.Name = "newTransferTab1";
            this.newTransferTab1.Size = new System.Drawing.Size(441, 568);
            this.newTransferTab1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(3, 554);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(159, 272);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OverviewTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.greetMessage);
            this.Controls.Add(this.newTransferBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.transactionsLogTab1);
            this.Controls.Add(this.newTransferTab1);
            this.Name = "OverviewTab";
            this.Size = new System.Drawing.Size(440, 699);
            this.Load += new System.EventHandler(this.OverviewTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private Label label1;
        private Button newTransferBtn;
        private TransactionsLogTab transactionsLogTab1;
        private Label greetMessage;
        private NewTransferTab newTransferTab1;
        private Button button1;
        private Button button2;
    }
}

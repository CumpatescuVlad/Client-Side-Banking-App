namespace ClientSideApp
{
    partial class StatementTab
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
            this.genState = new System.Windows.Forms.Label();
            this.fromDateBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toDateBox = new System.Windows.Forms.TextBox();
            this.Format = new System.Windows.Forms.Label();
            this.formatBox = new System.Windows.Forms.ComboBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // genState
            // 
            this.genState.AutoSize = true;
            this.genState.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.genState.Location = new System.Drawing.Point(98, 45);
            this.genState.Name = "genState";
            this.genState.Size = new System.Drawing.Size(206, 30);
            this.genState.TabIndex = 0;
            this.genState.Text = "Generate Statement";
            // 
            // fromDateBox
            // 
            this.fromDateBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fromDateBox.Location = new System.Drawing.Point(188, 119);
            this.fromDateBox.Name = "fromDateBox";
            this.fromDateBox.Size = new System.Drawing.Size(100, 25);
            this.fromDateBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate Statement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(101, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(101, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // toDateBox
            // 
            this.toDateBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toDateBox.Location = new System.Drawing.Point(188, 187);
            this.toDateBox.Name = "toDateBox";
            this.toDateBox.Size = new System.Drawing.Size(100, 25);
            this.toDateBox.TabIndex = 4;
            // 
            // Format
            // 
            this.Format.AutoSize = true;
            this.Format.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Format.Location = new System.Drawing.Point(101, 241);
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(82, 30);
            this.Format.TabIndex = 6;
            this.Format.Text = "Format";
            // 
            // formatBox
            // 
            this.formatBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.formatBox.FormattingEnabled = true;
            this.formatBox.Items.AddRange(new object[] {
            "Word",
            "Pdf",
            "Csv"});
            this.formatBox.Location = new System.Drawing.Point(188, 248);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(100, 25);
            this.formatBox.TabIndex = 7;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backBtn.Location = new System.Drawing.Point(12, 413);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(81, 31);
            this.backBtn.TabIndex = 8;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // StatementTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.formatBox);
            this.Controls.Add(this.Format);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toDateBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fromDateBox);
            this.Controls.Add(this.genState);
            this.Name = "StatementTab";
            this.Size = new System.Drawing.Size(440, 532);
            this.Load += new System.EventHandler(this.StatementTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label genState;
        private TextBox fromDateBox;
        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox toDateBox;
        private Label Format;
        private ComboBox formatBox;
        private Button backBtn;
    }
}

namespace ClientSideApp
{
    partial class ActivateApp
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
            this.doneBTn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Authentificate With Token";
            // 
            // doneBTn
            // 
            this.doneBTn.Location = new System.Drawing.Point(158, 288);
            this.doneBTn.Name = "doneBTn";
            this.doneBTn.Size = new System.Drawing.Size(118, 39);
            this.doneBTn.TabIndex = 1;
            this.doneBTn.Text = "DONE";
            this.doneBTn.UseVisualStyleBackColor = true;
            this.doneBTn.Click += new System.EventHandler(this.doneBTn_Click);
            // 
            // ActivateApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doneBTn);
            this.Controls.Add(this.label1);
            this.Name = "ActivateApp";
            this.Size = new System.Drawing.Size(445, 588);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button doneBTn;
    }
}

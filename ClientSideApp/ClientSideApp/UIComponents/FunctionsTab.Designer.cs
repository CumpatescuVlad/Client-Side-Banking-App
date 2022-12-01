namespace ClientSideApp
{
    partial class FunctionsTab
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
            this.standingOrders = new System.Windows.Forms.Label();
            this.directDebit = new System.Windows.Forms.Label();
            this.statementlabel = new System.Windows.Forms.Label();
            this.card = new System.Windows.Forms.Label();
            this.owner = new System.Windows.Forms.Label();
            this.standingOrderTab1 = new ClientSideApp.StandingOrderTab();
            this.dirtectDebitTab1 = new ClientSideApp.DirtectDebitTab();
            this.statementTab1 = new ClientSideApp.StatementTab();
            this.SuspendLayout();
            // 
            // standingOrders
            // 
            this.standingOrders.AutoSize = true;
            this.standingOrders.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.standingOrders.Location = new System.Drawing.Point(132, 114);
            this.standingOrders.Name = "standingOrders";
            this.standingOrders.Size = new System.Drawing.Size(170, 30);
            this.standingOrders.TabIndex = 0;
            this.standingOrders.Text = "Standing Orders";
            // 
            // directDebit
            // 
            this.directDebit.AutoSize = true;
            this.directDebit.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.directDebit.Location = new System.Drawing.Point(153, 170);
            this.directDebit.Name = "directDebit";
            this.directDebit.Size = new System.Drawing.Size(128, 30);
            this.directDebit.TabIndex = 1;
            this.directDebit.Text = "Direct Debit";
            // 
            // statementlabel
            // 
            this.statementlabel.AutoSize = true;
            this.statementlabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statementlabel.Location = new System.Drawing.Point(153, 233);
            this.statementlabel.Name = "statementlabel";
            this.statementlabel.Size = new System.Drawing.Size(111, 30);
            this.statementlabel.TabIndex = 2;
            this.statementlabel.Text = "Statement";
            // 
            // card
            // 
            this.card.AutoSize = true;
            this.card.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.card.Location = new System.Drawing.Point(3, 364);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(124, 30);
            this.card.TabIndex = 4;
            this.card.Text = "Credit Card";
            // 
            // owner
            // 
            this.owner.AutoSize = true;
            this.owner.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.owner.Location = new System.Drawing.Point(3, 394);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(78, 30);
            this.owner.TabIndex = 5;
            this.owner.Text = "Owner";
            // 
            // standingOrderTab1
            // 
            this.standingOrderTab1.Location = new System.Drawing.Point(0, 0);
            this.standingOrderTab1.Name = "standingOrderTab1";
            this.standingOrderTab1.Size = new System.Drawing.Size(440, 531);
            this.standingOrderTab1.TabIndex = 7;
            this.standingOrderTab1.Load += new System.EventHandler(this.standingOrderTab1_Load);
            // 
            // dirtectDebitTab1
            // 
            this.dirtectDebitTab1.Location = new System.Drawing.Point(-3, 0);
            this.dirtectDebitTab1.Name = "dirtectDebitTab1";
            this.dirtectDebitTab1.Size = new System.Drawing.Size(440, 531);
            this.dirtectDebitTab1.TabIndex = 8;
            // 
            // statementTab1
            // 
            this.statementTab1.Location = new System.Drawing.Point(0, 0);
            this.statementTab1.Name = "statementTab1";
            this.statementTab1.Size = new System.Drawing.Size(440, 532);
            this.statementTab1.TabIndex = 9;
            // 
            // FunctionsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.owner);
            this.Controls.Add(this.card);
            this.Controls.Add(this.statementlabel);
            this.Controls.Add(this.directDebit);
            this.Controls.Add(this.standingOrders);
            this.Controls.Add(this.standingOrderTab1);
            this.Controls.Add(this.dirtectDebitTab1);
            this.Controls.Add(this.statementTab1);
            this.Name = "FunctionsTab";
            this.Size = new System.Drawing.Size(440, 591);
            this.Load += new System.EventHandler(this.FunctionsTab_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label standingOrders;
        private Label directDebit;
        private Label statementlabel;
        private Label card;
        private Label owner;
        private StandingOrderTab standingOrderTab1;
        private DirtectDebitTab dirtectDebitTab1;
        private StatementTab statementTab1;
    }
}

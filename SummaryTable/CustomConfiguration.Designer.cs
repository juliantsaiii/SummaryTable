namespace SummaryTable
{
    partial class CustomConfiguration
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
            this.RuleList = new System.Windows.Forms.ListBox();
            this.RuleName = new System.Windows.Forms.TextBox();
            this.AddRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RuleList
            // 
            this.RuleList.FormattingEnabled = true;
            this.RuleList.ItemHeight = 15;
            this.RuleList.Location = new System.Drawing.Point(51, 102);
            this.RuleList.Name = "RuleList";
            this.RuleList.Size = new System.Drawing.Size(286, 304);
            this.RuleList.TabIndex = 0;
            // 
            // RuleName
            // 
            this.RuleName.Location = new System.Drawing.Point(51, 39);
            this.RuleName.Name = "RuleName";
            this.RuleName.Size = new System.Drawing.Size(155, 25);
            this.RuleName.TabIndex = 1;
            // 
            // AddRule
            // 
            this.AddRule.Location = new System.Drawing.Point(226, 41);
            this.AddRule.Name = "AddRule";
            this.AddRule.Size = new System.Drawing.Size(111, 23);
            this.AddRule.TabIndex = 2;
            this.AddRule.Text = "添加抓取规则";
            this.AddRule.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // CustomConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddRule);
            this.Controls.Add(this.RuleName);
            this.Controls.Add(this.RuleList);
            this.Name = "CustomConfiguration";
            this.Text = "新增模板抓取规则";
            this.Load += new System.EventHandler(this.CustomConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RuleList;
        private System.Windows.Forms.TextBox RuleName;
        private System.Windows.Forms.Button AddRule;
        private System.Windows.Forms.Label label1;
    }
}
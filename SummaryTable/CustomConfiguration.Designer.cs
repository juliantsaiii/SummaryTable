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
            this.SectionName = new System.Windows.Forms.TextBox();
            this.AddRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CodeRegex = new System.Windows.Forms.TextBox();
            this.ValueTimeRegex = new System.Windows.Forms.TextBox();
            this.CustomerRegex = new System.Windows.Forms.TextBox();
            this.LocationRegex = new System.Windows.Forms.TextBox();
            this.ArchitecherAreaRegex = new System.Windows.Forms.TextBox();
            this.SingleValueRegex = new System.Windows.Forms.TextBox();
            this.TotalValueRegex = new System.Windows.Forms.TextBox();
            this.AddOrUpdateRule = new System.Windows.Forms.Button();
            this.DeleteRule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RuleList
            // 
            this.RuleList.FormattingEnabled = true;
            this.RuleList.ItemHeight = 15;
            this.RuleList.Location = new System.Drawing.Point(29, 40);
            this.RuleList.Name = "RuleList";
            this.RuleList.Size = new System.Drawing.Size(155, 304);
            this.RuleList.TabIndex = 0;
            this.RuleList.SelectedIndexChanged += new System.EventHandler(this.RuleList_SelectedIndexChanged);
            // 
            // SectionName
            // 
            this.SectionName.Location = new System.Drawing.Point(217, 174);
            this.SectionName.Name = "SectionName";
            this.SectionName.Size = new System.Drawing.Size(138, 25);
            this.SectionName.TabIndex = 1;
            // 
            // AddRule
            // 
            this.AddRule.Location = new System.Drawing.Point(217, 129);
            this.AddRule.Name = "AddRule";
            this.AddRule.Size = new System.Drawing.Size(138, 25);
            this.AddRule.TabIndex = 2;
            this.AddRule.Text = "+";
            this.AddRule.UseVisualStyleBackColor = true;
            this.AddRule.Click += new System.EventHandler(this.AddRule_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "评估编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "价值时点：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "委托方名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "项目坐落：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "建筑面积：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(378, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "评估单价：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(378, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "评估总价：";
            // 
            // CodeRegex
            // 
            this.CodeRegex.Location = new System.Drawing.Point(473, 51);
            this.CodeRegex.Name = "CodeRegex";
            this.CodeRegex.Size = new System.Drawing.Size(320, 25);
            this.CodeRegex.TabIndex = 4;
            // 
            // ValueTimeRegex
            // 
            this.ValueTimeRegex.Location = new System.Drawing.Point(473, 95);
            this.ValueTimeRegex.Name = "ValueTimeRegex";
            this.ValueTimeRegex.Size = new System.Drawing.Size(320, 25);
            this.ValueTimeRegex.TabIndex = 4;
            // 
            // CustomerRegex
            // 
            this.CustomerRegex.Location = new System.Drawing.Point(473, 139);
            this.CustomerRegex.Name = "CustomerRegex";
            this.CustomerRegex.Size = new System.Drawing.Size(320, 25);
            this.CustomerRegex.TabIndex = 4;
            // 
            // LocationRegex
            // 
            this.LocationRegex.Location = new System.Drawing.Point(473, 183);
            this.LocationRegex.Name = "LocationRegex";
            this.LocationRegex.Size = new System.Drawing.Size(320, 25);
            this.LocationRegex.TabIndex = 4;
            // 
            // ArchitecherAreaRegex
            // 
            this.ArchitecherAreaRegex.Location = new System.Drawing.Point(473, 227);
            this.ArchitecherAreaRegex.Name = "ArchitecherAreaRegex";
            this.ArchitecherAreaRegex.Size = new System.Drawing.Size(320, 25);
            this.ArchitecherAreaRegex.TabIndex = 4;
            // 
            // SingleValueRegex
            // 
            this.SingleValueRegex.Location = new System.Drawing.Point(473, 271);
            this.SingleValueRegex.Name = "SingleValueRegex";
            this.SingleValueRegex.Size = new System.Drawing.Size(320, 25);
            this.SingleValueRegex.TabIndex = 4;
            // 
            // TotalValueRegex
            // 
            this.TotalValueRegex.Location = new System.Drawing.Point(473, 315);
            this.TotalValueRegex.Name = "TotalValueRegex";
            this.TotalValueRegex.Size = new System.Drawing.Size(320, 25);
            this.TotalValueRegex.TabIndex = 4;
            // 
            // AddOrUpdateRule
            // 
            this.AddOrUpdateRule.Location = new System.Drawing.Point(29, 378);
            this.AddOrUpdateRule.Name = "AddOrUpdateRule";
            this.AddOrUpdateRule.Size = new System.Drawing.Size(764, 43);
            this.AddOrUpdateRule.TabIndex = 5;
            this.AddOrUpdateRule.Text = "增加或更新抓取规则";
            this.AddOrUpdateRule.UseVisualStyleBackColor = true;
            this.AddOrUpdateRule.Click += new System.EventHandler(this.AddOrUpdateRule_Click);
            // 
            // DeleteRule
            // 
            this.DeleteRule.Location = new System.Drawing.Point(217, 219);
            this.DeleteRule.Name = "DeleteRule";
            this.DeleteRule.Size = new System.Drawing.Size(138, 23);
            this.DeleteRule.TabIndex = 6;
            this.DeleteRule.Text = "-";
            this.DeleteRule.UseVisualStyleBackColor = true;
            this.DeleteRule.Click += new System.EventHandler(this.DeleteRule_Click);
            // 
            // CustomConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteRule);
            this.Controls.Add(this.AddOrUpdateRule);
            this.Controls.Add(this.TotalValueRegex);
            this.Controls.Add(this.SingleValueRegex);
            this.Controls.Add(this.ArchitecherAreaRegex);
            this.Controls.Add(this.LocationRegex);
            this.Controls.Add(this.CustomerRegex);
            this.Controls.Add(this.ValueTimeRegex);
            this.Controls.Add(this.CodeRegex);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddRule);
            this.Controls.Add(this.SectionName);
            this.Controls.Add(this.RuleList);
            this.Name = "CustomConfiguration";
            this.Text = "新增模板抓取规则";
            this.Load += new System.EventHandler(this.CustomConfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RuleList;
        private System.Windows.Forms.TextBox SectionName;
        private System.Windows.Forms.Button AddRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CodeRegex;
        private System.Windows.Forms.TextBox ValueTimeRegex;
        private System.Windows.Forms.TextBox CustomerRegex;
        private System.Windows.Forms.TextBox LocationRegex;
        private System.Windows.Forms.TextBox ArchitecherAreaRegex;
        private System.Windows.Forms.TextBox SingleValueRegex;
        private System.Windows.Forms.TextBox TotalValueRegex;
        private System.Windows.Forms.Button AddOrUpdateRule;
        private System.Windows.Forms.Button DeleteRule;
    }
}
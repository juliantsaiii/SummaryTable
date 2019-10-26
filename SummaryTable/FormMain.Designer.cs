namespace SummaryTable
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Form1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.RuleConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.Reward = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form1,
            this.CustomConfiguration,
            this.Reward});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.Form1.Name = "Form1";
            this.Form1.Size = new System.Drawing.Size(68, 24);
            this.Form1.Text = "主界面";
            this.Form1.Click += new System.EventHandler(this.Form1_Click);
            // 
            // CustomConfiguration
            // 
            this.CustomConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RuleConfig,
            this.PersonConfig});
            this.CustomConfiguration.Name = "CustomConfiguration";
            this.CustomConfiguration.Size = new System.Drawing.Size(83, 24);
            this.CustomConfiguration.Text = "配置界面";
            // 
            // RuleConfig
            // 
            this.RuleConfig.Name = "RuleConfig";
            this.RuleConfig.Size = new System.Drawing.Size(224, 26);
            this.RuleConfig.Text = "抓取规则";
            this.RuleConfig.Click += new System.EventHandler(this.RuleConfig_Click);
            // 
            // PersonConfig
            // 
            this.PersonConfig.Name = "PersonConfig";
            this.PersonConfig.Size = new System.Drawing.Size(224, 26);
            this.PersonConfig.Text = "固定信息";
            this.PersonConfig.Click += new System.EventHandler(this.PersonConfig_Click);
            // 
            // Reward
            // 
            this.Reward.Name = "Reward";
            this.Reward.Size = new System.Drawing.Size(113, 24);
            this.Reward.Text = "请作者喝杯茶";
            this.Reward.Click += new System.EventHandler(this.Reward_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(821, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 31);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(818, 497);
            this.panel.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 529);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "评估汇总助手V2.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Form1;
        private System.Windows.Forms.ToolStripMenuItem CustomConfiguration;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripMenuItem Reward;
        private System.Windows.Forms.ToolStripMenuItem RuleConfig;
        private System.Windows.Forms.ToolStripMenuItem PersonConfig;
    }
}
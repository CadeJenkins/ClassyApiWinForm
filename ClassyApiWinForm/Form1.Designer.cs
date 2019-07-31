namespace ClassyApiWinForm
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmdDeserialise = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMembers = new System.Windows.Forms.Label();
            this.txtMembers = new System.Windows.Forms.TextBox();
            this.txtFundraisingPages = new System.Windows.Forms.TextBox();
            this.FPLabel = new System.Windows.Forms.Label();
            this.FTLabel = new System.Windows.Forms.Label();
            this.txtFundraisingTeams = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtActiveResults = new System.Windows.Forms.TextBox();
            this.txtDebugOutput = new System.Windows.Forms.TextBox();
            this.cmdClearJson = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1406, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw JSON(Serialised String)";
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(6, 25);
            this.txtInput.MaxLength = 750000;
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(1394, 154);
            this.txtInput.TabIndex = 0;
            // 
            // cmdDeserialise
            // 
            this.cmdDeserialise.Location = new System.Drawing.Point(12, 200);
            this.cmdDeserialise.Name = "cmdDeserialise";
            this.cmdDeserialise.Size = new System.Drawing.Size(131, 44);
            this.cmdDeserialise.TabIndex = 1;
            this.cmdDeserialise.Text = "GO!";
            this.cmdDeserialise.UseVisualStyleBackColor = true;
            this.cmdDeserialise.Click += new System.EventHandler(this.cmdDeserialise_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(149, 200);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(131, 44);
            this.cmdClear.TabIndex = 2;
            this.cmdClear.Text = "Clear Outputs";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblMembers);
            this.groupBox2.Controls.Add(this.txtMembers);
            this.groupBox2.Controls.Add(this.txtFundraisingPages);
            this.groupBox2.Controls.Add(this.FPLabel);
            this.groupBox2.Controls.Add(this.FTLabel);
            this.groupBox2.Controls.Add(this.txtFundraisingTeams);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtActiveResults);
            this.groupBox2.Controls.Add(this.txtDebugOutput);
            this.groupBox2.Location = new System.Drawing.Point(12, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1411, 272);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Debug Output";
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Location = new System.Drawing.Point(944, 0);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(99, 20);
            this.lblMembers.TabIndex = 8;
            this.lblMembers.Text = "Member Info";
            // 
            // txtMembers
            // 
            this.txtMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMembers.Location = new System.Drawing.Point(948, 26);
            this.txtMembers.Multiline = true;
            this.txtMembers.Name = "txtMembers";
            this.txtMembers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMembers.Size = new System.Drawing.Size(236, 240);
            this.txtMembers.TabIndex = 7;
            // 
            // txtFundraisingPages
            // 
            this.txtFundraisingPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFundraisingPages.Location = new System.Drawing.Point(718, 26);
            this.txtFundraisingPages.Multiline = true;
            this.txtFundraisingPages.Name = "txtFundraisingPages";
            this.txtFundraisingPages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFundraisingPages.Size = new System.Drawing.Size(235, 240);
            this.txtFundraisingPages.TabIndex = 6;
            // 
            // FPLabel
            // 
            this.FPLabel.AutoSize = true;
            this.FPLabel.Location = new System.Drawing.Point(714, 0);
            this.FPLabel.Name = "FPLabel";
            this.FPLabel.Size = new System.Drawing.Size(188, 20);
            this.FPLabel.TabIndex = 5;
            this.FPLabel.Text = "Active Fundraising Pages";
            // 
            // FTLabel
            // 
            this.FTLabel.AutoSize = true;
            this.FTLabel.Location = new System.Drawing.Point(480, 0);
            this.FTLabel.Name = "FTLabel";
            this.FTLabel.Size = new System.Drawing.Size(191, 20);
            this.FTLabel.TabIndex = 4;
            this.FTLabel.Text = "Active Fundraising Teams";
            // 
            // txtFundraisingTeams
            // 
            this.txtFundraisingTeams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFundraisingTeams.Location = new System.Drawing.Point(484, 26);
            this.txtFundraisingTeams.MaxLength = 500000;
            this.txtFundraisingTeams.Multiline = true;
            this.txtFundraisingTeams.Name = "txtFundraisingTeams";
            this.txtFundraisingTeams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFundraisingTeams.Size = new System.Drawing.Size(235, 240);
            this.txtFundraisingTeams.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Active Campaigns";
            // 
            // txtActiveResults
            // 
            this.txtActiveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtActiveResults.Location = new System.Drawing.Point(246, 26);
            this.txtActiveResults.Multiline = true;
            this.txtActiveResults.Name = "txtActiveResults";
            this.txtActiveResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActiveResults.Size = new System.Drawing.Size(241, 240);
            this.txtActiveResults.TabIndex = 1;
            // 
            // txtDebugOutput
            // 
            this.txtDebugOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebugOutput.Location = new System.Drawing.Point(6, 26);
            this.txtDebugOutput.Multiline = true;
            this.txtDebugOutput.Name = "txtDebugOutput";
            this.txtDebugOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebugOutput.Size = new System.Drawing.Size(242, 240);
            this.txtDebugOutput.TabIndex = 0;
            // 
            // cmdClearJson
            // 
            this.cmdClearJson.Location = new System.Drawing.Point(286, 200);
            this.cmdClearJson.Name = "cmdClearJson";
            this.cmdClearJson.Size = new System.Drawing.Size(131, 43);
            this.cmdClearJson.TabIndex = 4;
            this.cmdClearJson.Text = "Clear Raw Json";
            this.cmdClearJson.UseVisualStyleBackColor = true;
            this.cmdClearJson.Click += new System.EventHandler(this.cmdClearJson_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 534);
            this.Controls.Add(this.cmdClearJson);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdDeserialise);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSON Parser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdDeserialise;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtDebugOutput;
        private System.Windows.Forms.Button cmdClearJson;
        private System.Windows.Forms.TextBox txtActiveResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFundraisingPages;
        private System.Windows.Forms.Label FPLabel;
        private System.Windows.Forms.Label FTLabel;
        private System.Windows.Forms.TextBox txtFundraisingTeams;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.TextBox txtMembers;
    }
}


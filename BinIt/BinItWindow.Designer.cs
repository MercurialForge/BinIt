namespace BinIt
{
    partial class BinItWindow
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
            this.Snapshot = new System.Windows.Forms.Button();
            this.BinIt = new System.Windows.Forms.Button();
            this.TargetDesktop = new System.Windows.Forms.Label();
            this.m_ignoreShortcuts = new System.Windows.Forms.CheckBox();
            this.m_desktopLabel = new System.Windows.Forms.Label();
            this.Output = new System.Windows.Forms.Label();
            this.m_outputText = new System.Windows.Forms.Label();
            this.SnapShotTimeStamp = new System.Windows.Forms.Label();
            this.m_ssTimestamp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_ignoreFolders = new System.Windows.Forms.CheckBox();
            this.m_bUseSnapshots = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Snapshot
            // 
            this.Snapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Snapshot.Location = new System.Drawing.Point(18, 106);
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.Size = new System.Drawing.Size(157, 34);
            this.Snapshot.TabIndex = 0;
            this.Snapshot.Text = "Take Snapshot";
            this.Snapshot.UseVisualStyleBackColor = true;
            this.Snapshot.Click += new System.EventHandler(this.SnapShot_Click);
            // 
            // BinIt
            // 
            this.BinIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BinIt.Location = new System.Drawing.Point(404, 106);
            this.BinIt.Name = "BinIt";
            this.BinIt.Size = new System.Drawing.Size(157, 34);
            this.BinIt.TabIndex = 1;
            this.BinIt.Text = "BinIt";
            this.BinIt.UseVisualStyleBackColor = true;
            this.BinIt.Click += new System.EventHandler(this.BinIt_Click);
            // 
            // TargetDesktop
            // 
            this.TargetDesktop.AutoSize = true;
            this.TargetDesktop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetDesktop.Location = new System.Drawing.Point(3, 0);
            this.TargetDesktop.Name = "TargetDesktop";
            this.TargetDesktop.Size = new System.Drawing.Size(58, 14);
            this.TargetDesktop.TabIndex = 2;
            this.TargetDesktop.Text = "Target Desktop:";
            // 
            // m_ignoreShortcuts
            // 
            this.m_ignoreShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ignoreShortcuts.AutoSize = true;
            this.m_ignoreShortcuts.Location = new System.Drawing.Point(107, 3);
            this.m_ignoreShortcuts.Name = "m_ignoreShortcuts";
            this.m_ignoreShortcuts.Size = new System.Drawing.Size(104, 17);
            this.m_ignoreShortcuts.TabIndex = 3;
            this.m_ignoreShortcuts.Text = "Ignore Shortcuts";
            this.m_ignoreShortcuts.UseVisualStyleBackColor = true;
            this.m_ignoreShortcuts.CheckedChanged += new System.EventHandler(this.m_ignoreShortcuts_CheckedChanged);
            // 
            // m_desktopLabel
            // 
            this.m_desktopLabel.AutoSize = true;
            this.m_desktopLabel.Location = new System.Drawing.Point(80, 0);
            this.m_desktopLabel.Name = "m_desktopLabel";
            this.m_desktopLabel.Size = new System.Drawing.Size(22, 13);
            this.m_desktopLabel.TabIndex = 4;
            this.m_desktopLabel.Text = "C:/";
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output.Location = new System.Drawing.Point(3, 0);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(49, 13);
            this.Output.TabIndex = 5;
            this.Output.Text = "Output:";
            // 
            // m_outputText
            // 
            this.m_outputText.AutoSize = true;
            this.m_outputText.Location = new System.Drawing.Point(80, 0);
            this.m_outputText.Name = "m_outputText";
            this.m_outputText.Size = new System.Drawing.Size(62, 13);
            this.m_outputText.TabIndex = 6;
            this.m_outputText.Text = "Hello World";
            // 
            // SnapShotTimeStamp
            // 
            this.SnapShotTimeStamp.AutoSize = true;
            this.SnapShotTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SnapShotTimeStamp.Location = new System.Drawing.Point(3, 0);
            this.SnapShotTimeStamp.Name = "SnapShotTimeStamp";
            this.SnapShotTimeStamp.Size = new System.Drawing.Size(88, 13);
            this.SnapShotTimeStamp.TabIndex = 7;
            this.SnapShotTimeStamp.Text = "Last Snapshot";
            // 
            // m_ssTimestamp
            // 
            this.m_ssTimestamp.AutoSize = true;
            this.m_ssTimestamp.Location = new System.Drawing.Point(123, 0);
            this.m_ssTimestamp.Name = "m_ssTimestamp";
            this.m_ssTimestamp.Size = new System.Drawing.Size(33, 13);
            this.m_ssTimestamp.TabIndex = 8;
            this.m_ssTimestamp.Text = "None";
            this.m_ssTimestamp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.583F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.417F));
            this.tableLayoutPanel1.Controls.Add(this.SnapShotTimeStamp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_ssTimestamp, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 14);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33649F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.66351F));
            this.tableLayoutPanel2.Controls.Add(this.Output, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_outputText, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(542, 28);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.33649F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.66351F));
            this.tableLayoutPanel3.Controls.Add(this.TargetDesktop, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.m_desktopLabel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(18, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(542, 14);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_bUseSnapshots);
            this.flowLayoutPanel1.Controls.Add(this.m_ignoreShortcuts);
            this.flowLayoutPanel1.Controls.Add(this.m_ignoreFolders);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(542, 23);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // m_ignoreFolders
            // 
            this.m_ignoreFolders.AutoSize = true;
            this.m_ignoreFolders.Location = new System.Drawing.Point(217, 3);
            this.m_ignoreFolders.Name = "m_ignoreFolders";
            this.m_ignoreFolders.Size = new System.Drawing.Size(93, 17);
            this.m_ignoreFolders.TabIndex = 4;
            this.m_ignoreFolders.Text = "Ignore Folders";
            this.m_ignoreFolders.UseVisualStyleBackColor = true;
            this.m_ignoreFolders.CheckedChanged += new System.EventHandler(this.m_ignoreFolders_CheckedChanged);
            // 
            // m_bUseSnapshots
            // 
            this.m_bUseSnapshots.AutoSize = true;
            this.m_bUseSnapshots.Location = new System.Drawing.Point(3, 3);
            this.m_bUseSnapshots.Name = "m_bUseSnapshots";
            this.m_bUseSnapshots.Size = new System.Drawing.Size(98, 17);
            this.m_bUseSnapshots.TabIndex = 5;
            this.m_bUseSnapshots.Text = "Use Snapshots";
            this.m_bUseSnapshots.UseVisualStyleBackColor = true;
            this.m_bUseSnapshots.CheckedChanged += new System.EventHandler(this.m_bUseSnapshots_CheckedChanged);
            // 
            // BinItWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 146);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Snapshot);
            this.Controls.Add(this.BinIt);
            this.MaximumSize = new System.Drawing.Size(592, 185);
            this.MinimumSize = new System.Drawing.Size(365, 185);
            this.Name = "BinItWindow";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "BinIt - Desktop Clean Up";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Snapshot;
        private System.Windows.Forms.Button BinIt;
        private System.Windows.Forms.Label TargetDesktop;
        private System.Windows.Forms.CheckBox m_ignoreShortcuts;
        private System.Windows.Forms.Label m_desktopLabel;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.Label m_outputText;
        private System.Windows.Forms.Label SnapShotTimeStamp;
        private System.Windows.Forms.Label m_ssTimestamp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox m_ignoreFolders;
        private System.Windows.Forms.CheckBox m_bUseSnapshots;
    }
}


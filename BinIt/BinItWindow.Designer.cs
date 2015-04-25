﻿namespace BinIt
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
            this.components = new System.ComponentModel.Container();
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
            this.m_ignoreFolders = new System.Windows.Forms.CheckBox();
            this.m_overwrite = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_keepBoth = new System.Windows.Forms.CheckBox();
            this.tipFolders = new System.Windows.Forms.ToolTip(this.components);
            this.tipShortcuts = new System.Windows.Forms.ToolTip(this.components);
            this.tipOverwrite = new System.Windows.Forms.ToolTip(this.components);
            this.tipKeepBoth = new System.Windows.Forms.ToolTip(this.components);
            this.tipBinIt = new System.Windows.Forms.ToolTip(this.components);
            this.tipSnapshot = new System.Windows.Forms.ToolTip(this.components);
            this.tipUseIgnore = new System.Windows.Forms.ToolTip(this.components);
            this.m_bUseSnapshots = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_useDotIgnore = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Snapshot
            // 
            this.Snapshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Snapshot.Location = new System.Drawing.Point(18, 121);
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
            this.BinIt.Location = new System.Drawing.Point(181, 121);
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
            this.TargetDesktop.Size = new System.Drawing.Size(62, 13);
            this.TargetDesktop.TabIndex = 2;
            this.TargetDesktop.Text = "Directory:";
            // 
            // m_ignoreShortcuts
            // 
            this.m_ignoreShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ignoreShortcuts.AutoSize = true;
            this.m_ignoreShortcuts.Location = new System.Drawing.Point(3, 3);
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
            this.m_desktopLabel.Location = new System.Drawing.Point(104, 0);
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
            this.Output.Size = new System.Drawing.Size(76, 13);
            this.Output.TabIndex = 5;
            this.Output.Text = "Notification:";
            // 
            // m_outputText
            // 
            this.m_outputText.AutoSize = true;
            this.m_outputText.Location = new System.Drawing.Point(105, 0);
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
            this.SnapShotTimeStamp.Size = new System.Drawing.Size(92, 13);
            this.SnapShotTimeStamp.TabIndex = 7;
            this.SnapShotTimeStamp.Text = "Last Snapshot:";
            // 
            // m_ssTimestamp
            // 
            this.m_ssTimestamp.AutoSize = true;
            this.m_ssTimestamp.Location = new System.Drawing.Point(104, 0);
            this.m_ssTimestamp.Name = "m_ssTimestamp";
            this.m_ssTimestamp.Size = new System.Drawing.Size(33, 13);
            this.m_ssTimestamp.TabIndex = 8;
            this.m_ssTimestamp.Text = "None";
            this.m_ssTimestamp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.89069F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.10931F));
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.87805F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.12195F));
            this.tableLayoutPanel2.Controls.Add(this.Output, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_outputText, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 46);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(410, 57);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.63415F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.36585F));
            this.tableLayoutPanel3.Controls.Add(this.TargetDesktop, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.m_desktopLabel, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(18, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(410, 14);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // m_ignoreFolders
            // 
            this.m_ignoreFolders.AutoSize = true;
            this.m_ignoreFolders.Location = new System.Drawing.Point(3, 26);
            this.m_ignoreFolders.Name = "m_ignoreFolders";
            this.m_ignoreFolders.Size = new System.Drawing.Size(93, 17);
            this.m_ignoreFolders.TabIndex = 4;
            this.m_ignoreFolders.Text = "Ignore Folders";
            this.m_ignoreFolders.UseVisualStyleBackColor = true;
            this.m_ignoreFolders.CheckedChanged += new System.EventHandler(this.m_ignoreFolders_CheckedChanged);
            // 
            // m_overwrite
            // 
            this.m_overwrite.AutoSize = true;
            this.m_overwrite.Location = new System.Drawing.Point(85, 3);
            this.m_overwrite.Name = "m_overwrite";
            this.m_overwrite.Size = new System.Drawing.Size(71, 17);
            this.m_overwrite.TabIndex = 6;
            this.m_overwrite.Text = "Overwrite";
            this.m_overwrite.UseVisualStyleBackColor = true;
            this.m_overwrite.CheckedChanged += new System.EventHandler(this.m_overwrite_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(434, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 109);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.m_ignoreShortcuts);
            this.flowLayoutPanel2.Controls.Add(this.m_ignoreFolders);
            this.flowLayoutPanel2.Controls.Add(this.m_useDotIgnore);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(121, 90);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // m_keepBoth
            // 
            this.m_keepBoth.AutoSize = true;
            this.m_keepBoth.Location = new System.Drawing.Point(3, 3);
            this.m_keepBoth.Name = "m_keepBoth";
            this.m_keepBoth.Size = new System.Drawing.Size(76, 17);
            this.m_keepBoth.TabIndex = 7;
            this.m_keepBoth.Text = "Keep Both";
            this.m_keepBoth.UseVisualStyleBackColor = true;
            this.m_keepBoth.CheckedChanged += new System.EventHandler(this.m_keepBoth_CheckedChanged);
            // 
            // m_bUseSnapshots
            // 
            this.m_bUseSnapshots.AutoSize = true;
            this.m_bUseSnapshots.Location = new System.Drawing.Point(46, 98);
            this.m_bUseSnapshots.Name = "m_bUseSnapshots";
            this.m_bUseSnapshots.Size = new System.Drawing.Size(98, 17);
            this.m_bUseSnapshots.TabIndex = 5;
            this.m_bUseSnapshots.Text = "Use Snapshots";
            this.m_bUseSnapshots.UseVisualStyleBackColor = true;
            this.m_bUseSnapshots.CheckedChanged += new System.EventHandler(this.m_bUseSnapshots_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_keepBoth);
            this.flowLayoutPanel1.Controls.Add(this.m_overwrite);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 21);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(344, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 40);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Merge Settings";
            // 
            // m_useDotIgnore
            // 
            this.m_useDotIgnore.AutoSize = true;
            this.m_useDotIgnore.Location = new System.Drawing.Point(3, 49);
            this.m_useDotIgnore.Name = "m_useDotIgnore";
            this.m_useDotIgnore.Size = new System.Drawing.Size(80, 17);
            this.m_useDotIgnore.TabIndex = 6;
            this.m_useDotIgnore.Text = "Use .ignore";
            this.m_useDotIgnore.UseVisualStyleBackColor = true;
            this.m_useDotIgnore.CheckedChanged += new System.EventHandler(this.m_useDotIgnore_CheckedChanged);
            // 
            // BinItWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 162);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_bUseSnapshots);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Snapshot);
            this.Controls.Add(this.BinIt);
            this.MaximumSize = new System.Drawing.Size(592, 200);
            this.MinimumSize = new System.Drawing.Size(592, 200);
            this.Name = "BinItWindow";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BinIt - Desktop Clean Up";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox m_ignoreFolders;
        private System.Windows.Forms.CheckBox m_overwrite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox m_keepBoth;
        private System.Windows.Forms.ToolTip tipFolders;
        private System.Windows.Forms.ToolTip tipShortcuts;
        private System.Windows.Forms.ToolTip tipOverwrite;
        private System.Windows.Forms.ToolTip tipKeepBoth;
        private System.Windows.Forms.ToolTip tipBinIt;
        private System.Windows.Forms.ToolTip tipSnapshot;
        private System.Windows.Forms.ToolTip tipUseIgnore;
        private System.Windows.Forms.CheckBox m_bUseSnapshots;
        private System.Windows.Forms.CheckBox m_useDotIgnore;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}


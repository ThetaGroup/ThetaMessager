namespace ThetaMessager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbEditMap = new System.Windows.Forms.PictureBox();
            this.pbControlMap = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.miUser = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.miCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpControl = new System.Windows.Forms.TabPage();
            this.lbAtInfo = new System.Windows.Forms.ListBox();
            this.btStateUpdate = new System.Windows.Forms.Button();
            this.btOpenCom = new System.Windows.Forms.Button();
            this.btComSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSentText = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.dgvForSendings = new System.Windows.Forms.DataGridView();
            this.SelectState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpMapEdit = new System.Windows.Forms.TabPage();
            this.dgvForEdit = new System.Windows.Forms.DataGridView();
            this.colNameForEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberForEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMapEditEditor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btUpdate = new System.Windows.Forms.Button();
            this.textBoxNodeName = new System.Windows.Forms.TextBox();
            this.textBoxNodeNumber = new System.Windows.Forms.TextBox();
            this.tpLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpLog = new System.Windows.Forms.DateTimePicker();
            this.cmStripMapEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbControlMap)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForSendings)).BeginInit();
            this.tpMapEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForEdit)).BeginInit();
            this.panelMapEditEditor.SuspendLayout();
            this.tpLog.SuspendLayout();
            this.cmStripMapEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbEditMap
            // 
            this.pbEditMap.Image = global::ThetaMessager.Properties.Resources.map;
            this.pbEditMap.Location = new System.Drawing.Point(-4, 0);
            this.pbEditMap.Name = "pbEditMap";
            this.pbEditMap.Size = new System.Drawing.Size(600, 431);
            this.pbEditMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEditMap.TabIndex = 0;
            this.pbEditMap.TabStop = false;
            this.pbEditMap.Click += new System.EventHandler(this.pbEditMap_Click);
            // 
            // pbControlMap
            // 
            this.pbControlMap.Image = ((System.Drawing.Image)(resources.GetObject("pbControlMap.Image")));
            this.pbControlMap.Location = new System.Drawing.Point(-4, 0);
            this.pbControlMap.Name = "pbControlMap";
            this.pbControlMap.Size = new System.Drawing.Size(600, 431);
            this.pbControlMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbControlMap.TabIndex = 0;
            this.pbControlMap.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.AllowMerge = false;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSystem,
            this.miFunction});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(832, 25);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // miSystem
            // 
            this.miSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUser,
            this.miExit});
            this.miSystem.Name = "miSystem";
            this.miSystem.Size = new System.Drawing.Size(44, 21);
            this.miSystem.Text = "系统";
            // 
            // miUser
            // 
            this.miUser.Name = "miUser";
            this.miUser.Size = new System.Drawing.Size(152, 22);
            this.miUser.Text = "用户管理";
            this.miUser.Click += new System.EventHandler(this.miUser_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(152, 22);
            this.miExit.Text = "退出系统";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miFunction
            // 
            this.miFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCommand,
            this.clearCacheToolStripMenuItem});
            this.miFunction.Name = "miFunction";
            this.miFunction.Size = new System.Drawing.Size(44, 21);
            this.miFunction.Text = "功能";
            // 
            // miCommand
            // 
            this.miCommand.Name = "miCommand";
            this.miCommand.Size = new System.Drawing.Size(152, 22);
            this.miCommand.Text = "指令设置";
            this.miCommand.Click += new System.EventHandler(this.miCommand_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpControl);
            this.tcMain.Controls.Add(this.tpMapEdit);
            this.tcMain.Controls.Add(this.tpLog);
            this.tcMain.Location = new System.Drawing.Point(12, 28);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(821, 465);
            this.tcMain.TabIndex = 7;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpControl
            // 
            this.tpControl.Controls.Add(this.lbAtInfo);
            this.tpControl.Controls.Add(this.btStateUpdate);
            this.tpControl.Controls.Add(this.btOpenCom);
            this.tpControl.Controls.Add(this.btComSend);
            this.tpControl.Controls.Add(this.label4);
            this.tpControl.Controls.Add(this.cbSentText);
            this.tpControl.Controls.Add(this.label3);
            this.tpControl.Controls.Add(this.cbComPort);
            this.tpControl.Controls.Add(this.dgvForSendings);
            this.tpControl.Controls.Add(this.pbControlMap);
            this.tpControl.Location = new System.Drawing.Point(4, 22);
            this.tpControl.Name = "tpControl";
            this.tpControl.Padding = new System.Windows.Forms.Padding(3);
            this.tpControl.Size = new System.Drawing.Size(813, 439);
            this.tpControl.TabIndex = 0;
            this.tpControl.Text = "终端控制";
            this.tpControl.UseVisualStyleBackColor = true;
            // 
            // lbAtInfo
            // 
            this.lbAtInfo.BackColor = System.Drawing.Color.Black;
            this.lbAtInfo.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAtInfo.ForeColor = System.Drawing.Color.White;
            this.lbAtInfo.FormattingEnabled = true;
            this.lbAtInfo.ItemHeight = 12;
            this.lbAtInfo.Location = new System.Drawing.Point(604, 267);
            this.lbAtInfo.Name = "lbAtInfo";
            this.lbAtInfo.Size = new System.Drawing.Size(200, 160);
            this.lbAtInfo.TabIndex = 10;
            // 
            // btStateUpdate
            // 
            this.btStateUpdate.Location = new System.Drawing.Point(738, 238);
            this.btStateUpdate.Name = "btStateUpdate";
            this.btStateUpdate.Size = new System.Drawing.Size(69, 23);
            this.btStateUpdate.TabIndex = 9;
            this.btStateUpdate.Text = "更新状态";
            this.btStateUpdate.UseVisualStyleBackColor = true;
            this.btStateUpdate.Click += new System.EventHandler(this.btStateUpdate_Click);
            // 
            // btOpenCom
            // 
            this.btOpenCom.Location = new System.Drawing.Point(602, 238);
            this.btOpenCom.Name = "btOpenCom";
            this.btOpenCom.Size = new System.Drawing.Size(61, 23);
            this.btOpenCom.TabIndex = 7;
            this.btOpenCom.Text = "打开端口";
            this.btOpenCom.UseVisualStyleBackColor = true;
            this.btOpenCom.Click += new System.EventHandler(this.btOpenCom_Click);
            // 
            // btComSend
            // 
            this.btComSend.Location = new System.Drawing.Point(669, 238);
            this.btComSend.Name = "btComSend";
            this.btComSend.Size = new System.Drawing.Size(63, 23);
            this.btComSend.TabIndex = 6;
            this.btComSend.Text = "发送指令";
            this.btComSend.UseVisualStyleBackColor = true;
            this.btComSend.Click += new System.EventHandler(this.btComSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(602, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "指令内容";
            // 
            // cbSentText
            // 
            this.cbSentText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSentText.FormattingEnabled = true;
            this.cbSentText.Location = new System.Drawing.Point(661, 166);
            this.cbSentText.Name = "cbSentText";
            this.cbSentText.Size = new System.Drawing.Size(146, 20);
            this.cbSentText.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "发送端口";
            // 
            // cbComPort
            // 
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Location = new System.Drawing.Point(661, 203);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(146, 20);
            this.cbComPort.TabIndex = 2;
            // 
            // dgvForSendings
            // 
            this.dgvForSendings.AllowUserToResizeColumns = false;
            this.dgvForSendings.AllowUserToResizeRows = false;
            this.dgvForSendings.BackgroundColor = System.Drawing.Color.White;
            this.dgvForSendings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForSendings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectState,
            this.colName,
            this.colNumber,
            this.colState});
            this.dgvForSendings.Location = new System.Drawing.Point(603, 7);
            this.dgvForSendings.Name = "dgvForSendings";
            this.dgvForSendings.RowHeadersVisible = false;
            this.dgvForSendings.RowTemplate.Height = 23;
            this.dgvForSendings.Size = new System.Drawing.Size(204, 150);
            this.dgvForSendings.TabIndex = 1;
            this.dgvForSendings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvForSendings_CellContentClick);
            // 
            // SelectState
            // 
            this.SelectState.HeaderText = "全选";
            this.SelectState.Name = "SelectState";
            this.SelectState.ReadOnly = true;
            this.SelectState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SelectState.Width = 40;
            // 
            // colName
            // 
            this.colName.HeaderText = "终端名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 80;
            // 
            // colNumber
            // 
            this.colNumber.HeaderText = "终端号码";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Visible = false;
            // 
            // colState
            // 
            this.colState.HeaderText = "终端状态";
            this.colState.Name = "colState";
            this.colState.Width = 80;
            // 
            // tpMapEdit
            // 
            this.tpMapEdit.Controls.Add(this.dgvForEdit);
            this.tpMapEdit.Controls.Add(this.panelMapEditEditor);
            this.tpMapEdit.Controls.Add(this.pbEditMap);
            this.tpMapEdit.Location = new System.Drawing.Point(4, 22);
            this.tpMapEdit.Name = "tpMapEdit";
            this.tpMapEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpMapEdit.Size = new System.Drawing.Size(813, 439);
            this.tpMapEdit.TabIndex = 1;
            this.tpMapEdit.Text = "终端设置";
            this.tpMapEdit.UseVisualStyleBackColor = true;
            // 
            // dgvForEdit
            // 
            this.dgvForEdit.BackgroundColor = System.Drawing.Color.White;
            this.dgvForEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNameForEdit,
            this.colNumberForEdit});
            this.dgvForEdit.Location = new System.Drawing.Point(607, 113);
            this.dgvForEdit.Name = "dgvForEdit";
            this.dgvForEdit.RowHeadersVisible = false;
            this.dgvForEdit.RowTemplate.Height = 23;
            this.dgvForEdit.Size = new System.Drawing.Size(203, 318);
            this.dgvForEdit.TabIndex = 9;
            // 
            // colNameForEdit
            // 
            this.colNameForEdit.HeaderText = "终端名称";
            this.colNameForEdit.Name = "colNameForEdit";
            // 
            // colNumberForEdit
            // 
            this.colNumberForEdit.HeaderText = "终端号码";
            this.colNumberForEdit.Name = "colNumberForEdit";
            // 
            // panelMapEditEditor
            // 
            this.panelMapEditEditor.Controls.Add(this.label1);
            this.panelMapEditEditor.Controls.Add(this.btDelete);
            this.panelMapEditEditor.Controls.Add(this.label2);
            this.panelMapEditEditor.Controls.Add(this.btUpdate);
            this.panelMapEditEditor.Controls.Add(this.textBoxNodeName);
            this.panelMapEditEditor.Controls.Add(this.textBoxNodeNumber);
            this.panelMapEditEditor.Location = new System.Drawing.Point(607, 6);
            this.panelMapEditEditor.Name = "panelMapEditEditor";
            this.panelMapEditEditor.Size = new System.Drawing.Size(200, 100);
            this.panelMapEditEditor.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "节点名称";
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(109, 57);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(88, 23);
            this.btDelete.TabIndex = 6;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "节点号码";
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(14, 57);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(89, 23);
            this.btUpdate.TabIndex = 5;
            this.btUpdate.Text = "更新";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // textBoxNodeName
            // 
            this.textBoxNodeName.Location = new System.Drawing.Point(71, 3);
            this.textBoxNodeName.Name = "textBoxNodeName";
            this.textBoxNodeName.Size = new System.Drawing.Size(126, 21);
            this.textBoxNodeName.TabIndex = 2;
            // 
            // textBoxNodeNumber
            // 
            this.textBoxNodeNumber.Location = new System.Drawing.Point(71, 30);
            this.textBoxNodeNumber.Name = "textBoxNodeNumber";
            this.textBoxNodeNumber.Size = new System.Drawing.Size(126, 21);
            this.textBoxNodeNumber.TabIndex = 3;
            // 
            // tpLog
            // 
            this.tpLog.Controls.Add(this.rtbLog);
            this.tpLog.Controls.Add(this.label5);
            this.tpLog.Controls.Add(this.dtpLog);
            this.tpLog.Location = new System.Drawing.Point(4, 22);
            this.tpLog.Name = "tpLog";
            this.tpLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpLog.Size = new System.Drawing.Size(813, 439);
            this.tpLog.TabIndex = 2;
            this.tpLog.Text = "系统日志";
            this.tpLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(8, 39);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(796, 392);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "日志日期";
            // 
            // dtpLog
            // 
            this.dtpLog.Location = new System.Drawing.Point(65, 6);
            this.dtpLog.Name = "dtpLog";
            this.dtpLog.Size = new System.Drawing.Size(200, 21);
            this.dtpLog.TabIndex = 0;
            this.dtpLog.ValueChanged += new System.EventHandler(this.dtpLog_ValueChanged);
            // 
            // cmStripMapEdit
            // 
            this.cmStripMapEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiAdd});
            this.cmStripMapEdit.Name = "cmStripMapEdit";
            this.cmStripMapEdit.Size = new System.Drawing.Size(125, 26);
            // 
            // cmiAdd
            // 
            this.cmiAdd.Name = "cmiAdd";
            this.cmiAdd.Size = new System.Drawing.Size(124, 22);
            this.cmiAdd.Text = "新增节点";
            this.cmiAdd.Click += new System.EventHandler(this.cmiAdd_Click);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearCacheToolStripMenuItem.Text = "清除缓存";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 493);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(848, 532);
            this.MinimumSize = new System.Drawing.Size(848, 532);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科右前旗人防智能终端控制系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEditMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbControlMap)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpControl.ResumeLayout(false);
            this.tpControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForSendings)).EndInit();
            this.tpMapEdit.ResumeLayout(false);
            this.tpMapEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForEdit)).EndInit();
            this.panelMapEditEditor.ResumeLayout(false);
            this.panelMapEditEditor.PerformLayout();
            this.tpLog.ResumeLayout(false);
            this.tpLog.PerformLayout();
            this.cmStripMapEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbControlMap;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miSystem;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miFunction;
        private System.Windows.Forms.PictureBox pbEditMap;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpControl;
        private System.Windows.Forms.TabPage tpMapEdit;
        private System.Windows.Forms.ContextMenuStrip cmStripMapEdit;
        private System.Windows.Forms.ToolStripMenuItem cmiAdd;
        private System.Windows.Forms.Panel panelMapEditEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.TextBox textBoxNodeName;
        private System.Windows.Forms.TextBox textBoxNodeNumber;
        private System.Windows.Forms.DataGridView dgvForSendings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.ComboBox cbSentText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btComSend;
        private System.Windows.Forms.Button btOpenCom;
        private System.Windows.Forms.Button btStateUpdate;
        private System.Windows.Forms.ListBox lbAtInfo;
        private System.Windows.Forms.DataGridView dgvForEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameForEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberForEdit;
        private System.Windows.Forms.ToolStripMenuItem miUser;
        private System.Windows.Forms.ToolStripMenuItem miCommand;
        private System.Windows.Forms.TabPage tpLog;
        private System.Windows.Forms.DateTimePicker dtpLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;

    }
}


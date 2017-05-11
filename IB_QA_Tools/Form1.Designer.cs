namespace IB_QA_Tools
{
    partial class frmMainWindow
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
            this.txtPolicyNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gvPaymentSchedule = new System.Windows.Forms.DataGridView();
            this.btnGetSchedule = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtReasonFailure = new System.Windows.Forms.TextBox();
            this.cbPaymentStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.panelPaymentStatus = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaymentSchedule)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelPaymentStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPolicyNumber
            // 
            this.txtPolicyNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPolicyNumber.Location = new System.Drawing.Point(10, 49);
            this.txtPolicyNumber.Name = "txtPolicyNumber";
            this.txtPolicyNumber.Size = new System.Drawing.Size(190, 27);
            this.txtPolicyNumber.TabIndex = 1;
            this.txtPolicyNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPolicyNumber_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Policy Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Payment Schedule";
            // 
            // gvPaymentSchedule
            // 
            this.gvPaymentSchedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvPaymentSchedule.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.gvPaymentSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPaymentSchedule.Location = new System.Drawing.Point(11, 101);
            this.gvPaymentSchedule.Name = "gvPaymentSchedule";
            this.gvPaymentSchedule.ReadOnly = true;
            this.gvPaymentSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPaymentSchedule.Size = new System.Drawing.Size(907, 327);
            this.gvPaymentSchedule.TabIndex = 4;
            this.gvPaymentSchedule.SelectionChanged += new System.EventHandler(this.gvPaymentSchedule_SelectionChanged);
            // 
            // btnGetSchedule
            // 
            this.btnGetSchedule.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnGetSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetSchedule.ForeColor = System.Drawing.Color.White;
            this.btnGetSchedule.Location = new System.Drawing.Point(206, 48);
            this.btnGetSchedule.Name = "btnGetSchedule";
            this.btnGetSchedule.Size = new System.Drawing.Size(118, 28);
            this.btnGetSchedule.TabIndex = 5;
            this.btnGetSchedule.Text = "Get Schedule";
            this.btnGetSchedule.UseVisualStyleBackColor = false;
            this.btnGetSchedule.Visible = false;
            this.btnGetSchedule.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.toolsToolStripMenuItem.Text = "Operations";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // txtReasonFailure
            // 
            this.txtReasonFailure.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReasonFailure.Location = new System.Drawing.Point(571, 18);
            this.txtReasonFailure.Name = "txtReasonFailure";
            this.txtReasonFailure.Size = new System.Drawing.Size(212, 27);
            this.txtReasonFailure.TabIndex = 7;
            // 
            // cbPaymentStatus
            // 
            this.cbPaymentStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaymentStatus.FormattingEnabled = true;
            this.cbPaymentStatus.Location = new System.Drawing.Point(379, 18);
            this.cbPaymentStatus.Name = "cbPaymentStatus";
            this.cbPaymentStatus.Size = new System.Drawing.Size(186, 28);
            this.cbPaymentStatus.TabIndex = 9;
            this.cbPaymentStatus.SelectedIndexChanged += new System.EventHandler(this.cbPaymentStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(388, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Payment Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(580, 436);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Reason for failure";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(658, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "To select multiple entries please use Ctrl/Shift key\r\n";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(788, 17);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(106, 28);
            this.btnUpdateStatus.TabIndex = 8;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // panelPaymentStatus
            // 
            this.panelPaymentStatus.Controls.Add(this.btnUpdateStatus);
            this.panelPaymentStatus.Controls.Add(this.txtReasonFailure);
            this.panelPaymentStatus.Controls.Add(this.cbPaymentStatus);
            this.panelPaymentStatus.Enabled = false;
            this.panelPaymentStatus.Location = new System.Drawing.Point(12, 434);
            this.panelPaymentStatus.Name = "panelPaymentStatus";
            this.panelPaymentStatus.Size = new System.Drawing.Size(906, 51);
            this.panelPaymentStatus.TabIndex = 13;
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 498);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetSchedule);
            this.Controls.Add(this.gvPaymentSchedule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPolicyNumber);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelPaymentStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turbo1.2  IB QA Tool";
            ((System.ComponentModel.ISupportInitialize)(this.gvPaymentSchedule)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelPaymentStatus.ResumeLayout(false);
            this.panelPaymentStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPolicyNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gvPaymentSchedule;
        private System.Windows.Forms.Button btnGetSchedule;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox txtReasonFailure;
        private System.Windows.Forms.ComboBox cbPaymentStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Panel panelPaymentStatus;
    }
}


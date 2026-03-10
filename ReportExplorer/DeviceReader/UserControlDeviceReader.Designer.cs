namespace ReportExplorer
{
    partial class UserControlDeviceReader
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEU7 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDrift = new DevExpress.XtraEditors.SimpleButton();
            this.btnAnr = new DevExpress.XtraEditors.SimpleButton();
            this.btnLincheck = new DevExpress.XtraEditors.SimpleButton();
            this.EditSocket = new DevExpress.XtraEditors.TextEdit();
            this.labelDevice = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportExplorer.DeviceWaitForm), true, true, typeof(System.Windows.Forms.UserControl));
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditSocket.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20.44F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 84.56F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.EditSocket);
            this.tablePanel1.Controls.Add(this.labelDevice);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(314, 84);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            this.tablePanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tablePanel1_Paint);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl1, 2);
            this.panelControl1.Controls.Add(this.btnEU7);
            this.panelControl1.Controls.Add(this.btnDrift);
            this.panelControl1.Controls.Add(this.btnAnr);
            this.panelControl1.Controls.Add(this.btnLincheck);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(13, 42);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 1);
            this.panelControl1.Size = new System.Drawing.Size(288, 29);
            this.panelControl1.TabIndex = 3;
            // 
            // btnEU7
            // 
            this.btnEU7.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEU7.Location = new System.Drawing.Point(180, 0);
            this.btnEU7.Name = "btnEU7";
            this.btnEU7.Size = new System.Drawing.Size(60, 29);
            this.btnEU7.TabIndex = 3;
            this.btnEU7.Text = "EU7";
            // 
            // btnDrift
            // 
            this.btnDrift.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDrift.Location = new System.Drawing.Point(120, 0);
            this.btnDrift.Name = "btnDrift";
            this.btnDrift.Size = new System.Drawing.Size(60, 29);
            this.btnDrift.TabIndex = 2;
            this.btnDrift.Text = "Drift";
            // 
            // btnAnr
            // 
            this.btnAnr.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAnr.Location = new System.Drawing.Point(60, 0);
            this.btnAnr.Name = "btnAnr";
            this.btnAnr.Size = new System.Drawing.Size(60, 29);
            this.btnAnr.TabIndex = 1;
            this.btnAnr.Text = "ANR";
            // 
            // btnLincheck
            // 
            this.btnLincheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLincheck.Location = new System.Drawing.Point(0, 0);
            this.btnLincheck.Name = "btnLincheck";
            this.btnLincheck.Size = new System.Drawing.Size(60, 29);
            this.btnLincheck.TabIndex = 0;
            this.btnLincheck.Text = "Linearity";
            this.btnLincheck.Click += new System.EventHandler(this.btnLincheck_Click);
            // 
            // EditSocket
            // 
            this.tablePanel1.SetColumn(this.EditSocket, 1);
            this.EditSocket.EditValue = "IP-adress";
            this.EditSocket.Location = new System.Drawing.Point(70, 14);
            this.EditSocket.Name = "EditSocket";
            this.EditSocket.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSocket.Properties.Appearance.Options.UseFont = true;
            this.tablePanel1.SetRow(this.EditSocket, 0);
            this.EditSocket.Size = new System.Drawing.Size(231, 22);
            this.EditSocket.TabIndex = 2;
            // 
            // labelDevice
            // 
            this.labelDevice.Appearance.Font = new System.Drawing.Font("Tahoma", 10.75F, System.Drawing.FontStyle.Bold);
            this.labelDevice.Appearance.Options.UseFont = true;
            this.tablePanel1.SetColumn(this.labelDevice, 0);
            this.labelDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDevice.Location = new System.Drawing.Point(13, 12);
            this.labelDevice.Name = "labelDevice";
            this.tablePanel1.SetRow(this.labelDevice, 0);
            this.labelDevice.Size = new System.Drawing.Size(53, 26);
            this.labelDevice.TabIndex = 1;
            this.labelDevice.Text = "LGD";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // UserControlDeviceReader
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Name = "UserControlDeviceReader";
            this.Size = new System.Drawing.Size(314, 84);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditSocket.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit EditSocket;
        private DevExpress.XtraEditors.LabelControl labelDevice;
        private DevExpress.XtraEditors.SimpleButton btnLincheck;
        private DevExpress.XtraEditors.SimpleButton btnDrift;
        private DevExpress.XtraEditors.SimpleButton btnAnr;
        private DevExpress.XtraEditors.SimpleButton btnEU7;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}

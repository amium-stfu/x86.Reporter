namespace ReportExplorer
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
            this.WaitFormManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportExplorer.DeviceWaitForm), true, true);
            this.panelDefault = new DevExpress.XtraEditors.PanelControl();
            this.btnEditReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPublishLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.btnUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnGerman = new DevExpress.XtraEditors.SimpleButton();
            this.btnEnglish = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.space1 = new DevExpress.XtraEditors.LabelControl();
            this.btnMenu = new DevExpress.XtraEditors.SimpleButton();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.controlMqttStatusBottom = new ReportExplorer.ControlMqttStatusBottom();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.barManagerMenu = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.SubLgdImport = new DevExpress.XtraBars.BarSubItem();
            this.lgdSocket = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnLgdLincheck = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.datetime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cfg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeviceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Order = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bottomStatusControl1 = new ReportExplorer.ControlMqttStatusBottom();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.popupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelDefault)).BeginInit();
            this.panelDefault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // WaitFormManager
            // 
            this.WaitFormManager.ClosingDelay = 500;
            // 
            // panelDefault
            // 
            this.panelDefault.Appearance.BackColor = System.Drawing.Color.White;
            this.panelDefault.Appearance.Options.UseBackColor = true;
            this.panelDefault.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelDefault, 0);
            this.tablePanel1.SetColumnSpan(this.panelDefault, 2);
            this.panelDefault.Controls.Add(this.btnEditReport);
            this.panelDefault.Controls.Add(this.btnImportReport);
            this.panelDefault.Controls.Add(this.btnPublishLanguage);
            this.panelDefault.Controls.Add(this.btnExportLanguage);
            this.panelDefault.Controls.Add(this.btnUser);
            this.panelDefault.Controls.Add(this.btnGerman);
            this.panelDefault.Controls.Add(this.btnEnglish);
            this.panelDefault.Controls.Add(this.btnSave);
            this.panelDefault.Controls.Add(this.btnPrint);
            this.panelDefault.Controls.Add(this.space1);
            this.panelDefault.Controls.Add(this.btnMenu);
            this.panelDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDefault.Location = new System.Drawing.Point(13, 58);
            this.panelDefault.Name = "panelDefault";
            this.tablePanel1.SetRow(this.panelDefault, 2);
            this.panelDefault.Size = new System.Drawing.Size(1637, 76);
            this.panelDefault.TabIndex = 5;
            // 
            // btnEditReport
            // 
            this.btnEditReport.AllowFocus = false;
            this.btnEditReport.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnEditReport.Appearance.Options.UseForeColor = true;
            this.btnEditReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnEditReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEditReport.ImageOptions.SvgImage")));
            this.btnEditReport.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnEditReport.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnEditReport.Location = new System.Drawing.Point(1242, 0);
            this.btnEditReport.Name = "btnEditReport";
            this.btnEditReport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEditReport.Size = new System.Drawing.Size(80, 76);
            this.btnEditReport.TabIndex = 8;
            this.btnEditReport.Text = "New\r\nReport";
            // 
            // btnImportReport
            // 
            this.btnImportReport.AllowFocus = false;
            this.btnImportReport.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnImportReport.Appearance.Options.UseForeColor = true;
            this.btnImportReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImportReport.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnImportReport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImportReport.ImageOptions.SvgImage")));
            this.btnImportReport.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnImportReport.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnImportReport.Location = new System.Drawing.Point(1322, 0);
            this.btnImportReport.Name = "btnImportReport";
            this.btnImportReport.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnImportReport.Size = new System.Drawing.Size(80, 76);
            this.btnImportReport.TabIndex = 7;
            this.btnImportReport.Text = "Import\r\nReportfile";
            this.btnImportReport.Click += new System.EventHandler(this.btnImportReport_Click);
            // 
            // btnPublishLanguage
            // 
            this.btnPublishLanguage.AllowFocus = false;
            this.btnPublishLanguage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnPublishLanguage.Appearance.Options.UseForeColor = true;
            this.btnPublishLanguage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPublishLanguage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPublishLanguage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPublishLanguage.ImageOptions.SvgImage")));
            this.btnPublishLanguage.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnPublishLanguage.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnPublishLanguage.Location = new System.Drawing.Point(1402, 0);
            this.btnPublishLanguage.Name = "btnPublishLanguage";
            this.btnPublishLanguage.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPublishLanguage.Size = new System.Drawing.Size(80, 76);
            this.btnPublishLanguage.TabIndex = 6;
            this.btnPublishLanguage.Text = "Publish\r\nLanguage";
            this.btnPublishLanguage.Click += new System.EventHandler(this.btnPublishLanguage_Click);
            // 
            // btnExportLanguage
            // 
            this.btnExportLanguage.AllowFocus = false;
            this.btnExportLanguage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnExportLanguage.Appearance.Options.UseForeColor = true;
            this.btnExportLanguage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExportLanguage.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnExportLanguage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExportLanguage.ImageOptions.SvgImage")));
            this.btnExportLanguage.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnExportLanguage.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnExportLanguage.Location = new System.Drawing.Point(1482, 0);
            this.btnExportLanguage.Name = "btnExportLanguage";
            this.btnExportLanguage.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExportLanguage.Size = new System.Drawing.Size(80, 76);
            this.btnExportLanguage.TabIndex = 5;
            this.btnExportLanguage.Text = "Export\r\nLanguage";
            this.btnExportLanguage.Click += new System.EventHandler(this.btnExportLanguage_Click);
            // 
            // btnUser
            // 
            this.btnUser.AllowFocus = false;
            this.btnUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUser.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUser.ImageOptions.SvgImage")));
            this.btnUser.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnUser.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUser.Location = new System.Drawing.Point(1562, 0);
            this.btnUser.Name = "btnUser";
            this.btnUser.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUser.Size = new System.Drawing.Size(75, 76);
            this.btnUser.TabIndex = 2;
            this.btnUser.Text = "User";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnGerman
            // 
            this.btnGerman.AllowFocus = false;
            this.btnGerman.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnGerman.Appearance.Options.UseForeColor = true;
            this.btnGerman.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGerman.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnGerman.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGerman.ImageOptions.SvgImage")));
            this.btnGerman.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnGerman.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnGerman.Location = new System.Drawing.Point(353, 0);
            this.btnGerman.Name = "btnGerman";
            this.btnGerman.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnGerman.Size = new System.Drawing.Size(102, 76);
            this.btnGerman.TabIndex = 2;
            this.btnGerman.Text = "Deutsch";
            this.btnGerman.Click += new System.EventHandler(this.btnGerman_Click);
            // 
            // btnEnglish
            // 
            this.btnEnglish.AllowFocus = false;
            this.btnEnglish.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnEnglish.Appearance.Options.UseForeColor = true;
            this.btnEnglish.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEnglish.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnEnglish.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEnglish.ImageOptions.SvgImage")));
            this.btnEnglish.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnEnglish.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnEnglish.Location = new System.Drawing.Point(251, 0);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnEnglish.Size = new System.Drawing.Size(102, 76);
            this.btnEnglish.TabIndex = 2;
            this.btnEnglish.Text = "English";
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(170, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSave.Size = new System.Drawing.Size(81, 76);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AllowFocus = false;
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnPrint.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnPrint.Location = new System.Drawing.Point(89, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPrint.Size = new System.Drawing.Size(81, 76);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // space1
            // 
            this.space1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.space1.Dock = System.Windows.Forms.DockStyle.Left;
            this.space1.Location = new System.Drawing.Point(75, 0);
            this.space1.Name = "space1";
            this.space1.Size = new System.Drawing.Size(14, 76);
            this.space1.TabIndex = 4;
            // 
            // btnMenu
            // 
            this.btnMenu.AllowFocus = false;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMenu.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMenu.ImageOptions.SvgImage = global::ReportExplorer.Properties.Resources.menu1;
            this.btnMenu.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.btnMenu.ImageOptions.SvgImageSize = new System.Drawing.Size(30, 30);
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMenu.Size = new System.Drawing.Size(75, 76);
            this.btnMenu.TabIndex = 9;
            this.btnMenu.Text = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 700F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 48.07F)});
            this.tablePanel1.Controls.Add(this.controlMqttStatusBottom);
            this.tablePanel1.Controls.Add(this.panelDefault);
            this.tablePanel1.Controls.Add(this.pdfViewer1);
            this.tablePanel1.Controls.Add(this.gridControl);
            this.tablePanel1.Controls.Add(this.panelControl2);
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 6F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 463F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 6F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F)});
            this.tablePanel1.Size = new System.Drawing.Size(1663, 681);
            this.tablePanel1.TabIndex = 1;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // controlMqttStatusBottom
            // 
            this.controlMqttStatusBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.controlMqttStatusBottom.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.controlMqttStatusBottom, 0);
            this.tablePanel1.SetColumnSpan(this.controlMqttStatusBottom, 2);
            this.controlMqttStatusBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlMqttStatusBottom.Location = new System.Drawing.Point(13, 632);
            this.controlMqttStatusBottom.Name = "controlMqttStatusBottom";
            this.tablePanel1.SetRow(this.controlMqttStatusBottom, 5);
            this.controlMqttStatusBottom.Size = new System.Drawing.Size(1637, 36);
            this.controlMqttStatusBottom.TabIndex = 12;
            // 
            // pdfViewer1
            // 
            this.tablePanel1.SetColumn(this.pdfViewer1, 1);
            this.pdfViewer1.DetachStreamAfterLoadComplete = true;
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(713, 138);
            this.pdfViewer1.MenuManager = this.barManagerMenu;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            this.pdfViewer1.ReadOnly = true;
            this.tablePanel1.SetRow(this.pdfViewer1, 3);
            this.pdfViewer1.Size = new System.Drawing.Size(937, 484);
            this.pdfViewer1.TabIndex = 11;
            // 
            // barManagerMenu
            // 
            this.barManagerMenu.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("Device Import", new System.Guid("048569c6-f8f2-4880-81a6-6078b041cb05"))});
            this.barManagerMenu.DockControls.Add(this.barDockControlTop);
            this.barManagerMenu.DockControls.Add(this.barDockControlBottom);
            this.barManagerMenu.DockControls.Add(this.barDockControlLeft);
            this.barManagerMenu.DockControls.Add(this.barDockControlRight);
            this.barManagerMenu.DockWindowTabFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barManagerMenu.Form = this;
            this.barManagerMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.SubLgdImport,
            this.lgdSocket,
            this.btnLgdLincheck,
            this.barEditItem1});
            this.barManagerMenu.MaxItemId = 7;
            this.barManagerMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemButtonEdit2});
            this.barManagerMenu.ShowFullMenus = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerMenu;
            this.barDockControlTop.Size = new System.Drawing.Size(1663, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 681);
            this.barDockControlBottom.Manager = this.barManagerMenu;
            this.barDockControlBottom.Size = new System.Drawing.Size(1663, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManagerMenu;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 681);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1663, 0);
            this.barDockControlRight.Manager = this.barManagerMenu;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 681);
            // 
            // SubLgdImport
            // 
            this.SubLgdImport.Caption = "Import from LGD";
            this.SubLgdImport.CategoryGuid = new System.Guid("048569c6-f8f2-4880-81a6-6078b041cb05");
            this.SubLgdImport.Id = 3;
            this.SubLgdImport.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lgdSocket),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLgdLincheck)});
            this.SubLgdImport.MenuAppearance.AppearanceMenu.Hovered.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.SubLgdImport.MenuAppearance.AppearanceMenu.Hovered.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.AppearanceMenu.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubLgdImport.MenuAppearance.AppearanceMenu.Normal.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.AppearanceMenu.Pressed.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.SubLgdImport.MenuAppearance.AppearanceMenu.Pressed.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.HeaderItemAppearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.SubLgdImport.MenuAppearance.HeaderItemAppearance.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.MenuBar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubLgdImport.MenuAppearance.MenuBar.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.MenuCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubLgdImport.MenuAppearance.MenuCaption.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.SideStrip.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.SubLgdImport.MenuAppearance.SideStrip.Options.UseFont = true;
            this.SubLgdImport.MenuAppearance.SideStripNonRecent.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.SubLgdImport.MenuAppearance.SideStripNonRecent.Options.UseFont = true;
            this.SubLgdImport.Name = "SubLgdImport";
            // 
            // lgdSocket
            // 
            this.lgdSocket.Caption = "Socket";
            this.lgdSocket.CaptionToEditorIndent = 4;
            this.lgdSocket.CategoryGuid = new System.Guid("048569c6-f8f2-4880-81a6-6078b041cb05");
            this.lgdSocket.Edit = this.repositoryItemTextEdit1;
            this.lgdSocket.EditWidth = 180;
            this.lgdSocket.Id = 4;
            this.lgdSocket.Name = "lgdSocket";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.Font = new System.Drawing.Font("Tahoma", 12.25F);
            this.repositoryItemTextEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // btnLgdLincheck
            // 
            this.btnLgdLincheck.Caption = "Linearity Check";
            this.btnLgdLincheck.CategoryGuid = new System.Guid("048569c6-f8f2-4880-81a6-6078b041cb05");
            this.btnLgdLincheck.Id = 5;
            this.btnLgdLincheck.ImageOptions.SvgImage = global::ReportExplorer.Properties.Resources.checkmark1_80840;
            this.btnLgdLincheck.Name = "btnLgdLincheck";
            this.btnLgdLincheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLgdLincheck_ItemClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemButtonEdit2;
            this.barEditItem1.Id = 6;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // gridControl
            // 
            this.tablePanel1.SetColumn(this.gridControl, 0);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(13, 138);
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.tablePanel1.SetRow(this.gridControl, 3);
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(696, 484);
            this.gridControl.TabIndex = 10;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl.Click += new System.EventHandler(this.gridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.datetime,
            this.Type,
            this.Cfg,
            this.DeviceID,
            this.Date,
            this.Order,
            this.Result});
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 22;
            // 
            // Id
            // 
            this.Id.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.Id.AppearanceCell.Options.UseFont = true;
            this.Id.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.Id.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.Id.AppearanceHeader.Options.UseBackColor = true;
            this.Id.AppearanceHeader.Options.UseFont = true;
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.OptionsColumn.AllowFocus = false;
            this.Id.OptionsColumn.AllowMove = false;
            this.Id.Width = 152;
            // 
            // datetime
            // 
            this.datetime.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.datetime.AppearanceCell.Options.UseFont = true;
            this.datetime.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.datetime.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.datetime.AppearanceHeader.Options.UseBackColor = true;
            this.datetime.AppearanceHeader.Options.UseFont = true;
            this.datetime.Caption = "Report date";
            this.datetime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.datetime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datetime.FieldName = "datetime";
            this.datetime.Name = "datetime";
            this.datetime.OptionsColumn.AllowEdit = false;
            this.datetime.OptionsColumn.AllowFocus = false;
            this.datetime.OptionsColumn.AllowMove = false;
            this.datetime.OptionsColumn.ReadOnly = true;
            this.datetime.Visible = true;
            this.datetime.VisibleIndex = 0;
            this.datetime.Width = 242;
            // 
            // Type
            // 
            this.Type.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.Type.AppearanceCell.Options.UseFont = true;
            this.Type.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.Type.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.Type.AppearanceHeader.Options.UseBackColor = true;
            this.Type.AppearanceHeader.Options.UseFont = true;
            this.Type.Caption = "Type";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            this.Type.OptionsColumn.AllowEdit = false;
            this.Type.OptionsColumn.AllowFocus = false;
            this.Type.OptionsColumn.AllowMove = false;
            this.Type.Visible = true;
            this.Type.VisibleIndex = 1;
            this.Type.Width = 104;
            // 
            // Cfg
            // 
            this.Cfg.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.Cfg.AppearanceCell.Options.UseFont = true;
            this.Cfg.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.Cfg.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.Cfg.AppearanceHeader.Options.UseBackColor = true;
            this.Cfg.AppearanceHeader.Options.UseFont = true;
            this.Cfg.Caption = "Cfg";
            this.Cfg.FieldName = "Cfg";
            this.Cfg.Name = "Cfg";
            this.Cfg.OptionsColumn.AllowEdit = false;
            this.Cfg.OptionsColumn.AllowFocus = false;
            this.Cfg.OptionsColumn.AllowMove = false;
            this.Cfg.Visible = true;
            this.Cfg.VisibleIndex = 2;
            this.Cfg.Width = 166;
            // 
            // DeviceID
            // 
            this.DeviceID.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.DeviceID.AppearanceCell.Options.UseFont = true;
            this.DeviceID.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.DeviceID.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.DeviceID.AppearanceHeader.Options.UseBackColor = true;
            this.DeviceID.AppearanceHeader.Options.UseFont = true;
            this.DeviceID.Caption = "DeviceID";
            this.DeviceID.FieldName = "DeviceID";
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.OptionsColumn.AllowEdit = false;
            this.DeviceID.OptionsColumn.AllowFocus = false;
            this.DeviceID.OptionsColumn.AllowMove = false;
            this.DeviceID.Visible = true;
            this.DeviceID.VisibleIndex = 3;
            this.DeviceID.Width = 140;
            // 
            // Date
            // 
            this.Date.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.Date.AppearanceCell.Options.UseFont = true;
            this.Date.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.Date.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.Date.AppearanceHeader.Options.UseBackColor = true;
            this.Date.AppearanceHeader.Options.UseFont = true;
            this.Date.Caption = "Date";
            this.Date.FieldName = "Date";
            this.Date.Name = "Date";
            this.Date.OptionsColumn.AllowEdit = false;
            this.Date.OptionsColumn.AllowFocus = false;
            this.Date.OptionsColumn.AllowMove = false;
            this.Date.Visible = true;
            this.Date.VisibleIndex = 4;
            this.Date.Width = 252;
            // 
            // Order
            // 
            this.Order.AppearanceCell.Font = new System.Drawing.Font("Calibri", 12F);
            this.Order.AppearanceCell.Options.UseFont = true;
            this.Order.AppearanceHeader.BackColor = System.Drawing.Color.White;
            this.Order.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.Order.AppearanceHeader.Options.UseBackColor = true;
            this.Order.AppearanceHeader.Options.UseFont = true;
            this.Order.Caption = "Order";
            this.Order.FieldName = "Order";
            this.Order.Name = "Order";
            this.Order.OptionsColumn.AllowEdit = false;
            this.Order.OptionsColumn.AllowFocus = false;
            this.Order.OptionsColumn.AllowMove = false;
            this.Order.Visible = true;
            this.Order.VisibleIndex = 5;
            this.Order.Width = 232;
            // 
            // Result
            // 
            this.Result.Caption = "Result";
            this.Result.FieldName = "Result";
            this.Result.Name = "Result";
            this.Result.OptionsColumn.AllowEdit = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl2, 0);
            this.tablePanel1.SetColumnSpan(this.panelControl2, 2);
            this.panelControl2.Controls.Add(this.picLogo);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(13, 12);
            this.panelControl2.Name = "panelControl2";
            this.tablePanel1.SetRow(this.panelControl2, 0);
            this.panelControl2.Size = new System.Drawing.Size(1637, 36);
            this.panelControl2.TabIndex = 9;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Right;
            this.picLogo.EditValue = ((object)(resources.GetObject("picLogo.EditValue")));
            this.picLogo.Location = new System.Drawing.Point(1501, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.AllowFocused = false;
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(136, 36);
            this.picLogo.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl3.Location = new System.Drawing.Point(0, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(178, 33);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Report Explorer";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.labelControl2, 0);
            this.tablePanel1.SetColumnSpan(this.labelControl2, 2);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(13, 626);
            this.labelControl2.Name = "labelControl2";
            this.tablePanel1.SetRow(this.labelControl2, 4);
            this.labelControl2.Size = new System.Drawing.Size(1637, 2);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "labelControl2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.tablePanel1.SetColumn(this.labelControl1, 0);
            this.tablePanel1.SetColumnSpan(this.labelControl1, 2);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(13, 52);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 1);
            this.labelControl1.Size = new System.Drawing.Size(1637, 2);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "labelControl1";
            // 
            // bottomStatusControl1
            // 
            this.bottomStatusControl1.Location = new System.Drawing.Point(0, 0);
            this.bottomStatusControl1.Name = "bottomStatusControl1";
            this.bottomStatusControl1.Size = new System.Drawing.Size(1253, 37);
            this.bottomStatusControl1.TabIndex = 0;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            // 
            // popupMenu
            // 
            this.popupMenu.DrawMenuSideStrip = DevExpress.Utils.DefaultBoolean.True;
            this.popupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.SubLgdImport)});
            this.popupMenu.Manager = this.barManagerMenu;
            this.popupMenu.MenuAppearance.AppearanceMenu.Hovered.Font = new System.Drawing.Font("Tahoma", 12F);
            this.popupMenu.MenuAppearance.AppearanceMenu.Hovered.Options.UseFont = true;
            this.popupMenu.MenuAppearance.AppearanceMenu.Normal.BackColor = System.Drawing.Color.White;
            this.popupMenu.MenuAppearance.AppearanceMenu.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupMenu.MenuAppearance.AppearanceMenu.Normal.Options.UseFont = true;
            this.popupMenu.MenuAppearance.HeaderItemAppearance.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.popupMenu.MenuAppearance.HeaderItemAppearance.Options.UseFont = true;
            this.popupMenu.MenuAppearance.MenuBar.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.popupMenu.MenuAppearance.MenuBar.Options.UseFont = true;
            this.popupMenu.MenuAppearance.MenuCaption.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.popupMenu.MenuAppearance.MenuCaption.Options.UseFont = true;
            this.popupMenu.MenuAppearance.SideStrip.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.popupMenu.MenuAppearance.SideStrip.Options.UseFont = true;
            this.popupMenu.MenuAppearance.SideStripNonRecent.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.popupMenu.MenuAppearance.SideStripNonRecent.Options.UseFont = true;
            this.popupMenu.Name = "popupMenu";
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1663, 681);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MainForm.IconOptions.SvgImage")));
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelDefault)).EndInit();
            this.panelDefault.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelDefault;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraGrid.GridControl gridControl;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn Cfg;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceID;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn Order;
        private DevExpress.XtraGrid.Columns.GridColumn Result;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraEditors.SimpleButton btnEnglish;
        private DevExpress.XtraEditors.SimpleButton btnGerman;
        private DevExpress.XtraEditors.SimpleButton btnUser;
        private DevExpress.XtraEditors.LabelControl space1;
        private DevExpress.XtraEditors.SimpleButton btnPublishLanguage;
        private DevExpress.XtraEditors.SimpleButton btnExportLanguage;
        private DevExpress.XtraEditors.SimpleButton btnImportReport;
        private DevExpress.XtraEditors.SimpleButton btnEditReport;
        private ControlMqttStatusBottom bottomStatusControl1;
        private ControlMqttStatusBottom controlMqttStatusBottom;
        private DevExpress.XtraGrid.Columns.GridColumn datetime;
        private DevExpress.XtraEditors.SimpleButton btnMenu;
        private DevExpress.XtraBars.BarManager barManagerMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem SubLgdImport;
        private DevExpress.XtraBars.PopupMenu popupMenu;
        private DevExpress.XtraBars.BarEditItem lgdSocket;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem btnLgdLincheck;
        private DevExpress.XtraSplashScreen.SplashScreenManager WaitFormManager;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
    }
}
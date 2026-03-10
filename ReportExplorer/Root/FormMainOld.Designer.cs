namespace ReportExplorer
{
    partial class FormMainOld
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainOld));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Print = new DevExpress.XtraBars.BarButtonItem();
            this.Save = new DevExpress.XtraBars.BarButtonItem();
            this.Online = new DevExpress.XtraBars.BarCheckItem();
            this.Broker = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Topic = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Region_de = new DevExpress.XtraBars.BarCheckItem();
            this.Region_en = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.space = new DevExpress.XtraBars.BarStaticItem();
            this.ExportLanguageFile = new DevExpress.XtraBars.BarButtonItem();
            this.openDevice = new DevExpress.XtraBars.BarButtonItem();
            this.lgdSocket = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.split = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.btnLinCheck = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.lgdImport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.lgd = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cfg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeviceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Order = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Result = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.BackColor = System.Drawing.Color.White;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.Print,
            this.Save,
            this.Online,
            this.Broker,
            this.Topic,
            this.Region_de,
            this.Region_en,
            this.barButtonItem1,
            this.barButtonItem2,
            this.space,
            this.ExportLanguageFile,
            this.openDevice,
            this.lgdSocket,
            this.split,
            this.barButtonItem3,
            this.barEditItem1,
            this.btnLinCheck,
            this.barButtonItem4});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 28;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.lgdImport});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemPictureEdit1});
            this.ribbonControl1.Size = new System.Drawing.Size(1333, 158);
            // 
            // Print
            // 
            this.Print.Caption = "Print";
            this.Print.Id = 1;
            this.Print.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Print.ImageOptions.SvgImage")));
            this.Print.Name = "Print";
            this.Print.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonPrint_ItemClick);
            // 
            // Save
            // 
            this.Save.AllowRightClickInMenu = false;
            this.Save.Caption = "Save";
            this.Save.Id = 3;
            this.Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Save.ImageOptions.SvgImage")));
            this.Save.Name = "Save";
            this.Save.VisibleInSearchMenu = false;
            this.Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSave_ItemClick);
            // 
            // Online
            // 
            this.Online.Caption = "Unknown";
            this.Online.Id = 5;
            this.Online.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Online.ImageOptions.SvgImage")));
            this.Online.Name = "Online";
            this.Online.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // Broker
            // 
            this.Broker.Caption = "Broker";
            this.Broker.Edit = this.repositoryItemTextEdit1;
            this.Broker.EditWidth = 200;
            this.Broker.Id = 6;
            this.Broker.Name = "Broker";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // Topic
            // 
            this.Topic.Caption = "Topic";
            this.Topic.CaptionToEditorIndent = 9;
            this.Topic.Edit = this.repositoryItemTextEdit2;
            this.Topic.EditValue = "";
            this.Topic.EditWidth = 200;
            this.Topic.Id = 7;
            this.Topic.Name = "Topic";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // Region_de
            // 
            this.Region_de.Caption = "DE";
            this.Region_de.Id = 12;
            this.Region_de.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Region_de.ImageOptions.SvgImage")));
            this.Region_de.Name = "Region_de";
            this.Region_de.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.Region_de_CheckedChanged);
            // 
            // Region_en
            // 
            this.Region_en.BindableChecked = true;
            this.Region_en.Caption = "EN";
            this.Region_en.Checked = true;
            this.Region_en.Id = 13;
            this.Region_en.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("Region_en.ImageOptions.SvgImage")));
            this.Region_en.Name = "Region_en";
            this.Region_en.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.Region_en_CheckedChanged);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Language";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "C0 Report";
            this.barButtonItem2.Id = 15;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // space
            // 
            this.space.Caption = "          ";
            this.space.Id = 16;
            this.space.Name = "space";
            // 
            // ExportLanguageFile
            // 
            this.ExportLanguageFile.Caption = "Language";
            this.ExportLanguageFile.Id = 17;
            this.ExportLanguageFile.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ExportLanguageFile.ImageOptions.SvgImage")));
            this.ExportLanguageFile.Name = "ExportLanguageFile";
            this.ExportLanguageFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportLanguageFile_ItemClick);
            // 
            // openDevice
            // 
            this.openDevice.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.openDevice.Caption = "LinCheck";
            this.openDevice.Id = 21;
            this.openDevice.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.openDevice.Name = "openDevice";
            this.openDevice.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // lgdSocket
            // 
            this.lgdSocket.Caption = "Socket";
            this.lgdSocket.Edit = this.repositoryItemTextEdit3;
            this.lgdSocket.EditHeight = 22;
            this.lgdSocket.EditValue = "127.0.0.1:7700";
            this.lgdSocket.EditWidth = 100;
            this.lgdSocket.Id = 22;
            this.lgdSocket.Name = "lgdSocket";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // split
            // 
            this.split.Id = 23;
            this.split.Name = "split";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 24;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_3);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = this.repositoryItemPictureEdit1;
            this.barEditItem1.Id = 25;
            this.barEditItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEditItem1.ImageOptions.Image")));
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // btnLinCheck
            // 
            this.btnLinCheck.Caption = "Lincheck";
            this.btnLinCheck.Id = 26;
            this.btnLinCheck.ItemAppearance.Hovered.BackColor = System.Drawing.Color.LightGray;
            this.btnLinCheck.ItemAppearance.Hovered.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnLinCheck.ItemAppearance.Hovered.Options.UseBackColor = true;
            this.btnLinCheck.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnLinCheck.ItemAppearance.Normal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLinCheck.ItemAppearance.Normal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinCheck.ItemAppearance.Normal.Options.UseBackColor = true;
            this.btnLinCheck.ItemAppearance.Normal.Options.UseFont = true;
            this.btnLinCheck.ItemAppearance.Pressed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.btnLinCheck.ItemAppearance.Pressed.ForeColor = System.Drawing.Color.Gray;
            this.btnLinCheck.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnLinCheck.ItemAppearance.Pressed.Options.UseForeColor = true;
            this.btnLinCheck.Name = "btnLinCheck";
            this.btnLinCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLinCheck_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "PDF View";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.Print);
            this.ribbonPageGroup1.ItemLinks.Add(this.Save);
            this.ribbonPageGroup1.ItemLinks.Add(this.space);
            this.ribbonPageGroup1.ItemLinks.Add(this.Region_de);
            this.ribbonPageGroup1.ItemLinks.Add(this.Region_en);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup3.ItemLinks.Add(this.Online);
            this.ribbonPageGroup3.ItemLinks.Add(this.Broker);
            this.ribbonPageGroup3.ItemLinks.Add(this.Topic);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "MQTT Data";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Import";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.ExportLanguageFile);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Export";
            // 
            // lgdImport
            // 
            this.lgdImport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.lgd});
            this.lgdImport.Name = "lgdImport";
            this.lgdImport.Text = "Device Import";
            // 
            // lgd
            // 
            this.lgd.ItemLinks.Add(this.lgdSocket);
            this.lgd.ItemLinks.Add(this.btnLinCheck);
            this.lgd.Name = "lgd";
            this.lgd.Text = "LGD";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 486.09F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 39.91F)});
            this.tablePanel1.Controls.Add(this.gridControl1);
            this.tablePanel1.Controls.Add(this.pdfViewer1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 158);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 7F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F)});
            this.tablePanel1.Size = new System.Drawing.Size(1333, 695);
            this.tablePanel1.TabIndex = 1;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(13, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.tablePanel1.SetRow(this.gridControl1, 1);
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(482, 587);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.Type,
            this.Cfg,
            this.DeviceID,
            this.Date,
            this.Order,
            this.Result});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.AllowEdit = false;
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            this.Id.Width = 152;
            // 
            // Type
            // 
            this.Type.Caption = "Type";
            this.Type.FieldName = "Type";
            this.Type.Name = "Type";
            this.Type.OptionsColumn.AllowEdit = false;
            this.Type.Visible = true;
            this.Type.VisibleIndex = 1;
            this.Type.Width = 63;
            // 
            // Cfg
            // 
            this.Cfg.Caption = "Cfg";
            this.Cfg.FieldName = "Cfg";
            this.Cfg.Name = "Cfg";
            this.Cfg.OptionsColumn.AllowEdit = false;
            this.Cfg.Visible = true;
            this.Cfg.VisibleIndex = 2;
            this.Cfg.Width = 100;
            // 
            // DeviceID
            // 
            this.DeviceID.Caption = "DeviceID";
            this.DeviceID.FieldName = "DeviceID";
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.OptionsColumn.AllowEdit = false;
            this.DeviceID.Visible = true;
            this.DeviceID.VisibleIndex = 3;
            this.DeviceID.Width = 145;
            // 
            // Date
            // 
            this.Date.Caption = "Date";
            this.Date.FieldName = "Date";
            this.Date.Name = "Date";
            this.Date.OptionsColumn.AllowEdit = false;
            this.Date.Visible = true;
            this.Date.VisibleIndex = 4;
            this.Date.Width = 120;
            // 
            // Order
            // 
            this.Order.Caption = "Order";
            this.Order.FieldName = "Order";
            this.Order.Name = "Order";
            this.Order.OptionsColumn.AllowEdit = false;
            this.Order.Visible = true;
            this.Order.VisibleIndex = 5;
            this.Order.Width = 105;
            // 
            // Result
            // 
            this.Result.Caption = "Result";
            this.Result.FieldName = "Result";
            this.Result.Name = "Result";
            this.Result.OptionsColumn.AllowEdit = false;
            // 
            // pdfViewer1
            // 
            this.tablePanel1.SetColumn(this.pdfViewer1, 1);
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(499, 38);
            this.pdfViewer1.MenuManager = this.ribbonControl1;
            this.pdfViewer1.Name = "pdfViewer1";
            this.tablePanel1.SetRow(this.pdfViewer1, 1);
            this.pdfViewer1.Size = new System.Drawing.Size(821, 587);
            this.pdfViewer1.TabIndex = 0;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "ribbonPageGroup5";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 27;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // FormMainOld
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 853);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormMainOld";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Amium Report Explorer";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem Print;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
 
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DeviceID;
        private DevExpress.XtraGrid.Columns.GridColumn Date;
        private DevExpress.XtraGrid.Columns.GridColumn Order;
        private DevExpress.XtraGrid.Columns.GridColumn Type;
        private DevExpress.XtraGrid.Columns.GridColumn Result;
        private DevExpress.XtraBars.BarButtonItem Save;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraBars.BarCheckItem Online;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarEditItem Broker;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem Topic;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn Cfg;
        private DevExpress.XtraBars.BarCheckItem Region_de;
        private DevExpress.XtraBars.BarCheckItem Region_en;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarStaticItem space;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem ExportLanguageFile;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem openDevice;
        private DevExpress.XtraBars.Ribbon.RibbonPage lgdImport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup lgd;
        private DevExpress.XtraBars.BarEditItem lgdSocket;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraBars.BarStaticItem split;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraBars.BarButtonItem btnLinCheck;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}


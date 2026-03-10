namespace ReportExplorer
{
    partial class UserControlMqttStatusBottom
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelClock = new DevExpress.XtraEditors.LabelControl();
            this.labelMqtt = new DevExpress.XtraEditors.LabelControl();
            this.labelUri = new DevExpress.XtraEditors.LabelControl();
            this.labelRootTopic = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelClock);
            this.panelControl1.Controls.Add(this.labelMqtt);
            this.panelControl1.Controls.Add(this.labelUri);
            this.panelControl1.Controls.Add(this.labelRootTopic);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1253, 37);
            this.panelControl1.TabIndex = 0;
            // 
            // labelClock
            // 
            this.labelClock.Appearance.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.labelClock.Appearance.Options.UseFont = true;
            this.labelClock.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelClock.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelClock.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelClock.ImageOptions.SvgImage = global::ReportExplorer.Properties.Resources.clock;
            this.labelClock.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.labelClock.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.labelClock.Location = new System.Drawing.Point(0, 0);
            this.labelClock.Name = "labelClock";
            this.labelClock.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelClock.Size = new System.Drawing.Size(199, 33);
            this.labelClock.TabIndex = 10;
            this.labelClock.Text = "2024-10-29 18:16:30";
            // 
            // labelMqtt
            // 
            this.labelMqtt.Appearance.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.labelMqtt.Appearance.Options.UseFont = true;
            this.labelMqtt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelMqtt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelMqtt.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelMqtt.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelMqtt.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMqtt.ImageOptions.SvgImage = global::ReportExplorer.Properties.Resources.mqtt;
            this.labelMqtt.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.labelMqtt.Location = new System.Drawing.Point(651, 0);
            this.labelMqtt.Name = "labelMqtt";
            this.labelMqtt.Size = new System.Drawing.Size(152, 37);
            this.labelMqtt.TabIndex = 8;
            this.labelMqtt.Text = "Disconnected";
            // 
            // labelUri
            // 
            this.labelUri.Appearance.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.labelUri.Appearance.Options.UseFont = true;
            this.labelUri.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelUri.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelUri.Location = new System.Drawing.Point(803, 0);
            this.labelUri.Name = "labelUri";
            this.labelUri.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labelUri.Size = new System.Drawing.Size(271, 31);
            this.labelUri.TabIndex = 9;
            this.labelUri.Text = "mqtt://mqtt.amium.link:11883  ";
            // 
            // labelRootTopic
            // 
            this.labelRootTopic.Appearance.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.labelRootTopic.Appearance.Options.UseFont = true;
            this.labelRootTopic.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelRootTopic.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelRootTopic.Location = new System.Drawing.Point(1074, 0);
            this.labelRootTopic.Name = "labelRootTopic";
            this.labelRootTopic.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labelRootTopic.Size = new System.Drawing.Size(179, 31);
            this.labelRootTopic.TabIndex = 9;
            this.labelRootTopic.Text = "stfu/amium/reports  ";
            // 
            // BottomStatusControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "BottomStatusControl";
            this.Size = new System.Drawing.Size(1253, 37);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelMqtt;
        private DevExpress.XtraEditors.LabelControl labelUri;
        private DevExpress.XtraEditors.LabelControl labelRootTopic;
        private DevExpress.XtraEditors.LabelControl labelClock;
    }
}

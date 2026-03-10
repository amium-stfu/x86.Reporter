namespace ReportExplorer
{
    partial class ControlMqttStatusBottom
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
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 0);
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
            this.labelClock.Location = new System.Drawing.Point(5, 4);
            this.labelClock.Name = "labelClock";
            this.labelClock.Size = new System.Drawing.Size(199, 29);
            this.labelClock.TabIndex = 10;
            this.labelClock.Text = "2024-10-29 18:16:30";
            // 
            // labelMqtt
            // 
            this.labelMqtt.Appearance.BackColor = System.Drawing.Color.Yellow;
            this.labelMqtt.Appearance.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.labelMqtt.Appearance.Options.UseBackColor = true;
            this.labelMqtt.Appearance.Options.UseFont = true;
            this.labelMqtt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelMqtt.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelMqtt.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelMqtt.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelMqtt.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMqtt.ImageOptions.SvgImage = global::ReportExplorer.Properties.Resources.mqtt;
            this.labelMqtt.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            this.labelMqtt.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.labelMqtt.Location = new System.Drawing.Point(1100, 4);
            this.labelMqtt.Name = "labelMqtt";
            this.labelMqtt.Padding = new System.Windows.Forms.Padding(0, 7, 10, 0);
            this.labelMqtt.Size = new System.Drawing.Size(148, 31);
            this.labelMqtt.TabIndex = 8;
            this.labelMqtt.Text = "Disconnected";
            // 
            // ControlMqttStatusBottom
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "ControlMqttStatusBottom";
            this.Size = new System.Drawing.Size(1253, 37);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelMqtt;
        private DevExpress.XtraEditors.LabelControl labelClock;
    }
}

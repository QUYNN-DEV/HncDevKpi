namespace DEV_KPI.UI
{
    partial class frmMain
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::DEV_KPI.UI.SplashScreen1), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barFooter = new DevExpress.XtraBars.Bar();
            this.textBar = new DevExpress.XtraBars.BarStaticItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.mnuDoiNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btnQuanLyKPI = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnChangeLog = new DevExpress.XtraBars.BarButtonItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barFooter,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.textBar,
            this.barSubItem1,
            this.mnuDoiNguoiDung,
            this.barSubItem2,
            this.btnQuanLyKPI,
            this.barSubItem3,
            this.btnChangeLog});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.barFooter;
            // 
            // barFooter
            // 
            this.barFooter.BarName = "Status bar";
            this.barFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFooter.DockCol = 0;
            this.barFooter.DockRow = 0;
            this.barFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.textBar)});
            this.barFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFooter.OptionsBar.DrawDragBorder = false;
            this.barFooter.OptionsBar.UseWholeRow = true;
            this.barFooter.Text = "Status bar";
            // 
            // textBar
            // 
            this.textBar.Id = 0;
            this.textBar.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBar.ItemAppearance.Hovered.Options.UseFont = true;
            this.textBar.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBar.ItemAppearance.Normal.Options.UseFont = true;
            this.textBar.Name = "textBar";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barSubItem3, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Hệ thống";
            this.barSubItem1.Id = 1;
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mnuDoiNguoiDung)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // mnuDoiNguoiDung
            // 
            this.mnuDoiNguoiDung.Caption = "Đổi người dùng";
            this.mnuDoiNguoiDung.Id = 2;
            this.mnuDoiNguoiDung.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnuDoiNguoiDung.ImageOptions.Image")));
            this.mnuDoiNguoiDung.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mnuDoiNguoiDung.ImageOptions.LargeImage")));
            this.mnuDoiNguoiDung.Name = "mnuDoiNguoiDung";
            this.mnuDoiNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mnuDoiNguoiDung_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Đánh giá KPI";
            this.barSubItem2.Id = 3;
            this.barSubItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.Image")));
            this.barSubItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem2.ImageOptions.LargeImage")));
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnQuanLyKPI, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // btnQuanLyKPI
            // 
            this.btnQuanLyKPI.Caption = "Quản lý KPI nhân viên";
            this.btnQuanLyKPI.Id = 4;
            this.btnQuanLyKPI.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKPI.ImageOptions.Image")));
            this.btnQuanLyKPI.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnQuanLyKPI.ImageOptions.LargeImage")));
            this.btnQuanLyKPI.Name = "btnQuanLyKPI";
            this.btnQuanLyKPI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLyKPI_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Trợ giúp";
            this.barSubItem3.Id = 5;
            this.barSubItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem3.ImageOptions.Image")));
            this.barSubItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem3.ImageOptions.LargeImage")));
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(952, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 528);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(952, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 502);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(952, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 502);
            // 
            // btnChangeLog
            // 
            this.btnChangeLog.Caption = "Change log";
            this.btnChangeLog.Id = 6;
            this.btnChangeLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeLog.ImageOptions.Image")));
            this.btnChangeLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChangeLog.ImageOptions.LargeImage")));
            this.btnChangeLog.Name = "btnChangeLog";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 553);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmMain.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đánh giá KPI nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barFooter;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem textBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem mnuDoiNguoiDung;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyKPI;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem btnChangeLog;
    }
}
namespace QL_CuaHangBanDoAn
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnGoiMon = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoai = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonAn = new DevExpress.XtraBars.BarButtonItem();
            this.btnNL = new DevExpress.XtraBars.BarButtonItem();
            this.btnNCC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.btnXNL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSDDH = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.btnHoaDon = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.txtMaNV = new DevExpress.XtraBars.BarHeaderItem();
            this.txtTenNV = new DevExpress.XtraBars.BarHeaderItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.txtNgayHT = new DevExpress.XtraBars.BarHeaderItem();
            this.txtGio = new DevExpress.XtraBars.BarHeaderItem();
            this.bar_dsDDH = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gd_DatHang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gd_DanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gd_NhanVien = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gd_ThongKe = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.BackColor = System.Drawing.Color.White;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnGoiMon,
            this.btnLoai,
            this.btnMonAn,
            this.btnNL,
            this.btnNCC,
            this.barButtonItem6,
            this.btnXNL,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.btnDH,
            this.btnDSDDH,
            this.barButtonItem16,
            this.btnHoaDon,
            this.barHeaderItem1,
            this.barEditItem1,
            this.txtMaNV,
            this.txtTenNV,
            this.barSubItem1,
            this.txtNgayHT,
            this.txtGio,
            this.bar_dsDDH});
            this.ribbon.LargeImages = this.imageCollection1;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ribbon.MaxItemId = 27;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsStubGlyphs.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.OptionsStubGlyphs.UseFont = true;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.gd_DatHang,
            this.gd_DanhMuc,
            this.gd_NhanVien,
            this.gd_ThongKe});
            this.ribbon.QuickToolbarItemLinks.Add(this.txtMaNV);
            this.ribbon.QuickToolbarItemLinks.Add(this.txtTenNV);
            this.ribbon.QuickToolbarItemLinks.Add(this.txtNgayHT);
            this.ribbon.QuickToolbarItemLinks.Add(this.txtGio);
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemFontEdit1});
            this.ribbon.Size = new System.Drawing.Size(944, 153);
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // btnGoiMon
            // 
            this.btnGoiMon.Caption = "Gọi Món";
            this.btnGoiMon.Id = 1;
            this.btnGoiMon.ImageOptions.LargeImageIndex = 0;
            this.btnGoiMon.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoiMon.ItemAppearance.Normal.Options.UseFont = true;
            this.btnGoiMon.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoiMon.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnGoiMon.Name = "btnGoiMon";
            this.btnGoiMon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnLoai
            // 
            this.btnLoai.Caption = "Loại Món Ăn";
            this.btnLoai.Id = 3;
            this.btnLoai.ImageOptions.LargeImageIndex = 5;
            this.btnLoai.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoai.ItemAppearance.Normal.Options.UseFont = true;
            this.btnLoai.Name = "btnLoai";
            this.btnLoai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnMonAn
            // 
            this.btnMonAn.Caption = "Danh Sách Món Ăn";
            this.btnMonAn.Id = 4;
            this.btnMonAn.ImageOptions.LargeImageIndex = 1;
            this.btnMonAn.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonAn.ItemAppearance.Normal.Options.UseFont = true;
            this.btnMonAn.Name = "btnMonAn";
            this.btnMonAn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // btnNL
            // 
            this.btnNL.Caption = "Nguyên Liệu";
            this.btnNL.Id = 5;
            this.btnNL.ImageOptions.LargeImageIndex = 6;
            this.btnNL.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNL.ItemAppearance.Normal.Options.UseFont = true;
            this.btnNL.Name = "btnNL";
            this.btnNL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // btnNCC
            // 
            this.btnNCC.Caption = "Nhà Cung Cấp";
            this.btnNCC.Id = 6;
            this.btnNCC.ImageOptions.LargeImageIndex = 7;
            this.btnNCC.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNCC.ItemAppearance.Normal.Options.UseFont = true;
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Nhập Nguyên Liệu";
            this.barButtonItem6.Id = 7;
            this.barButtonItem6.ImageOptions.LargeImageIndex = 8;
            this.barButtonItem6.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem6.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // btnXNL
            // 
            this.btnXNL.Caption = "Xuất Nguyên Liệu";
            this.btnXNL.Id = 8;
            this.btnXNL.ImageOptions.LargeImageIndex = 9;
            this.btnXNL.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXNL.ItemAppearance.Normal.Options.UseFont = true;
            this.btnXNL.Name = "btnXNL";
            this.btnXNL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Danh Sách Nhân Viên";
            this.barButtonItem8.Id = 9;
            this.barButtonItem8.ImageOptions.LargeImageIndex = 3;
            this.barButtonItem8.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem8.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "Tài Khoản";
            this.barButtonItem9.Id = 10;
            this.barButtonItem9.ImageOptions.LargeImageIndex = 10;
            this.barButtonItem9.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem9.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "Doanh Thu";
            this.barButtonItem10.Id = 11;
            this.barButtonItem10.ImageOptions.LargeImageIndex = 11;
            this.barButtonItem10.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem10.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem10.Name = "barButtonItem10";
            this.barButtonItem10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // btnDH
            // 
            this.btnDH.Caption = "Đơn Đặt Hàng";
            this.btnDH.Id = 14;
            this.btnDH.ImageOptions.ImageUri.Uri = "SendBehindText";
            this.btnDH.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDH.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDH.Name = "btnDH";
            this.btnDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem12_ItemClick);
            // 
            // btnDSDDH
            // 
            this.btnDSDDH.Caption = "Danh Sách Đơn Đặt Hàng";
            this.btnDSDDH.Id = 15;
            this.btnDSDDH.ImageOptions.LargeImageIndex = 10;
            this.btnDSDDH.ItemAppearance.Disabled.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSDDH.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnDSDDH.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSDDH.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDSDDH.Name = "btnDSDDH";
            this.btnDSDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem15_ItemClick);
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Caption = "Hóa đơn";
            this.barButtonItem16.Id = 16;
            this.barButtonItem16.ImageOptions.Image = global::QL_CuaHangBanDoAn.Properties.Resources.bill;
            this.barButtonItem16.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem16.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem16.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem16.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.barButtonItem16.Name = "barButtonItem16";
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Caption = "Hóa Đơn";
            this.btnHoaDon.Id = 17;
            this.btnHoaDon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHoaDon.ImageOptions.Image")));
            this.btnHoaDon.ImageOptions.LargeImageIndex = 6;
            this.btnHoaDon.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ItemAppearance.Normal.Options.UseFont = true;
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem13_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "barHeaderItem1";
            this.barHeaderItem1.Id = 18;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemFontEdit1;
            this.barEditItem1.Id = 19;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Appearance.Options.UseFont = true;
            this.txtMaNV.Id = 20;
            this.txtMaNV.Name = "txtMaNV";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Appearance.Options.UseFont = true;
            this.txtTenNV.Id = 21;
            this.txtTenNV.Name = "txtTenNV";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 22;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // txtNgayHT
            // 
            this.txtNgayHT.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayHT.Appearance.Options.UseFont = true;
            this.txtNgayHT.Id = 23;
            this.txtNgayHT.Name = "txtNgayHT";
            // 
            // txtGio
            // 
            this.txtGio.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGio.Appearance.Options.UseFont = true;
            this.txtGio.Id = 24;
            this.txtGio.Name = "txtGio";
            // 
            // bar_dsDDH
            // 
            this.bar_dsDDH.Caption = "Danh Sách Đơn Đặt Hàng";
            this.bar_dsDDH.Id = 26;
            this.bar_dsDDH.ImageOptions.ImageUri.Uri = "WorkWeekView";
            this.bar_dsDDH.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar_dsDDH.ItemAppearance.Normal.Options.UseFont = true;
            this.bar_dsDDH.Name = "bar_dsDDH";
            this.bar_dsDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_dsDDH_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(35, 35);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "order1.png");
            this.imageCollection1.Images.SetKeyName(1, "food_water.png");
            this.imageCollection1.Images.SetKeyName(2, "order.jpg");
            this.imageCollection1.Images.SetKeyName(3, "nhanvien.png");
            this.imageCollection1.Images.SetKeyName(4, "oder2.png");
            this.imageCollection1.Images.SetKeyName(5, "food.png");
            this.imageCollection1.Images.SetKeyName(6, "list.png");
            this.imageCollection1.Images.SetKeyName(7, "home-256.png");
            this.imageCollection1.Images.SetKeyName(8, "nhap1.png");
            this.imageCollection1.Images.SetKeyName(9, "xuat.png");
            this.imageCollection1.Images.SetKeyName(10, "account.png");
            this.imageCollection1.Images.SetKeyName(11, "doanhthu.png");
            this.imageCollection1.Images.SetKeyName(12, "kho.png");
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonPage1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.ribbonPage1.Appearance.Options.UseFont = true;
            this.ribbonPage1.Appearance.Options.UseForeColor = true;
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup8});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Bán Hàng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGoiMon);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnHoaDon);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // gd_DatHang
            // 
            this.gd_DatHang.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gd_DatHang.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gd_DatHang.Appearance.BorderColor = System.Drawing.Color.Beige;
            this.gd_DatHang.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gd_DatHang.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gd_DatHang.Appearance.Options.UseBackColor = true;
            this.gd_DatHang.Appearance.Options.UseBorderColor = true;
            this.gd_DatHang.Appearance.Options.UseFont = true;
            this.gd_DatHang.Appearance.Options.UseForeColor = true;
            this.gd_DatHang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.gd_DatHang.Name = "gd_DatHang";
            this.gd_DatHang.Text = "Đặt Hàng";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnXNL, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDH, true);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // gd_DanhMuc
            // 
            this.gd_DanhMuc.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gd_DanhMuc.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gd_DanhMuc.Appearance.Options.UseFont = true;
            this.gd_DanhMuc.Appearance.Options.UseForeColor = true;
            this.gd_DanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.gd_DanhMuc.Name = "gd_DanhMuc";
            this.gd_DanhMuc.Text = "Danh Mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnLoai, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMonAn, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNL, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnNCC, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // gd_NhanVien
            // 
            this.gd_NhanVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gd_NhanVien.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gd_NhanVien.Appearance.Options.UseFont = true;
            this.gd_NhanVien.Appearance.Options.UseForeColor = true;
            this.gd_NhanVien.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.gd_NhanVien.Name = "gd_NhanVien";
            this.gd_NhanVien.Text = "Nhân Viên";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem8, true);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem9, true);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // gd_ThongKe
            // 
            this.gd_ThongKe.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gd_ThongKe.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gd_ThongKe.Appearance.Options.UseFont = true;
            this.gd_ThongKe.Appearance.Options.UseForeColor = true;
            this.gd_ThongKe.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.gd_ThongKe.Name = "gd_ThongKe";
            this.gd_ThongKe.Text = "Thống Kê";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItem10, true);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.bar_dsDDH);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "Hóa Đơn";
            this.barButtonItem14.Id = 17;
            this.barButtonItem14.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem14.ImageOptions.Image")));
            this.barButtonItem14.ImageOptions.LargeImageIndex = 6;
            this.barButtonItem14.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem14.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // frm_Main
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 580);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Main";
            this.Ribbon = this.ribbon;
            this.Text = "TRANG CHỦ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnGoiMon;
        private DevExpress.XtraBars.BarButtonItem btnLoai;
        private DevExpress.XtraBars.BarButtonItem btnMonAn;
        private DevExpress.XtraBars.BarButtonItem btnNL;
        private DevExpress.XtraBars.BarButtonItem btnNCC;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem btnXNL;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem btnDH;
        private DevExpress.XtraBars.BarButtonItem btnDSDDH;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPage gd_DatHang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage gd_DanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage gd_NhanVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage gd_ThongKe;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnHoaDon;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.BarHeaderItem txtMaNV;
        private DevExpress.XtraBars.BarHeaderItem txtTenNV;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarHeaderItem txtNgayHT;
        private DevExpress.XtraBars.BarHeaderItem txtGio;
        private DevExpress.XtraBars.BarButtonItem bar_dsDDH;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
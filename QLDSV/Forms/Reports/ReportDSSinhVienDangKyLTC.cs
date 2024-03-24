using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV.Forms.Reports {
    public partial class ReportDSSinhVienDangKyLTC : DevExpress.XtraReports.UI.XtraReport {
        public ReportDSSinhVienDangKyLTC() {
            InitializeComponent();
        }

        public ReportDSSinhVienDangKyLTC(string nienKhoa, int hocKy, int nhom, string maMonHoc) {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Database.ConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = hocKy;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = nhom;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = maMonHoc;
            this.sqlDataSource1.Fill();
        }

    }
}

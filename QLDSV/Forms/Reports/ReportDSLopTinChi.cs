using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV.Forms.Reports {
    public partial class ReportDSLopTinChi : DevExpress.XtraReports.UI.XtraReport {
        public ReportDSLopTinChi() {
            InitializeComponent();
        }

        public ReportDSLopTinChi(string nienKhoa, int hocKy) {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Database.ConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = hocKy;
            this.sqlDataSource1.Fill();
        }
    }
}

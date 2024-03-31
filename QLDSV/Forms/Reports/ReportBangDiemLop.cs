using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV.Forms.Reports {
    public partial class ReportBangDiemLop : DevExpress.XtraReports.UI.XtraReport {
        public ReportBangDiemLop() {
            InitializeComponent();
        }
        public ReportBangDiemLop(string maLop) {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Database.ConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;
            this.sqlDataSource1.Fill();
        }
    }
}

using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV.Forms.Reports {
    public partial class ReportPhieuDiemSV : DevExpress.XtraReports.UI.XtraReport {
        public ReportPhieuDiemSV() {
            InitializeComponent();
        }

        public ReportPhieuDiemSV(string maSV) {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Database.ConnectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maSV;
            this.sqlDataSource1.Fill();
        }

    }
}

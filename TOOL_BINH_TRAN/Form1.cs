using System.Threading.Tasks;
using TOOL_BINH_TRAN.domain;
using TOOL_BINH_TRAN.helper;
using TOOL_BINH_TRAN.model;

namespace TOOL_BINH_TRAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckAll(dataGridView1, "cbxAccount", true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckAll(dataGridView1, "cbxAccount", false);

        }

        private void btnPasteData_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.LoadDataFromClipboard(dataGridView1);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void btnSelectBlack_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckSelected(dataGridView1, "cbxAccount", true);
        }

        private void btnUnselectedBlack_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.CheckSelected(dataGridView1, "cbxAccount", false);

        }

        private void btnDeleteDataBlack_Click(object sender, EventArgs e)
        {
            DataGridViewHelper.RemoveSelectedRows(dataGridView1);
        }


        // nút để test
        private async void button2_Click(object sender, EventArgs e)
        {
            string cookie = "c_user=61577545237679;xs=10:S98x-G67giS4PQ:2:1750653333:-1:-1;datr=ZdtYaAuSA6L1XLR6CtHMFAvk;fr=0yyaagxDNYs0y5jn2.AWfeV38Sy70nH1MXywBc6rp13s4YnpupMWF5PuvNGcMtReSLyCE.BoWNtl..AAA.0.0.BoWNtl.AWeWmmKCCdLjwvsoG3pN1Bkyqzs;sb=ZdtYaPgIOEzA8zZrpNBrwOTw;wd=1920x953;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1750653801730%2C%22v%22%3A1%7D;";

            string proxy = "212.32.97.139:42911:I7AtQXJk4UKfcJk:FPMkcku0u7UQg86";

            string fb_dtsg = await HelperUtils.getFbDtsg(cookie, proxy);

            string result = await RegisterAppDomain.RegisterAppAsync(cookie, fb_dtsg, proxy);

            if (result.Contains("công"))
            {
               string result2 = await RegisterAppDomain.sendSMSCodeAction(cookie, fb_dtsg, proxy);

                MessageBox.Show(result2);
            } else
            {
                MessageBox.Show(result);
            }


        }
    }
}

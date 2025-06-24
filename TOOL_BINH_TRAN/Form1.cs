using System.Threading.Tasks;
using TOOL_BINH_TRAN.domain;
using TOOL_BINH_TRAN.helper;
using TOOL_BINH_TRAN.model;
using System.Threading;

namespace TOOL_BINH_TRAN
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cts;
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

        // nút để test (nút STOP)
        private void button2_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        // start
        private async void button1_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            var tasks = new List<Task>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["cbxAccount"].Value != null && (bool)row.Cells["cbxAccount"].Value)
                {
                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            if (token.IsCancellationRequested) return;

                            string cookie = row.Cells["cookie"].Value.ToString();
                            if (string.IsNullOrEmpty(cookie))
                            {
                                this.Invoke(new Action(() => row.Cells["process"].Value = "Cookie lỗi!"));
                                return;
                            }

                            this.Invoke(new Action(() => row.Cells["process"].Value = "Đang get FBDTSG..."));
                            string fb_dtsg = await HelperUtils.getFbDtsg(cookie);

                            if (token.IsCancellationRequested) return;

                            if (fb_dtsg.Contains("Lỗi"))
                            {
                                this.Invoke(new Action(() => row.Cells["process"].Value = "Lấy fb_dtsg thất bại!"));
                                return;
                            }

                            this.Invoke(new Action(() => row.Cells["process"].Value = "Đang lấy email từ cookie..."));
                            var emails = await EmailDomain.GetAllEmailFromCookie(cookie);

                            if (token.IsCancellationRequested) return;

                            if (emails.Count == 0)
                            {
                                this.Invoke(new Action(() => row.Cells["process"].Value = "Email lỗi hoặc không có email nào!"));
                                return;
                            }

                            List<string> emails2 = new List<string>();
                            foreach (ContactInfo item in emails)
                            {
                                if (!item.HasAnyPendingStatus)
                                {
                                    emails2.Add(item.NormalizedContactPoint.ToString());
                                }
                            }

                            if (emails2.Count == 0)
                            {
                                this.Invoke(new Action(() => row.Cells["process"].Value = "Không có email hợp lệ nào!"));
                                return;
                            }

                            this.Invoke(new Action(() => row.Cells["process"].Value = "Đang đăng ký ứng dụng..."));
                            string result = await RegisterAppDomain.RegisterAppAsync(cookie, fb_dtsg);

                            if (token.IsCancellationRequested) return;

                            this.Invoke(new Action(() => row.Cells["process"].Value = result));
                            foreach (var item in emails2)
                            {
                                if (token.IsCancellationRequested) return;
                                string result2 = await RegisterAppDomain.sendEmail(cookie, fb_dtsg, item);
                                if (result2.Contains("thành"))
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        row.Cells["process"].Value = $"Đã gửi email: {item}";
                                        row.Cells["email"].Value += "\n" + item + " thành công";
                                    }));
                                }
                                else
                                {
                                    this.Invoke(new Action(() =>
                                    {
                                        row.Cells["process"].Value = $"Gửi email {item} thất bại: {result2}";
                                        row.Cells["email"].Value += "\n" + item + " thất bại";
                                    }));
                                }
                            }
                            this.Invoke(new Action(() => row.Cells["process"].Value = "Đã hoàn thành!"));
                        }
                        catch (OperationCanceledException)
                        {
                            this.Invoke(new Action(() => row.Cells["process"].Value = "Đã dừng!"));
                        }
                    }, token));
                }
            }

            if (tasks.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản!");
                return;
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                // Có thể xử lý thêm nếu cần
            }
        }
    }
}

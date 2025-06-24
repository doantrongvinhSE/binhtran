using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TOOL_BINH_TRAN.helper
{
    public class DataGridViewHelper
    {
        public static void CheckAll(DataGridView grid, string columnName, bool state)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Cells[columnName].Value = state;
            }
        }


        public static void RemoveSelectedRows(DataGridView grid)
        {
            // Tạo danh sách các chỉ số hàng cần xóa
            List<int> rowsToRemove = new List<int>();

            // Thu thập tất cả các chỉ số hàng có ô được chọn
            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                if (!rowsToRemove.Contains(cell.RowIndex))
                {
                    rowsToRemove.Add(cell.RowIndex);
                }
            }

            // Sắp xếp theo thứ tự giảm dần để xóa từ dưới lên trên
            rowsToRemove.Sort();
            rowsToRemove.Reverse();

            // Xóa các hàng
            foreach (int rowIndex in rowsToRemove)
            {
                grid.Rows.RemoveAt(rowIndex);
            }
        }

        public static void CheckSelected(DataGridView grid, string columnName, bool state)
        {
            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                grid.Rows[cell.RowIndex].Cells[columnName].Value = state;
            }
        }


        public static void LoadDataFromClipboard(DataGridView grid)
        {
            string clipboardText = Clipboard.GetText();

            if (!string.IsNullOrEmpty(clipboardText))
            {
                string[] lines = clipboardText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string line in lines)
                {
                    if (line.Contains("|"))
                    {
                        string[] parts = line.Split('|');

                        int rowIndex = grid.Rows.Add();

                        string cookie = "", faCode = "", token = "";

                        // Tìm phần chứa "c_user=" trong các phần sau khi tách bằng dấu |
                        foreach (var part in parts)
                        {
                            if (part.Contains("c_user="))
                            {
                                cookie = part.Trim();
                                break;
                            }
                        }


                        //MessageBox.Show("Cookie: " + cookie + "\nFaCode: " + faCode + "\nToken: " + token);

                        // Gán giá trị cho các cột cố định, ví dụ như "stt" và "cbxDataGridView"
                        grid.Rows[rowIndex].Cells["cbxAccount"].Value = false;
                        grid.Rows[rowIndex].Cells["stt"].Value = rowIndex + 1;

                        // Gán các cột theo đúng thứ tự
                        grid.Rows[rowIndex].Cells["uid"].Value = parts[0].Trim();

                        // Gán giá trị vào các cột trong DataGridView
                        grid.Rows[rowIndex].Cells["cookie"].Value = cookie;
                        //grid.Rows[rowIndex].Cells["faCode"].Value = faCode;


                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu hợp lệ trong clipboard!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

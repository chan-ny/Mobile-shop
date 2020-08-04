using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mobilephone.Manager
{
    class Seller : ConnectionDB
    {
        public static string BillID { set; get; }
        public static string productID { set; get; }
        public static string CustomerID { set; get; }
        public static string Amount { set; get; }
        public static string Price { set; get; }
        public static string Qty { set; get; }
        public static string AmountMoney { set; get; }


        public static string Staff { set; get; }
        public static string PayID { set; get; }


        /// <summary>
        /// / Comment
        /// </summary>
        /// 
        public static string CommentBill { set; get; }
        public static string CommentStaff { set; get; }
        public static string CommentCus { set; get; }
        public static string CommentSeller { set; get; }
        public static string CommentDetial { set; get; }



        public static string sql = "";

        public static void saveData(DataGridView dgv)
        {
            ConnectDB();
            sql = "insert into SaleBill values(@staffID,@customerID,@price,@number,@total,@createDate,@updatedate)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("staffID", Staff);
            cmd.Parameters.AddWithValue("customerID", CustomerID);
            cmd.Parameters.AddWithValue("price", Price);
            cmd.Parameters.AddWithValue("number", Qty);
            cmd.Parameters.AddWithValue("total", AmountMoney);
            cmd.Parameters.AddWithValue("createDate", setDate);
            cmd.Parameters.AddWithValue("updatedate", setDate);

            DialogResult message = MessageBox.Show("Do you want to Record value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (message.Equals(DialogResult.OK))
            {
                int result = cmd.ExecuteNonQuery();
                if (result != 0)
                {

                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        ConnectDB();
                        sql = "";
                        sql = "insert into Salelist values(@saleID,@productId,@price,@qty,@amount)";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("saleID", BillID);
                        cmd.Parameters.AddWithValue("productId", dgv.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("price", dgv.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("qty", dgv.Rows[i].Cells[5].Value);
                        cmd.Parameters.AddWithValue("amount", Amount);
                        cmd.ExecuteNonQuery();

                        ///chang product
                        /// 
                        sql = "";
                        ConnectDB();
                        sql = "update ProductMobile set productQTYOFF=productQTYOFF-@qty,productAmountQTY=productAmountQTY-@remove where productId=@id";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("id", dgv.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("qty", dgv.Rows[i].Cells[5].Value);
                        cmd.Parameters.AddWithValue("remove", dgv.Rows[i].Cells[5].Value);
                        cmd.ExecuteNonQuery();

                        ///insurance
                        /// 
                     

                        /////print pos
                    }
                    createInsurance();
                }
                else
                {
                    MessageBox.Show("Can not Record Value....");
                }


            }


        }


        public static void createInsurance()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddYears(1);

            ConnectDB();
            sql = "insert into Insurance  values(@saleBill,1,@start,@end,@CreateDate,@UpdateDate)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("saleBill", BillID);
            cmd.Parameters.AddWithValue("start", d1);
            cmd.Parameters.AddWithValue("end", d2);
            cmd.Parameters.AddWithValue("CreateDate", setDate);
            cmd.Parameters.AddWithValue("UpdateDate", setDate);
            cmd.ExecuteNonQuery();

        }
    }
}

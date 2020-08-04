using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mobilephone.Manager
{
    class DataProduct:ConnectionDB
    {

        public static string ID { set; get; }
        public static string Name { set; get; }
        public static string Colors { set; get; }
        public static string Brands { set; get; }
        public static string Size { set; get; }
        public static string ScrennSize { set; get; }
        public static string Units { set; get; }
        public static string Networks { set; get; }
        public static string Annouced { set; get; }
        public static string Sim { set; get; }
        public static string Blutooth { set; get; }
        public static string GPS { set; get; }
        public static string Battery { set; get; }
        public static string OS { set; get; }
        public static string Chipset { set; get; }
        public static string CPU { set; get; }
        public static string GPU { set; get; }
        public static string RAM { set; get; }
        public static string Memory { set; get; }
        public static string FrontCamera { set; get; }
        public static string FrontVideo { set; get; }
        public static string RearCamera { set; get; }
        public static string RearVideo { set; get; }
        public static string Price { set; get; }
        public static string StockON { set; get; }
        public static string StockOFF { set; get; }
        public static string AmountQty { set; get; }
        public static string SalePrice { set; get; }
        public static string Profit { set; get; }
        public static byte[] Photo { set; get; }
        public static string SearchName { set; get; }
        public static int States { set; get; }
        public static string sql = "";


        public static string StateImg = "";
        public static void setComboBox(string sql,ComboBox cb,string name,string id)
        {
            ConnectDB();
            cmd = new SqlCommand(sql,con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds,"table");
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = name;
            cb.ValueMember = id;
        }
        public static void setComboBoxSize(string sql, ComboBox cb, string name, string id)
        {
            ConnectDB();
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            cb.DataSource = ds.Tables[0];
            cb.DisplayMember = name;
            cb.ValueMember = id;
        }
        public static void sentComboBox(string tb,string value, ComboBox cb, string name, string id)
        {
            ConnectDB();
            sql = "select * from "+ tb +" where "+ name +" =N'"+value+"'";
            cmd = new SqlCommand(sql, con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds, "table");
            cb.DataSource = ds.Tables[0];
            cb.ValueMember = name;
            cb.ValueMember = id;
        }
        public static void setLoadData(DataGridView dgv,string sql)
        {
            ConnectDB();
            cmd = new SqlCommand(sql,con);
            dat = new SqlDataAdapter(cmd);
            ds = new DataSet();
            dat.Fill(ds);
            dgv.RowTemplate.Height = 100;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = ds.Tables[0];
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img = (DataGridViewImageColumn)dgv.Columns[3];
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            formatDatagridView(dgv);

        }

        public static void formatDatagridView(DataGridView dgv)
        {
            dgv.Columns[2].HeaderText = "ລະຫັດຄ້າ";
            dgv.Columns[3].HeaderText = "ຮູບພາບ";
            dgv.Columns[4].HeaderText = "ຊື່ສີນຄ້າ";
            dgv.Columns[5].HeaderText = "ປະເພດສີ";
            dgv.Columns[6].HeaderText = "ລາຍລະອຽດສີ";
            dgv.Columns[7].HeaderText = "ຍິຫໍ້";
            dgv.Columns[8].HeaderText = "ລາຍລະອຽດຍິຫໍ້";
            dgv.Columns[9].HeaderText = "ປະເພດ";
            dgv.Columns[10].HeaderText = "ເວີຊັ້ນ";
            dgv.Columns[11].HeaderText = "ໜ້າຈໍ";
            dgv.Columns[12].HeaderText = "ຂະໜາດໜ້າຈໍ";
            dgv.Columns[13].HeaderText = "ຫົວໜວ່ຍ";
            dgv.Columns[14].HeaderText = "ລາຍລະອຽດໜ່ວຍ";
            dgv.Columns[15].HeaderText = "ເນັດເວີລ";
            dgv.Columns[16].HeaderText = "ວັນທີຜະລິດ";
            dgv.Columns[17].HeaderText = "ຊີມກາດ";
            dgv.Columns[18].HeaderText = "ບູທຸດ";
            dgv.Columns[19].HeaderText = "ຈີພີເອັດ";
            dgv.Columns[20].HeaderText = "ແບັດເຕີລີ";
            dgv.Columns[21].HeaderText = "ລະບົບປະຕີບັດການ";
            dgv.Columns[22].HeaderText = "ຊີບເຊັດ";
            dgv.Columns[23].HeaderText = "ຊີພີຢູ";
            dgv.Columns[24].HeaderText = "ຈີພີຢູ";
            dgv.Columns[25].HeaderText = "ແຣມ";
            dgv.Columns[26].HeaderText = "ຄວາມຈຳ";
            dgv.Columns[27].HeaderText = "ກ້ອງໜ້າ";
            dgv.Columns[28].HeaderText = "ວີດິໂອກ້ອງໜ້າ";
            dgv.Columns[29].HeaderText = "ກ້ອງຫຼັງ";
            dgv.Columns[30].HeaderText = "ວີດິໂອກ້ອງຫຼັງ";
            dgv.Columns[31].HeaderText = "ລາຄານຳເຂົ້າ";
            dgv.Columns[32].HeaderText = "ຈຳນວນ ON";
            dgv.Columns[33].HeaderText = "ຈຳນວນ OFF";
            dgv.Columns[34].HeaderText = "ລວມ";
            dgv.Columns[35].HeaderText = "ລາຄາຂາຍ";
            dgv.Columns[36].HeaderText = "ຜົນກຳໄລ";
            dgv.Columns[37].HeaderText = "ວັນເດືອນສ້າງ";
            dgv.Columns[38].HeaderText = "ວັນເດືອນແກ້ໄຂ";

        }
        public static void checkEmpty()
        {
            if (ID.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Name.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Colors.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Brands.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Size.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (ScrennSize.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Units.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Networks.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Annouced.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Sim.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Blutooth.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (GPS.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Battery.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (OS.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Chipset.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (CPU.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (GPU.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (RAM.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Memory.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (FrontCamera.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (FrontVideo.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (RearCamera.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (RearVideo.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Price.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (StockON.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (StockOFF.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (AmountQty.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (SalePrice.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Profit.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else if (Photo.Equals(""))
            {
                MessageBox.Show("please input value to TextBox ?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (States == 1)
                {
                    saveData();
                }
                if (States == 2)
                {
                    upadateData();
                }
            }

        }

        public static void AutoID(TextBox txt)
        {
            ConnectDB();
            try
            {
                sql = "select max(productId)+1 as id from ProductMobile";
                cmd = new SqlCommand(sql,con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txt.Text = dr["id"].ToString();
                }
                dr.Close();
            }
            catch
            {
                MessageBox.Show("can not Load Value ID ?");
            }
            finally
            {
                con.Close();
            }
        }
        public static void cleatData(TextBox txt)
        {
            txt.Clear();
        }

        public static void searchData(DataGridView dgv)
        {
            if (SearchName == "")
            {
                dgv.Visible = true;
                setLoadData(dgv, "select * from tb_products");
            }
            else
            {
                ConnectDB();
                sql = " select * from tb_products where productName like @name";
                cmd = new SqlCommand(sql,con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name","%" + SearchName + "%");
                dat = new SqlDataAdapter(cmd);
                ds = new DataSet();
                dat.Fill(ds,"table");
                dgv.DataSource = ds;
                dgv.DataMember = "table";
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img = (DataGridViewImageColumn)dgv.Columns[3];
                img.ImageLayout = DataGridViewImageCellLayout.Zoom;
                formatDatagridView(dgv);


            }
        }

        public static void saveData()
        {
            ConnectDB();
            try
            {
                sql = "insert into ProductMobile values(@productName,@colorId,@brandsId,@sizeId,@screenId,@unitId,@productNetwork,@productAnnounced,"
                    + "@productSim,@productBlutooth,@productGPS,@productBattery,@productOS,@productChipset,@productCPU,@productGPU,@productRAM,@productMemery,"
                    + "@productFrontCamera,@productFrontVIdeo,@productRearCamera,@productRearVIdeo,@productPrice,@Qtyon,@Qtyoff,@productQty,@productSalePrice,@productProfit,"
                    + "@CreateDate,@UpdateDate)";
                cmd = new SqlCommand(sql,con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("productName",Name);
                cmd.Parameters.AddWithValue("colorId", Colors);
                cmd.Parameters.AddWithValue("brandsId",Brands );
                cmd.Parameters.AddWithValue("sizeId", Size);
                cmd.Parameters.AddWithValue("screenId", ScrennSize);
                cmd.Parameters.AddWithValue("unitId",Units );
                cmd.Parameters.AddWithValue("productNetwork", Networks );
                cmd.Parameters.AddWithValue("productAnnounced", Annouced );
                cmd.Parameters.AddWithValue("productSim",Sim );
                cmd.Parameters.AddWithValue("productBlutooth",Blutooth );
                cmd.Parameters.AddWithValue("productGPS",GPS );
                cmd.Parameters.AddWithValue("productBattery",Battery );
                cmd.Parameters.AddWithValue("productOS", OS );
                cmd.Parameters.AddWithValue("productChipset",Chipset );
                cmd.Parameters.AddWithValue("productCPU", CPU);
                cmd.Parameters.AddWithValue("productGPU",GPU );
                cmd.Parameters.AddWithValue("productRAM",RAM );
                cmd.Parameters.AddWithValue("productMemery", Memory);
                cmd.Parameters.AddWithValue("productFrontCamera",FrontCamera );
                cmd.Parameters.AddWithValue("productFrontVIdeo", FrontVideo );
                cmd.Parameters.AddWithValue("productRearCamera", RearCamera);
                cmd.Parameters.AddWithValue("productRearVIdeo", RearVideo );
                cmd.Parameters.AddWithValue("productPrice", Price );
                cmd.Parameters.AddWithValue("Qtyon", StockON);
                cmd.Parameters.AddWithValue("Qtyoff", StockOFF);
                cmd.Parameters.AddWithValue("productQty", AmountQty );
                cmd.Parameters.AddWithValue("productSalePrice", SalePrice);
                cmd.Parameters.AddWithValue("productProfit", Profit);
                cmd.Parameters.AddWithValue("CreateDate", setDate);
                cmd.Parameters.AddWithValue("UpdateDate", setDate);

                DialogResult message = MessageBox.Show("Do you want to Save Change value ?","Question ?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        sql = " insert into photo values(@productId,@photo)";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("productId", ID);
                        cmd.Parameters.AddWithValue("photo", Photo);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void upadateData()
        {
            ConnectDB();
            try
            {
                sql = "update ProductMobile set productName=@productName,colorId=@colorId,brandsId=@brandsId,sizeId=@sizeId,screenId=@screenId,unitId=@unitId,productNetwork=@productNetwork,productAnnounced=@productAnnounced,"
                    + "productSim=@productSim,productBlutooth=@productBlutooth,productGPS=@productGPS,productBattery=@productBattery,productOS=@productOS,productChipset=@productChipset,productCPU=@productCPU,productGPU=@productGPU,productRAM=@productRAM,productMemery=@productMemery,"
                    + "productFrontCamera=@productFrontCamera,productFrontVIdeo=@productFrontVIdeo,productRearCamera=@productRearCamera,productRearVIdeo=@productRearVIdeo,productPrice=@productPrice,productQTYON=@Qtyon,productQTYOFF=@Qtyoff,productAmountQTY=@productQty,productSalePrice=@productSalePrice,productProfit=@productProfit,"
                    + "UpdateDate=@UpdateDate where productId=@productId ";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("productId", ID);
                cmd.Parameters.AddWithValue("productName", Name);
                cmd.Parameters.AddWithValue("colorId", Colors);
                cmd.Parameters.AddWithValue("brandsId", Brands);
                cmd.Parameters.AddWithValue("sizeId", Size);
                cmd.Parameters.AddWithValue("screenId", ScrennSize);
                cmd.Parameters.AddWithValue("unitId", Units);
                cmd.Parameters.AddWithValue("productNetwork", Networks);
                cmd.Parameters.AddWithValue("productAnnounced", Annouced);
                cmd.Parameters.AddWithValue("productSim", Sim);
                cmd.Parameters.AddWithValue("productBlutooth", Blutooth);
                cmd.Parameters.AddWithValue("productGPS", GPS);
                cmd.Parameters.AddWithValue("productBattery", Battery);
                cmd.Parameters.AddWithValue("productOS", OS);
                cmd.Parameters.AddWithValue("productChipset", Chipset);
                cmd.Parameters.AddWithValue("productCPU", CPU);
                cmd.Parameters.AddWithValue("productGPU", GPU);
                cmd.Parameters.AddWithValue("productRAM", RAM);
                cmd.Parameters.AddWithValue("productMemery", Memory);
                cmd.Parameters.AddWithValue("productFrontCamera", FrontCamera);
                cmd.Parameters.AddWithValue("productFrontVIdeo", FrontVideo);
                cmd.Parameters.AddWithValue("productRearCamera", RearCamera);
                cmd.Parameters.AddWithValue("productRearVIdeo", RearVideo);
                cmd.Parameters.AddWithValue("productPrice", Price);
                cmd.Parameters.AddWithValue("Qtyon", StockON);
                cmd.Parameters.AddWithValue("Qtyoff", StockOFF);
                cmd.Parameters.AddWithValue("productQty", AmountQty);
                cmd.Parameters.AddWithValue("productSalePrice", SalePrice);
                cmd.Parameters.AddWithValue("productProfit", Profit);
                cmd.Parameters.AddWithValue("UpdateDate", setDate);

                DialogResult message = MessageBox.Show("Do you want to  Change value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                   
                        sql = " update photo set img=@photo where productId=@id";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("photo", Photo);
                        cmd.Parameters.AddWithValue("id", ID);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }
        public static void deleteData(DataGridView dgv)
        {
            ConnectDB();
            try
            {
                sql = "delete from photo  where productId=@id";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", ID);
                
                DialogResult message = MessageBox.Show("Do you want to delete value ?", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (message.Equals(DialogResult.OK))
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        sql = "delete from ProductMobile where productId=@productId ";
                        cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("productId", ID);
                        cmd.ExecuteNonQuery();
                        setLoadData(dgv, "select * from tb_products");
                    }
                    else
                    {
                        MessageBox.Show("Can not Record Value....");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}

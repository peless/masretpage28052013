using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Globalization;


/// <summary>
/// Summary description for DBservices
/// </summary>
public class DBservices
{
    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    SqlDataAdapter da = new SqlDataAdapter();
    SqlDataAdapter da_prod = new SqlDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt_item = new DataTable();
    DataTable dt_order = new DataTable();
    SqlConnection con;
    string vendorSN;
    string Id;
    string iswork = "false";
    string numBranch;
    string poId;
    int numbe_messag = 0;



    public static SqlConnection connect(String conString)
    {
        try
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<string> getVendorName()
    {

        SqlConnection con;
        List<string> Names = new List<string>();

        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            String selectSTR = "SELECT Name FROM Vendor";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Names.Add(Convert.ToString(dr["Name"]));
            }

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        return Names;
    }

    public string getVendorSN(string name)
    {
        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT * FROM Vendor";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row

                string Name = Convert.ToString(dr["Name"]);
                if (name == Name)
                {
                    vendorSN = Convert.ToString(dr["SN"]);

                }
            }

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        return vendorSN;
    }

    public List<Item> ReadItem(string vendorsn)
    {
        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {

            String selectSTR = "SELECT * FROM Item where VendorSN=" + vendorsn;

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            da.SelectCommand = cmd;

            da.Fill(ds, "Item");
            dt_item = ds.Tables["Item"];

            List<Item> itemList = new List<Item>();

            foreach (DataRow dr in dt_item.Rows)
            {

                string Name = dr["Name"].ToString();
                string SN = dr["SN"].ToString();
                string Category = dr["Category"].ToString();
                int Numinbox = Convert.ToInt32(dr["Numinbox"]);

                itemList.Add(new Item(Name, SN, Numinbox, Category));

            }

            con.Close();
            return itemList;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public string getWorkerID(string workerName, string password)
    {
        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {
            String selectSTR = "SELECT W_ID FROM Worker where Name= '" + workerName + "' AND PW='" + password + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Id = dr["W_ID"].ToString();
            }
            return Id;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public string getWorkerBranch(string workerID)
    {
        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT B_ID FROM WorkerInBranch where W_Id= '" + workerID + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                numBranch = dr["B_ID"].ToString();
            }
            return numBranch;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public string getPO_ID()
    {
        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT MAX(PO_ID) as POMAX FROM PO";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                poId = dr["POMAX"].ToString();
                //poId = dr[0].ToString();
            }

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        return poId;



    }

    public void insertOrder(string status, string OrderDate, string workerID, string Branch)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String insertSTR;

             DateTime ChangedDate=ChangeDate(OrderDate);

            //string timeString = OrderDate;
            //IFormatProvider culture = new CultureInfo("en-US", true);
            //DateTime dateVal = DateTime.ParseExact(timeString, "dd.MM.yyyy", culture);

             insertSTR = "INSERT INTO PO Values ('" + status + "','" + ChangedDate + "',null, null ,'no'," + workerID + "," + Branch + ")";
            SqlCommand cmd = new SqlCommand(insertSTR, con);


            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public void insertItemOrder(string poID, string SN, int Quantity)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        String insertSTR;

        insertSTR = "INSERT INTO ITEM_PO Values (" + poID + ",'" + SN + "','" + Quantity + "','0')";
        SqlCommand cmd = new SqlCommand(insertSTR, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }


    }

    public string chekIN(string workerName, string password)
    {
        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT * FROM Worker ";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                string Name = dr["Name"].ToString();
                string Password = dr["PW"].ToString();
                if ((workerName == Name) && (password == Password))
                {
                    iswork = dr["Title"].ToString(); ;

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return iswork;

    }

    public List<Order> ReadOrder(string workerName, string password)
    {
        SqlConnection con;
        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        try
        {

            String selectSTR = "  select * from PO where B_ID =(select WIB.B_ID from WorkerInBranch WIB  where WIB.W_Id = (select W.W_ID from Worker W 	where W.Name='" + workerName + "' and W.PW='" + password + "'))order by PO_ID desc";

            SqlCommand cmd = new SqlCommand(selectSTR, con);


            da.SelectCommand = cmd;

            da.Fill(ds, "Order");
            dt_order = ds.Tables["Order"];

            List<Order> OrderList = new List<Order>();

            foreach (DataRow dr in dt_order.Rows)
            {
                string Po_id = dr["Po_id"].ToString();
                string Status = dr["Status"].ToString();
                string Po_date = dr["PO_DATE"].ToString();
                string Sup_date = dr["Sup_date"].ToString();


                OrderList.Add(new Order(Po_id, Status, Po_date, Sup_date));

            }

            con.Close();
            return OrderList;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public List<ItemInOrder> ReadItemInOrder(string NumberOrder)
    {
        SqlConnection con;
        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "select *  from  ITEM_PO where ITEM_PO.PO_ID = " + NumberOrder;

            SqlCommand cmd = new SqlCommand(selectSTR, con);


            da.SelectCommand = cmd;

            da.Fill(ds, "ItenInOrder");
            dt_order = ds.Tables["ItenInOrder"];

            List<ItemInOrder> listItemInOrder = new List<ItemInOrder>();

            foreach (DataRow dr in dt_order.Rows)
            {

                string PO_ID = dr["PO_ID"].ToString();
                string SN = dr["SN"].ToString();
                string Quant = dr["Quant"].ToString();
                string Stat = dr["Approved"].ToString();

                listItemInOrder.Add(new ItemInOrder(PO_ID, SN, Quant,Stat));

            }

            con.Close();
            return listItemInOrder;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void UpDateOrder(string numOrder, string status, string NumberDelivery, string sup_date)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            DateTime ChangedDate = ChangeDate(sup_date);
            string update = "update PO SET Status='" + status + "' , SUP_DATE='" + ChangedDate + "'  , NumberDelivey=" + NumberDelivery + " where PO_ID =" + numOrder;
            SqlCommand cmd = new SqlCommand(update, con);


            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public string insertINV(DataTable dt)
    {


        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file



            string date = DateTime.Now.ToShortDateString();

            string sql1 = "INSERT INTO Invoice (INV_Date) VALUES ('" + date + "')";
            using (con)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql1;
                try
                {
                    cmd.ExecuteNonQuery();
                    string re = SelectDate(date, dt);
                    return re;
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
    }

    public string SelectDate(string date, DataTable dt)
    {
        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file


            string ReturnID;
            SqlCommand cmd1 = new SqlCommand();
            Object returnValue;

            cmd1.CommandText = "select INV_ID from Invoice  where INV_Date='" + date + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            try
            {
                returnValue = cmd1.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            ReturnID = returnValue.ToString();
            InsertItemINV(ReturnID, dt);
            return ReturnID;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

    }

    public string InsertItemINV(string ID, DataTable dt)
    {
        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file


            string sql = "INSERT INTO Item_Invoice (Delivery_ID,SN, Quant,Price,Item_Sum,Del_Date,INV_ID,B_ID) VALUES (@A, @B, @C ,@D ,@E ,@F ,@G, @H)";
            using (con)
            {
                try
                {

                    foreach (DataRow r in dt.Rows)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@A", r[0]);
                        cmd.Parameters.AddWithValue("@B", r[1]);
                        cmd.Parameters.AddWithValue("@C", r[2]);
                        cmd.Parameters.AddWithValue("@D", r[3]);
                        cmd.Parameters.AddWithValue("@E", r[4]);
                        cmd.Parameters.AddWithValue("@F", r[5]);
                        cmd.Parameters.AddWithValue("@G", ID);
                        cmd.Parameters.AddWithValue("@H", r[6]);

                        //Branch_NUM	INV_NUM	DEL_ID	SN	Quant	Price	Sum	date

                        cmd.ExecuteNonQuery();
                    }
                    return "Inv Added to DB";
                }
                catch (Exception ex)
                {
                    // write to log
                    throw (ex);
                }

            }
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

    }

    public Int32 GetTotSum(string ID)
    {
        Int32 price = 0;
        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file


            String selectSTR = "select SUM(Item_Sum) from Item_Invoice where INV_ID='" + ID + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                price = Convert.ToInt32(dr[0]);
            }
            return price;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
    }

    public List<ItemInINV> GetITEMINV(string ID)
    {
        List<ItemInINV> list = new List<ItemInINV>();
        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file


            String selectSTR = "select II.SN,II.Price,II.Quant,IT.price from Item_Invoice II,Item IT where II.INV_ID='2' AND II.SN=IT.SN AND II.Price!=IT.price group by II.SN,II.Price,II.Quant,IT.Price";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {// Read till the end of the data into a row
                string SN = dr[0].ToString();
                int INV_P = Convert.ToInt32(dr[1]);
                int INV_Quant = Convert.ToInt32(dr[2]);
                int IT_P = Convert.ToInt32(dr[3]);

                ItemInINV It_Inv = new ItemInINV(SN, INV_P, INV_Quant, IT_P);
                list.Add(It_Inv);
            }
            return list;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
    }

    public bool chekID(string workerID)
    {
        SqlConnection con;
        bool iswork = false;
        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        String selectSTR = " SELECT W_ID FROM Worker  ";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {// Read till the end of the data into a row
            string w_id = dr["W_ID"].ToString();
            if (workerID == w_id)
            {
                iswork = true;

            }
        }

        return iswork;

    }

    public void insertNewPass(string WorkerID, string WorkerPass)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        String insertSTR;

        insertSTR = "UPDATE Worker SET PW='" + WorkerPass + "'WHERE W_ID=" + WorkerID + "";
        SqlCommand cmd = new SqlCommand(insertSTR, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public void insertNewWorker(string WorkerNmae, string WorkerID, string WorkerPass, string WorkerTitle)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        String insertSTR;

        insertSTR = "Insert Into Worker Values('" + WorkerID + "','" + WorkerNmae + "','" + WorkerPass + "','" + WorkerTitle + "') ";
        SqlCommand cmd = new SqlCommand(insertSTR, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public static void InsertError(string error, string page)
    {
        try
        {
            //SqlConnection con;
            //con=DBservices.connect("igroup31_test1ConnectionString");
            //con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings["igroup31_test1ConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            //return con;
            string sql = "INSERT INTO Errors (Error,Er_page) VALUES ('" + error + "','" + page + "')";
            using (con)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

        }

        catch (Exception ex)
        {
            //do nothing - so it would not create a loop;

        }
    }

    public static void DeleteOrder(int OrderNum)
    {
        try
        {
            SqlConnection con;
            con = connect("igroup31_test1ConnectionString");


            string sql = "UPDATE PO SET Status='cancelled' WHERE PO_ID='" + OrderNum + "'";
            using (con)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static string CheckStatus(int po_id)
    {
        //checks the status of a PO and returns a boolean value of true if status is cancelled/closed and false for all else.
        string status = null;
        try
        {
            SqlConnection con;
            con = connect("igroup31_test1ConnectionString");

            String selectSTR = "select status from PO where PO_ID='" + po_id + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {// Read till the end of the data into a row
                status = dr[0].ToString();
            }
            return status;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

    }

    public static void AprroveItem(string PO, string SN)
    {
        try
        {
            SqlConnection con;
            con = connect("igroup31_test1ConnectionString");

            string insertSTR = "UPDATE ITEM_PO SET Approved=1 WHERE PO_ID='" + PO + "' AND SN='" + SN + "'";

            SqlCommand cmd = new SqlCommand(insertSTR, con);


            int numEffected = cmd.ExecuteNonQuery(); // execute the command
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void insertNewPatient(string ID, string Kupah, string Num, string Name, string Zantar, string branch, string needle, string coil, string infusionBag, string solutions)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        String insertSTR;

        insertSTR = "Insert Into Patient Values('" + ID + "','" + Kupah + "','" + Num + "','" + Name + "','" + Zantar + "','" + branch + "','" + needle + "','" + coil + "','" + infusionBag + "','" + solutions + "') ";
        SqlCommand cmd = new SqlCommand(insertSTR, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public List<Patient> ReadPatient(string workerName, string password)
    {
        DataTable dt_Patient = new DataTable();
        SqlConnection con;
        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        try
        {

            String selectSTR = " select * from Patient where B_ID =(select WIB.B_ID from WorkerInBranch WIB  where WIB.W_Id = (select W.W_ID from Worker W 	where W.Name='" + workerName + "' and W.PW=" + password + "))order by Name desc";

            SqlCommand cmd = new SqlCommand(selectSTR, con);


            da.SelectCommand = cmd;

            da.Fill(ds, "Patient");
            dt_Patient = ds.Tables["Patient"];

            List<Patient> PatientList = new List<Patient>();

            foreach (DataRow dr in dt_Patient.Rows)
            {
                string Name = dr["Name"].ToString();
                string P_ID = dr["P_ID"].ToString();
                string Kupah = dr["Kupah"].ToString();
                string Patient_num = dr["Patient_num"].ToString();
                string Zantar = dr["Zantar"].ToString();
                string needle = dr["Needle"].ToString();
                string coil = dr["Coil"].ToString();
                string infusionBag = dr["InfusionBag"].ToString();
                string solutions = dr["Solutions"].ToString();

                PatientList.Add(new Patient(P_ID, Name, Kupah, Patient_num, Zantar, needle, coil, infusionBag, solutions));

            }

            con.Close();
            return PatientList;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void UpDatePatient(string ID, string Kupah, string Zantar, string needle, string coil, string infusionBag, string solutions)
    {

        SqlConnection con;

        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            string update = "update Patient SET Kupah='" + Kupah + "', Zantar='" + Zantar + "', Needle='" + needle + "', Coil='" + coil + "', InfusionBag='" + infusionBag + "', Solutions='" + solutions + "' where   P_ID=" + ID + "";
            SqlCommand cmd = new SqlCommand(update, con);


            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public List<Patient> InfoPatient(string ID)
    {
        DataTable dt_Patient = new DataTable();
        SqlConnection con;
        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        try
        {

            String selectSTR = "select * from Patient  where   P_ID=" + ID + "";

            SqlCommand cmd = new SqlCommand(selectSTR, con);


            da.SelectCommand = cmd;

            da.Fill(ds, "Patient");
            dt_Patient = ds.Tables["Patient"];

            List<Patient> PatientList = new List<Patient>();

            foreach (DataRow dr in dt_Patient.Rows)
            {
                string Name = dr["Name"].ToString();
                string P_ID = dr["P_ID"].ToString();
                string Kupah = dr["Kupah"].ToString();
                string Patient_num = dr["Patient_num"].ToString();
                string Zantar = dr["Zantar"].ToString();
                string needle = dr["Needle"].ToString();
                string coil = dr["Coil"].ToString();
                string infusionBag = dr["InfusionBag"].ToString();
                string solutions = dr["Solutions"].ToString();

                PatientList.Add(new Patient(P_ID, Name, Kupah, Patient_num, Zantar, needle, coil, infusionBag, solutions));

            }

            con.Close();
            return PatientList;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public List<Item> getItem()
    {

        SqlConnection con;
        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        try
        {

            String selectSTR = "SELECT * FROM Item";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            da.SelectCommand = cmd;

            da.Fill(ds, "Item");
            dt_item = ds.Tables["Item"];

            List<Item> itemList = new List<Item>();

            foreach (DataRow dr in dt_item.Rows)
            {

                string Name = dr["Name"].ToString();
                string SN = dr["SN"].ToString();
                string Category = dr["Category"].ToString();
                int Numinbox = Convert.ToInt32(dr["Numinbox"]);

                itemList.Add(new Item(Name, SN, Numinbox, Category));

            }

            con.Close();
            return itemList;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Message> ReadMessage()
    {
        DataTable dt_Patient = new DataTable();
        SqlConnection con;
        try
        {

            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        try
        {

            String selectSTR = "select * from Message";

            SqlCommand cmd = new SqlCommand(selectSTR, con);


            da.SelectCommand = cmd;

            da.Fill(ds, "Message");
            dt_Patient = ds.Tables["Message"];

            List<Message> MessageList = new List<Message>();

            foreach (DataRow dr in dt_Patient.Rows)
            {
                string Number = dr["Number"].ToString();
                string Text_Message = dr["Text_Message"].ToString();


                MessageList.Add(new Message(Number, Text_Message));

            }

            con.Close();
            return MessageList;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public static void DeleteMessage(string text_message)
    {
        try
        {
            SqlConnection con;
            con = connect("igroup31_test1ConnectionString");


            string sql = "DELETE FROM Message WHERE Text_Message='" + text_message + "';";
            using (con)
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void insertNewMessage(string text_message)
    {

        SqlConnection con;

        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String insertSTR;

        insertSTR = "insert into Message values (" + numbe_messag + ",'" + text_message + "')";
        numbe_messag++;
        SqlCommand cmd = new SqlCommand(insertSTR, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public void insertNewIteam(string Name, string sn, string catrgory, string numINbox, string price, string vandor)
    {
        SqlConnection con;

        try
        {
            con = connect("igroup31_test1ConnectionString"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String insertSTR;

        insertSTR = "insert into Item values (" + sn + ",'" + Name + ",' " + catrgory + ",'" + numINbox + ",'" + price + ",'" + vandor + ",')";
        numbe_messag++;
        SqlCommand cmd = new SqlCommand(insertSTR, con);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

        }
        catch (Exception ex)
        {

            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public static DateTime ChangeDate(string OrderDate)
    {
        //taked a string in the format of dd.MM.yyyy returns/converts it to standart datetime.
        try
        {
            string timeString = OrderDate;
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime dateVal = DateTime.ParseExact(timeString, "dd.MM.yyyy", culture);

            return dateVal;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    public static DataTable GetBranches()
    {
        try
        {
            SqlConnection con = connect("igroup31_test1ConnectionString");

            String selectSTR = "SELECT * FROM Branch";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataAdapter da_branch = new SqlDataAdapter();

            da_branch.SelectCommand = cmd;

            DataSet ds_branch = new DataSet();

            da_branch.Fill(ds_branch, "Branch");

            DataTable dt_branch = new DataTable();

            dt_branch = ds_branch.Tables["Branch"];

            return dt_branch;
        }
        catch (Exception ex)
        {
            throw ex;
        }




            
    }

    public static DataTable GetBranchesData(string query)
    {
        DataTable dt = new DataTable();
        SqlConnection con = connect("igroup31_test1ConnectionString");
   
        using (con)
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }

    public static DataTable GetItemInfo()
    {
        try
        {
            DataTable dt = new DataTable();
            SqlConnection con = connect("igroup31_test1ConnectionString");

            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("select * from Item"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            
            }

            

        }
        catch (Exception ex)
        {
            throw ex;
        }
            
    }
}
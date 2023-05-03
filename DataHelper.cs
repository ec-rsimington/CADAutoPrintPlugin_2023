using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CADAutoPrintPlugin_2023
{
      class DataHelper
      {
            public System.Data.SqlClient.SqlConnection sqlConnection()
            {
                  #region
                  //string connetionString = null;

                  ////connetionString = "server=DB-01;database=Manufacturing;Trusted_Connection=true";
                  //connetionString = "server=DB-01;database=Manufacturing;User ID=bomuser;Password=@Evans12345;Connection Timeout=30000";

                  //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connetionString);

                  //return sqlConnection1;
                  #endregion

                  string connetionString = null;

                  SqlConnection conn = new SqlConnection(
                   new SqlConnectionStringBuilder()
                   {
                         DataSource = "cgy-nodejs-p1n1",
                         InitialCatalog = "Manufacturing",
                         UserID = "vaultuser",
                         Password = "@Evans12345",
                   }.ConnectionString
                  );

                  System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(conn.ConnectionString);

                  return conn;
            }

            public System.Data.SqlClient.SqlConnection sqlAPIConnection()
            {
                  string connetionString = null;
                  SqlConnection conn = new SqlConnection(
                   new SqlConnectionStringBuilder()
                   {
                         DataSource = "cgy-nodejs-p1n1",
                         InitialCatalog = "API",
                         UserID = "vaultuser",
                         Password = "@Evans12345",

                   }.ConnectionString
                  );

                  System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(conn.ConnectionString);
                  return conn;
            }

            public int AddNewDesignBoM
            (string username,
            int projectid,
            string projectname,
            string projectnumber,
            string projectrev,
            string bom,
            string materials,
            string structured)
            {
                  int bomID = 0;

                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Connection = connection;

                  cmd.CommandText = ("InsertDesignBoM");

                  try
                  {
                        cmd.Connection = connection;

                        connection.Open();

                        cmd.Parameters.AddWithValue("@active", true);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@projectid", projectid);
                        cmd.Parameters.AddWithValue("@projectnumber", projectnumber);
                        cmd.Parameters.AddWithValue("@projectname", projectname);
                        cmd.Parameters.AddWithValue("@projectrev", projectrev);
                        cmd.Parameters.AddWithValue("@bom", bom);
                        cmd.Parameters.AddWithValue("@materials", materials);
                        cmd.Parameters.AddWithValue("@structured", structured);

                        bomID = (int)cmd.ExecuteScalar();

                        connection.Close();

                        //Success = true;
                  }
                  catch
                  {
                        connection.Close();
                        bomID = 0;
                  }

                  return bomID;

            }

            public bool UpdateDesignBoM
                (int bomid,
                string username,
                int projectid,
                string projectname,
                string projectnumber,
                string projectrev,
                string bom,
                string materials,
                string structured)
            {
                  bool Success = false;

                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Connection = connection;

                  cmd.CommandText = ("UpdateDesignBoM");

                  try
                  {
                        cmd.Connection = connection;

                        connection.Open();

                        cmd.Parameters.AddWithValue("@bomid", bomid);
                        cmd.Parameters.AddWithValue("@active", true);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@projectid", projectid);
                        cmd.Parameters.AddWithValue("@projectnumber", projectnumber);
                        cmd.Parameters.AddWithValue("@projectname", projectname);
                        cmd.Parameters.AddWithValue("@projectrev", projectrev);
                        cmd.Parameters.AddWithValue("@bom", bom);
                        cmd.Parameters.AddWithValue("@materials", materials);
                        cmd.Parameters.AddWithValue("@structured", structured);

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        Success = true;

                        connection.Close();

                        //Success = true;
                  }
                  catch
                  {
                        connection.Close();
                        Success = false;
                  }

                  return Success;

            }

            public bool AddNewProject
           (string jobnumber,
           string username,
           int finishscheduleid,
           int bomid,
           string jobname)
            {
                  bool Success = false;

                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Connection = connection;

                  cmd.CommandText = ("spInsertProjectIDs");

                  try
                  {
                        cmd.Connection = connection;

                        connection.Open();

                        cmd.Parameters.AddWithValue("@active", true);
                        cmd.Parameters.AddWithValue("@projectnumber", jobnumber);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@finishscheduleid", finishscheduleid);
                        cmd.Parameters.AddWithValue("@bomid", bomid);
                        cmd.Parameters.AddWithValue("@projectname", jobname);

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        Success = true;

                        connection.Close();
                  }
                  catch
                  {
                        connection.Close();
                  }

                  return Success;

            }

            public bool UpdateProject
            (string jobnumber,
            string username,
            int bomid)
            {
                  bool Success = false;

                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  cmd.CommandType = System.Data.CommandType.StoredProcedure;
                  cmd.Connection = connection;

                  cmd.CommandText = ("spUpdateProjectIDs");

                  try
                  {
                        cmd.Connection = connection;

                        connection.Open();

                        cmd.Parameters.AddWithValue("@projectnumber", jobnumber);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@bomid", bomid);

                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        Success = true;

                        connection.Close();
                  }
                  catch
                  {
                        connection.Close();
                        Success = false;
                  }

                  return Success;

            }

            public int GetBoMIDByProjectNumber(string JobNumber)
            {
                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  connection.Open();

                  cmd = new SqlCommand("GetBoMIDByProjectNumber", connection);
                  cmd.CommandType = CommandType.StoredProcedure;

                  SqlDataAdapter sda = new SqlDataAdapter(cmd);

                  Int32 BoMID = 0;

                  try
                  {
                        cmd.Parameters.AddWithValue("@JobNumber", JobNumber);
                        BoMID = cmd.ExecuteScalar() != null ? (Int32)cmd.ExecuteScalar() : 0;
                  }
                  catch (Exception searchError)
                  {
                        MessageBox.Show(searchError.Message);
                  }
                  finally
                  {
                        connection.Close();
                  }
                  return BoMID;
            }

            public string GetItemIDFromAPI(string uuid)
            {
                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  connection.Open();

                  cmd = new SqlCommand("GetItemIDFromAPI", connection);
                  cmd.CommandType = CommandType.StoredProcedure;

                  SqlDataAdapter sda = new SqlDataAdapter(cmd);

                  string itemID = "";

                  try
                  {
                        cmd.Parameters.AddWithValue("@uuid", uuid);
                        itemID = cmd.ExecuteScalar() != null ? (string)cmd.ExecuteScalar() : "NO ITEM FOUND";
                  }
                  catch (Exception searchError)
                  {
                        MessageBox.Show(searchError.Message);
                  }
                  finally
                  {
                        connection.Close();
                  }
                  return itemID;
            }

            public string GetDesignBoMByProjectNumber(string ProjNumber)
            {
                 
                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  connection.Open();

                  cmd = new SqlCommand("GetDesignBoMByProjNum", connection);
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;

                  string dBoM = "";
                  try
                  {
                        cmd.Parameters.AddWithValue("@ProjectNumber", ProjNumber);
                        dBoM = cmd.ExecuteScalar() != null ? (string)cmd.ExecuteScalar() : "NO BoM FOUND";

                        connection.Close();
                  }
                  catch (Exception searchError)
                  {
                        MessageBox.Show(searchError.Message);
                  }
                  finally
                  {
                        connection.Close();
                  }
                  return dBoM;
            }

            public List<string> GetIssuerInfoByProjectNumber(string ProjNumber)
            {
                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  connection.Open();

                  cmd = new SqlCommand("GetIssuerInfoByProjectNumber", connection);
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;

                  SqlDataAdapter sda = new SqlDataAdapter(cmd);
                  List<string> issuerInfo = new List<string>();

                  try
                  {
                        cmd.Parameters.AddWithValue("@ProjectNumber", ProjNumber);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                              if (reader.HasRows)
                              {
                                    while (reader.Read())
                                    {
                                          issuerInfo.Add(reader[0].ToString().ToUpper());
                                          issuerInfo.Add(reader[1].ToString().ToUpper());
                                    }
                              }
                        }

                        connection.Close();
                  }
                  catch (Exception searchError)
                  {
                        MessageBox.Show(searchError.Message);
                  }
                  finally
                  {
                        connection.Close();
                  }
                  return issuerInfo;
            }

            public string GetEngineeringBoMByID(int BomID)
            {
                  DataTable dT = new DataTable();

                  System.Data.SqlClient.SqlConnection connection = sqlConnection();
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                  connection.Open();

                  cmd = new SqlCommand("GetEngineeringBoMByID", connection);
                  cmd.CommandType = System.Data.CommandType.StoredProcedure;

                  SqlDataAdapter sda = new SqlDataAdapter(cmd);

                  string EngineeringBoM = string.Empty;

                  try
                  {
                        cmd.Parameters.AddWithValue("@BomID", BomID);

                        EngineeringBoM = (string)cmd.ExecuteScalar();
                  }
                  catch (Exception searchError)
                  {
                        MessageBox.Show(searchError.Message);
                  }
                  finally
                  {
                        connection.Close();
                  }
                  return EngineeringBoM;
            }

            public DataTable GetSearchProjectData(string Search, string AreaID)
            {
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                  System.Data.SqlClient.SqlConnection conn = sqlAPIConnection();
                  DataTable dt = new DataTable();

                  conn.Open();
                  cmd = new SqlCommand("SearchProductionUuid", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                  {
                        try
                        {
                              cmd.Parameters.Add(new SqlParameter("@search", Search));
                              sda.Fill(dt);
                        }
                        finally
                        {
                              if (conn != null)
                              {
                                    conn.Close();
                              }
                        }
                  }
                  return dt;
            }

            public DataTable GetAllProductionItemsByUUID(string UUID)
            {
                  System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                  System.Data.SqlClient.SqlConnection conn = sqlAPIConnection();
                  DataTable dt = new DataTable();

                  conn.Open();
                  cmd = new SqlCommand("GetProductionItemsUuid", conn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                  {
                        sda.SelectCommand.CommandTimeout = 0;
                        try
                        {
                              cmd.Parameters.Add(new SqlParameter("@uuid", UUID));
                              sda.Fill(dt);
                        }
                        catch /*(Exception getdataError)*/
                        {

                        }
                        finally
                        {
                              if (conn != null)
                              {
                                    conn.Close();
                              }
                        }
                  }
                  return dt;
            }

            public string GetBarcode(string productionid, string partnumber, string rev, string AreaID)
            {
                  string barcodeID = "";
                  System.Data.SqlClient.SqlConnection conn = sqlAPIConnection();
                  SqlDataReader rdr = null;

                  try
                  {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("getBarcode", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@production", productionid));
                        cmd.Parameters.Add(new SqlParameter("@partnumber", partnumber));
                        cmd.Parameters.Add(new SqlParameter("@rev", rev));
                        cmd.Parameters.Add(new SqlParameter("@dataAreaId", AreaID));
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                              barcodeID = rdr["BARCODEID"].ToString();
                        }
                  }
                  finally
                  {
                        if (conn != null)
                        {
                              conn.Close();
                        }
                        if (rdr != null)
                        {
                              rdr.Close();
                        }
                  }
                  return barcodeID;
            }
      }
}

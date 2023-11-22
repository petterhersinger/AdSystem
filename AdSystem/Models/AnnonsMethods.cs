using System.Data;
using System.Data.SqlClient;

namespace AdSystem.Models;

public class AnnonsMethods
{
    public List<AnnonsModel> GetAllAnnonser(out string errormsg)
    {
        SqlConnection dbConnection = new SqlConnection();

        dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdSystem;Integrated Security=True";

        string sqlstring = "SELECT * FROM [dbo].[tbl_ads]";

        SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

        SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
        DataSet myDS = new DataSet();

        List<AnnonsModel> annonsList = new List<AnnonsModel>();
        try
        {
            dbConnection.Open();

            myAdapter.Fill(myDS, "Annons");

            foreach (DataRow row in myDS.Tables["Annons"].Rows)
            {
                AnnonsModel annons = new AnnonsModel();
                annons.AnnonsId = Convert.ToInt32(row["ad_id"]);
                annons.AnnonsorId = Convert.ToInt32(row["ad_annonsor_id"]);
                annons.Rubrik = row["ad_rubrik"].ToString();
                annons.Innehall = row["ad_innehall"].ToString();
                annons.Pris = Convert.ToDecimal(row["ad_pris"]);
                annons.VaransPris = Convert.ToDecimal(row["ad_varans_pris"]);

                annonsList.Add(annons);
            }

            errormsg = "";
            return annonsList;
        }
        catch (Exception e)
        {
            errormsg = e.Message;
            return null;
        }
        finally
        {
            dbConnection.Close();
        }
    }
    public int InsertAnnons(AnnonsModel annons, out string errormsg)
    {
        SqlConnection dbConnection = new SqlConnection();

        dbConnection.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdSystem;Integrated Security=True";

        string sqlstring = "INSERT INTO [dbo].[tbl_ads] " +
                           "(ad_annonsor_id, ad_rubrik, ad_innehall, ad_pris, ad_varans_pris) " +
                           "VALUES (@AnnonsorId, @Rubrik, @Innehall, @Pris, @VaransPris)";

        SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

        dbCommand.Parameters.AddWithValue("@AnnonsorId", annons.AnnonsorId);
        dbCommand.Parameters.AddWithValue("@Rubrik", annons.Rubrik);
        dbCommand.Parameters.AddWithValue("@Innehall", annons.Innehall);
        dbCommand.Parameters.AddWithValue("@Pris", annons.Pris);
        dbCommand.Parameters.AddWithValue("@VaransPris", annons.VaransPris);

        try
        {
            dbConnection.Open();
            int rowsAffected = dbCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                errormsg = "";
            }
            else
            {
                errormsg = "No advertisement is inserted to the database.";
            }

            return rowsAffected;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            errormsg = e.Message;
            return 0;
        }
        finally
        {
            dbConnection.Close();
        }
    }
}
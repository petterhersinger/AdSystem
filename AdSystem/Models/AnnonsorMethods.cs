using System.Data;
using System.Data.SqlClient;

namespace AdSystem.Models;

public class AnnonsorMethods
{
    public AnnonsorModel GetAnnonsor(int AnnonsorId, out string errormsg)
    {
        SqlConnection dbConnection = new SqlConnection();

        dbConnection.ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdSystem;Integrated Security=True";

        string sqlstring = "SELECT * FROM [dbo].[tbl_annonsorer] WHERE an_annonsor_id = @AnnonsorId";

        SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);
        dbCommand.Parameters.AddWithValue("@AnnonsorId", AnnonsorId);

        SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
        DataSet myDS = new DataSet();

        List<AnnonsorModel> annonsorList = new List<AnnonsorModel>();
        try
        {
            dbConnection.Open();

            myAdapter.Fill(myDS, "Annonsor");

            int count = myDS.Tables["Annonsor"].Rows.Count;

            if (count > 0)
            {
                AnnonsorModel annonsor = new AnnonsorModel();
                DataRow row = myDS.Tables["Annonsor"].Rows[0];

                annonsor.AnnonsorId = Convert.ToInt16(row["an_annonsor_id"]);
                annonsor.PrenumerantId = Convert.ToInt32(row["an_prenumerant_id"]);
                annonsor.ForetagsAnnonsor = Convert.ToBoolean(row["an_foretagsannonsor"]);
                annonsor.Namn = row["an_namn"].ToString();
                annonsor.Organisationsnummer = row["an_organisationsnummer"].ToString();
                annonsor.Telefonnummer = row["an_telefonnummer"].ToString();
                annonsor.Utdelningsadress = row["an_utdelningsadress"].ToString();
                annonsor.Postnummer = row["an_postnummer"].ToString();
                annonsor.Ort = row["an_ort"].ToString();
                annonsor.Fakturaadress = row["an_fakturaadress"].ToString();

                errormsg = "";
                return annonsor;
            }
            else
            {
                errormsg = "No annonsor was found in the database.";
                return null;
            }
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

    public int InsertAnnonsor(AnnonsorModel annonsor, out string errormsg)
    {
        SqlConnection dbConnection = new SqlConnection();

        dbConnection.ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdSystem;Integrated Security=True";

        string sqlstring = "INSERT INTO [dbo].[tbl_annonsorer] " +
                           "(an_prenumerant_id, an_foretagsannonsor, an_namn, an_organisationsnummer, " +
                           "an_telefonnummer, an_utdelningsadress, an_postnummer, an_ort, an_fakturaadress) " +
                           "VALUES (@PrenumerantId, @ForetagsAnnonsor, @Namn, @Organisationsnummer, " +
                           "@Telefonnummer, @Utdelningsadress, @Postnummer, @Ort, @Fakturaadress)";

        SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);

        dbCommand.Parameters.AddWithValue("@PrenumerantId", annonsor.PrenumerantId);
        dbCommand.Parameters.AddWithValue("@ForetagsAnnonsor", annonsor.ForetagsAnnonsor);
        dbCommand.Parameters.AddWithValue("@Namn", annonsor.Namn);
        dbCommand.Parameters.AddWithValue("@Organisationsnummer", annonsor.Organisationsnummer);
        dbCommand.Parameters.AddWithValue("@Telefonnummer", annonsor.Telefonnummer);
        dbCommand.Parameters.AddWithValue("@Utdelningsadress", annonsor.Utdelningsadress);
        dbCommand.Parameters.AddWithValue("@Postnummer", annonsor.Postnummer);
        dbCommand.Parameters.AddWithValue("@Ort", annonsor.Ort);
        dbCommand.Parameters.AddWithValue("@Fakturaadress", annonsor.Fakturaadress);

        try
        {
            dbConnection.Open();
            int rowsAffected = dbCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"API response is: {rowsAffected}");
                errormsg = "";
            }
            else
            {
                Console.WriteLine($"API response is: {rowsAffected}");
                errormsg = "No annonsor is inserted to the database.";
            }

            return rowsAffected;
        }
        catch (Exception e)
        {
            errormsg = e.Message;
            return 0;
        }
        finally
        {
            dbConnection.Close();
        }
    }

    public AnnonsorModel GetAnnonsorByOrganisationsnummer(string organisationsnummer, out string errormsg)
    {
        SqlConnection dbConnection = new SqlConnection();

        dbConnection.ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdSystem;Integrated Security=True";

        string sqlstring = "SELECT * FROM [dbo].[tbl_annonsorer] WHERE an_organisationsnummer = @Organisationsnummer";

        SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);
        dbCommand.Parameters.AddWithValue("@Organisationsnummer", organisationsnummer);

        SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
        DataSet myDS = new DataSet();

        List<AnnonsorModel> annonsorList = new List<AnnonsorModel>();
        try
        {
            dbConnection.Open();

            myAdapter.Fill(myDS, "Annonsor");

            int count = myDS.Tables["Annonsor"].Rows.Count;

            if (count > 0)
            {
                AnnonsorModel annonsor = new AnnonsorModel();
                DataRow row = myDS.Tables["Annonsor"].Rows[0];

                annonsor.AnnonsorId = Convert.ToInt16(row["an_annonsor_id"]);
                annonsor.PrenumerantId = Convert.ToInt32(row["an_prenumerant_id"]);
                annonsor.ForetagsAnnonsor = Convert.ToBoolean(row["an_foretagsannonsor"]);
                annonsor.Namn = row["an_namn"].ToString();
                annonsor.Organisationsnummer = row["an_organisationsnummer"].ToString();
                annonsor.Telefonnummer = row["an_telefonnummer"].ToString();
                annonsor.Utdelningsadress = row["an_utdelningsadress"].ToString();
                annonsor.Postnummer = row["an_postnummer"].ToString();
                annonsor.Ort = row["an_ort"].ToString();
                annonsor.Fakturaadress = row["an_fakturaadress"].ToString();

                errormsg = "";
                return annonsor;
            }
            else
            {
                errormsg = "No annonsor was found in the database.";
                return null;
            }
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

    public AnnonsorModel GetAnnonsorByPrenumerantId(int prenumerantId, out string errormsg)
    {
        SqlConnection dbConnection = new SqlConnection();

        dbConnection.ConnectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdSystem;Integrated Security=True";

        string sqlstring = "SELECT * FROM [dbo].[tbl_annonsorer] WHERE an_prenumerant_id = @PrenumerantId";

        SqlCommand dbCommand = new SqlCommand(sqlstring, dbConnection);
        dbCommand.Parameters.AddWithValue("@PrenumerantId", prenumerantId);

        SqlDataAdapter myAdapter = new SqlDataAdapter(dbCommand);
        DataSet myDS = new DataSet();

        List<AnnonsorModel> annonsorList = new List<AnnonsorModel>();
        try
        {
            dbConnection.Open();

            myAdapter.Fill(myDS, "Annonsor");

            int count = myDS.Tables["Annonsor"].Rows.Count;

            if (count > 0)
            {
                AnnonsorModel annonsor = new AnnonsorModel();
                DataRow row = myDS.Tables["Annonsor"].Rows[0];

                annonsor.AnnonsorId = Convert.ToInt16(row["an_annonsor_id"]);
                annonsor.PrenumerantId = Convert.ToInt32(row["an_prenumerant_id"]);
                annonsor.ForetagsAnnonsor = Convert.ToBoolean(row["an_foretagsannonsor"]);
                annonsor.Namn = row["an_namn"].ToString();
                annonsor.Organisationsnummer = row["an_organisationsnummer"].ToString();
                annonsor.Telefonnummer = row["an_telefonnummer"].ToString();
                annonsor.Utdelningsadress = row["an_utdelningsadress"].ToString();
                annonsor.Postnummer = row["an_postnummer"].ToString();
                annonsor.Ort = row["an_ort"].ToString();
                annonsor.Fakturaadress = row["an_fakturaadress"].ToString();

                errormsg = "";
                return annonsor;
            }
            else
            {
                errormsg = "No annonsor was found in the database.";
                return null;
            }
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
}
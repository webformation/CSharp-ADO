using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSet_nonType
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connexion = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = demo; Integrated Security = True");
            SqlDataAdapter DemoDataAdapter = new SqlDataAdapter("select * from annuaire", connexion);

            DataSet DemoDataSet = new DataSet();
            DemoDataAdapter.Fill(DemoDataSet, "Annuaire");

            DataTable AnnuaireTable = DemoDataSet.Tables["Annuaire"];
            DataTableReader AnnuaireReader = DemoDataSet.CreateDataReader(AnnuaireTable);
            while (AnnuaireReader.Read())     
            {
                Console.WriteLine(String.Format("{0} {1}", AnnuaireReader["nom"], AnnuaireReader["age"]));
            }

            SqlCommandBuilder DemoSqlCommandBuilder = new SqlCommandBuilder(DemoDataAdapter);
            DemoDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataRow AnnuaireDataRow = AnnuaireTable.NewRow();
            AnnuaireDataRow["nom"] = "jean";
            AnnuaireDataRow["age"] = "99";
            AnnuaireTable.Rows.Add(AnnuaireDataRow);
            DemoDataAdapter.Update(DemoDataSet, "Annuaire");
        }
    }
}

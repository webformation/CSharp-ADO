

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetType
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSetDemo.annuaireDataTable DataTableAnnuaire = new DataSetDemo.annuaireDataTable();
            DataSetDemoTableAdapters.annuaireTableAdapter TableAdapterAnnuaire = new DataSetDemoTableAdapters.annuaireTableAdapter();
            TableAdapterAnnuaire.Fill(DataTableAnnuaire);
            
            foreach (var l in DataTableAnnuaire)
            {
            Console.WriteLine(String.Format("{0} {1}",l.nom, l.age));
            }
            DataRow nl = DataTableAnnuaire.NewRow();
            nl["nom"] = "Dupond";
            nl["age"] = 20;
            DataTableAnnuaire.Rows.Add(nl);
            TableAdapterAnnuaire.Update(DataTableAnnuaire);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetType
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSetDemo.annuaireDataTable anDT = new DataSetDemo.annuaireDataTable();
            DataSetDemoTableAdapters.annuaireTableAdapter anTA = new DataSetDemoTableAdapters.annuaireTableAdapter();
            anTA.Fill(anDT);
            
            foreach (var l in anDT)
            {
                Console.WriteLine(String.Format("{0} {1}",l.nom, l.age));
            }
        }
    }
}

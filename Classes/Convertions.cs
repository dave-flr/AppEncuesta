using DXApplication1.Classes.Charts;
using DXApplication1.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Classes
{
    public static class Convertions
    {
        public static List<Questions> ConvertoToList(DataTable table)
        {
            List<Questions> list = new List<Questions>();
            int i = 0;

            foreach (DataRow rows in table.Rows)
            {
                Questions result = new Questions();
                result.Valor = Convert.ToString(table.Rows[i]["valor"]);
                result.Cantidad = Convert.ToInt32(table.Rows[i]["cantidad"]);

                list.Add(result);
                i++;
            }

            return list;
        }

        public static List<QuestionNumerical> ConverToListNumerical(DataTable table)
        {
            List<QuestionNumerical> list = new List<QuestionNumerical>();
            int i = 0;

            foreach (DataRow rows in table.Rows)
            {
                QuestionNumerical result = new QuestionNumerical();
                result.Valor = Convert.ToInt32(table.Rows[i]["valor"]);
                result.Cantidad = Convert.ToInt32(table.Rows[i]["cantidad"]);

                list.Add(result);
                i++;
            }

            return list;
        }

    }
}

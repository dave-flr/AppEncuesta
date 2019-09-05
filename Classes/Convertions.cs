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

        public static List<Respuestas> ConvertoToListResp(DataTable table)
        {
            List<Respuestas> list = new List<Respuestas>();
            int i = 0;

            foreach (DataRow rows in table.Rows)
            {
                Respuestas result = new Respuestas();
                result.Numero = Convert.ToInt32(table.Rows[i]["numero"]);
                result.I = Convert.ToString(table.Rows[i]["I"]);
                result.Ii = Convert.ToString(table.Rows[i]["II"]);
                result.Iii = Convert.ToInt32(table.Rows[i]["III"]);
                result.Iv = Convert.ToString(table.Rows[i]["IV"]);
                result.V = Convert.ToInt32(table.Rows[i]["V"]);
                result.Vi = Convert.ToInt32(table.Rows[i]["VI"]);
                result.Vii = Convert.ToInt32(table.Rows[i]["VII"]);
                result.Viii = Convert.ToInt32(table.Rows[i]["VIII"]);
                result.Ix = Convert.ToInt32(table.Rows[i]["IX"]);
                result.X = Convert.ToInt32(table.Rows[i]["X"]);
                result.Xi = Convert.ToInt32(table.Rows[i]["XI"]);
                result.Xii = Convert.ToInt32(table.Rows[i]["XII"]);
                result.Xiii = Convert.ToInt32(table.Rows[i]["XIII"]);
                result.Xiv = Convert.ToInt32(table.Rows[i]["XIV"]);
                result.Xv = Convert.ToInt32(table.Rows[i]["XV"]);
                result.Xvi = Convert.ToInt32(table.Rows[i]["XVI"]);
                result.Xvii = Convert.ToInt32(table.Rows[i]["XVII"]);

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

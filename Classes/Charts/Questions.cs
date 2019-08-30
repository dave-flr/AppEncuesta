using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Classes.Charts
{
    public class Questions
    {
        string valor;
        int cantidad;

        public string Valor { get => valor; set => valor = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }

    public class QuestionNumerical
    {
        int valor;
        int cantidad;
        public int Valor { get => valor; set => valor = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}

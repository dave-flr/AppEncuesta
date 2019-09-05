using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.Classes
{
    public class Respuestas
    {
        int numero;
        string i;
        string ii;
        int iii;
        string iv;
        int v;
        int vi;
        int vii;
        int viii;
        int ix;
        int x;
        int xi;
        int xii;
        int xiii;
        int xiv;
        int xv;
        int xvi;
        int xvii;

        public int Numero { get => numero; set => numero = value; }
        public string I { get => i; set => i = value; }
        public string Ii { get => ii; set => ii = value; }
        public int Iii { get => iii; set => iii = value; }
        public string Iv { get => iv; set => iv = value; }
        public int V { get => v; set => v = value; }
        public int Vi { get => vi; set => vi = value; }
        public int Vii { get => vii; set => vii = value; }
        public int Viii { get => viii; set => viii = value; }
        public int Ix { get => ix; set => ix = value; }
        public int X { get => x; set => x = value; }
        public int Xi { get => xi; set => xi = value; }
        public int Xii { get => xii; set => xii = value; }
        public int Xiii { get => xiii; set => xiii = value; }
        public int Xiv { get => xiv; set => xiv = value; }
        public int Xv { get => xv; set => xv = value; }
        public int Xvi { get => xvi; set => xvi = value; }
        public int Xvii { get => xvii; set => xvii = value; }
    }
    class Iii
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }

    class V
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Vi
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Vii
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Viii
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class X
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }

    class Xi
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Xii
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Xiii
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Xiv
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Xv
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
    class Xvii
    {
        int key;
        string value;

        public int Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }

    public static class TableNames{
        public static string returnTableName(int i) {
            switch (i)
            {
                case 3:
                    return "iii_sexo";
                case 5:
                    return "v_departamento";
                case 6:
                    return "vi_ciudad";
                case 7:
                    return "vii_facultad";
                case 8:
                    return "viii_carrera";
                case 10:
                    return "x_matricula";
                case 11:
                    return "xi_becado";
                case 12:
                    return "xii";
                case 13:
                    return "xiii";
                case 14:
                    return "xiv";
                case 15:
                    return "xv";
                case 17:
                    return "xvii";
                default:
                    return null;
            }
        }
    }

   /* public class TableNames {
        string sexo = "iii_sexo";
        string departamento = "v_departamento";
        string ciudad = "vi_ciudad";
        string facultad = "vii_facultad";
        string carrera = "viii_carrera";
        string matricula = "x_matricula";
        string becado = "xi_becado";
        string xii = "xii";
        string xiii = "xiii";
        string xiv = "xiv";
        string xv = "xv";
        string xvii = "xvii";

        public string returnTableName(int i) {
            switch (i)
            {
                case 3:
                    return sexo;
                case 5:
                    return departamento;
                case 6:
                    return ciudad;
                case 7:
                    return facultad;
                case 8:
                    return carrera;
                case 10:
                    return matricula;
                case 11:
                    return becado;
                case 12:
                    return xii;
                case 13:
                    return xiii;
                case 14:
                    return xiv;
                case 15:
                    return xv;
                case 17:
                    return xvii;
                default:
                    return null;
            }

        }
    }*/
}

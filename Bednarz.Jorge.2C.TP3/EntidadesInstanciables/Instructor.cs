using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(4));
            //Aguardo un segundo a que el Random genere otro número aleatorio
            System.Threading.Thread.Sleep(1000);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)Instructor._random.Next(4));
        }

        static Instructor()
        {
            _random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Retorna todos los datos del Alumno
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Se da si se da esa clase
        /// </summary>
        /// <returns>string</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            bool existe = false;
            //Recorro la cola
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        //ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al nombre de la clases que da.
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}
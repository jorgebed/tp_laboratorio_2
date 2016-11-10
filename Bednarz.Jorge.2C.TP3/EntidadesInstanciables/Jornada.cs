using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    public class Jornada
    {
        #region ATRIBUTOS
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        #endregion

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.guardar("Jornada.txt", jornada.ToString());
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool participa = false;

            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    participa = true;
            }
            return participa;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            sb.AppendLine("CLASES DE " + this._clase + " POR ");
           // sb.AppendLine(this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }
    }
}
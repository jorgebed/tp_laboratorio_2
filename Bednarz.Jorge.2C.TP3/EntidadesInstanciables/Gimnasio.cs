using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornadas;

        #region ENUMERADOS
        public enum EClases
        {
            Natacion,
            Pilates,
            CrossFit,
            Yoga
        }
        #endregion

        #region PROPIEDAD
        private Jornada this[int i]
        {
            get { return this._jornadas[i]; }
        }
        #endregion

        #region CONSTRUCTORES
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }
        #endregion

        public static bool Guardar(Gimnasio gim)
        {
            XmlTextWriter XmlTw = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MiarchivoPXML.xml", Encoding.UTF8);
            XmlSerializer XmlSer = new XmlSerializer(typeof(Gimnasio));

            XmlSer.Serialize(XmlTw, gim);
            XmlTw.Close();
            return true;
        }

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in gim._jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        //Un gimnasio será igual a un Alumno si el mismo está inscripto en él
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            bool esta = false;

            foreach (Alumno item in g._alumnos)
            {
                if (item == a)
                    esta = true;
            }
            return esta;
        }
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        //La igualación entre un Gimnasio y una Clase retornará el primer instructor capaz de dar esa clase
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            Instructor instructor = null;
            try
            {
                if (!object.Equals(g, null))
                {
                    foreach (Instructor item in g._instructores)
                    {
                        if (item == clase)
                        {
                            instructor = item;
                            break;
                        }
                    }
                }
            }
            catch (SinInstructorException e)
            {
                Console.WriteLine(e.Message);
            }
            return instructor;            
        }

        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            Instructor instructor = null;
            try
            {
                if (!object.Equals(g, null))
                {
                    foreach (Instructor item in g._instructores)
                    {
                        if (item != clase)
                        {
                            instructor = item;
                            break;
                        }
                    }
                }
            }
            catch (SinInstructorException e)
            {
                Console.WriteLine(e.Message);
            }

            return instructor; 
        }

        //Un Gimnasio será igual a un instructor si el mismo está dando clases en él
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool esta = false;

            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                    esta = true;
            }

            return esta;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            //El alumno ya existe en el gimnasio (excepción)
            if (g == a)
                throw new AlumnoRepetidoException();
            else
                g._alumnos.Add(a);
            return g;
        }

        /*Al agregar una clase a un Gimnasio se deberá generar y agregar 
          una nueva jornada indicando la clase, un instructor que pueda darla
          (según su atributo ClasesDelDia) y la lista de Alumnos que la toman 
          (todos los que coincidadn en su campo ClaseQueToma)
         */
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            //Creo y agrego la nuevaJornada a la lista _jornadas
            Jornada nuevaJornada = new Jornada(clase, g == clase);
            g._jornadas.Add(nuevaJornada);

            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                    nuevaJornada += item;
            }
            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);

            return g;
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
    }
}
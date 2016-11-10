using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        #region ATRIBUTOS
        private int _identificador;
        #endregion

        #region METODOS
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio && (PersonaGimnasio)obj == this);
        }

        /// <summary>
        /// Retorna todos los datos de la Persona + PersonaGimnasio
        /// </summary>
        /// <returns>string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._identificador);

            return sb.ToString();
        }

        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            //Son iguales <=> mismo tipo && (id || dni)
            return (pg1.GetType() == pg2.GetType() && (pg1._identificador == pg2._identificador || pg1.DNI == pg2.DNI));
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        abstract protected string ParticiparEnClase();

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        #endregion
    }
}
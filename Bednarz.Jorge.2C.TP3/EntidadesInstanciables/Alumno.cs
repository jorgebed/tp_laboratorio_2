using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        #region ATRIBUTOS
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region ENUMERADOS
        public enum EEstadoCuenta
        {
            AlDia,
            MesPrueba,
            Deudor
        }
        #endregion

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Retorna todos los datos del Alumno
        /// </summary>
        /// <returns>string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("ESTADO CUENTA: " + this._estadoCuenta);
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Si toma la clase y su estado no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>bool</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return (a._estadoCuenta != EEstadoCuenta.Deudor && a._claseQueToma == clase);
        }

        //Un Alumno será distinto a un EClase sólo si no toma esa clase
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            return a._claseQueToma != clase;
        }

        //Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
    }
}
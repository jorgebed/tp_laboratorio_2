using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ATRIBUTOS
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        #region ENUMERADO
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region PROPIEDADES
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }

            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (DniInvalidoException)
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
           set
           {
               try
               {
                   this._dni = ValidarDni(this.Nacionalidad, value);
               }
               catch (DniInvalidoException)
               {
                   throw new NacionalidadInvalidaException();
               }
           }    
        }
        #endregion

        #region CONSTRUCTORES
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion  

        #region METODOS
        /// <summary>
        /// Retorna todos los datos de la Persona
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el ingreso del DNI tenga el formato correcto
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">int DNI</param>
        /// <returns>int</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;
            bool isOk = false;

            if (ENacionalidad.Argentino == nacionalidad)
            {
                if (dato > 0 && dato <= 89999999)
                {
                    dniValidado = dato;
                    isOk = true;
                }                
            }

            if (ENacionalidad.Extranjero == nacionalidad)
            {
                if (dato > 89999999 && dato <= 99999999)
                {
                    dniValidado = dato;
                    isOk = true;
                }                
            }

            if(!isOk)
                throw new DniInvalidoException();

            return dniValidado;            
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            bool isOk = false;
            int dni = 0;

            isOk = int.TryParse(dato, out dni);
            
            if(isOk)
                return ValidarDni(Nacionalidad, dni);
            else
                throw new DniInvalidoException();
        }

        private string ValidarNombreApellido(string dato)
        {
            bool isOk = false;

            for (int i = 0; i < dato.Length; i++)
            {
                isOk = char.IsLetter(dato, i);
                if (isOk == false)
                {
                    dato = null;
                    break;
                }
            }
            return dato;
        }
        #endregion
    }
}
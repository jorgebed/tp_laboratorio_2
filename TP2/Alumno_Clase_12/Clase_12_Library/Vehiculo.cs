using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        //ENUMERADO EMARCA
        public enum EMarca
        {
            Yamaha, 
            Chevrolet, 
            Ford, 
            Iveco, 
            Scania, 
            BMW
        }

        //ATRIBUTOS
        protected EMarca _marca;
        protected string _patente;
        protected ConsoleColor _color;

        #region CONSTRUCTOR
        public Vehiculo(string patente, EMarca marca, ConsoleColor color)
        {
            this._patente = patente;
            this._marca = marca;
            this._color = color;
        }
        #endregion

        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        public abstract short CantidadRuedas 
        {
            get;
        }

        /// <summary>
        /// Muestra los atributos de Vehiculo
        /// </summary>
        /// <returns>Retorna un string con los atributos de Vehiculo</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1">Vehiculo Uno</param>
        /// <param name="v2">Vehiculo Dos</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1._patente == v2._patente);
        }
        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1">Vehiculo Uno</param>
        /// <param name="v2">Vehiculo Dos</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}

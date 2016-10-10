using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        #region CONSTRUCTOR
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }

        #region METODOS
        /// <summary>
        /// Muestra los atributos de Automovil
        /// </summary>
        /// <returns>Retorna un string con los atributos de Automovil</returns>
        
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.Append("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}

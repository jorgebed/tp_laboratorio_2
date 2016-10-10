using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        #region CONSTRUCTOR
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        #endregion
        
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Muestra los atributos de Moto
        /// </summary>
        /// <returns>Retorna un string con los atributos de Moto</returns>
        public sealed override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.Append("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}

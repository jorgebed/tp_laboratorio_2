using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_WF
{
    class Numero
    {
        private double numero;

        public double getNumero()
        {
            return this.numero;
        }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            setNumero(numero);
        }

        private void setNumero(string numero)
        {
            this.numero = ValidarNumero(numero);
        }

        private static double ValidarNumero(string NumeroString)
        {
            double numero = 0;

            if (double.TryParse(NumeroString, out numero) == false)
                return 0;
            else
                return numero;
        }
    }
}

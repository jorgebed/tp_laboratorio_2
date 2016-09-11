using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_WF
{
    class Calculadora
    {
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double numero = 0;

            switch (operador)
            {
                case "+":
                    numero = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    numero = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    numero = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() == 0)
                        return 0;
                    else
                        numero = numero1.getNumero() / numero2.getNumero();
                    break;
            }
            return numero;
        }

        public string validarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;
            else
                return "+";
        }
    }
}

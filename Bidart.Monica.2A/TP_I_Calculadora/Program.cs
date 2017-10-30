using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_I_Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero numeroUno = new Numero("10");
            Numero numeroDos = new Numero(5);

            Console.WriteLine(numeroUno.GetNumero());// xq era esto de la ruta...
            Console.WriteLine(numeroDos.GetNumero());

            Console.WriteLine("La Suma de {0} y {1} Resultado {2} ",numeroUno.GetNumero(),numeroDos.GetNumero(),Calculadora.Operar(numeroUno, numeroDos, "+"));
            Console.WriteLine("La Resta de {0} y {1} Resultado {2} ", numeroUno.GetNumero(), numeroDos.GetNumero(), Calculadora.Operar(numeroUno, numeroDos, "-"));
            Console.WriteLine("El Producto de {0} y {1} Resultado {2} ", numeroUno.GetNumero(), numeroDos.GetNumero(), Calculadora.Operar(numeroUno, numeroDos, "*"));
            Console.WriteLine("La Division de {0} y {1} Resultado {2} ", numeroUno.GetNumero(), numeroDos.GetNumero(), Calculadora.Operar(numeroUno, numeroDos, "/"));

            Console.ReadKey();
        }
    }
}

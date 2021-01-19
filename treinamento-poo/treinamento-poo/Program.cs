using System;
using System.Collections.Generic;
using treinamento_poo.Classes_e_Objetos;

namespace treinamento_poo
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassesEObjetos classes_e_objetos = new ClassesEObjetos();
            // int opcao = Convert.ToInt32(Console.ReadLine());
            // switch (opcao)
            // {
            //     case 1:
                    Console.WriteLine("Classes e Objetos:");
                    classes_e_objetos.Executar();
                    // break;
            // }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program : Human
    {

        static void Main(string[] args)
        {
             

        }

    }

    
}

public class Human
{
    public virtual void Mensagem()
    {
        Console.WriteLine("teste");
    }

    public static void estatico()
    {

    }

}




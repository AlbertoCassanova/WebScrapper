using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebScrapper
{
    public class IO
    {
        public IO()
        {
            Console.WriteLine("Iniciando el prograna...");
        }
        public List<string> Input()
        {
            Console.WriteLine("Introduzca el nombre del archivo a procesar: ");
            var input = Console.ReadLine();
            using (var reader = new StreamReader(input))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
                return listA;

            }
        }
    }
}

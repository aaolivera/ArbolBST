using ArbolBST.Arbol;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ArbolBST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Leyendo datos a insertar...");
            var data = File.ReadAllText("input20000.txt").Split(',').Select(x => int.Parse(x));
            Console.WriteLine($"Datos leidos: {data.Count()}");
            Console.WriteLine($"----------------------------");
            Console.WriteLine($"Generando arbol...");

            var arbol = new Arbol<int>();
            foreach (var number in data)
            {
                arbol.Insertar(number);
            }
            Console.WriteLine($"Datos insertados: {arbol.Cantidad}, repetidos: {data.Count() - arbol.Cantidad}, altura: {arbol.Altura()}");

            Console.WriteLine($"----------------------------");
            Existe(arbol, 10);
            Existe(arbol, 4000000);
            Existe(arbol, 445490);
        }

        private static void Existe(Arbol<int> arbol, int dato)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine($"Buscando \"{dato}\": {arbol.Existe(dato)} en {sw.Elapsed.TotalMilliseconds}ms, nodos recorridos: {arbol.RecorridosEnUltimaBusqueda}");
            sw.Stop();
        }
    }
}

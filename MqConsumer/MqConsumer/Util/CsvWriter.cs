using MqConsumer.Models;
using System;
using System.IO;

namespace MqConsumer.Repositorio
{
    public static class CsvWriter
    {
        private const string path = @"C:\Comportamentos.csv";

        public static void Add(Comportamento comportamento)
        {
            if (!File.Exists(path))
            {
                string header = $"IP,NomePagina,Browser,Parametros";

                File.WriteAllText(path, header);
            }

            File.AppendAllText(path, Environment.NewLine + comportamento.ToString());
        }
    }
}

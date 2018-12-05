using System;
using System.Threading.Tasks;

namespace RWQPredictor
{
    class Program
    {
        private static string TrainDataPath = "winequality-red.csv";
        private static string TestDataPath = "winequality_test.csv";
        private static string ModelPath = "MLModels/WineClassificationModel.zip";
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
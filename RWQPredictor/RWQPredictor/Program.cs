using System;
using System.Threading.Tasks;
using Microsoft.ML;

namespace RWQPredictor
{
    class Program
    {
        private static string TrainDataPath = "winequality-red.csv";
        private static string TestDataPath = "winequality_test.csv";
        private static string ModelPath = "MLModels/WineClassificationModel.zip";
        
        static async Task Main(string[] args)
        {
            try
            {
                // Create MLContext to be shared across the model creation workflow objects 
                // Set a random seed for repeatable/deterministic results across multiple trainings.
                var mlContext = new MLContext(DateTime.Now.Millisecond);

                // Read data, create model and save it
                BuildTrainEvaluateAndSaveModel(mlContext);

                // Test prediction
                TestSomePredictions(mlContext);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void TestSomePredictions(MLContext mlContext)
        {
            var modelScorer = new Common.ModelScorer<WineData, WinePrediction>(mlContext);
            modelScorer.LoadModelFromZipFile(ModelPath);

            var prediction = modelScorer.PredictSingle(WineDataExamples.Test1);
            Console.WriteLine($"Expected: 6");
            for (int i = 0; i < prediction.Score.Length; i++)
                Console.WriteLine($"{i}:  {prediction.Score[i]:0.####}");
            
            prediction = modelScorer.PredictSingle(WineDataExamples.Test2);
            Console.WriteLine($"Expected: 5");
            for (int i = 0; i < prediction.Score.Length; i++)
                Console.WriteLine($"{i}:  {prediction.Score[i]:0.####}");
        }

        private static void BuildTrainEvaluateAndSaveModel(MLContext mlContext)
        {
             // Loading configuration
            var textLoader = WineLoaderFactory.CreateTextLoader(mlContext);
            var trainingDataView = textLoader.Read(TrainDataPath);
            var testDataView = textLoader.Read(TestDataPath);

            // Create pipeline
            var dataProcessPipeline = mlContext.Transforms.Concatenate("Features", "FixedAcidity",
                                                                                   "VolatileAcidity",
                                                                                   "CitricAcidity",
                                                                                   "ResidualSugar" ,
                                                                                   "Chlorides" ,
                                                                                   "FreeSulfuDioxide" ,
                                                                                   "TotalSulfuDioxide" ,
                                                                                   "Density" ,
                                                                                   "Ph",
                                                                                   "Sulphates" ,
                                                                                   "Alcohol" );

            //  Set the training algorithm                        
            var modelBuilder = new Common.ModelBuilder<WineData, WinePrediction>(mlContext, dataProcessPipeline);
            var trainer = mlContext.MulticlassClassification.Trainers.StochasticDualCoordinateAscent(labelColumn: "Label", featureColumn: "Features");
            modelBuilder.AddTrainer(trainer);

            // Train the model fitting to the DataSet
            Console.WriteLine("=============== Training the model ===============");
            modelBuilder.Train(trainingDataView);

            // Evaluate the model and show accuracy stats
            Console.WriteLine("===== Evaluating Model's accuracy with Test data =====");
            var metrics = modelBuilder.EvaluateMultiClassClassificationModel(testDataView, "Label");
            Common.ConsoleHelper.PrintMultiClassClassificationMetrics(trainer.ToString(), metrics);

            // STEP 6: Save/persist the trained model to a .ZIP file
            Console.WriteLine("=============== Saving the model to a file ===============");
            modelBuilder.SaveModelAsFile(ModelPath);
        }
    }
}
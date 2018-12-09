using Microsoft.ML;
using Microsoft.ML.Runtime.Data;

namespace RWQPredictor
{
    public class WineLoaderFactory
    {
        public static TextLoader CreateTextLoader(MLContext mlContext)
        {
            return  mlContext.Data.TextReader(new TextLoader.Arguments()
            {
                Separator = ";",
                HasHeader = true,
                Column = new[]
                {
                    new TextLoader.Column("FixedAcidity", DataKind.R4, 0),
                    new TextLoader.Column("VolatileAcidity", DataKind.R4, 1),
                    new TextLoader.Column("CitricAcidity", DataKind.R4, 2),
                    new TextLoader.Column("ResidualSugar", DataKind.R4, 3),
                    new TextLoader.Column("Chlorides", DataKind.R4, 4),
                    new TextLoader.Column("FreeSulfuDioxide", DataKind.R4, 5),
                    new TextLoader.Column("TotalSulfuDioxide", DataKind.R4, 6),
                    new TextLoader.Column("Density", DataKind.R4, 7),
                    new TextLoader.Column("Ph", DataKind.R4, 8),
                    new TextLoader.Column("Sulphates", DataKind.R4, 9),
                    new TextLoader.Column("Alcohol", DataKind.R4, 10),
                    
                    new TextLoader.Column("Label", DataKind.R4, 11),

                }
            });
        }
    }
}
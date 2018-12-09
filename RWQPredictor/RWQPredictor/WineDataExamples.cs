namespace RWQPredictor
{
    public class WineDataExamples
    {
        public static WineData Test1 => new WineData()
        {
            FixedAcidity = 6.6f,
            VolatileAcidity = 0.5f,
            CitricAcidity = 0.01f,
            ResidualSugar = 1.5f,
            Chlorides = 0.06f,
            FreeSulfuDioxide = 17,
            TotalSulfuDioxide = 26,
            Density = 0.9952f,
            Ph = 3.4f,
            Sulphates = 0.58f,
            Alcohol = 9.8f
        };
        
        public static WineData Test2 => new WineData()
        {
            FixedAcidity = 7.6f,
            VolatileAcidity = 0.49f,
            CitricAcidity = 0.33f,
            ResidualSugar = 1.9f,
            Chlorides = 0.074f,
            FreeSulfuDioxide = 27,
            TotalSulfuDioxide = 85,
            Density = 0.99706f,
            Ph = 3.41f,
            Sulphates = 0.58f,
            Alcohol = 9f
        };
        
    }
}
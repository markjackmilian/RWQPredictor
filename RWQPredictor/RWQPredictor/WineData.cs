namespace RWQPredictor
{
    public class WineData
    {
        public float FixedAcidity { get; set; }
        public float VolatileAcidity { get; set; }
        public float CitricAcidity { get; set; }
        public float ResidualSugar { get; set; }
        public float Chlorides { get; set; }
        public float FreeSulfuDioxide { get; set; }
        public float TotalSulfuDioxide { get; set; }
        public float Density { get; set; }
        public float Ph { get; set; }
        public float Sulphates { get; set; }
        public float Alcohol { get; set; }
    }

    public class WinePrediction
    {
        public float[] Score { get; set; }
    }
}
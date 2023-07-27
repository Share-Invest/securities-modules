using Microsoft.ML.Data;

namespace ShareInvest.ML.Entities;

public class HalfYearPrediction : HalfYearData
{
    [ColumnName("PredictedLabel")]
    public bool Prediction
    {
        get; set;
    }
    public float Probability
    {
        get; set;
    }
    public float Score
    {
        get; set;
    }
}
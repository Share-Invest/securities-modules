using Microsoft.ML.Data;

namespace ShareInvest.Models;

public class OutputPrediction
{
    [ColumnName("PredictedLabel")]
    public bool Prediction
    {
        get; set;
    }
    public double Probability
    {
        get; set;
    }
    public double Score
    {
        get; set;
    }
}
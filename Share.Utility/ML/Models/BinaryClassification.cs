using Microsoft.ML;
using Microsoft.ML.Trainers;

using Newtonsoft.Json;

using ShareInvest.ML.Entities;
using ShareInvest.Properties;

namespace ShareInvest.ML;

public class BinaryClassification
{
    public HalfYearPrediction Prediction(ITransformer model, HalfYearData data)
    {
        var engine = context.Model.CreatePredictionEngine<HalfYearData, HalfYearPrediction>(model);

        return engine.Predict(data);
    }
    public string Evaluate(ITransformer model, IDataView testSet)
    {
        var predictions = model.Transform(testSet);

        var metrics = context.BinaryClassification.Evaluate(predictions, labelColumnName: Resources.LABEL);

        Console.WriteLine(JsonConvert.SerializeObject(metrics, Formatting.Indented));

        return JsonConvert.SerializeObject(new
        {
            metrics.Accuracy,
            metrics.AreaUnderRocCurve,
            metrics.AreaUnderPrecisionRecallCurve,
            metrics.F1Score,
            metrics.Entropy,
            metrics.LogLoss,
            metrics.LogLossReduction,
            metrics.PositivePrecision,
            metrics.PositiveRecall,
            metrics.NegativePrecision,
            metrics.NegativeRecall
        });
    }
    public (ITransformer, IDataView) Learning(IEnumerable<HalfYearData> enumerable)
    {
        IDataView dataView = context.Data.LoadFromEnumerable(enumerable);

        var estimator = context.Transforms.Concatenate(Resources.FEATURE, nameof(HalfYearData.ClosePrices),
                                                                          nameof(HalfYearData.HighPrices),
                                                                          nameof(HalfYearData.LowPrices),
                                                                          nameof(HalfYearData.OpenPrices),
                                                                          nameof(HalfYearData.Volumes));

        var splitDataView = context.Data.TrainTestSplit(dataView, testFraction: 0.2);

        var pipeline = estimator.Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(options));

        return (pipeline.Fit(splitDataView.TrainSet), splitDataView.TestSet);
    }
    public BinaryClassification(int? seed = null, int? gpuDeviceId = null)
    {
        options = new SdcaLogisticRegressionBinaryTrainer.Options
        {
            MaximumNumberOfIterations =
#if DEBUG
                                        default
#else
                                        0x800
#endif
                                        ,
            LabelColumnName = Resources.LABEL,
            FeatureColumnName = Resources.FEATURE
        };
        context = seed != null ? new MLContext(seed) : new MLContext();

        context.GpuDeviceId = gpuDeviceId;
    }
    readonly SdcaLogisticRegressionBinaryTrainer.Options options;
    readonly MLContext context;
}
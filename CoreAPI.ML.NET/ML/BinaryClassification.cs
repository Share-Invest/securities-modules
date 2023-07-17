using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;

using Newtonsoft.Json;

using ShareInvest.Models;

namespace ShareInvest.ML;

public class BinaryClassification
{
    public IDataView Learning(IEnumerable<InputConditionData> enumerable)
    {
        IDataView dataView =

            context.Data.LoadFromEnumerable(enumerable);

        var estimator = context.Transforms.Conversion.ConvertType(nameof(InputConditionData.ClosePrices), outputKind: DataKind.Single)

            .Append(context.Transforms.Conversion.ConvertType(nameof(InputConditionData.HighPrices), outputKind: DataKind.Single))
            .Append(context.Transforms.Conversion.ConvertType(nameof(InputConditionData.LowPrices), outputKind: DataKind.Single))
            .Append(context.Transforms.Conversion.ConvertType(nameof(InputConditionData.OpenPrices), outputKind: DataKind.Single))
            .Append(context.Transforms.Conversion.ConvertType(nameof(InputConditionData.Volumes), outputKind: DataKind.Single))
            .Append(context.Transforms.Conversion.ConvertType(nameof(InputConditionData.DateTimes), outputKind: DataKind.Single))
            .Append(context.Transforms.Concatenate("Features", nameof(InputConditionData.ClosePrices),
                                                               nameof(InputConditionData.HighPrices),
                                                               nameof(InputConditionData.LowPrices),
                                                               nameof(InputConditionData.OpenPrices),
                                                               nameof(InputConditionData.Volumes),
                                                               nameof(InputConditionData.DateTimes)));

        var splitDataView = context.Data.TrainTestSplit(dataView);

        var pipeline =

            estimator.Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(new SdcaLogisticRegressionBinaryTrainer.Options
            {
                LabelColumnName = "Label",
                FeatureColumnName = "Features",
                MaximumNumberOfIterations = 0x400
            }));

        ITransformer model = pipeline.Fit(splitDataView.TrainSet);

        return model.Transform(splitDataView.TestSet);
    }
    public void Evaluate(IDataView predictions)
    {
        CalibratedBinaryClassificationMetrics metrics = context.BinaryClassification.Evaluate(predictions, labelColumnName: "Label");

        Console.WriteLine(JsonConvert.SerializeObject(metrics, Formatting.Indented));
    }
    public BinaryClassification(int? seed = null, int? gpuDeviceId = 0)
    {
        context = seed != null ? new MLContext(seed) : new MLContext();

        context.GpuDeviceId = gpuDeviceId;
    }
    readonly MLContext context;
}
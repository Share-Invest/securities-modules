using ShareInvest.ML.Entities;

namespace ShareInvest.ML;

public class DataPreprocessing
{
    public IEnumerable<(string, HalfYearData)> StartTestSetProcess()
    {
        for (int y = 0; y < 5; y++)
        {
            var inputCharts = new InputStockChart[124];

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i > list.Count - 125)
                {
                    inputCharts[inputCharts.Length - list.Count + i] = list[i - y];

                    continue;
                }
                break;
            }
            int maxPrice = inputCharts.Max(s => s.High), minPrice = inputCharts.Min(s => s.Low);
            long maxVolume = inputCharts.Max(s => s.Volume), minVolume = inputCharts.Min(s => s.Volume);
            string? maxDateTime = inputCharts.Max(s => s.DateTime);

            if (inputCharts[^1].Volume == 0 || string.IsNullOrEmpty(maxDateTime) ||
                maxPrice == minPrice && maxPrice == 0 || maxVolume == minVolume && maxVolume == 0)
            {
                continue;
            }
            var conditionData = new HalfYearData
            {
                Satisfy = false,
                HighPrices = new float[inputCharts.Length],
                OpenPrices = new float[inputCharts.Length],
                LowPrices = new float[inputCharts.Length],
                ClosePrices = new float[inputCharts.Length],
                Volumes = new float[inputCharts.Length]
            };
            Normalization np = new(maxPrice, (double)minPrice), nv = new(maxVolume, (double)minVolume);

            for (int i = 0; i < inputCharts.Length; i++)
            {
                conditionData.ClosePrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].Current));
                conditionData.LowPrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].Low));
                conditionData.HighPrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].High));
                conditionData.OpenPrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].Start));
                conditionData.Volumes[i] = Convert.ToSingle(nv.Normalize(inputCharts[i].Volume));
            }
            yield return (maxDateTime, conditionData);
        }
    }
    public IEnumerable<HalfYearData> StartTrainSetProcess()
    {
        while (list.Count > 125)
        {
            InputStockChart? forecastedChart = null;

            var inputCharts = new InputStockChart[124];

            for (int i = list.Count - 2; i >= 0; i--)
            {
                if (i >= list.Count - 125)
                {
                    inputCharts[inputCharts.Length - list.Count + i + 1] = list[i];

                    continue;
                }
                forecastedChart = list[^1];

                break;
            }
            int maxPrice = inputCharts.Max(s => s.High), minPrice = inputCharts.Min(s => s.Low);
            long maxVolume = inputCharts.Max(s => s.Volume), minVolume = inputCharts.Min(s => s.Volume);

            list.RemoveAt(list.Count - 1);

            if (inputCharts[^1].Volume == 0 || maxPrice == minPrice && maxPrice == 0 || maxVolume == minVolume && maxVolume == 0)
            {
                continue;
            }
            var conditionData = new HalfYearData
            {
                Satisfy = forecastedChart != null && IsSatisfied(forecastedChart, inputCharts[^1]),
                HighPrices = new float[inputCharts.Length],
                OpenPrices = new float[inputCharts.Length],
                LowPrices = new float[inputCharts.Length],
                ClosePrices = new float[inputCharts.Length],
                Volumes = new float[inputCharts.Length]
            };
            Normalization np = new(maxPrice, (double)minPrice), nv = new(maxVolume, (double)minVolume);

            for (int i = 0; i < inputCharts.Length; i++)
            {
                conditionData.ClosePrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].Current));
                conditionData.LowPrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].Low));
                conditionData.HighPrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].High));
                conditionData.OpenPrices[i] = Convert.ToSingle(np.Normalize(inputCharts[i].Start));
                conditionData.Volumes[i] = Convert.ToSingle(nv.Normalize(inputCharts[i].Volume));
            }
            yield return conditionData;
        }
    }
    public DataPreprocessing(List<InputStockChart> list, double riseRate = 1.15)
    {
        this.list = list;
        this.riseRate = riseRate;
    }
    bool IsSatisfied(InputStockChart forecastedChart, InputStockChart inputChart)
    {
        return forecastedChart.Current > inputChart.Current * riseRate;
    }
    readonly List<InputStockChart> list;
    readonly double riseRate;
}
using ShareInvest.OpenAPI.Entity;

using Skender.Stock.Indicators;

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace ShareInvest;

public static class Cache
{
    public static MarketOperation MarketOperation
    {
        get; set;
    }
    public static int RemainingWorkCount
    {
        get => queueWorker.Count;
    }
    public static long Epoch
    {
        get => 621_355_968_000_000_000;
    }
    public static string? CompanyName
    {
        get
        {
            var location = Assembly.GetExecutingAssembly().Location;

            return FileVersionInfo.GetVersionInfo(location).CompanyName;
        }
    }
    public static IEnumerable<KeyValuePair<string, ConcurrentQueue<string>>> GetTempStorageEnumerator()
    {
        foreach (var kv in tempStorage)
        {
            yield return kv;
        }
    }
    public static (bool tryDequeue, object? task) GetTasksFromQueue()
    {
        var tryDequeue = queueWorker.TryDequeue(out object? task);

        return (tryDequeue, task);
    }
    public static (bool tryDequeue, (string code, string data)) GetTasksFromFuturesQueue()
    {
        var tryDequeue = futuresQueueWorker.TryDequeue(out var task);

        return (tryDequeue, task);
    }
    public static string[] GetConclusion(string code)
    {
        return stocksConclusion.TryGetValue(code, out string? value) ? value.Split('\t') : Array.Empty<string>();
    }
    public static string[] GetStockQuote(string code)
    {
        return stockQuotes.TryGetValue(code, out string? value) ? value.Split('\t') : Array.Empty<string>();
    }
    public static ConcurrentStack<Quote>? GetFuturesData(string code)
    {
        return futuresRealTypeData.TryGetValue(code, out var quotes) ? quotes : null;
    }
    public static Entities.Indicators? GetIndicators(string code)
    {
        return indicators.TryGetValue(code, out var value) ? value : null;
    }
    public static void SetTempStorage(string code, string data)
    {
        if (tempStorage.TryGetValue(code, out ConcurrentQueue<string>? queue))
        {
            queue.Enqueue(data);

            return;
        }
        tempStorage[code] = new ConcurrentQueue<string>(new[] { data });
    }
    public static IEnumerable<Entities.StockTheme> SetStockTheme(Entities.StockTheme e)
    {
        if (string.IsNullOrEmpty(e.ThemeCode) is false)
        {
            stockTheme[e.ThemeCode] = e;
        }
        if (stockTheme.Count <= 0x100)
        {
            return Enumerable.Empty<Entities.StockTheme>();
        }
        var stocks = from st in stockTheme
                     orderby Convert.ToDouble(st.Value.RateCompareToPreviousDay) descending
                     select st.Value;

        return stocks.Take(3);
    }
    public static void SetTasksInQueue<T>(T task) where T : class
    {
        if (task != null)
        {
            queueWorker.Enqueue(task);
        }
    }
    public static void SetFuturesConclusion(string code, string data)
    {
        futuresQueueWorker.Enqueue((code, data));

        futuresConclusion[code] = data;
    }
    public static void SetFuturesTheoreticalPrice(string code, string data)
    {
        futuresQueueWorker.Enqueue((code, data));
    }
    public static void SetConclusion(string code, string data)
    {
        stocksConclusion[code] = data;
    }
    public static void SetFuturesQuote(string code, string data)
    {
        futuresQueueWorker.Enqueue((code, data));

        futuresQuotes[code] = data;
    }
    public static void SetStockQuote(string code, string data)
    {
        stockQuotes[code] = data;
    }
    public static void SetIndicators(string code, IEnumerable<MacdResult> indicator)
    {
        indicators[code].Macd = indicator;
    }
    public static void SetIndicators(string code, IEnumerable<SuperTrendResult> indicator)
    {
        indicators[code].SuperTrend = indicator;
    }
    public static void SetIndicators(string code, IEnumerable<SlopeResult> indicator)
    {
        indicators[code].Slope = indicator;
    }
    public static void SetIndicators(string code, IEnumerable<AtrStopResult> indicator)
    {
        indicators[code].AtrStop = indicator;
    }
    public static bool InitializedFuturesQuotes(string code)
    {
        if (futuresRealTypeData.TryGetValue(code, out var quotes) && quotes.IsEmpty is false)
        {
            var carryForwardQuotes = quotes.OrderByDescending(ks => ks.Date).Take(0x400);

            InitializedFuturesQuotes(code, carryForwardQuotes);
        }
        return quotes == null || quotes.IsEmpty;
    }
    public static void InitializedFuturesQuotes(string code, IEnumerable<Quote> quotes)
    {
        if (indicators.TryGetValue(code, out var value))
        {
            value.Macd = quotes.GetMacd().Condense().RemoveWarmupPeriods();
            value.Slope = quotes.GetSlope(14).Condense().RemoveWarmupPeriods();
            value.SuperTrend = quotes.GetSuperTrend().Condense().RemoveWarmupPeriods();
            value.AtrStop = quotes.GetAtrStop().Condense().RemoveWarmupPeriods();
        }
        else
        {
            indicators[code] = new Entities.Indicators
            {
                AtrStop = quotes.GetAtrStop().Condense().RemoveWarmupPeriods(),
                Macd = quotes.GetMacd().Condense().RemoveWarmupPeriods(),
                Slope = quotes.GetSlope(14).Condense().RemoveWarmupPeriods(),
                SuperTrend = quotes.GetSuperTrend().Condense().RemoveWarmupPeriods()
            };
        }
        futuresRealTypeData[code] = new ConcurrentStack<Quote>(quotes.OrderBy(ks => ks.Date));
    }
    public static void SaveTemporarily(string sScrNo, TR constructor)
    {
        stores[sScrNo] = constructor;
    }
    public static TR? GetConstructor(string sTrCode, string sScrNo)
    {
        if (stores.Remove(sScrNo, out TR? constructor))
        {
            return constructor;
        }
        var typeName = string.Concat(typeof(TR).Namespace, '.', sTrCode);

        return TrConstructor.Assembly.CreateInstance(typeName, true) as TR;
    }
    public static Dictionary<int, string> Error => new()
    {
        {
            0,
            "정상처리"
        },
        {
            -1,
            "미접속상태"
        },
        {
            -10,
            "실패"
        },
        {
            -11,
            "조건번호 없음"
        },
        {
            -12,
            "조건번호와 조건식 불일치"
        },
        {
            -13,
            "조건검색 조회요청 초과"
        },
        {
            -22,
            "전문 처리 실패"
        },
        {
            -0x64,
            "사용자정보교환 실패"
        },
        {
            -101,
            "서버 접속 실패"
        },
        {
            -102,
            "버전처리 실패"
        },
        {
            -103,
            "개인방화벽 실패"
        },
        {
            -104,
            "메모리 보호실패"
        },
        {
            -105,
            "함수입력값 오류"
        },
        {
            -0x6A,
            "통신연결 종료"
        },
        {
            -107,
            "보안모듈 오류"
        },
        {
            -108,
            "공인인증 로그인 필요"
        },
        {
            -0xC8,
            "시세조회 과부하"
        },
        {
            -201,
            "전문작성 초기화 실패"
        },
        {
            -0xCA,
            "전문작성 입력값 오류"
        },
        {
            -203,
            "데이터 없음"
        },
        {
            -204,
            "조회가능한 종목수 초과.(한번에 조회 가능한 종목개수는 최대 100종목)"
        },
        {
            -205,
            "데이터 수신 실패"
        },
        {
            -206,
            "조회가능한 FID수 초과.(한번에 조회 가능한 FID개수는 최대 100개)"
        },
        {
            -207,
            "실시간 해제오류"
        },
        {
            -209,
            "시세조회 제한"
        },
        {
            -0xD3,
            "시세조회 과부하"
        },
        {
            -300,
            "입력값 오류"
        },
        {
            -301,
            "계좌비밀번호 없음"
        },
        {
            -302,
            "타인계좌 사용오류"
        },
        {
            -303,
            "주문가격이 주문착오 금액기준 초과."
        },
        {
            -304,
            "주문가격이 주문착오 금액기준 초과."
        },
        {
            -305,
            "주문수량이 총발행주수의 1% 초과오류"
        },
        {
            -306,
            "주문수량은 총발행주수의 3% 초과오류"
        },
        {
            -307,
            "주문전송 실패"
        },
        {
            -308,
            "주문전송 과부하"
        },
        {
            -309,
            "주문수량 300계약 초과"
        },
        {
            -310,
            "주문수량 500계약 초과"
        },
        {
            -311,
            "주문전송제한 과부하"
        },
        {
            -340,
            "계좌정보 없음"
        },
        {
            -500,
            "종목코드 없음"
        }
    };
    static readonly ConcurrentQueue<(string code, string data)> futuresQueueWorker = new();
    static readonly ConcurrentQueue<object> queueWorker = new();
    static readonly ConcurrentDictionary<string, Entities.StockTheme> stockTheme = new();
    static readonly ConcurrentDictionary<string, TR> stores = new();
    static readonly ConcurrentDictionary<string, string> stockQuotes = new();
    static readonly ConcurrentDictionary<string, string> stocksConclusion = new();
    static readonly ConcurrentDictionary<string, string> futuresConclusion = new();
    static readonly ConcurrentDictionary<string, string> futuresQuotes = new();
    static readonly ConcurrentDictionary<string, ConcurrentStack<Quote>> futuresRealTypeData = new();
    static readonly ConcurrentDictionary<string, ConcurrentQueue<string>> tempStorage = new();
    static readonly ConcurrentDictionary<string, Entities.Indicators> indicators = new();
}
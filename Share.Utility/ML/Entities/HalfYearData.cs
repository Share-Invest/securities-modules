﻿using Microsoft.ML.Data;

namespace ShareInvest.ML.Entities;

public class HalfYearData
{
    [LoadColumn(1), VectorType(124)]
    public float[]? OpenPrices
    {
        get; set;
    }
    [LoadColumn(2), VectorType(124)]
    public float[]? HighPrices
    {
        get; set;
    }
    [LoadColumn(3), VectorType(124)]
    public float[]? LowPrices
    {
        get; set;
    }
    [LoadColumn(4), VectorType(124)]
    public float[]? ClosePrices
    {
        get; set;
    }
    [LoadColumn(5), VectorType(124)]
    public float[]? Volumes
    {
        get; set;
    }
    [LoadColumn(6), ColumnName("Label")]
    public bool Satisfy
    {
        get; set;
    }
}
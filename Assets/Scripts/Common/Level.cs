using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int Number { get; set; }

    public int TappedsToReach { get; set; }

    public float BetweenInstantiateTimeMin { get; set; }
    public float BetweenInstantiateTimeMax { get; set; }

    public float MaxSizeCircle { get; set; }

    public float MinSizeCircle { get; set; }

    public float SizeChangeInSecondCircle { get; set; }

    //public int MaxCirclesAtSameTime { get; set; }

    public int ChanceCoinInCirclePercent { get; set; }
    public int CountCoinsInCircle { get; set; }
    public int ChanceCoinOnFieldPercent { get; set; }
    public int MaxCoinsCountOnField { get; set; }
    public float CoinTimeOfLife { get; set; }
    public int ChanceToBadCircle { get; set; }
    public int ChanceToGoodCircle { get; set; }

    public override string ToString()
    {
        return Number.ToString();
    }
}

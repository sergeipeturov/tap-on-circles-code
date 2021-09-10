using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LevelsManager
{
    //максиум для MaxSizeCircle = 0,4 (самый большой)
    //минимум для SizeChangeInSecondCircle = 0,05 (самый медленный)

    private static List<Level> levels = new List<Level>()
    {
        new Level()
        {
            Number = 1,
            BetweenInstantiateTimeMax = 1f,
            BetweenInstantiateTimeMin = 0.5f,
            MaxSizeCircle = 0.4f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.05f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 0,
            ChanceCoinInCirclePercent = 0,
            MaxCoinsCountOnField = 0,
            ChanceCoinOnFieldPercent = 0,
            CoinTimeOfLife = 0.0f,
            ChanceToBadCircle = -30,
            ChanceToGoodCircle = -30,
            TappedsToReach = Random.Range(30, 35)
        },
        new Level()
        {
            Number = 2,
            BetweenInstantiateTimeMax = 0.9f,
            BetweenInstantiateTimeMin = 0.5f,
            MaxSizeCircle = 0.4f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.05f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 0,
            ChanceCoinInCirclePercent = 0,
            MaxCoinsCountOnField = 0,
            ChanceCoinOnFieldPercent = 1,
            CoinTimeOfLife = -0.5f,
            ChanceToBadCircle = 0,
            ChanceToGoodCircle = 0,
            TappedsToReach = Random.Range(50, 55)
        },
        new Level()
        {
            Number = 3,
            BetweenInstantiateTimeMax = 0.8f,
            BetweenInstantiateTimeMin = 0.5f,
            MaxSizeCircle = 0.4f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.05f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 0,
            ChanceCoinInCirclePercent = 1,
            MaxCoinsCountOnField = 0,
            ChanceCoinOnFieldPercent = 2,
            CoinTimeOfLife = -1.0f,
            ChanceToBadCircle = 0,
            ChanceToGoodCircle = 5,
            TappedsToReach = Random.Range(97, 103)
        },
        new Level()
        {
            Number = 4,
            BetweenInstantiateTimeMax = 0.8f,
            BetweenInstantiateTimeMin = 0.4f,
            MaxSizeCircle = 0.4f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.05f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 1,
            ChanceCoinInCirclePercent = 2,
            MaxCoinsCountOnField = 1,
            ChanceCoinOnFieldPercent = 3,
            CoinTimeOfLife = -1.5f,
            ChanceToBadCircle = 0,
            ChanceToGoodCircle = 5,
            TappedsToReach = Random.Range(197, 203)
        },
        new Level()
        {
            Number = 5,
            BetweenInstantiateTimeMax = 0.7f,
            BetweenInstantiateTimeMin = 0.4f,
            MaxSizeCircle = 0.35f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.05f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 2,
            ChanceCoinInCirclePercent = 3,
            MaxCoinsCountOnField = 2,
            ChanceCoinOnFieldPercent = 4,
            CoinTimeOfLife = -2.0f,
            ChanceToBadCircle = 0,
            ChanceToGoodCircle = 10,
            TappedsToReach = Random.Range(497, 503)
        },
        new Level()
        {
            Number = 6,
            BetweenInstantiateTimeMax = 0.7f,
            BetweenInstantiateTimeMin = 0.3f,
            MaxSizeCircle = 0.3f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.05f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 3,
            ChanceCoinInCirclePercent = 4,
            MaxCoinsCountOnField = 2,
            ChanceCoinOnFieldPercent = 5,
            CoinTimeOfLife = -2.5f,
            ChanceToBadCircle = 0,
            ChanceToGoodCircle = 10,
            TappedsToReach = Random.Range(997, 1003)
        },
        new Level()
        {
            Number = 7,
            BetweenInstantiateTimeMax = 0.6f,
            BetweenInstantiateTimeMin = 0.3f,
            MaxSizeCircle = 0.3f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.06f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 3,
            ChanceCoinInCirclePercent = 5,
            MaxCoinsCountOnField = 2,
            ChanceCoinOnFieldPercent = 6,
            CoinTimeOfLife = -3.0f,
            ChanceToBadCircle = 5,
            ChanceToGoodCircle = 15,
            TappedsToReach = Random.Range(1497, 1503)
        },
        new Level()
        {
            Number = 8,
            BetweenInstantiateTimeMax = 0.6f,
            BetweenInstantiateTimeMin = 0.2f,
            MaxSizeCircle = 0.3f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.06f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 4,
            ChanceCoinInCirclePercent = 6,
            MaxCoinsCountOnField = 3,
            ChanceCoinOnFieldPercent = 7,
            CoinTimeOfLife = -3.5f,
            ChanceToBadCircle = 5,
            ChanceToGoodCircle = 15,
            TappedsToReach = Random.Range(1997, 2003)
        },
        new Level()
        {
            Number = 9,
            BetweenInstantiateTimeMax = 0.5f,
            BetweenInstantiateTimeMin = 0.2f,
            MaxSizeCircle = 0.3f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.07f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 4,
            ChanceCoinInCirclePercent = 7,
            MaxCoinsCountOnField = 3,
            ChanceCoinOnFieldPercent = 8,
            CoinTimeOfLife = -4.0f,
            ChanceToBadCircle = 10,
            ChanceToGoodCircle = 20,
            TappedsToReach = Random.Range(3497, 3503)
        },
        new Level()
        {
            Number = 10,
            BetweenInstantiateTimeMax = 0.5f,
            BetweenInstantiateTimeMin = 0.1f,
            MaxSizeCircle = 0.3f,
            MinSizeCircle = 0.15f,
            SizeChangeInSecondCircle = 0.07f,
            //MaxCirclesAtSameTime = 1,
            CountCoinsInCircle = 5,
            ChanceCoinInCirclePercent = 10,
            MaxCoinsCountOnField = 3,
            ChanceCoinOnFieldPercent = 10,
            CoinTimeOfLife = -4.5f,
            ChanceToBadCircle = 10,
            ChanceToGoodCircle = 20,
            TappedsToReach = int.MaxValue
        }
    };

    public static Level CurrentLevel { get { return currentLevel < levels.Count ? levels.FirstOrDefault(x => x.Number == currentLevel) : levels.Last(); } }

    public static Level GoNext()
    {
        currentLevel += 1;
        return CurrentLevel;
    }

    public static Level StartGame()
    {
        currentLevel = 1;
        return CurrentLevel;
    }

    private static int currentLevel;
}

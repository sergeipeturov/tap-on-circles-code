using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer
{
    public static int GetTapCostInCoins(int maxCoinsCount, int chanseInPercent)
    {
        bool[] chanseArray = new bool[100];
        for (int i = 0; i < chanseArray.Length; i++)
        {
            chanseArray[i] = false;
        }
        for (int i = 0; i < chanseInPercent; i++)
        {
            chanseArray[i] = true;
        }
        int res = 0;
        for (int i = 0; i < maxCoinsCount; i++)
        {
            if (chanseArray[Mathf.FloorToInt(Random.Range(0, chanseArray.Length))])
                    res++;
        }
        return res;
    }

    public static bool GetResultByChanse(int chanseInPercent)
    {
        bool[] chanseArray = new bool[100];
        for (int i = 0; i < chanseArray.Length; i++)
        {
            chanseArray[i] = false;
        }
        for (int i = 0; i < chanseInPercent; i++)
        {
            chanseArray[i] = true;
        }
        return chanseArray[Mathf.FloorToInt(Random.Range(0, chanseArray.Length))];
    }

    public static List<int> GetArrayOfRandomOrders(int maxOrder)
    {
        List<int> orders = new List<int>();
        List<int> ordersAll = new List<int>();
        for (int i = 1; i <= maxOrder; i++)
        {
            ordersAll.Add(i);
        }
        for (int i = 0; i < maxOrder; i++)
        {
            int randomOrder = ordersAll[Mathf.FloorToInt(Random.Range(0, ordersAll.Count))];
            orders.Add(randomOrder);
            ordersAll.Remove(randomOrder);
        }
        return orders;
    }
}

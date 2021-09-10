using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemModel
{
    public string Name { get; set; }
    public string DescriptionKey { get; set; }
    public int[] Costs { get; set; }
    public float[] Values { get; set; }
    public int CurrentLevel { get; set; } //0 - 5
    public int CurrentCost { get { if (CurrentLevel < 5) return Costs[CurrentLevel]; else return 0; } }

    public int GetCurrentValueInt()
    {
        if (CurrentLevel < 6) return (int)Values[CurrentLevel]; else return 0;
    }

    public float GetCurrentValueFloat()
    {
        if (CurrentLevel < 6) return Values[CurrentLevel]; else return 0;
    }

    public ShopItemModelJson ToShopItemModelJson()
    {
        var shopItemModelJson = new ShopItemModelJson()
        {
            Costs = new List<int>(Costs),
            Values = new List<float>(Values),
            Name = Name,
            DescriptionKey = DescriptionKey,
            CurrentLevel = CurrentLevel
        };
        return shopItemModelJson;
    }

    public void FromShopItemModelJson(ShopItemModelJson shopItemModelJson)
    {
        Costs = shopItemModelJson.Costs.ToArray();
        Values = shopItemModelJson.Values.ToArray();
        Name = shopItemModelJson.Name;
        DescriptionKey = shopItemModelJson.DescriptionKey;
        CurrentLevel = shopItemModelJson.CurrentLevel;
    }
}

[Serializable]
public class ShopItemModelJson
{
    public string Name;
    public string DescriptionKey;
    public List<int> Costs;
    public List<float> Values;
    public int CurrentLevel;
}

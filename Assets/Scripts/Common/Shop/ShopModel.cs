using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel
{
    public List<ShopItemModel> ShopItems = new List<ShopItemModel>();

    public ShopModel()
    {
        ShopItems = new List<ShopItemModel>()
        {
            new ShopItemModel()
            {
                Name = "RageCombo",
                DescriptionKey = "RageCombo",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 35, 30, 25, 20, 15, 10 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "MaxCoinOnField",
                DescriptionKey = "MaxCoinOnField",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 0, 1, 2, 3, 4, 5 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "ChanceCoinOnField",
                DescriptionKey = "ChanceCoinOnField",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 0, 1, 2, 5, 10, 15 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "TimeOfLifeCoinOnField",
                DescriptionKey = "TimeOfLifeCoinOnField",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "CoinCountInCircle",
                DescriptionKey = "CoinCountInCircle",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 0, 1, 2, 3, 5, 7 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "ChanceCoinCountInCircle",
                DescriptionKey = "ChanceCoinCountInCircle",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 0, 1, 2, 5, 10, 15 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "LossesToGameOver",
                DescriptionKey = "LossesToGameOver",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 5, 10, 15, 20, 25, 30 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "ChanceOfGoodCircle",
                DescriptionKey = "ChanceOfGoodCircle",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 5, 10, 15, 20, 25, 30 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "ChanceOfBadCircle",
                DescriptionKey = "ChanceOfBadCircle",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 30, 25, 20, 15, 10, 5 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "TapCostOfCircle",
                DescriptionKey = "TapCostOfCircle",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 1, 2, 3, 4, 5, 7 },
                CurrentLevel = 0
            },
            new ShopItemModel()
            {
                Name = "TimeOfLifeCircle",
                DescriptionKey = "TimeOfLifeCircle",
                Costs = new int[5] { 100, 250, 500, 1000, 2000 },
                Values = new float[6] { 0.0f, 0.01f, 0.02f, 0.03f, 0.04f, 0.05f },
                CurrentLevel = 0
            }
        };
    }

    public int BuyItem(string itemName, int coins)
    {
        var boughtItem = ShopItems.FirstOrDefault(x => x.Name == itemName);
        if (boughtItem != null)
        {
            coins -= boughtItem.CurrentCost;
            boughtItem.CurrentLevel++;
        }
        return coins;
    }

    public int GetIntValue(string nameOfShopItem)
    {
        var shopItem = ShopItems.FirstOrDefault(x => x.Name == nameOfShopItem);
        if (shopItem != null)
            return shopItem.GetCurrentValueInt();
        else
            return 0;
    }

    public float GetFloatValue(string nameOfShopItem)
    {
        var shopItem = ShopItems.FirstOrDefault(x => x.Name == nameOfShopItem);
        if (shopItem != null)
            return shopItem.GetCurrentValueFloat();
        else
            return 0;
    }

    public ShopModelJson ToShopModelJson()
    {
        var shopModelJson = new ShopModelJson();
        shopModelJson.ShopItems.Clear();
        foreach (var item in ShopItems)
        {
            shopModelJson.ShopItems.Add(item.ToShopItemModelJson());
        }
        return shopModelJson;
    }

    public void FromShopModelJson(ShopModelJson shopModelJson)
    {
        ShopItems.Clear();
        foreach (var item in shopModelJson.ShopItems)
        {
            var newItem = new ShopItemModel();
            newItem.FromShopItemModelJson(item);
            ShopItems.Add(newItem);
        }
    }
}

[Serializable]
public class ShopModelJson
{
    public List<ShopItemModelJson> ShopItems = new List<ShopItemModelJson>();
}

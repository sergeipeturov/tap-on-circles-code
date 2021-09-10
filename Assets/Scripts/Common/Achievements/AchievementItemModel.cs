using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementItemModel
{
    public string Name { get; set; }
    public string CurrentDescription { get { if (CurrentLevel < 2) return Descriptions[CurrentLevel]; else return Descriptions.Last(); } }
    public string[] Descriptions { get; set; }
    public int CurrentLevel { get; set; } //0 - 3
    public int BronzeReward { get; set; }
    public int SilverReward { get; set; }
    public int GoldReward { get; set; }

    public AchievementItemModelJson ToAchievementItemModelJson()
    {
        var achievementItemModelJson = new AchievementItemModelJson()
        {
            Name = Name,
            Descriptions = new List<string>(Descriptions),
            CurrentLevel = CurrentLevel,
            BronzeReward = BronzeReward,
            SilverReward = SilverReward,
            GoldReward = GoldReward
        };
        return achievementItemModelJson;
    }

    public void FromAchievementItemModelJson(AchievementItemModelJson achievementItemModelJson)
    {
        Name = achievementItemModelJson.Name;
        Descriptions = achievementItemModelJson.Descriptions.ToArray();
        CurrentLevel = achievementItemModelJson.CurrentLevel;
        BronzeReward = achievementItemModelJson.BronzeReward;
        SilverReward = achievementItemModelJson.SilverReward;
        GoldReward = achievementItemModelJson.GoldReward;
    }

    public void CollectBronzeReward()
    {
        BronzeReward = 0;
    }

    public void CollectSilverReward()
    {
        SilverReward = 0;
    }

    public void CollectGoldReward()
    {
        GoldReward = 0;
    }
}

[Serializable]
public class AchievementItemModelJson
{
    public string Name;
    public List<string> Descriptions;
    public int CurrentLevel;
    public int BronzeReward;
    public int SilverReward;
    public int GoldReward;
}
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsModel
{
    public delegate void AchUnlock();
    public event AchUnlock AchUnlockNotify;

    public List<AchievementItemModel> AchievementItems = new List<AchievementItemModel>();

    public int ScoresByRound 
    { 
        get { return scoresByRound; }
        set 
        {
            scoresByRound = value;
            if (scoresByRound >= 100)
            {
                UnlockAchievement("RoundScore", 1);
            }
            if (scoresByRound >= 1000)
            {
                UnlockAchievement("RoundScore", 2);
            }
            if (scoresByRound >= 10000)
            {
                UnlockAchievement("RoundScore", 3);
            }
        }
    }

    public int CoinsByRound
    {
        get { return coinsByRound; }
        set
        {
            coinsByRound = value;
            if (coinsByRound >= 100)
            {
                UnlockAchievement("RoundCoins", 1);
            }
            if (coinsByRound >= 1000)
            {
                UnlockAchievement("RoundCoins", 2);
            }
            if (coinsByRound >= 10000)
            {
                UnlockAchievement("RoundCoins", 3);
            }
        }
    }

    public int ComboByRound
    {
        get { return comboByRound; }
        set
        {
            comboByRound = value;
            switch (comboByRound)
            {
                case 25:
                    UnlockAchievement("Combo", 1);
                    break;
                case 100:
                    UnlockAchievement("Combo", 2);
                    break;
                case 250:
                    UnlockAchievement("Combo", 3);
                    break;
            }
        }
    }

    public int RagePlayed
    {
        get { return ragePlayed; }
        set
        {
            ragePlayed = value;
            switch (ragePlayed)
            {
                case 1:
                    UnlockAchievement("RagePlayed", 1);
                    break;
                case 5:
                    UnlockAchievement("RagePlayed", 2);
                    break;
                case 10:
                    UnlockAchievement("RagePlayed", 3);
                    break;
            }
        }
    }

    public int RageDone
    {
        get { return rageDone; }
        set
        {
            rageDone = value;
            switch (rageDone)
            {
                case 1:
                    UnlockAchievement("RageDone", 1);
                    break;
                case 5:
                    UnlockAchievement("RageDone", 2);
                    break;
                case 10:
                    UnlockAchievement("RageDone", 3);
                    break;
            }
        }
    }

    public int RageIdeal
    {
        get { return rageIdeal; }
        set
        {
            rageIdeal = value;
            switch (rageIdeal)
            {
                case 1:
                    UnlockAchievement("RageIdeal", 1);
                    break;
                case 5:
                    UnlockAchievement("RageIdeal", 2);
                    break;
                case 10:
                    UnlockAchievement("RageIdeal", 3);
                    break;
            }
        }
    }

    public int LevelPassed
    {
        get { return levelPassed; }
        set
        {
            levelPassed = value;
            switch (levelPassed)
            {
                case 5:
                    UnlockAchievement("LevelPassed", 1);
                    break;
                case 7:
                    UnlockAchievement("LevelPassed", 2);
                    break;
                case 10:
                    UnlockAchievement("LevelPassed", 3);
                    break;
            }
        }
    }

    public int LevelPassedNoLoss
    {
        get { return levelPassedNoLoss; }
        set
        {
            levelPassedNoLoss = value;
            switch (levelPassedNoLoss)
            {
                case 5:
                    UnlockAchievement("LevelPassedNoLoss", 1);
                    break;
                case 7:
                    UnlockAchievement("LevelPassedNoLoss", 2);
                    break;
                case 10:
                    UnlockAchievement("LevelPassedNoLoss", 3);
                    break;
            }
        }
    }

    public int ScoresTotal
    {
        get { return scoresTotal; }
        set
        {
            scoresTotal = value;
            if (scoresTotal >= 10000)
            {
                UnlockAchievement("ScoresTotal", 1);
            }
            if (scoresTotal >= 100000)
            {
                UnlockAchievement("ScoresTotal", 2);
            }
            if (scoresTotal >= 1000000)
            {
                UnlockAchievement("ScoresTotal", 3);
            }
        }
    }

    public int CoinsTotal
    {
        get { return coinsTotal; }
        set
        {
            coinsTotal = value;
            if (coinsTotal >= 10000)
            {
                UnlockAchievement("CoinsTotal", 1);
            }
            if (coinsTotal >= 100000)
            {
                UnlockAchievement("CoinsTotal", 2);
            }
            if (coinsTotal >= 1000000)
            {
                UnlockAchievement("CoinsTotal", 3);
            }
        }
    }

    public AchievementsModel()
    {
        RagePlayed = 0;
        RageDone = 0;
        RageIdeal = 0;
        ScoresTotal = 0;
        CoinsTotal = 0;

        AchievementItems = new List<AchievementItemModel>()
        {
            new AchievementItemModel()
            {
                Name = "RoundScore",
                Descriptions = new string[3] 
                {
                    "RoundScoreAch1",
                    "RoundScoreAch2",
                    "RoundScoreAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 100,
                SilverReward = 250,
                GoldReward = 500
            },
            new AchievementItemModel()
            {
                Name = "RoundCoins",
                Descriptions = new string[3]
                {
                    "RoundCoinsAch1",
                    "RoundCoinsAch2",
                    "RoundCoinsAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 100,
                SilverReward = 250,
                GoldReward = 500
            },
            new AchievementItemModel()
            {
                Name = "Combo",
                Descriptions = new string[3]
                {
                    "ComboAch1",
                    "ComboAch2",
                    "ComboAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 250,
                SilverReward = 500,
                GoldReward = 1000
            },
            new AchievementItemModel()
            {
                Name = "RagePlayed",
                Descriptions = new string[3]
                {
                    "RagePlayedAch1",
                    "RagePlayedAch2",
                    "RagePlayedAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 100,
                SilverReward = 250,
                GoldReward = 500
            },
            new AchievementItemModel()
            {
                Name = "RageDone",
                Descriptions = new string[3]
                {
                    "RageDoneAch1",
                    "RageDoneAch2",
                    "RageDoneAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 500,
                SilverReward = 1000,
                GoldReward = 5000
            },
            new AchievementItemModel()
            {
                Name = "RageIdeal",
                Descriptions = new string[3]
                {
                    "RageIdealAch1",
                    "RageIdealAch2",
                    "RageIdealAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 1000,
                SilverReward = 5000,
                GoldReward = 10000
            },
            new AchievementItemModel()
            {
                Name = "RageDoneByRound",
                Descriptions = new string[3]
                {
                    "RageDoneByRoundAch1",
                    "RageDoneByRoundAch2",
                    "RageDoneByRoundAch3",
                },
                CurrentLevel = 0,
                BronzeReward = 100,
                SilverReward = 500,
                GoldReward = 1000
            },
            new AchievementItemModel()
            {
                Name = "LevelPassed",
                Descriptions = new string[3]
                {
                    "LevelPassedAch1",
                    "LevelPassedAch2",
                    "LevelPassedAch3"
                },
                CurrentLevel = 0,
                BronzeReward = 500,
                SilverReward = 750,
                GoldReward = 1000
            },
            new AchievementItemModel()
            {
                Name = "LevelPassedNoLoss",
                Descriptions = new string[3]
                {
                    "LevelPassedNoLossAch1",
                    "LevelPassedNoLossAch2",
                    "LevelPassedNoLossAch3"
                },
                CurrentLevel = 0,
                BronzeReward = 1000,
                SilverReward = 2500,
                GoldReward = 5000
            },
            new AchievementItemModel()
            {
                Name = "ScoresTotal",
                Descriptions = new string[3]
                {
                    "ScoresTotalAch1",
                    "ScoresTotalAch2",
                    "ScoresTotalAch3"
                },
                CurrentLevel = 0,
                BronzeReward = 1000,
                SilverReward = 2500,
                GoldReward = 5000
            },
            new AchievementItemModel()
            {
                Name = "CoinsTotal",
                Descriptions = new string[3]
                {
                    "CoinsTotalAch1",
                    "CoinsTotalAch2",
                    "CoinsTotalAch3"
                },
                CurrentLevel = 0,
                BronzeReward = 1000,
                SilverReward = 2500,
                GoldReward = 5000
            }
        };
    }

    public void StartNewRound()
    {
        ScoresByRound = 0;
        CoinsByRound = 0;
        ComboByRound = 0;
        LevelPassed = 0;
        LevelPassedNoLoss = 0;
        doneRagesByRound.Clear();
    }

    public void CollectPlayedRage(int rageIndex)
    {
        if (!playedRages.Any(x => x == rageIndex))
        {
            playedRages.Add(rageIndex);
            RagePlayed++;
        }
    }

    public void CollectDoneRage(int rageIndex)
    {
        if (!doneRages.Any(x => x == rageIndex))
        {
            doneRages.Add(rageIndex);
            RageDone++;
        }
    }

    public void CollectIdealRage(int rageIndex)
    {
        if (!idealRages.Any(x => x == rageIndex))
        {
            idealRages.Add(rageIndex);
            RageIdeal++;
        }
    }

    public void CollectDoneRageByRound(int rageIndex)
    {
        if (!doneRagesByRound.Any(x => x == rageIndex))
        {
            doneRagesByRound.Add(rageIndex);
            switch (doneRagesByRound.Count)
            {
                case 2:
                    UnlockAchievement("RageDoneByRound", 1);
                    break;
                case 6:
                    UnlockAchievement("RageDoneByRound", 2);
                    break;
                case 10:
                    UnlockAchievement("RageDoneByRound", 3);
                    break;
            }
        }
    }

    public AchievementsModelJson ToAchievementsModelJson()
    {
        var achievementModelJson = new AchievementsModelJson()
        {
            CoinsTotal = CoinsTotal,
            LevelPassed = LevelPassed,
            LevelPassedNoLoss = LevelPassedNoLoss,
            RageDone = RageDone,
            RageIdeal = RageIdeal,
            RagePlayed = RagePlayed,
            ScoresTotal = ScoresTotal,
            DoneRagesList = doneRages,
            IdealRagesList = idealRages,
            PlayedRagesList = playedRages
        };
        achievementModelJson.AchievementItems.Clear();
        foreach (var item in AchievementItems)
        {
            achievementModelJson.AchievementItems.Add(item.ToAchievementItemModelJson());
        }
        return achievementModelJson;
    }

    public void FromAchievementsModelJson(AchievementsModelJson achievementModelJson)
    {
        AchievementItems.Clear();
        foreach (var item in achievementModelJson.AchievementItems)
        {
            var newItem = new AchievementItemModel();
            newItem.FromAchievementItemModelJson(item);
            AchievementItems.Add(newItem);
        }
        CoinsTotal = achievementModelJson.CoinsTotal;
        LevelPassed = achievementModelJson.LevelPassed;
        LevelPassedNoLoss = achievementModelJson.LevelPassedNoLoss;
        RageDone = achievementModelJson.RageDone;
        RageIdeal = achievementModelJson.RageIdeal;
        RagePlayed = achievementModelJson.RagePlayed;
        ScoresTotal = achievementModelJson.ScoresTotal;
        doneRages = achievementModelJson.DoneRagesList;
        idealRages = achievementModelJson.IdealRagesList;
        playedRages = achievementModelJson.PlayedRagesList;
    }

    private void UnlockAchievement(string achievementName, int medalIndex)
    {
        var achievement = AchievementItems.FirstOrDefault(x => x.Name == achievementName);
        if (achievement != null)
        {
            if (achievement.CurrentLevel < medalIndex)
            {
                achievement.CurrentLevel = medalIndex;
                AchUnlockNotify?.Invoke();
            }
        }
    }

    private int scoresByRound;
    private int coinsByRound;
    private int comboByRound;
    private int ragePlayed;
    private List<int> playedRages = new List<int>();
    private int rageDone;
    private List<int> doneRages = new List<int>();
    private int rageIdeal;
    private List<int> idealRages = new List<int>();
    private List<int> doneRagesByRound = new List<int>();
    private int levelPassed;
    private int levelPassedNoLoss;
    private int scoresTotal;
    private int coinsTotal;
}

[Serializable]
public class AchievementsModelJson
{
    public List<AchievementItemModelJson> AchievementItems = new List<AchievementItemModelJson>();

    public int RagePlayed;
    public List<int> PlayedRagesList = new List<int>();

    public int RageDone;
    public List<int> DoneRagesList = new List<int>();

    public int RageIdeal;
    public List<int> IdealRagesList = new List<int>();

    public int LevelPassed;

    public int LevelPassedNoLoss;

    public int ScoresTotal;

    public int CoinsTotal;
}

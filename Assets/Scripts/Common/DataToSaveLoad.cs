using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataToSaveLoad
{
    public ShopModelJson Shop;
    public AchievementsModelJson Achievements;
    public int HighScores;
    public int CoinsTotal;
    public int RecordCombo;
    public int RecordOrder;
    public bool SoundOn;
    public List<bool> FirstTimePlayBools = new List<bool>();
    public bool IsRusLanguage;
}

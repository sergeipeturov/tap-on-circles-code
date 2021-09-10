using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementItemScript : MonoBehaviour
{
    public delegate void CollectAward(int award);
    public event CollectAward CollectAwardNotify;

    public TextMeshProUGUI Description;
    public Image[] AILevels;
    public GameObject DoneImage;

    public Sprite AILevelBronze;
    public Sprite AILevelSilver;
    public Sprite AILevelGold;
    public Sprite AILevelBlanc;

    public GameObject BronzeRewardAvail;
    public GameObject SilverRewardAvail;
    public GameObject GoldRewardAvail;

    public AchievementItemModel Model { get; set; }

    void Awake()
    {
        DoneImage.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetModel(AchievementItemModel achievementItemModel)
    {
        Model = achievementItemModel;
        Description.text = LocalizationManager.GetStringByKey(achievementItemModel.CurrentDescription);
        switch (Model.CurrentLevel)
        {
            case 0:
                AILevels[0].sprite = AILevelBlanc;
                BronzeRewardAvail.SetActive(false);

                AILevels[1].sprite = AILevelBlanc;
                SilverRewardAvail.SetActive(false);

                AILevels[2].sprite = AILevelBlanc;
                GoldRewardAvail.SetActive(false);
                break;
            case 1:
                AILevels[0].sprite = AILevelBronze;
                if (Model.BronzeReward != 0) BronzeRewardAvail.SetActive(true);
                else BronzeRewardAvail.SetActive(false);

                AILevels[1].sprite = AILevelBlanc;
                SilverRewardAvail.SetActive(false);

                AILevels[2].sprite = AILevelBlanc;
                GoldRewardAvail.SetActive(false);
                break;
            case 2:
                AILevels[0].sprite = AILevelBronze;
                if (Model.BronzeReward != 0) BronzeRewardAvail.SetActive(true);
                else BronzeRewardAvail.SetActive(false);

                AILevels[1].sprite = AILevelSilver;
                if (Model.SilverReward != 0) SilverRewardAvail.SetActive(true);
                else SilverRewardAvail.SetActive(false);

                AILevels[2].sprite = AILevelBlanc;
                GoldRewardAvail.SetActive(false);
                break;
            case 3:
                AILevels[0].sprite = AILevelBronze;
                if (Model.BronzeReward != 0) BronzeRewardAvail.SetActive(true);
                else BronzeRewardAvail.SetActive(false);

                AILevels[1].sprite = AILevelSilver;
                if (Model.SilverReward != 0) SilverRewardAvail.SetActive(true);
                else SilverRewardAvail.SetActive(false);

                AILevels[2].sprite = AILevelGold;
                if (Model.GoldReward != 0) GoldRewardAvail.SetActive(true);
                else GoldRewardAvail.SetActive(false);
                DoneImage.SetActive(true);
                break;
        }
    }

    public void CollectBronzeReward()
    {
        if (Model.CurrentLevel >= 1)
        {
            if (Model.BronzeReward != 0)
            {
                BronzeRewardAvail.SetActive(false);
                CollectAwardNotify?.Invoke(Model.BronzeReward);
                Model.CollectBronzeReward();
            }
        }
    }

    public void CollectSilverReward()
    {
        if (Model.CurrentLevel >= 2)
        {
            if (Model.SilverReward != 0)
            {
                SilverRewardAvail.SetActive(false);
                CollectAwardNotify?.Invoke(Model.SilverReward);
                Model.CollectSilverReward();
            }
        }
    }

    public void CollectGoldReward()
    {
        if (Model.CurrentLevel >= 3)
        {
            if (Model.GoldReward != 0)
            {
                GoldRewardAvail.SetActive(false);
                CollectAwardNotify?.Invoke(Model.GoldReward);
                Model.CollectGoldReward();
            }
        }
    }
}

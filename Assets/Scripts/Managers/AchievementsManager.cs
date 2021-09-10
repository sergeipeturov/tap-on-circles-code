using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementsManager : MonoBehaviour
{
    public delegate void ShowAchivement();
    public event ShowAchivement ShowAchivementNotify;

    public GameObject AchievementScrollBarContent;
    public GameObject AchievementItemPrefab;
    public GameObject AchievementUnlockedMessage;
    public TextMeshProUGUI CoinsText;

    public SoundManager SoundManager { get; set; } //знаю, что это плохо, но так быстрей, чем переделывать на синглтон
    public List<GameObject> AchievementItems { get; set; } = new List<GameObject>();
    public AchievementsModel Model { get; set; }
    public int Coins { get { return coins; } set { coins = value; CoinsText.text = coins.ToString(); } }
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAchievementsModel(AchievementsModel achievementsModel, int coins)
    {
        if (Model == null)
        {
            Model = achievementsModel;
            Coins = coins;
            Model.AchUnlockNotify += ShowUnlockMessage;
        }
        else
        {
            Model = achievementsModel;
            Coins = coins;
        }
        foreach (var item in AchievementItems)
        {
            item.GetComponent<AchievementItemScript>().CollectAwardNotify -= AchievementsManager_CollectAwardNotify;
            Destroy(item);
        }
        AchievementItems.Clear();
        foreach (var achievItem in Model.AchievementItems)
        {
            var achievItemObject = Instantiate(AchievementItemPrefab);
            achievItemObject.GetComponent<AchievementItemScript>().SetModel(achievItem);
            achievItemObject.GetComponent<AchievementItemScript>().CollectAwardNotify += AchievementsManager_CollectAwardNotify;
            achievItemObject.transform.SetParent(AchievementScrollBarContent.transform, false);
            AchievementItems.Add(achievItemObject);
        }
    }

    private void AchievementsManager_CollectAwardNotify(int award)
    {
        Coins += award;
        SoundManager.PlayCoinCollect();
    }

    private void ShowUnlockMessage()
    {
        AchievementUnlockedMessage.GetComponent<Animator>().SetTrigger("AchieveUnlock");
        ShowAchivementNotify?.Invoke();
    }
}

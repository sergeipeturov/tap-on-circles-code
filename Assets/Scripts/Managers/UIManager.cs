using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI PointsText;
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI LossText;
    public Slider ComboSlider;
    public GameObject RageButton;

    public GameObject GameModePanel;
    public GameObject MainMenuPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject BeforeRagePanel;
    public GameObject RagePanel;
    public GameObject AfterRagePanel;
    public GameObject ShopPanel;
    public GameObject AchievementsPanel;
    public GameObject WinPanel;
    public GameObject ResetPanel;
    public GameObject HelpPanel;

    public TextMeshProUGUI PointsRageText;
    public GameObject IdealImage;
    public GameObject DoneImage;
    public GameObject FailImage;

    public TextMeshProUGUI HighScoresText;
    public TextMeshProUGUI MainMenuCoinsText;
    public TextMeshProUGUI WinText;

    public GameObject LanguageButton;
    public Sprite EnLang;
    public Sprite RusLang;

    public GameObject AdsButton;
    public Sprite GoodAdsButton;
    public Sprite BadAdsButton;

    public Text ResetTutorialButtonText;
    public Text ResetAllButtonText;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHighScoresText(int points)
    {
        HighScoresText.text = $"{points}";
    }
    public void SetMainMenuCoinsText(int coins)
    {
        MainMenuCoinsText.text = $"{coins}";
    }

    public void SetPointsText(int points)
    {
        PointsText.text = $"{points}";
    }
    public void SetCoinsText(int coins)
    {
        CoinsText.text = $"{coins}";
    }
    public void SetLevelText(Level level)
    {
        LevelText.text = $"Level: {level}";
    }
    public void SetLossText(int loss)
    {
        LossText.text = $"{loss}";
    }
    public void SetComboSlider(int combo)
    {
        ComboSlider.value = combo;
    }
    public void AllowRageMode(bool allow)
    {
        RageButton.SetActive(allow);
    }

    public void SetGameModePanel(bool goOrNo)
    {
        if (AfterRagePanel.activeSelf) AfterRagePanel.SetActive(false);
        GameModePanel.SetActive(goOrNo);
    }

    public void SetPauseMode(bool pause)
    {
        PausePanel.SetActive(pause);
    }
    public void SetMainMenuMode(bool mainMenu)
    {
        MainMenuPanel.SetActive(mainMenu);
        GameModePanel.SetActive(!mainMenu);
        if (PausePanel.activeSelf) PausePanel.SetActive(false);
        if (GameOverPanel.activeSelf) GameOverPanel.SetActive(false);
        if (BeforeRagePanel.activeSelf) BeforeRagePanel.SetActive(false);
        if (RagePanel.activeSelf) RagePanel.SetActive(false);
        if (AfterRagePanel.activeSelf) AfterRagePanel.SetActive(false);
        if (WinPanel.activeSelf) WinPanel.SetActive(false);
    }
    public void SetGameOver(bool gameOver, int points = 0, int hs = 0, int coins = 0, int coinsTotal = 0, int maxCombo = 0, int recordCombo = 0, int maxOrder = 0, int recordOrder = 0)
    {
        GameOverPanel.SetActive(gameOver);
        GameOverPanel.transform.Find("PointsText").Find("Value").GetComponent<Text>().text = $"{points}";
        GameOverPanel.transform.Find("HighScoreText").Find("Value").GetComponentInChildren<Text>().text = $"{hs}";
        GameOverPanel.transform.Find("CoinsText").Find("Value").GetComponentInChildren<Text>().text = $"{coins}";
        GameOverPanel.transform.Find("CoinsTotalText").Find("Value").GetComponentInChildren<Text>().text = $"{coinsTotal}";
        GameOverPanel.transform.Find("MaxComboText").Find("Value").GetComponentInChildren<Text>().text = $"{maxCombo}";
        GameOverPanel.transform.Find("RecordComboText").Find("Value").GetComponentInChildren<Text>().text = $"{recordCombo}";
        GameOverPanel.transform.Find("MaxOrderText").Find("Value").GetComponentInChildren<Text>().text = $"{maxOrder}";
        GameOverPanel.transform.Find("RecordOrderText").Find("Value").GetComponentInChildren<Text>().text = $"{recordOrder}";
    }
    public void SetBeforeRage(bool goOrNo)
    {
        BeforeRagePanel.SetActive(goOrNo);
        if (goOrNo)
        {
            //BeforeRagePanel.transform.Find("RageImage").GetComponent<Animator>().SetTrigger("FadeIn");
            BeforeRagePanel.transform.Find("GetReadyImage").GetComponent<Animator>().SetTrigger("FadeIn");
        }
    }
    public void SetRageMode(bool goOrNo)
    {
        RagePanel.SetActive(goOrNo);
    }
    public void SetAfterRage(bool goOrNo, RageModeResult rageModeResult = RageModeResult.done)
    {
        SetRageMode(false);
        var pointsUI = AfterRagePanel.transform.Find("Points");
        var coinsUI = AfterRagePanel.transform.Find("Coins");
        var bonusUI = AfterRagePanel.transform.Find("BonusImage");
        var bonusPointsUI = AfterRagePanel.transform.Find("BonusPoints");
        var bonusCoinsUI = AfterRagePanel.transform.Find("BonusCoins");
        pointsUI.GetComponentInChildren<TextMeshProUGUI>().text = PointsRageText.text;
        AfterRagePanel.SetActive(goOrNo);
        if (goOrNo)
        {
            switch (rageModeResult)
            {
                case RageModeResult.ideal:
                    IdealImage.SetActive(true);
                    DoneImage.SetActive(false);
                    FailImage.SetActive(false);
                    AfterRagePanel.transform.Find("IdealImage").GetComponent<Animator>().SetTrigger("FadeIn");
                    pointsUI.gameObject.SetActive(true);
                    coinsUI.gameObject.SetActive(true);
                    bonusUI.gameObject.SetActive(true);
                    bonusPointsUI.gameObject.SetActive(true);
                    bonusCoinsUI.gameObject.SetActive(true);
                    pointsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    coinsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    bonusUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    bonusPointsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    bonusCoinsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    break;
                case RageModeResult.done:
                    IdealImage.SetActive(false);
                    DoneImage.SetActive(true);
                    FailImage.SetActive(false);
                    AfterRagePanel.transform.Find("DoneImage").GetComponent<Animator>().SetTrigger("FadeIn");
                    pointsUI.gameObject.SetActive(true);
                    coinsUI.gameObject.SetActive(true);
                    bonusUI.gameObject.SetActive(false);
                    bonusPointsUI.gameObject.SetActive(false);
                    bonusCoinsUI.gameObject.SetActive(false);
                    pointsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    coinsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    break;
                case RageModeResult.fail:
                    IdealImage.SetActive(false);
                    DoneImage.SetActive(false);
                    FailImage.SetActive(true);
                    pointsUI.gameObject.SetActive(true);
                    coinsUI.gameObject.SetActive(true);
                    bonusUI.gameObject.SetActive(false);
                    bonusPointsUI.gameObject.SetActive(false);
                    bonusCoinsUI.gameObject.SetActive(false);
                    AfterRagePanel.transform.Find("FailImage").GetComponent<Animator>().SetTrigger("FadeIn");
                    pointsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    coinsUI.GetComponent<Animator>().SetTrigger("FadeIn");
                    break;
            }
        }
    }

    public void SetPointsTextRage(int points)
    {
        PointsRageText.text = $"{points}";
    }
    public void SetBonusPointsTextRage(int points)
    {
        AfterRagePanel.transform.Find("BonusPoints").GetComponentInChildren<TextMeshProUGUI>().text = $"{points}";
    }
    public void SetCoinsTextRage(int coins)
    {
        AfterRagePanel.transform.Find("Coins").GetComponentInChildren<TextMeshProUGUI>().text = $"{coins}";
    }
    public void SetBonusCoinsTextRage(int coins)
    {
        AfterRagePanel.transform.Find("BonusCoins").GetComponentInChildren<TextMeshProUGUI>().text = $"{coins}";
    }

    public void ShowShopPanel(bool show)
    {
        MainMenuPanel.SetActive(!show);
        ShopPanel.SetActive(show);
    }
    public void ShowAchievementsPanel(bool show, bool isFromMainMenu = true)
    {
        if (show)
        {
            isAchievFromMainMenu = isFromMainMenu;
        }
        if (isAchievFromMainMenu) MainMenuPanel.SetActive(!show);
        else PausePanel.SetActive(!show);
        AchievementsPanel.SetActive(show);
    }

    public void SetComboToRage(int newComboToRage)
    {
        ComboSlider.maxValue = newComboToRage;
    }

    public void ShowWinPanel(bool show)
    {
        if (show)
        {
            GameModePanel.SetActive(false);
            WinPanel.SetActive(show);
            WinText.text = LocalizationManager.GetStringByKey("WinModeText");
        }
        
    }

    public void SetLanguage(bool isRus)
    {
        LanguageButton.GetComponent<Image>().sprite = isRus ? RusLang : EnLang;
    }

    public void ShowResetPanel(bool show)
    {
        ResetTutorialButtonText.text = LocalizationManager.GetStringByKey("ResetTutorButton");
        ResetAllButtonText.text = LocalizationManager.GetStringByKey("ResetAllButton");
        MainMenuPanel.SetActive(!show);
        ResetPanel.SetActive(show);
    }

    public void ShowHelpPanel(bool show)
    {
        MainMenuPanel.SetActive(!show);
        HelpPanel.SetActive(show);
    }

    public void SetAdsButtonAvail(bool available)
    {
        AdsButton.GetComponent<Button>().interactable = available;
        if (available)
        {
            AdsButton.GetComponent<Image>().sprite = GoodAdsButton;
        }
        else
        {
            AdsButton.GetComponent<Image>().sprite = BadAdsButton;
        }
    }

    private bool isAchievFromMainMenu;
}

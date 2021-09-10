using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class GameManager : MonoBehaviour
{
    public Camera MainCamera;

    private GameState currentState;
    public GameState CurrentState 
    { 
        get { return currentState; } 
        set 
        { 
            if (value == GameState.gameOver)
            {

            }
            currentState = value; 
            OnGameStateChanged(); 
        } 
    }
    private bool allowRageMode;
    public bool AllowRageMode
    { 
        get { return allowRageMode; } 
        set 
        {
            if (!allowRageMode && value)
                soundManager.PlayRageOn();
            allowRageMode = value; 
            uIManager.AllowRageMode(allowRageMode);

            if (allowRageMode &&!FirstTimePlayBools[1])
                tutorialManager.ShowRageMessages();
        } 
    }

    public Level Level 
    { 
        get { return level; } 
        set 
        { 
            level = value; ApplyLevelAndShopVariables();
            if (Achievements != null)
            {
                Achievements.LevelPassed = level.Number;
                if (Loss == 0 && !wasRestartForAds)
                    Achievements.LevelPassedNoLoss = level.Number;
            }
            uIManager?.SetLevelText(level);
            if (level.Number != 1) soundManager.IncreaseMusicSpeed();

            if (level.Number == 2 && !FirstTimePlayBools[2])
                tutorialManager.ShowSpecialMessages();
        } 
    }
    public int Points 
    { 
        get { return points; } 
        set 
        { 
            points = value;
            if (CurrentState == GameState.playingNormal && Achievements != null) Achievements.ScoresByRound = points;
            if (points < 0) points = 0; 
            uIManager?.SetPointsText(points); 
            if (points > maxPoitsCoinsValue)
            {
                points = maxPoitsCoinsValue;
                CurrentState = GameState.win;
            }
        } 
    }
    public int Tappeds { get { return tappeds; } set { tappeds = value; CheckTappedsToReachNextLevel(); } }
    public int Loss { get { return loss; } set { loss = value; Combo = 0; uIManager?.SetLossText(loss); CheckLossToGameOver(); } }
    public int Order { get; set; }
    public int Combo
    {
        get { return combo; }
        set
        {
            if (value == 0)
            {
                if (MaxCombo < combo)
                {
                    MaxCombo = combo;
                }
            }

            combo = value;
            if (Achievements != null) Achievements.ComboByRound = combo;
            uIManager?.SetComboSlider(combo);
            CheckComboToRage();
        }
    }
    public int HighScores { get { return highScores; } set { highScores = value; uIManager?.SetHighScoresText(highScores); } }
    public int Coins 
    { 
        get { return coins; } 
        private set 
        { 
            coins = value;
            if (CurrentState == GameState.playingNormal && Achievements != null) Achievements.CoinsByRound = coins;
            if (coins < 0) coins = 0;
            uIManager?.SetCoinsText(coins);
            if (coins > maxPoitsCoinsValue)
            {
                coins = maxPoitsCoinsValue;
                CurrentState = GameState.win;
            }
        } 
    }
    public int CoinsTotal 
    { 
        get { return coinsTotal; } 
        private set 
        { 
            coinsTotal = value; 
            uIManager?.SetMainMenuCoinsText(coinsTotal); 
        } 
    }

    public ShopModel Shop { get; set; }
    public AchievementsModel Achievements { get; set; }

    public int ComboToRage { get { return comboToRage; } set { comboToRage = value; uIManager?.SetComboToRage(ComboToRage); } }
    public int MaxCombo { get; set; }
    public int RecordCombo { get; set; }
    public int MaxOrder { get; set; }
    public int RecordOrder { get; set; }

    public int ChanceCoinInCirclePercent { get; set; }
    public int CountCoinsInCircle { get; set; }
    public int MaxCoinsCountOnField { get; set; }
    public int ChanceCoinOnFieldPercent { get; set; }
    public float CoinTimeOfLife { get; set; }
    public int ChanceToBadCircle { get; set; }
    public int ChanceToGoodCircle { get; set; }
    public float SizeChangeInSecondCircle { get; set; }

    public bool SoundOn { get { return soundOn; } set { soundOn = value; soundManager.Mute(soundOn); } }
    public List<bool> FirstTimePlayBools { get; set; } = new List<bool>();

    private void Awake()
    {
        //PlayerPrefs.DeleteAll(); //test
        //LocalizationManager.SetLanguage(false); //test

        //float ratio = Screen.height / Screen.width;
        //float ortSize = целевая_высота / 200f;
        //MainCamera
        MobileAds.Initialize(initStatus => { });

        float aspectRatio = 9f / 16f;
        MainCamera.aspect = aspectRatio;
        float currentAspectRatio = 1f * Screen.width / Screen.height;
        cameraSizeCoef = ((currentAspectRatio * 100) / aspectRatio) / 100;

        soundManager = transform.Find("SoundManager").gameObject.GetComponent<SoundManager>();
        uIManager = GetComponent<UIManager>();
        shopManager = GetComponent<ShopManager>();
        shopManager.SoundManager = soundManager;
        achievementsManager = GetComponent<AchievementsManager>();
        achievementsManager.SoundManager = soundManager;
        achievementsManager.ShowAchivementNotify += AchievementsManager_ShowAchivementNotify;
        backgroundManager = FindObjectOfType<BackgroundManager>();
        circlesInstantiator = GetComponent<CirclesInstantiator>();
        circlesInstantiator.CameraSizeCoef = cameraSizeCoef;
        tutorialManager = GetComponent<TutorialManager>();
        tutorialManager.SetModel();
        tutorialManager.TutorialDoneNotify += TutorialManager_TutorialDoneNotify;
        LoadGame();

        if (!FirstTimePlayBools.Any()) //заполняем массив обучений для игрока, если он в первый раз играет
        {
        //FirstTimePlayBools.Clear();
            FirstTimePlayBools.Add(false); //0 - по поводу UI и основной механики (wellcome). появляется при первом старте новой игры
            FirstTimePlayBools.Add(false); //1 - по поводу Rage. появляется, когда заполняется Rage шкала в первый раз
            FirstTimePlayBools.Add(false); //2 - по поводу * и X, монет и магазина. появляется на 2 уровне
            FirstTimePlayBools.Add(false); //3 - по поводу ачивок. появляется в момент первой ачивки
            FirstTimePlayBools.Add(false); //4 - по поводу gameover. появляется в момент первого гэймовера
        }
    
        Application.targetFrameRate = 60;
        achievementsManager.SetAchievementsModel(Achievements, CoinsTotal); //чтобы показывалось уведомление об ачивке
        rageMode = transform.Find("RageManager").gameObject.GetComponent<RageMode>();
        rageMode.SetModel(circlesInstantiator, uIManager, Achievements, soundManager);
        CurrentState = GameState.mainMenu;

        /*ChanceCoinInCirclePercent = 5;
        CountCoinsInCircle = 10;
        ChanceCoinOnFieldPercent = 20;
        MaxCoinsCountOnField = 1;
        CoinTimeOfLife = 5.0f;*/
        /*ChanceCoinInCirclePercent = baseChanceCoinInCirclePercent;
        CountCoinsInCircle = baseCountCoinsInCircle + Level.CountCoinsInCircle;
        ChanceCoinOnFieldPercent = baseChanceCoinOnFieldPercent + Level.ChanceCoinOnFieldPercent;
        MaxCoinsCountOnField = baseMaxCoinsCountOnField + Level.MaxCoinsCountOnField;
        CoinTimeOfLife = baseCoinTimeOfLife + Level.CoinTimeOfLife;*/
    }

    void Start()
    {
        CreateAndLoadRewardedAd();
    }

    void Update()
    {
        if (CurrentState == GameState.playingNormal)
        {
            if (badCirclesObjects.Any(x => x == null))
                badCirclesObjects.Clear();
            if (goodCirclesObjects.Any(x => x == null))
                goodCirclesObjects.Clear();

            milisecs += Time.deltaTime;
            if (milisecs > Random.Range(Level.BetweenInstantiateTimeMin, Level.BetweenInstantiateTimeMax))
            {
                milisecs = 0.0f;
                Order++;
                var circleObject = circlesInstantiator.InstantiateCircleObject(
                    SizeChangeInSecondCircle,
                    Random.Range(Level.MinSizeCircle, Level.MaxSizeCircle),
                    Order,
                    baseCircleTapCost,
                    Randomizer.GetTapCostInCoins(CountCoinsInCircle, ChanceCoinInCirclePercent)
                    );

                //проверка на то, чтобы круг не появился точно внутри другого круга
                while (circles.Any(x => x.transform.position.x == circleObject.transform.position.x && x.transform.position.y == circleObject.transform.position.y))
                {
                    Destroy(circleObject);
                    circleObject = circlesInstantiator.InstantiateCircleObject(
                        SizeChangeInSecondCircle,
                        Random.Range(Level.MinSizeCircle, Level.MaxSizeCircle),
                        Order,
                        baseCircleTapCost,
                        Randomizer.GetTapCostInCoins(CountCoinsInCircle, ChanceCoinInCirclePercent)
                        );
                }
                
                circleObject.GetComponent<CircleObjectScript>().CircleEventNotify += GameManager_CircleEventNotify;
                circles.Add(circleObject);
            }

            //появление других объектов
            if (milisecs > Random.Range(Level.BetweenInstantiateTimeMin, Level.BetweenInstantiateTimeMax))
            {
                if (coinsObjects.Count < MaxCoinsCountOnField)
                {
                    bool spawnCoin = Randomizer.GetResultByChanse(ChanceCoinOnFieldPercent);
                    if (spawnCoin)
                    {
                        var coinObject = circlesInstantiator.InstantiateCoinObject(Random.Range(5, 26), CoinTimeOfLife, cameraSizeCoef);
                        coinObject.GetComponent<CoinObjectScript>().CircleEventNotify += GameManager_CoinEventNotify;
                        coinsObjects.Add(coinObject);
                    }
                }

                if (goodCirclesObjects.Count < baseMaxCountGoodCircle)
                {
                    bool spawnCircle = Randomizer.GetResultByChanse(ChanceToGoodCircle);
                    if (spawnCircle)
                    {
                        milisecs = 0.0f;
                        var circleObject = circlesInstantiator.InstantiateCircleObject(
                            SizeChangeInSecondCircle,
                            Random.Range(Level.MinSizeCircle, Level.MaxSizeCircle),
                            0,
                            0,
                            0
                            );

                        //проверка на то, чтобы круг не появился точно внутри другого круга
                        while (circles.Any(x => x.transform.position.x == circleObject.transform.position.x && x.transform.position.y == circleObject.transform.position.y))
                        {
                            circleObject = circlesInstantiator.InstantiateCircleObject(
                            SizeChangeInSecondCircle,
                            Random.Range(Level.MinSizeCircle, Level.MaxSizeCircle),
                            0,
                            0,
                            0
                            );
                        }

                        circleObject.GetComponent<CircleObjectScript>().CircleEventNotify += GameManager_CircleEventNotify;
                        goodCirclesObjects.Add(circleObject);
                    }
                }

                if (badCirclesObjects.Count < baseMaxCountBadCircle)
                {
                    bool spawnCircle = Randomizer.GetResultByChanse(ChanceToBadCircle);
                    if (spawnCircle)
                    {
                        milisecs = 0.0f;
                        var circleObject = circlesInstantiator.InstantiateCircleObject(
                            SizeChangeInSecondCircle,
                            Random.Range(Level.MinSizeCircle, Level.MaxSizeCircle),
                            -1,
                            0,
                            0
                            );

                        //проверка на то, чтобы круг не появился точно внутри другого круга
                        while (circles.Any(x => x.transform.position.x == circleObject.transform.position.x && x.transform.position.y == circleObject.transform.position.y))
                        {
                            circleObject = circlesInstantiator.InstantiateCircleObject(
                            SizeChangeInSecondCircle,
                            Random.Range(Level.MinSizeCircle, Level.MaxSizeCircle),
                            0,
                            0,
                            0
                            );
                        }

                        circleObject.GetComponent<CircleObjectScript>().CircleEventNotify += GameManager_CircleEventNotify;
                        badCirclesObjects.Add(circleObject);
                    }
                }
            }
        }

        if (CurrentState == GameState.beforeRageMode)
        {
            curDelay++;
            if (curDelay >= maxDelay)
            {
                curDelay = 0.0f; maxDelay = 0.0f;
                CurrentState = GameState.playingRage;
            }
        }

        if (CurrentState == GameState.playingRage)
        {
            
        }

        if (CurrentState == GameState.afterRageMode)
        {
            curDelay++;
            if (curDelay >= maxDelay)
            {
                curDelay = 0.0f; maxDelay = 0.0f;
                CurrentState = GameState.playingNormal;
            }
        }
    }

    public void StartNewGame()
    {
        Points = 0;
        Coins = 0;
        Tappeds = 0;
        Loss = 0;
        Order = 0;
        Combo = 0;
        MaxCombo = 0;
        MaxOrder = 0;
        uIManager.SetMainMenuMode(false);
        Level = LevelsManager.StartGame();
        milisecs = Level.BetweenInstantiateTimeMin;
        AllowRageMode = false;
        PauseGame(false);
        ClearField();
        CurrentState = GameState.playingNormal;
        Achievements.StartNewRound();
        wasRestartForAds = false;
        soundManager.StartNewGame();

        if (!FirstTimePlayBools[0])
            tutorialManager.ShowWellcomeMessages();
    }

    public void AddCoins(int coinsToAdd)
    {
        Coins += coinsToAdd;
        if (Achievements != null && coinsToAdd > 0) Achievements.CoinsTotal += coinsToAdd;
        CoinsTotal += coinsToAdd;
    }

    public void PauseGame(bool pause)
    {
        if (pause) soundManager.PlayDefault();
        else soundManager.PlayNormal();
        isPaused = pause;
        Time.timeScale = isPaused ? 0 : 1;
        uIManager.SetPauseMode(isPaused);
    }

    public void EnterRageMode()
    {
        ClearField();
        CurrentState = GameState.beforeRageMode;
    }

    public void ContinueForAds()
    {
        //test. раскомментить
        if (rewardedAd != null && rewardedAd.IsLoaded())
        {
            soundManager.StopMusic();
            rewardedAd.Show();
        }
        //test. удалить
        //Combo = 0;
        //Loss = 0;
        //CurrentState = GameState.playingNormal;
        //wasRestartForAds = true;
    }

    public void ExitToMainMenu()
    {
        CurrentState = GameState.mainMenu;
    }

    public void ShowShop(bool show)
    {
        if (show)
        {
            shopManager.SetShopModel(Shop, CoinsTotal);
        }
        else
        {
            Shop = shopManager.Model;
            CoinsTotal = shopManager.Coins;
        }
        uIManager.ShowShopPanel(show);
    }

    public void ShowAchievementsFromMainMenu()
    {
        achievementsManager.SetAchievementsModel(Achievements, CoinsTotal);
        uIManager.ShowAchievementsPanel(true, true);
    }

    public void ShowAchievementsFromPauseMenu()
    {
        achievementsManager.SetAchievementsModel(Achievements, CoinsTotal);
        uIManager.ShowAchievementsPanel(true, false);
    }
    public void CloseAchievements()
    {
        Achievements = achievementsManager.Model;
        uIManager.ShowAchievementsPanel(false);
        CoinsTotal = achievementsManager.Coins;
    }

    public void Mute()
    {
        SoundOn = !SoundOn;
    }

    public void ChangeLanguage()
    {
        LocalizationManager.SetLanguage(!LocalizationManager.IsRus);
        uIManager.SetLanguage(LocalizationManager.IsRus);
        tutorialManager.SetModel();
    }

    public void OnLogoClick()
    {
        Application.OpenURL("https://vk.com/penguin_the_narrator");
    }

    public void ShowResetMenu(bool show)
    {
        uIManager.ShowResetPanel(show);
    }

    public void ResetTutorial()
    {
        FirstTimePlayBools[0] = false; //0 - по поводу UI и основной механики (wellcome). появляется при первом старте новой игры
        FirstTimePlayBools[1] = false; //1 - по поводу Rage. появляется, когда заполняется Rage шкала в первый раз
        FirstTimePlayBools[2] = false; //2 - по поводу * и X, монет и магазина. появляется на 2 уровне
        FirstTimePlayBools[3] = false; //3 - по поводу ачивок. появляется в момент первой ачивки
        FirstTimePlayBools[4] = false; //4 - по поводу gameover. появляется в момент первого гэймовера
        ShowResetMenu(false);
    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        achievementsManager.Model = null;
        LoadDefaultGameData();
        FirstTimePlayBools[0] = false; //0 - по поводу UI и основной механики (wellcome). появляется при первом старте новой игры
        FirstTimePlayBools[1] = false; //1 - по поводу Rage. появляется, когда заполняется Rage шкала в первый раз
        FirstTimePlayBools[2] = false; //2 - по поводу * и X, монет и магазина. появляется на 2 уровне
        FirstTimePlayBools[3] = false; //3 - по поводу ачивок. появляется в момент первой ачивки
        FirstTimePlayBools[4] = false; //4 - по поводу gameover. появляется в момент первого гэймовера
        ShowResetMenu(false);
    }

    public void ShowHelp(bool show)
    {
        uIManager.ShowHelpPanel(show);
    }

    private void SetLanguage(bool isRus)
    {
        LocalizationManager.SetLanguage(isRus);
        uIManager.SetLanguage(isRus);
        tutorialManager.SetModel();
    }

    private void CheckTappedsToReachNextLevel()
    {
        if (Level?.TappedsToReach != int.MaxValue)
        {
            if (Tappeds >= Level?.TappedsToReach)
            {
                Level = LevelsManager.GoNext();
            }
        }
    }

    private void CheckLossToGameOver()
    {
        if (CurrentState == GameState.playingNormal)
        {
            if (Loss >= lossesToGameOver)
            {
                CurrentState = GameState.gameOver;
            }
        }
    }

    private void CheckComboToRage()
    {
        if (CurrentState != GameState.mainMenu)
        {
            if (Combo >= ComboToRage)
            {
                AllowRageMode = true;
            }
            else
            {
                AllowRageMode = false;
            }
        }
    }

    private void GameManager_CircleEventNotify(GameObject gameObject, bool isOnTap)
    {
        if (isOnTap)
        {
            if (gameObject.GetComponent<CircleObjectScript>().Order > 0)
            {
                soundManager.PlayCircleBlow();
                Points += gameObject.GetComponent<CircleObjectScript>().TapCost;
                if (Achievements != null) Achievements.ScoresTotal += gameObject.GetComponent<CircleObjectScript>().TapCost;
                Tappeds += 1;
                AddCoins(gameObject.GetComponent<CircleObjectScript>().TapCostInCoins);
                if (gameObject.GetComponent<CircleObjectScript>().Order == lastTappedCircleOrder + 1)
                {
                    Combo += 1;
                }
                else
                {
                    Combo = 0;
                }

                lastTappedCircleOrder = gameObject.GetComponent<CircleObjectScript>().Order;

                gameObject.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
                circles.Remove(gameObject);
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<CircleObjectScript>().Order == 0) //good circle
            {
                soundManager.PlayRightWrong(true);
                backgroundManager.GoGoodFlash();
                ClearFieldOnGoodCircleTap();
                Combo = 0;
            }
            else if (gameObject.GetComponent<CircleObjectScript>().Order == -1) //bad circle
            {
                soundManager.PlayRightWrong(false);
                backgroundManager.GoBadFlash();
                ClearFieldOnBadCircleTap();
                Combo = 0;
                Loss += 1;
            }
        }
        else
        {
            if (gameObject.GetComponent<CircleObjectScript>().Order > 0)
            {
                Loss += 1;
                gameObject.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
                circles.Remove(gameObject);
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<CircleObjectScript>().Order == 0) //good circle
            {
                gameObject.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
                goodCirclesObjects.Remove(gameObject);
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<CircleObjectScript>().Order == -1) //bad circle
            {
                gameObject.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
                badCirclesObjects.Remove(gameObject);
                Destroy(gameObject);
            }
        }

        
    }

    private void GameManager_CoinEventNotify(GameObject gameObject, bool isOnTap)
    {
        if (isOnTap)
        {
            soundManager.PlayCoinCollect();
            AddCoins(gameObject.GetComponent<CoinObjectScript>().Cost);
            Combo = 0;
        }

        gameObject.GetComponent<CoinObjectScript>().CircleEventNotify -= GameManager_CoinEventNotify;
        coinsObjects.Remove(gameObject);
        Destroy(gameObject);
    }

    private void OnGameStateChanged()
    {
        if (CurrentState == GameState.gameOver)
        {
            soundManager.PlayGameOver();

            isPaused = true;
            Time.timeScale = 0;

            if (HighScores < Points)
            {
                HighScores = Points;
            }

            Combo = 0;
            if (RecordCombo < MaxCombo)
            {
                RecordCombo = MaxCombo;
            }

            if (MaxOrder < Order)
            {
                MaxOrder = Order;
            }
            if (RecordOrder < MaxOrder)
            {
                RecordOrder = MaxOrder;
            }

            uIManager.SetGameOver(true, Points, HighScores, Coins, CoinsTotal, MaxCombo, RecordCombo, MaxOrder, RecordOrder);

            if (!FirstTimePlayBools[4])
                tutorialManager.ShowGameOverMessages();
        }
        if (CurrentState == GameState.playingNormal)
        {
            soundManager.PlayNormal();
            isPaused = false;
            Time.timeScale = 1;
            uIManager.SetGameOver(false);
            uIManager.SetMainMenuMode(false);
            uIManager.SetGameModePanel(true);
            backgroundManager.GoNormalBackground();
        }
        if (CurrentState == GameState.mainMenu)
        {
            soundManager.PlayDefault();

            ClearField();

            isPaused = false;
            Time.timeScale = 1;

            backgroundManager.GoMainMenuBackground();
            uIManager.SetMainMenuMode(true);

            if (HighScores < Points)
            {
                HighScores = Points;
            }

            Points = 0;
            Tappeds = 0;
            Loss = 0;
        }
        if (CurrentState == GameState.beforeRageMode)
        {
            soundManager.PlayRage();
            maxDelay = 200.0f;
            curDelay = 0.0f;
            uIManager.SetGameModePanel(false);
            uIManager.SetBeforeRage(true);
        }

        if (CurrentState == GameState.playingRage)
        {
            //soundManager.PlayRage();
            uIManager.SetBeforeRage(false);
            uIManager.SetRageMode(true);
            currentRage = rageMode.GetRandomRage(baseCircleTapCost);
            currentRage.RageDoneNotify += GameManager_RageDoneNotify;
            currentRage.GoRage();
            backgroundManager.GoRageBackground();
        }

        if (CurrentState == GameState.afterRageMode)
        {
            soundManager.PlayRageResult(rageModeResult);
            currentRage.RageDoneNotify -= GameManager_RageDoneNotify;
            maxDelay = 200.0f;
            curDelay = 0.0f;
            uIManager.SetAfterRage(true, rageModeResult);
            Combo = 0;
        }

        if (CurrentState == GameState.win)
        {
            soundManager.PlayRageResult(RageModeResult.ideal);

            isPaused = true;
            Time.timeScale = 0;

            if (HighScores < Points)
            {
                HighScores = Points;
            }

            Combo = 0;
            if (RecordCombo < MaxCombo)
            {
                RecordCombo = MaxCombo;
            }

            if (MaxOrder < Order)
            {
                MaxOrder = Order;
            }
            if (RecordOrder < MaxOrder)
            {
                RecordOrder = MaxOrder;
            }

            uIManager.ShowWinPanel(true);
        }
    }

    private void ClearField()
    {
        foreach (var item in circles)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        circles.Clear();
        foreach (var item in coinsObjects)
        {
            item.GetComponent<CoinObjectScript>().CircleEventNotify -= GameManager_CoinEventNotify;
            Destroy(item);
        }
        coinsObjects.Clear();
        foreach (var item in badCirclesObjects)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        badCirclesObjects.Clear();
        foreach (var item in goodCirclesObjects)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        goodCirclesObjects.Clear();
    }

    private void ClearFieldOnGoodCircleTap()
    {
        int pointsTotalForClearingField = 0;
        int coinsTotalForClearingField = 0;
        foreach (var item in circles)
        {
            //GameManager_CircleEventNotify(item, true);
            pointsTotalForClearingField += item.GetComponent<CircleObjectScript>().TapCost;
            coinsTotalForClearingField += item.GetComponent<CircleObjectScript>().TapCostInCoins;
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        Points += pointsTotalForClearingField;
        if (Achievements != null) Achievements.ScoresTotal += pointsTotalForClearingField;
        AddCoins(coinsTotalForClearingField);
        circles.Clear();
        foreach (var item in badCirclesObjects)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        badCirclesObjects.Clear();
        foreach (var item in goodCirclesObjects)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        goodCirclesObjects.Clear();
    }

    private void ClearFieldOnBadCircleTap()
    {
        int pointsTotalForClearingField = 0;
        int coinsTotalForClearingField = 0;
        int lossesTotalForClearingField = 0;
        foreach (var item in circles)
        {
            //GameManager_CircleEventNotify(item, true);
            pointsTotalForClearingField += item.GetComponent<CircleObjectScript>().TapCost;
            coinsTotalForClearingField += item.GetComponent<CircleObjectScript>().TapCostInCoins;
            lossesTotalForClearingField++;
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        Points -= pointsTotalForClearingField;
        AddCoins(-coinsTotalForClearingField);
        Loss += lossesTotalForClearingField;
        circles.Clear();
        foreach (var item in badCirclesObjects)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        badCirclesObjects.Clear();
        foreach (var item in goodCirclesObjects)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= GameManager_CircleEventNotify;
            Destroy(item);
        }
        goodCirclesObjects.Clear();
    }

    private void ApplyLevelAndShopVariables()
    {
        //apply Shop to Base
        baseChanceCoinInCirclePercent = Shop.GetIntValue("ChanceCoinCountInCircle");
        baseCountCoinsInCircle = Shop.GetIntValue("CoinCountInCircle");
        baseChanceCoinOnFieldPercent = Shop.GetIntValue("ChanceCoinOnField");
        baseMaxCoinsCountOnField = Shop.GetIntValue("MaxCoinOnField");
        baseCoinTimeOfLife = Shop.GetFloatValue("TimeOfLifeCoinOnField");
        ComboToRage = Shop.GetIntValue("RageCombo");
        lossesToGameOver = Shop.GetIntValue("LossesToGameOver");
        baseChanceToBadCircle = Shop.GetIntValue("ChanceOfBadCircle");
        baseChanceToGoodCircle = Shop.GetIntValue("ChanceOfGoodCircle");
        baseCircleTapCost = Shop.GetIntValue("TapCostOfCircle");
        baseCircleTimeOfLife = Shop.GetFloatValue("TimeOfLifeCircle");

        //apply Level
        ChanceCoinInCirclePercent = baseChanceCoinInCirclePercent + Level.ChanceCoinInCirclePercent; 
        if (ChanceCoinInCirclePercent < 0) ChanceCoinInCirclePercent = 0;

        CountCoinsInCircle = baseCountCoinsInCircle + Level.CountCoinsInCircle; 
        if (CountCoinsInCircle < 0) CountCoinsInCircle = 0;

        ChanceCoinOnFieldPercent = baseChanceCoinOnFieldPercent + Level.ChanceCoinOnFieldPercent; 
        if (ChanceCoinOnFieldPercent < 0) ChanceCoinOnFieldPercent = 0;

        MaxCoinsCountOnField = baseMaxCoinsCountOnField + Level.MaxCoinsCountOnField; 
        if (MaxCoinsCountOnField < 0) MaxCoinsCountOnField = 0;

        CoinTimeOfLife = baseCoinTimeOfLife + Level.CoinTimeOfLife; 
        if (CoinTimeOfLife < 0) CoinTimeOfLife = 0;

        ChanceToBadCircle = baseChanceToBadCircle + Level.ChanceToBadCircle; 
        if (ChanceToBadCircle < 0) ChanceToBadCircle = 0;

        ChanceToGoodCircle = baseChanceToGoodCircle + Level.ChanceToGoodCircle; 
        if (ChanceToGoodCircle < 0) ChanceToGoodCircle = 0;

        SizeChangeInSecondCircle = baseCircleTimeOfLife + Level.SizeChangeInSecondCircle;
        if (SizeChangeInSecondCircle < 0) SizeChangeInSecondCircle = 0;
    }

    private void GameManager_RageDoneNotify(RageModeResult result, int points, int bonusPoints, int coins, int bonusCoins)
    {
        rageModeResult = result;
        CurrentState = GameState.afterRageMode;
        Points += points + bonusPoints;
        AddCoins(coins + bonusCoins);
        if (Achievements != null) Achievements.ScoresTotal += points + bonusPoints;
    }

    private void SaveGame()
    {
        DataToSaveLoad saveData = new DataToSaveLoad()
        {
            Achievements = Achievements.ToAchievementsModelJson(),
            Shop = Shop.ToShopModelJson(),
            HighScores = HighScores,
            CoinsTotal = CoinsTotal,
            RecordCombo = RecordCombo,
            RecordOrder = RecordOrder,
            SoundOn = SoundOn,
            FirstTimePlayBools = FirstTimePlayBools,
            IsRusLanguage = LocalizationManager.IsRus
        };
        var saveJsonStr = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("SaveData", saveJsonStr);
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("SaveData"))
        {
            var loadJsonString = PlayerPrefs.GetString("SaveData");
            var loadData = JsonUtility.FromJson<DataToSaveLoad>(loadJsonString);
            if (loadData != null)
            {
                if (loadData.Achievements != null && loadData.Achievements.AchievementItems.Any())
                {
                    var ach = new AchievementsModel();
                    ach.FromAchievementsModelJson(loadData.Achievements);
                    Achievements = ach;
                }
                else
                {
                    Achievements = new AchievementsModel();
                }
                if (loadData.Shop != null && loadData.Shop.ShopItems.Any())
                {
                    var sh = new ShopModel();
                    sh.FromShopModelJson(loadData.Shop);
                    Shop = sh;
                }
                else
                {
                    Shop = new ShopModel();
                }
                HighScores = loadData.HighScores;
                CoinsTotal = loadData.CoinsTotal;
                RecordCombo = loadData.RecordCombo;
                RecordOrder = loadData.RecordOrder;
                SoundOn = loadData.SoundOn;
                FirstTimePlayBools = loadData.FirstTimePlayBools;
                SetLanguage(loadData.IsRusLanguage);
            }
            else
                LoadDefaultGameData();
        }
        else
            LoadDefaultGameData();
    }

    private void LoadDefaultGameData()
    {
        HighScores = 0;
        CoinsTotal = 0; //test. must be 0
        RecordCombo = 0;
        RecordOrder = 0;
        Shop = new ShopModel();
        Achievements = new AchievementsModel();
        achievementsManager.SetAchievementsModel(Achievements, CoinsTotal);
        //rageMode.SetModel(circlesInstantiator, uIManager, Achievements, soundManager);
        SoundOn = true;
        SetLanguage(false);
    }

    private void OnApplicationPause(bool pause)
    {
        SaveGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void TutorialManager_TutorialDoneNotify(int tutorialIndex)
    {
        FirstTimePlayBools[tutorialIndex] = true;
    }

    private void AchievementsManager_ShowAchivementNotify()
    {
        if (!FirstTimePlayBools[3])
        {
            Time.timeScale = 0;
            tutorialManager.ShowAchieveMessages();
        }
    }

    private void CreateAndLoadRewardedAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917"; //test
        
        rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.OnUserEarnedReward += RewardedAd_OnUserEarnedReward;
        rewardedAd.OnAdClosed += RewardedAd_OnAdClosed;
        rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;
        rewardedAd.OnAdFailedToLoad += RewardedAd_OnAdFailedToLoad;
        rewardedAd.LoadAd(request);
    }

    private void RewardedAd_OnUserEarnedReward(object sender, Reward e)
    {
        Debug.Log("REWARDED!");
        Combo = 0;
        Loss = 0;
        CurrentState = GameState.playingNormal;
        wasRestartForAds = true;
    }

    private void RewardedAd_OnAdClosed(object sender, System.EventArgs e)
    {
        CreateAndLoadRewardedAd();
    }

    private void RewardedAd_OnAdFailedToLoad(object sender, AdErrorEventArgs e)
    {
        adAllowed = false;
        uIManager.SetAdsButtonAvail(adAllowed);
    }

    private void RewardedAd_OnAdLoaded(object sender, System.EventArgs e)
    {
        adAllowed = true;
        uIManager.SetAdsButtonAvail(adAllowed);
    }

    private int points;
    private int highScores;
    private int tappeds;
    private int loss;
    private int combo;
    private int coins;
    private int coinsTotal;
    private Level level;
    private UIManager uIManager;
    private ShopManager shopManager;
    private AchievementsManager achievementsManager;
    private BackgroundManager backgroundManager;
    private CirclesInstantiator circlesInstantiator;
    private List<GameObject> circles = new List<GameObject>();
    private List<GameObject> coinsObjects = new List<GameObject>();
    private List<GameObject> badCirclesObjects = new List<GameObject>();
    private List<GameObject> goodCirclesObjects = new List<GameObject>();
    private int lastTappedCircleOrder = 0;
    private bool isPaused;
    private Rage currentRage;
    private RageMode rageMode;
    private RageModeResult rageModeResult;
    private bool wasRestartForAds;
    private SoundManager soundManager;
    private bool soundOn;
    private TutorialManager tutorialManager;
    private RewardedAd rewardedAd;
    private bool adAllowed;

    private int baseChanceCoinInCirclePercent;
    private int baseCountCoinsInCircle;
    private int baseChanceCoinOnFieldPercent;
    private int baseMaxCoinsCountOnField;
    private float baseCoinTimeOfLife;
    private int comboToRage;
    private int lossesToGameOver;
    private int baseChanceToBadCircle;
    private int baseChanceToGoodCircle;
    private int baseMaxCountBadCircle = 1;
    private int baseMaxCountGoodCircle = 1;
    private int baseCircleTapCost;
    private float baseCircleTimeOfLife;
    private float cameraSizeCoef;

    private float curDelay;
    private float maxDelay;

    private float milisecs;

    private const int maxPoitsCoinsValue = 999999999;
}

public enum GameState : int
{ 
    mainMenu = 0,
    playingNormal,
    playingRage,
    gameOver,
    beforeRageMode,
    afterRageMode,
    win
}

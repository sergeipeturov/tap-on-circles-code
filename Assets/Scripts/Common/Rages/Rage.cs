using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour
{
    public delegate void RageDone(RageModeResult result, int points, int bonusPoints, int coins, int bonusCoins);
    public event RageDone RageDoneNotify;

    protected CirclesInstantiator _circlesInstantiator;
    protected UIManager _uIManager;
    protected AchievementsModel _achievementsModel;
    protected SoundManager _soundManager;

    public int Points 
    { 
        get { return points; } 
        set 
        { 
            points = value; 
            _uIManager?.SetPointsTextRage(points); 
        } 
    }
    public int BonusPoints { get; set; }
    public int Coins { get; set; }
    public int BonusCoins { get; set; }

    public int Stage 
    { 
        get { return stage; } 
        set 
        { 
            stage = value;
            lastTappedCircleOrder = 0;
            currentTimeBetweenStages = 0.0f;
            if (stage < maxStage) 
                StageState = RageStageState.setup; 
            else 
                RaiseRageDone(); 
        } 
    }

    public RageStageState StageState { get { return stageState; } set { stageState = value; } }

    private void Start()
    {
        
    }

    public void SetModel(CirclesInstantiator circlesInstantiator, UIManager uIManager, AchievementsModel achievementsModel, SoundManager soundManager)
    {
        _circlesInstantiator = circlesInstantiator; _uIManager = uIManager; _achievementsModel = achievementsModel; _soundManager = soundManager;
        modeResult = RageModeResult.ideal;
    }

    public void GoRage()
    {
        Points = 0;
        Coins = 100;
        _uIManager.SetCoinsTextRage(Coins);
        BonusCoins = 1000;
        _uIManager.SetBonusCoinsTextRage(BonusCoins);
        Stage = 1;
        //isOn = true;
        modeResult = RageModeResult.ideal;
    }

    public void SetTapCost(int newTapCost)
    {
        tapCost = newTapCost * 5;
    }

    protected virtual void Rage_CircleEventNotify(GameObject gameObject, bool isTapEvent)
    {
        if (isTapEvent)
        {
            _soundManager.PlayCircleBlow();
            Points += gameObject.GetComponent<CircleObjectScript>().TapCost;
            if (gameObject.GetComponent<CircleObjectScript>().Order != lastTappedCircleOrder + 1)
            {
                modeResult = RageModeResult.done;
            }

            lastTappedCircleOrder = gameObject.GetComponent<CircleObjectScript>().Order;
        }
        else
        {
            ClearField();
            modeResult = RageModeResult.fail;
            RaiseRageDone();
        }

        gameObject.GetComponent<CircleObjectScript>().CircleEventNotify -= Rage_CircleEventNotify;
        circles.Remove(gameObject);
        GameObject.Destroy(gameObject);
    }

    protected GameObject InstantiateCircleObject(float sizeChangeInSecond, float circleSize, float xPos, float yPos, int order, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        var circle = _circlesInstantiator.InstantiateCircleObject(sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);
        circle.GetComponent<CircleObjectScript>().CircleEventNotify += Rage_CircleEventNotify;
        return circle;
    }

    protected GameObject InstantiateCircleObjectRandomPosition(List<GameObject> circles, float sizeChangeInSecond, float circleSize, int order, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float xPos = Random.Range(-2, 2);
        float yPos = Random.Range(-4, 2);
        var circle = _circlesInstantiator.InstantiateCircleObject(sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);

        //проверка на то, чтобы круг не появился точно внутри другого круга
        while (circles.Any(x => x.transform.position.x == circle.transform.position.x && x.transform.position.y == circle.transform.position.y))
        {
            Destroy(circle);
            xPos = Random.Range(-2, 2);
            yPos = Random.Range(-4, 2);
            circle = _circlesInstantiator.InstantiateCircleObject(sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);
        }

        circle.GetComponent<CircleObjectScript>().CircleEventNotify += Rage_CircleEventNotify;
        return circle;
    }

    protected GameObject InstantiateCircleObjectRandomPositionWithMaths(List<GameObject> circles, float sizeChangeInSecond, float circleSize, int order, int complexity = 1, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float xPos = Random.Range(-2, 2);
        float yPos = Random.Range(-4, 2);
        var circle = _circlesInstantiator.InstantiateCircleObjectWithMaths(sizeChangeInSecond, circleSize, xPos, yPos, order, complexity, tapCost, moving, moveSpeed, moveTime);

        //проверка на то, чтобы круг не появился точно внутри другого круга
        while (circles.Any(x => x.transform.position.x == circle.transform.position.x && x.transform.position.y == circle.transform.position.y))
        {
            Destroy(circle);
            xPos = Random.Range(-2, 2);
            yPos = Random.Range(-4, 2);
            circle = _circlesInstantiator.InstantiateCircleObjectWithMaths(sizeChangeInSecond, circleSize, xPos, yPos, order, complexity, tapCost, moving, moveSpeed, moveTime);
        }

        circle.GetComponent<CircleObjectScript>().CircleEventNotify += Rage_CircleEventNotify;
        return circle;
    }

    protected GameObject InstantiateCircleObjectRandomPositionWithRims(List<GameObject> circles, float sizeChangeInSecond, float circleSize, int order, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float xPos = Random.Range(-2, 2);
        float yPos = Random.Range(-4, 2);
        var circle = _circlesInstantiator.InstantiateCircleObjectWithRims(sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);

        //проверка на то, чтобы круг не появился точно внутри другого круга
        while (circles.Any(x => x.transform.position.x == circle.transform.position.x && x.transform.position.y == circle.transform.position.y))
        {
            Destroy(circle);
            xPos = Random.Range(-2, 2);
            yPos = Random.Range(-4, 2);
            circle = _circlesInstantiator.InstantiateCircleObjectWithRims(sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);
        }

        circle.GetComponent<CircleObjectScript>().CircleEventNotify += Rage_CircleEventNotify;
        return circle;
    }

    protected GameObject InstantiateCircleObjectRandomPositionInAdditionalMode(List<GameObject> circles, AdditionalModeType type, float sizeChangeInSecond, float circleSize, int order, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float xPos = Random.Range(-2, 2);
        float yPos = Random.Range(-4, 2);
        var circle = _circlesInstantiator.InstantiateCircleObjectInAdditionalMode(type, sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);

        //проверка на то, чтобы круг не появился точно внутри другого круга
        while (circles.Any(x => x.transform.position.x == circle.transform.position.x && x.transform.position.y == circle.transform.position.y))
        {
            Destroy(circle);
            xPos = Random.Range(-2, 2);
            yPos = Random.Range(-4, 2);
            circle = _circlesInstantiator.InstantiateCircleObjectInAdditionalMode(type, sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving, moveSpeed, moveTime);
        }

        circle.GetComponent<CircleObjectScript>().CircleEventNotify += Rage_CircleEventNotify;
        return circle;
    }

    protected GameObject InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(float sizeChangeInSecond, float circleSize, float centerX, float centerY,
        float angle, float radius, int order, bool moveLeft = true, float moveSpeed = 0.5f, bool moving = false)
    {
        float xPos = centerX + Mathf.Cos(angle) * radius;
        float yPos = centerY + Mathf.Sin(angle) * radius;
        var circle = _circlesInstantiator.InstantiateCircleObject(sizeChangeInSecond, circleSize, xPos, yPos, order, tapCost, moving);
        circle.GetComponent<CircleObjectScript>().CircleEventNotify += Rage_CircleEventNotify;
        circle.GetComponent<CircleObjectScript>().MoveAround(radius, angle, moveLeft, moveSpeed);
        return circle;
    }

    protected virtual void OnStageStateChanged() { }

    protected void RaiseRageDone()
    {
        StageState = RageStageState.end;
        if (modeResult == RageModeResult.fail)
        {
            Points = 0; BonusPoints = 0; Coins = 0; BonusCoins = 0;
            _uIManager.SetCoinsTextRage(Coins);
        }
        if (modeResult == RageModeResult.done)
        {
            BonusPoints = 0; BonusCoins = 0;
            _achievementsModel.CollectDoneRage(rageIndex);
            _achievementsModel.CollectDoneRageByRound(rageIndex);
        }
        if (modeResult == RageModeResult.ideal)
        {
            _achievementsModel.CollectDoneRage(rageIndex);
            _achievementsModel.CollectIdealRage(rageIndex);
            _achievementsModel.CollectDoneRageByRound(rageIndex);
        }
        RageDoneNotify?.Invoke(modeResult, Points, BonusPoints, Coins, BonusCoins);
    }

    protected void ChangingOrders(bool reverse = false)
    {
        if (!reverse)
        {
            if (circles.Any())
            {
                int next = 0;
                int prev = circles[0].GetComponent<CircleObjectScript>().Order;
                for (int i = 0; i < circles.Count; i++)
                {
                    bool isLast = i == circles.Count - 1;
                    if (!isLast)
                    {
                        next = circles[i + 1].GetComponent<CircleObjectScript>().Order;
                        circles[i + 1].GetComponent<CircleObjectScript>().Order = prev;
                        prev = next;
                    }
                    else
                    {
                        next = circles[0].GetComponent<CircleObjectScript>().Order;
                        circles[0].GetComponent<CircleObjectScript>().Order = prev;
                        prev = next;
                    }
                }
            }
        }
        else
        {
            if (circles.Any())
            {
                int next = 0;
                int prev = circles[circles.Count - 1].GetComponent<CircleObjectScript>().Order;
                for (int i = circles.Count - 1; i >= 0; i--)
                {
                    bool isLast = i == 0;
                    if (!isLast)
                    {
                        next = circles[i - 1].GetComponent<CircleObjectScript>().Order;
                        circles[i - 1].GetComponent<CircleObjectScript>().Order = prev;
                        prev = next;
                    }
                    else
                    {
                        next = circles[circles.Count - 1].GetComponent<CircleObjectScript>().Order;
                        circles[circles.Count - 1].GetComponent<CircleObjectScript>().Order = prev;
                        prev = next;
                    }
                }
            }
        }
    }

    private void ClearField()
    {
        foreach (var item in circles)
        {
            item.GetComponent<CircleObjectScript>().CircleEventNotify -= Rage_CircleEventNotify;
            GameObject.Destroy(item);
        }
        circles.Clear();
    }

    private int points;
    private int lastTappedCircleOrder;
    private RageModeResult modeResult;
    private int stage; 
    private RageStageState stageState;

    protected List<GameObject> circles = new List<GameObject>();
    //protected List<CircleObjectScript> circleObjects = new List<CircleObjectScript>();
    protected int maxStage;
    protected float maxTimeBetweenStages;
    protected float currentTimeBetweenStages;
    protected int tapCost;
    protected int rageIndex;
}

public enum RageStageState : int
{ 
    setup = 0,
    plaing,
    end
}

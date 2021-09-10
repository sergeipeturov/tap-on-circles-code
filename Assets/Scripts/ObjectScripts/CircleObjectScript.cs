using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObjectScript : MonoBehaviour
{
    public delegate void CircleEvent(GameObject gameObject, bool isTapEvent);
    public event CircleEvent CircleEventNotify;

    public GameObject[] Coins;

    public float Size { get; set; }
    public float SizeWithCoeff { get; set; }
    public float SizeChangeInSecond { get; set; }
    public float SizeChangeInSecondWithCoeff { get; set; }
    public float ColorChangeFloat { get; set; }
    
    /// <summary>
    /// Если Order = 0, то это Good Circle
    /// Если Order = -1, то это Bad Circle
    /// </summary>
    public int Order 
    { 
        get { return order; } 
        set 
        { 
            order = value;
            if (!additionalMode)
            {
                if (order > 0)
                    NumberText.GetComponent<TextMesh>().text = order.ToString();
                else if (order == 0)
                    NumberText.GetComponent<TextMesh>().text = "*";
                else if (order == -1)
                    NumberText.GetComponent<TextMesh>().text = "X";
            }
        } 
    }

    public bool Moving { get; set; }
    public CircleState CurrentState { get; set; }
    public int TapCost { get; set; }
    public int TapCostInCoins { get; set; } //сколько монет дается за шар (0 - 10)

    /// <summary>
    /// Отвечает ли на тапы. Нужно, чтобы пофиксить баг, когда тап засчитывается, хотя круг еще не появился визуально
    /// </summary>
    public bool IsTappable { get; set; }

    private void Awake()
    {
        NumberText = transform.Find("Text");
        transform.Find("Additional").gameObject.SetActive(false);
        IsTappable = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;

        if (timeSpent >= timeWhenIsNotTappable)
            IsTappable = true;

        Size -= SizeChangeInSecond * Time.deltaTime;
        //Size -= SizeChangeInSecondWithCoeff * Time.deltaTime;
        //SizeWithCoeff -= SizeChangeInSecondWithCoeff * Time.deltaTime;
        SizeWithCoeff -= SizeChangeInSecond * Time.deltaTime;
        ApplyNewSize();
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.red, timeSpent * ColorChangeFloat);
        bool isOverSize = isGrows ? Size > minMaxSize : Size < minMaxSize;
        if (isOverSize)
        {
            CircleEventNotify?.Invoke(this.gameObject, false);
        }

        if (Moving)
        {
            MakeMoveDecisionAndMove();
            currentMovingTime++;
            if (currentMovingTime >= maxMovingTime)
            {
                currentMovingTime = 0.0f;
                CurrentState = CircleState.staying;
            }
        }

        if (movingAround)
        {
            float newX = centerX + Mathf.Cos(angle) * radius;
            float newY = centerY + Mathf.Sin(angle) * radius;
            transform.position = new Vector3(newX, newY, 0.0f);
            if (movingAroundLeft)
                angle += Time.deltaTime * moveSpeed;
            else
                angle -= Time.deltaTime * moveSpeed;
            if (angle >= 360.0f)
            {
                angle = 0.0f;
            }
        }
    }

    public void SetModel(float sizeChangeInSecond, float sizeChangeInSecondWithCoeff, float size, float sizeWithCoeff, int order, int tapCost = 1, int tapCostInCoins = 0, bool isMoving = true, float _moveSpeed = 0.5f, float _maxMovingTime = 100.0f)
    {
        isGrows = sizeChangeInSecond < 0;
        minMaxSize = isGrows ? 0.8f : 0.05f;
        Size = size; 
        SizeWithCoeff = sizeWithCoeff;
        SizeChangeInSecond = sizeChangeInSecond; 
        SizeChangeInSecond = sizeChangeInSecondWithCoeff;
        Order = order;
        Moving = isMoving;
        moveSpeed = _moveSpeed;
        maxMovingTime = _maxMovingTime;
        //NumberText.GetComponent<TextMesh>().text = Order.ToString();
        ApplyNewSize(true);
        timeSpent = 0.0f;
        CurrentState = CircleState.staying;
        TapCost = tapCost;
        TapCostInCoins = tapCostInCoins;
        if (tapCostInCoins > Coins.Length) tapCostInCoins = Coins.Length;
        for (int i = 0; i < tapCostInCoins; i++)
        {
            Coins[i].SetActive(true);
        }
    }

    public void SetModelWithMaths(float sizeChangeInSecond, float sizeChangeInSecondWithCoeff, float size, float sizeWithCoeff, int order, int complexity = 1, int tapCost = 1, int tapCostInCoins = 0, bool isMoving = true, float _moveSpeed = 0.5f, float _maxMovingTime = 100.0f)
    {
        SetAdditionalModeOn(AdditionalModeType.maths, null);
        isGrows = sizeChangeInSecond < 0;
        minMaxSize = isGrows ? 0.8f : 0.05f;
        Size = size;
        SizeWithCoeff = sizeWithCoeff;
        SizeChangeInSecond = sizeChangeInSecond;
        SizeChangeInSecond = sizeChangeInSecondWithCoeff;
        Order = order;
        Moving = isMoving;
        moveSpeed = _moveSpeed;
        maxMovingTime = _maxMovingTime;
        //NumberText.GetComponent<TextMesh>().text = Order.ToString();
        ApplyNewSize(true);
        timeSpent = 0.0f;
        CurrentState = CircleState.staying;
        TapCost = tapCost;
        TapCostInCoins = tapCostInCoins;
        if (tapCostInCoins > Coins.Length) tapCostInCoins = Coins.Length;
        for (int i = 0; i < tapCostInCoins; i++)
        {
            Coins[i].SetActive(true);
        }

        //придумываем формулу вместо порядкового номера
        switch (complexity)
        {
            case 1: //только + и -
                NumberText.GetComponent<TextMesh>().text = FormulaGenerator.GenerateSimpleFormula(Order);
                break;
            case 2: //все операции

                break;
            default:
                break;
        }
    }

    public void SetModelWithRims(float sizeChangeInSecond, float sizeChangeInSecondWithCoeff, float size, float sizeWithCoeff, int order, int tapCost = 1, int tapCostInCoins = 0, bool isMoving = true, float _moveSpeed = 0.5f, float _maxMovingTime = 100.0f)
    {
        SetAdditionalModeOn(AdditionalModeType.rims, null);
        isGrows = sizeChangeInSecond < 0;
        minMaxSize = isGrows ? 0.8f : 0.05f;
        Size = size;
        SizeWithCoeff = sizeWithCoeff;
        SizeChangeInSecond = sizeChangeInSecond;
        SizeChangeInSecond = sizeChangeInSecondWithCoeff;
        Order = order;
        Moving = isMoving;
        moveSpeed = _moveSpeed;
        maxMovingTime = _maxMovingTime;
        //NumberText.GetComponent<TextMesh>().text = Order.ToString();
        ApplyNewSize(true);
        timeSpent = 0.0f;
        CurrentState = CircleState.staying;
        TapCost = tapCost;
        TapCostInCoins = tapCostInCoins;
        if (tapCostInCoins > Coins.Length) tapCostInCoins = Coins.Length;
        for (int i = 0; i < tapCostInCoins; i++)
        {
            Coins[i].SetActive(true);
        }
        NumberText.GetComponent<TextMesh>().text = FormulaGenerator.GenerateRimNum(Order);
    }

    public void OnTap()
    {
        if (IsTappable)
            CircleEventNotify?.Invoke(this.gameObject, true);
    }

    public void MoveAround(float _radius, float _startAngle, bool _moveLeft = true, float _speed = 0.5f,  float _centerX = 0.0f, float _centerY = 0.0f)
    {
        movingAround = true; 
        radius = _radius;
        centerX = _centerX; 
        centerY = _centerY;
        angle = _startAngle;
        moveSpeed = _speed;
        movingAroundLeft = _moveLeft;
    }

    public void MoveTo(Vector3 target)
    {
        GetComponent<Rigidbody2D>().AddForce(target, ForceMode2D.Impulse);
    }

    public void ChangeMass(float newMass)
    {
        GetComponent<Rigidbody2D>().mass = newMass;
    }

    public void SetAdditionalModeOn(AdditionalModeType type, Sprite sprite)
    {
        additionalMode = true;
        switch (type)
        {
            case AdditionalModeType.maths:
            case AdditionalModeType.rims:
                NumberText.gameObject.SetActive(true);
                break;
            case AdditionalModeType.geometric:
            case AdditionalModeType.mirror:
                NumberText.gameObject.SetActive(false);
                transform.Find("Additional").gameObject.SetActive(true);
                transform.Find("Additional").gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                break;
        }
    }

    public void SetAdditionalModeOff()
    {
        additionalMode = false;
        transform.Find("Additional").gameObject.SetActive(false);
        NumberText.gameObject.SetActive(true);
    }

    private void ApplyNewSize(bool isFromSetModel = false)
    {
        transform.localScale = new Vector3(Size, SizeWithCoeff, Size);
        //transform.localScale = new Vector3(Size, Size, Size);
        //ResizeWithScreenRatio();
        if (isFromSetModel) ColorChangeFloat = (0.4f - Size + 1) * 0.2f * (0.05f - SizeChangeInSecond + 1.5f);
        if (Size < -0.05)
        {
            //CircleEventNotify?.Invoke(this.gameObject, false);
            Destroy(gameObject);
        }
    }

    private void MakeMoveDecisionAndMove()
    {
        if (CurrentState == CircleState.staying)
        {
            CurrentState = CircleState.moving;
            moveDirection = Directions.GetRandomDirection();
        }
        if (CurrentState == CircleState.moving)
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CurrentState = CircleState.staying;
        /*if (collision.gameObject.name == "WallLeft")
            moveDirection = Vector3.right;
        if (collision.gameObject.name == "WallRight")
            moveDirection = Vector3.left;
        if (collision.gameObject.name == "WallUp")
            moveDirection = Vector3.down;
        if (collision.gameObject.name == "WallDown")
            moveDirection = Vector3.up;*/
        moveDirection = -moveDirection;
    }

    /*private void ResizeWithScreenRatio()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;
        //transform.localScale = new Vector3(1, 1, 1);

        float scaleXCoef = transform.localScale.x;
        scaleXCoef = 1 / scaleXCoef;
        float scaleYCoef = transform.localScale.y;
        scaleYCoef = 1 / scaleYCoef;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width / scaleXCoef;
        transform.localScale = xWidth;
        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height / scaleYCoef;
        transform.localScale = yHeight;
        //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y);
    }*/

    private float timeSpent;
    private Transform NumberText;
    private float moveSpeed = 0.5f;
    private float currentMovingTime = 0.0f;
    private float maxMovingTime = 100.0f;
    private Vector3 moveDirection;
    private float minMaxSize = 0.05f;
    private bool isGrows = false;
    private bool movingAround = false;
    private bool movingAroundLeft = true;
    private float angle = 0.0f;
    private float radius = 2.0f;
    private float centerX = 0.0f;
    private float centerY = 0.0f;
    private bool additionalMode = false;
    private int order;
    private float timeWhenIsNotTappable = 0.15f;
}

public enum CircleState: int
{
    staying = 0,
    moving
}

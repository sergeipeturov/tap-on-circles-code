using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObjectScript : MonoBehaviour
{
    public delegate void CircleEvent(GameObject gameObject, bool isTapEvent);
    public event CircleEvent CircleEventNotify;

    public int Cost { get; set; }

    public float TimeOfLife { get; set; }

    public CircleState CurrentState { get; set; }

    public float SizeScreenRatioCoeff { get; set; }

    private void Awake()
    {
        NumberText = transform.Find("Text");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        if (timeSpent > TimeOfLife)
        {
            CircleEventNotify?.Invoke(this.gameObject, false);
        }

        MakeMoveDecisionAndMove();
        currentMovingTime++;
        if (currentMovingTime >= maxMovingTime)
        {
            currentMovingTime = 0.0f;
            CurrentState = CircleState.staying;
        }
    }

    public void SetModel(int cost, float timeOfLife, float sizeScreenRatioCoeff)
    {
        SizeScreenRatioCoeff = sizeScreenRatioCoeff;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * sizeScreenRatioCoeff, transform.localScale.z);

        Cost = cost;
        TimeOfLife = timeOfLife;
        NumberText.GetComponent<TextMesh>().text = $"{Cost.ToString()}c";
        timeSpent = 0.0f;
        CurrentState = CircleState.staying;
    }

    public void OnTap()
    {
        CircleEventNotify?.Invoke(this.gameObject, true);
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
        moveDirection = -moveDirection;
    }

    private float timeSpent;
    private Transform NumberText;
    private float moveSpeed = 3.0f;
    private float currentMovingTime = 0.0f;
    private float maxMovingTime = 10.0f;
    private Vector3 moveDirection;
}

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CirclesInstantiator : MonoBehaviour
{
    public GameObject CircleObjectPrefab;
    public GameObject CoinObjectPrefab;

    public Sprite OneCorner;
    public Sprite TwoCorner;
    public Sprite ThreeCorner;
    public Sprite FourCorner;
    public Sprite FiveCorner;
    public Sprite SixCorner;
    public Sprite OneMirror;
    public Sprite TwoMirror;
    public Sprite ThreeMirror;
    public Sprite FourMirror;
    public Sprite FiveMirror;
    public Sprite SixMirror;
    public Sprite SevenMirror;

    public float CameraSizeCoef { get; set; } = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject InstantiateCircleObject(float sizeChangeInSecond, float circleSize, int order, int tapCost = 1, int tapCostInCoins = 0, bool isMoving = true, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float xPos = Random.Range(-2, 2);
        float yPos = Random.Range(-4, 2);

        float _sizeChangeInSecond = sizeChangeInSecond * CameraSizeCoef;
        float _circleSize = circleSize * CameraSizeCoef;

        Vector3 instantiatePosition = new Vector3(xPos, yPos, 0f);
        GameObject circleObject = Instantiate(CircleObjectPrefab, instantiatePosition, Quaternion.identity) as GameObject;
        circleObject.transform.localScale = new Vector3(circleSize, _circleSize, circleSize);
        //circleObject.GetComponent<SpriteRenderer>().sprite.rect.size = 
        //    new Vector2(circleObject.GetComponent<SpriteRenderer>().sprite.rect.size.x * CameraSizeCoef, circleObject.GetComponent<SpriteRenderer>().sprite.rect.size.y * CameraSizeCoef);
        circleObject.GetComponent<CircleObjectScript>().SetModel(sizeChangeInSecond, _sizeChangeInSecond, circleSize, _circleSize, order, tapCost, tapCostInCoins, isMoving, moveSpeed, moveTime);
        return circleObject;
    }

    public GameObject InstantiateCircleObject(float sizeChangeInSecond, float circleSize, float xPos, float yPos, int order, int tapCost = 5, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float _sizeChangeInSecond = sizeChangeInSecond * CameraSizeCoef;
        float _circleSize = circleSize * CameraSizeCoef;

        Vector3 instantiatePosition = new Vector3(xPos, yPos, 0f);
        GameObject circleObject = Instantiate(CircleObjectPrefab, instantiatePosition, Quaternion.identity) as GameObject;
        circleObject.transform.localScale = new Vector3(_circleSize, _circleSize, _circleSize);
        circleObject.GetComponent<CircleObjectScript>().SetModel(sizeChangeInSecond, _sizeChangeInSecond, circleSize, _circleSize, order, tapCost, 0, moving, moveSpeed, moveTime);
        return circleObject;
    }

    public GameObject InstantiateCircleObjectInAdditionalMode(AdditionalModeType type, float sizeChangeInSecond, float circleSize, float xPos, float yPos, int order, int tapCost = 5, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float _sizeChangeInSecond = sizeChangeInSecond * CameraSizeCoef;
        float _circleSize = circleSize * CameraSizeCoef;

        Vector3 instantiatePosition = new Vector3(xPos, yPos, 0f);
        GameObject circleObject = Instantiate(CircleObjectPrefab, instantiatePosition, Quaternion.identity) as GameObject;
        circleObject.transform.localScale = new Vector3(_circleSize, _circleSize, _circleSize);
        circleObject.GetComponent<CircleObjectScript>().SetModel(sizeChangeInSecond, _sizeChangeInSecond, circleSize, _circleSize, order, tapCost, 0, moving, moveSpeed, moveTime);
        switch (type)
        {
            case AdditionalModeType.geometric:
                switch (order)
                {
                    case 1:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, OneCorner);
                        break;
                    case 2:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, TwoCorner);
                        break;
                    case 3:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, ThreeCorner);
                        break;
                    case 4:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, FourCorner);
                        break;
                    case 5:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, FiveCorner);
                        break;
                    case 6:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, SixCorner);
                        break;
                    default:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, OneCorner);
                        break;
                }
                break;
            case AdditionalModeType.mirror:
                switch (order)
                {
                    case 1:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, OneMirror);
                        break;
                    case 2:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, TwoMirror);
                        break;
                    case 3:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, ThreeMirror);
                        break;
                    case 4:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, FourMirror);
                        break;
                    case 5:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, FiveMirror);
                        break;
                    case 6:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, SixMirror);
                        break;
                    case 7:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, SevenMirror);
                        break;
                    default:
                        circleObject.GetComponent<CircleObjectScript>().SetAdditionalModeOn(type, OneMirror);
                        break;
                }
                break;
        }
        return circleObject;
    }

    public GameObject InstantiateCircleObjectWithMaths(float sizeChangeInSecond, float circleSize, float xPos, float yPos, int order, int complexity = 1, int tapCost = 5, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float _sizeChangeInSecond = sizeChangeInSecond * CameraSizeCoef;
        float _circleSize = circleSize * CameraSizeCoef;

        Vector3 instantiatePosition = new Vector3(xPos, yPos, 0f);
        GameObject circleObject = Instantiate(CircleObjectPrefab, instantiatePosition, Quaternion.identity) as GameObject;
        circleObject.transform.localScale = new Vector3(_circleSize, _circleSize, _circleSize);
        circleObject.GetComponent<CircleObjectScript>().SetModelWithMaths(sizeChangeInSecond, _sizeChangeInSecond, circleSize, _circleSize, order, complexity, tapCost, 0, moving, moveSpeed, moveTime);
        return circleObject;
    }

    public GameObject InstantiateCircleObjectWithRims(float sizeChangeInSecond, float circleSize, float xPos, float yPos, int order, int tapCost = 5, bool moving = false, float moveSpeed = 0.5f, float moveTime = 100.0f)
    {
        float _sizeChangeInSecond = sizeChangeInSecond * CameraSizeCoef;
        float _circleSize = circleSize * CameraSizeCoef;

        Vector3 instantiatePosition = new Vector3(xPos, yPos, 0f);
        GameObject circleObject = Instantiate(CircleObjectPrefab, instantiatePosition, Quaternion.identity) as GameObject;
        circleObject.transform.localScale = new Vector3(_circleSize, _circleSize, _circleSize);
        circleObject.GetComponent<CircleObjectScript>().SetModelWithRims(sizeChangeInSecond, _sizeChangeInSecond, circleSize, _circleSize, order, tapCost, 0, moving, moveSpeed, moveTime);
        return circleObject;
    }

    public GameObject InstantiateCoinObject(int cost, float timeOfLife, float sizeScreenRationCoeff)
    {
        float xPos = Random.Range(-2, 2);
        float yPos = Random.Range(-4, 2);

        Vector3 instantiatePosition = new Vector3(xPos, yPos, 0f);
        GameObject coinObject = Instantiate(CoinObjectPrefab, instantiatePosition, Quaternion.identity) as GameObject;
        coinObject.GetComponent<CoinObjectScript>().SetModel(cost, timeOfLife, sizeScreenRationCoeff);
        return coinObject;
    }
}

public enum AdditionalModeType : int
{
    geometric = 0,
    mirror,
    maths,
    rims
}

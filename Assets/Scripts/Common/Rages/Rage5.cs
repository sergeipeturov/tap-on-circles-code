using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage5 : Rage
{
    void Start()
    {
        rageIndex = 4;
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            maxDelayBetweenMovingForFirstStage = 50.0f;
            curDelayBetweenMoving = 0.0f;
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -2f, 2f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 2f, 0.5f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -2f, -0.5f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 2f, -2f, 4));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -2f, -3.5f, 5));
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            maxDelayBetweenMovingForSecondStage = 30.0f;
            curDelayBetweenMoving = 25.0f;

            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -2f, 1.5f, 1));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.15f, 0.0f, 0.0f, 0.0f, 0.7f, 3, false, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.15f, 0.0f, 0.0f, 180.0f, 0.7f, 4, false, 1.5f));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 2f, -3f, 2));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            maxDelayBetweenMovingForThirdStage = 0.5f;
            curDelayBetweenMoving = -4.5f;
            thirdStageFlag1 = false;
            thirdStageFlag2 = false;

            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -0.15f, -3.91f, 1));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -0.18f, -0.79f, 2));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -0.71f, 0.11f, 3));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -1.28f, 0.99f, 4));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -1.71f, 2.03f, 5));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -0.65f, 2.03f, 6));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, 0.41f, 2.03f, 7));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, 1.46f, 2.03f, 8));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, 0.85f, 1.06f, 9));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, 0.31f, 0.14f, 10));
            circles.Add(InstantiateCircleObject(0.015f, 0.15f, -0.17f, 1.1f, 11));
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            curDelayBetweenMoving++;
            if (curDelayBetweenMoving <= maxDelayBetweenMovingForFirstStage) return;
            curDelayBetweenMoving = 0.0f;
            foreach (var item in circles)
            {
                if (item.transform.position.x < 0) item.GetComponent<CircleObjectScript>().MoveTo(Vector3.right * 10);
                if (item.transform.position.x > 0) item.GetComponent<CircleObjectScript>().MoveTo(Vector3.left * 10);
            }
        }

        if (Stage == 2 && StageState == RageStageState.plaing)
        {
            curDelayBetweenMoving++;
            if (curDelayBetweenMoving <= maxDelayBetweenMovingForSecondStage) return;
            curDelayBetweenMoving = 0.0f;
            foreach (var item in circles)
            {
                if (item.GetComponent<CircleObjectScript>().Order != 3 && item.GetComponent<CircleObjectScript>().Order != 4)
                {
                    if (item.transform.position.y > 0) item.GetComponent<CircleObjectScript>().MoveTo(Vector3.down * 10);
                    if (item.transform.position.y < 0) item.GetComponent<CircleObjectScript>().MoveTo(Vector3.up * 10);
                }
            }
        }

        if (Stage == 3 && StageState == RageStageState.plaing)
        {
            curDelayBetweenMoving++;
            if (curDelayBetweenMoving <= maxDelayBetweenMovingForThirdStage) return;
            curDelayBetweenMoving = 0.0f;
            if (!thirdStageFlag2)
            {
                if (!thirdStageFlag1)
                {
                    thirdStageFlag1 = !thirdStageFlag1;
                    var fc = circles.FirstOrDefault(x => x.GetComponent<CircleObjectScript>().Order == 1);
                    if (fc != null)
                    {
                        fc.GetComponent<CircleObjectScript>().MoveTo(Vector3.up * 20);
                    }
                }
                else
                {
                    thirdStageFlag2 = !thirdStageFlag2;
                    foreach (var item in circles)
                    {
                        if (item.GetComponent<CircleObjectScript>().Order != 1)
                        {
                            item.GetComponent<CircleObjectScript>().MoveTo(Directions.GetRandomDirection() * 10);
                        }
                    }
                }
            }
        }

        if (StageState == RageStageState.plaing)
        {
            if (!circles.Any())
            {
                Stage++;
            }
        }

        //if (Stage == maxStage - 1 && StageState == RageStageState.end)
        //{
        //    RaiseRageDone();
        //}
    }

    private float curDelayBetweenMoving = 0.0f;
    private float maxDelayBetweenMovingForFirstStage = 30.0f;
    private float maxDelayBetweenMovingForSecondStage = 30.0f;
    private float maxDelayBetweenMovingForThirdStage = 30.0f;
    private bool thirdStageFlag1 = false;
    private bool thirdStageFlag2 = false;
}

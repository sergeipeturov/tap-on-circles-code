using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage9 : Rage
{
    void Start()
    {
        rageIndex = 8;
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            maxTimeBetweenCirclesInFirstStage = 50.0f;
            currentTimeBetweenCircles = 0.0f;
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, 1.85f, 2.28f, 1));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, 0.78f, 1.22f, 2));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, -0.36f, 0.26f, 3));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, -1.39f, -0.84f, 4));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, 0.12f, -1.06f, 5));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, 1.56f, -1.16f, 6));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, 0.7f, -2.5f, 7));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, -0.48f, -3.41f, 8));
            circles.Add(InstantiateCircleObject(0.02f, 0.2f, -1.64f, -4.25f, 9));
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            maxTimeBetweenCirclesInSecondStage = 50.0f;
            currentTimeBetweenCircles = 0.0f;
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, -1.9f, 1.24f, 1));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, -0.93f, 0.04f, 2));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, 0.05f, -1.11f, 3));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, 1.04f, -2.18f, 4));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, 1.91f, -3.42f, 5));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, 1.91f, 1.14f, 6));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, 1.0f, 0.0f, 7));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, -0.96f, -2.27f, 8));
            circles.Add(InstantiateCircleObject(0.025f, 0.2f, -1.9f, -3.44f, 9));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            maxTimeBetweenCirclesInThirdStage = 50.0f;
            currentTimeBetweenCircles = 0.0f;
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 1));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 2));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 3));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 4));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 5));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 6));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 7));
            circles.Add(InstantiateCircleObjectRandomPosition(circles, 0.02f, 0.2f, 8));
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            currentTimeBetweenCircles++;
            if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInFirstStage) return;
            currentTimeBetweenCircles = 0.0f;
            ChangingOrders();
        }

        if (Stage == 2 && StageState == RageStageState.plaing)
        {
            currentTimeBetweenCircles++;
            if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInSecondStage) return;
            currentTimeBetweenCircles = 0.0f;
            ChangingOrders();
        }

        if (Stage == 3 && StageState == RageStageState.plaing)
        {
            currentTimeBetweenCircles++;
            if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInThirdStage) return;
            currentTimeBetweenCircles = 0.0f;
            ChangingOrders();
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

    private float currentTimeBetweenCircles;
    private float maxTimeBetweenCirclesInFirstStage;
    private float maxTimeBetweenCirclesInSecondStage;
    private float maxTimeBetweenCirclesInThirdStage;
}

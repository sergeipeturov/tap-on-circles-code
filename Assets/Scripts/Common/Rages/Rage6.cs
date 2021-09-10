using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage6 : Rage
{
    void Start()
    {
        rageIndex = 5;
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            curOrderForFirstStage = 0;
            maxTimeBetweenCirclesInFirstStage = 40.0f;
            currentTimeBetweenCircles = 38.0f;
            maxOrderForFirstStage = Random.Range(8, 10);
            tappedsForFirstStage = 0;
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            curOrderForSecondStage = 0;
            maxTimeBetweenCirclesInSecondStage = 20.0f;
            currentTimeBetweenCircles = 18.0f;
            maxOrderForSecondStage = Random.Range(8, 10);
            tappedsForSecondStage = 0;
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            maxTimeBetweenCirclesInThirdStage = 100.0f;
            tappedsForThirdStage = 0;
            curOrderForThirdStage = 1;
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            if (curOrderForFirstStage <= maxOrderForFirstStage)
            {
                currentTimeBetweenCircles++;
                if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInFirstStage) return;
                currentTimeBetweenCircles = 0.0f;
                curOrderForFirstStage++;
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForFirstStage, 1, true));
            }

            if (!circles.Any() && tappedsForFirstStage >= maxOrderForFirstStage)
            {
                Stage++;
            }
        }

        if (Stage == 2 && StageState == RageStageState.plaing)
        {
            if (curOrderForSecondStage <= maxOrderForSecondStage)
            {
                currentTimeBetweenCircles++;
                if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInSecondStage) return;
                currentTimeBetweenCircles = 0.0f;
                curOrderForSecondStage++;
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForSecondStage, 1, true));
            }

            if (!circles.Any() && tappedsForSecondStage >= maxOrderForSecondStage)
            {
                Stage++;
            }
        }

        if (Stage == 3 && StageState == RageStageState.plaing)
        {
            if (curOrderForThirdStage == 1)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 2)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 3)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 4)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }

            currentTimeBetweenCircles++;
            if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInThirdStage) return;
            currentTimeBetweenCircles = 0.0f;

            if (thirdStageFlag)
            {
                if (curOrderForThirdStage == 9)
                {
                    circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 10)
                {
                    circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 11)
                {
                    circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 12)
                {
                    circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                    curOrderForThirdStage++;
                }
            }

            if (curOrderForThirdStage == 5)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 6)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 7)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 8)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithMaths(circles, 0.025f, 0.2f, curOrderForThirdStage, 1, true));
                curOrderForThirdStage++;
            }
            if (curOrderForThirdStage == 9) thirdStageFlag = true;

            if (!circles.Any() && tappedsForThirdStage >= 12)
            {
                Stage++;
            }
        }

        if (Stage != 1 && Stage != 2 && Stage != 3 && StageState == RageStageState.plaing)
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

    protected override void Rage_CircleEventNotify(GameObject gameObject, bool isTapEvent)
    {
        if (Stage == 1) tappedsForFirstStage++;
        if (Stage == 2) tappedsForSecondStage++;
        if (Stage == 3) tappedsForThirdStage++;
        base.Rage_CircleEventNotify(gameObject, isTapEvent);
    }

    private int tappedsForFirstStage;
    private int tappedsForSecondStage;
    private int tappedsForThirdStage;
    private int curOrderForFirstStage;
    private int curOrderForSecondStage;
    private int curOrderForThirdStage;
    private int maxOrderForFirstStage;
    private int maxOrderForSecondStage;
    private float currentTimeBetweenCircles;
    private float maxTimeBetweenCirclesInFirstStage;
    private float maxTimeBetweenCirclesInSecondStage;
    private float maxTimeBetweenCirclesInThirdStage;
    private bool thirdStageFlag = false;
}

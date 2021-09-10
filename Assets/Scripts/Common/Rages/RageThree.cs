using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageThree : Rage
{
    //TODO: разобраться, почему иногда обнуляет набранные очки
    void Start()
    {
        rageIndex = 2;
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            curOrderForFirstStage = 1;
            currentTimeBetweenCircles = 0.0f;
            maxTimeBetweenCirclesInFirstStage = 8.0f;
            maxOrderForFirstStage = Random.Range(20, 26);
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            curOrderForSecondStage = 0;
            maxTimeBetweenCirclesInSecondStage = 15.0f;
            maxOrderForSecondStage = Random.Range(8, 12);
            tappedsForSecondStage = 0;
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            //curOrderForSecondStage = 0;
            maxTimeBetweenCirclesInThirdStage = 70.0f;
            tappedsForThirdStage = 0;
            curOrderForThirdStage = 1;
            sizeChangeForThirdStage = -0.3f;
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            if (curOrderForFirstStage <= maxOrderForFirstStage)
            {
                if (!circles.Any())
                {
                    //TODO: добавить рандомное появление круга, на который нельзя нажимать (после того, как такие круги сделаю в основном режиме)
                    currentTimeBetweenCircles++;
                    if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInFirstStage) return;
                    currentTimeBetweenCircles = 0.0f;
                    circles.Add(InstantiateCircleObject(-2.0f, 0.05f, 0f, 0f, curOrderForFirstStage));
                }
            }
            else
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
                circles.Add(InstantiateCircleObjectRandomPosition(circles, - 1.0f, 0.05f, curOrderForSecondStage));
            }

            if (!circles.Any() && tappedsForSecondStage >= maxOrderForSecondStage)
            {
                Stage++;
            }
        }

        if (Stage == 3 && StageState == RageStageState.plaing)
        {
            //if (curOrderForSecondStage <= maxOrderForSecondStage)
            //{
                if (curOrderForThirdStage == 1)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 1));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 2)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 2));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 3)
                { 
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 3));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 4)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 4));
                    curOrderForThirdStage++;
                }
                    
                currentTimeBetweenCircles++;
                if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInThirdStage) return;
                currentTimeBetweenCircles = 0.0f;

                if (curOrderForThirdStage == 5)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 5));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 6)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 6));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 7)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 7));
                    curOrderForThirdStage++;
                }
                if (curOrderForThirdStage == 8)
                {
                    circles.Add(InstantiateCircleObjectRandomPosition(circles, sizeChangeForThirdStage, 0.05f, 8));
                    curOrderForThirdStage++;
                }
            //}

            if (!circles.Any() && tappedsForThirdStage >= 8)
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
        if (Stage == 1) curOrderForFirstStage++;
        if (Stage == 2) tappedsForSecondStage++;
        if (Stage == 3) tappedsForThirdStage++;
        base.Rage_CircleEventNotify(gameObject, isTapEvent);
    }

    private int curOrderForFirstStage = 1;
    private int maxOrderForFirstStage;
    private float currentTimeBetweenCircles = 0.0f;
    private float maxTimeBetweenCirclesInFirstStage = 8.0f;
    private float maxTimeBetweenCirclesInSecondStage = 12.0f;
    private float maxTimeBetweenCirclesInThirdStage = 30.0f;
    private int curOrderForSecondStage = 0;
    private int maxOrderForSecondStage;
    private int tappedsForSecondStage = 0;
    private int tappedsForThirdStage = 0;
    private int curOrderForThirdStage = 1;
    private float sizeChangeForThirdStage = -0.7f;
}

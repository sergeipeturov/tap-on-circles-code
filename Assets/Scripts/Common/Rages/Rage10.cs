using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage10 : Rage
{
    void Start()
    {
        rageIndex = 9;
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            maxTimeBetweenCirclesInFirstStage = 100.0f;
            tappedsForFirstStage = 0;
            curOrderForFirstStage = 1;
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 150, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 151, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 152, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 153, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 154, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 155, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 156, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 157, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 158, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 159, true));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 1595, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 1596, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 1597, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 1598, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 1599, true));
            circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, 1600, true));
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            if (curOrderForFirstStage == 1)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 2)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 3)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 4)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }

            currentTimeBetweenCircles++;
            if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInFirstStage) return;
            currentTimeBetweenCircles = 0.0f;
            
            if (curOrderForFirstStage == 5)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 6)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 7)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 8)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 9)
            {
                circles.Add(InstantiateCircleObjectRandomPositionWithRims(circles, 0.03f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }

            if (!circles.Any() && tappedsForFirstStage >= 9)
            {
                Stage++;
            }
        }

        if (Stage != 1 && StageState == RageStageState.plaing)
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
        base.Rage_CircleEventNotify(gameObject, isTapEvent);
    }

    private int tappedsForFirstStage;
    private int curOrderForFirstStage;
    private float currentTimeBetweenCircles;
    private float maxTimeBetweenCirclesInFirstStage;
}

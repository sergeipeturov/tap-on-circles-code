using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage4 : Rage
{
    void Start()
    {
        rageIndex = 3;
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 0.0f, 2.0f, 1, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 0.7f, 2.0f, 2, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 1.4f, 2.0f, 3, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 2.1f, 2.0f, 4, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 2.8f, 2.0f, 5, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 3.5f, 2.0f, 6, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 4.2f, 2.0f, 7, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 4.9f, 2.0f, 8, false, 0.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 5.6f, 2.0f, 9, false, 0.5f));
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 0.0f, 2.0f, 6, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 0.7f, 2.0f, 7, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 1.4f, 2.0f, 8, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 2.1f, 2.0f, 9, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 2.8f, 2.0f, 1, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 3.5f, 2.0f, 2, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 4.2f, 2.0f, 3, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 4.9f, 2.0f, 4, true, 1.5f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.05f, 0.2f, 0.0f, 0.0f, 5.6f, 2.0f, 5, true, 1.5f));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            var orders = Randomizer.GetArrayOfRandomOrders(9);

            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 0.0f, 2.0f, orders[0], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 0.7f, 2.0f, orders[1], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 1.4f, 2.0f, orders[2], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 2.1f, 2.0f, orders[3], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 2.8f, 2.0f, orders[4], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 3.5f, 2.0f, orders[5], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 4.2f, 2.0f, orders[6], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 4.9f, 2.0f, orders[7], false, 1.0f));
            circles.Add(InstantiateCircleObjectByCenterAngleRadiusAndMoveAround(0.03f, 0.2f, 0.0f, 0.0f, 5.6f, 2.0f, orders[8], false, 1.0f));
            StageState = RageStageState.plaing;
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
}

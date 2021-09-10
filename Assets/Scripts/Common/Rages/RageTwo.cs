using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageTwo : Rage
{
    void Start()
    {
        rageIndex = 1;
        maxStage = 5;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, 0.5f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, 0f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, -0.5f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, -1f, 4));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, 0.5f, 8));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, 0f, 7));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, -0.5f, 6));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, -1f, 5));
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, 0.5f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, 0f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, -0.5f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, -1f, 4));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, 0.5f, 5));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, 0f, 6));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, -0.5f, 7));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, -1f, 8));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, 0.5f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, 0f, 6));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, -0.5f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.3f, -1f, 8));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, 0.5f, 5));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, 0f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, -0.5f, 7));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.8f, -1f, 4));
            StageState = RageStageState.plaing;
        }

        if (Stage == 4 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            var orders = Randomizer.GetArrayOfRandomOrders(8);

            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -1.3f, 0.5f, orders[0]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -1.3f, 0f, orders[1]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -1.3f, -0.5f, orders[2]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -1.3f, -1f, orders[3]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 1.8f, 0.5f, orders[4]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 1.8f, 0f, orders[5]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 1.8f, -0.5f, orders[6]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 1.8f, -1f, orders[7]));
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

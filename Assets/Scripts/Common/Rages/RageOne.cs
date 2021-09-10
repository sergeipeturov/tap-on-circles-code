using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageOne : Rage
{
    void Start()
    {
        rageIndex = 0;
        maxStage = 5;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.8f, 1f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -0.7f, 2f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 0.8f, 2f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.9f, 1f, 4));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.8f, -1f, 8));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -0.7f, -2f, 7));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 0.8f, -2f, 6));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.9f, -1f, 5));
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.8f, 1f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -0.7f, 2f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 0.8f, 2f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.9f, 1f, 4));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.8f, -1f, 5));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -0.7f, -2f, 6));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 0.8f, -2f, 7));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.9f, -1f, 8));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.8f, 1f, 1));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -0.7f, 2f, 6));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 0.8f, 2f, 3));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.9f, 1f, 8));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -1.8f, -1f, 5));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, -0.7f, -2f, 2));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 0.8f, -2f, 7));
            circles.Add(InstantiateCircleObject(0.05f, 0.2f, 1.9f, -1f, 4));
            StageState = RageStageState.plaing;
        }

        if (Stage == 4 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            var orders = Randomizer.GetArrayOfRandomOrders(8);

            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -1.8f, 1f, orders[0]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -0.7f, 2f, orders[1]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 0.8f, 2f, orders[2]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 1.9f, 1f, orders[3]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -1.8f, -1f, orders[4]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, -0.7f, -2f, orders[5]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 0.8f, -2f, orders[6]));
            circles.Add(InstantiateCircleObject(0.03f, 0.2f, 1.9f, -1f, orders[7]));
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

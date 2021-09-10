using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage11 : Rage
{
    /*void Start()
    {
        maxStage = 4;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 100;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 1));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 2));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 3));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 4));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 5));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 6));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 7));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 8));
            circles.Add(InstantiateCircleObjectRandomPosition(0.002f, 0.2f, 9));
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 1));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 2));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 3));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 4));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 5));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 6));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 7));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 8));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 9));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 1));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 2));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 3));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 4));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 5));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 6));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 7));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 8));
            circles.Add(InstantiateCircleObjectRandomPosition(0.05f, 0.2f, 9));
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            foreach (var item in circles)
            {
                item.transform.RotateAround(Vector3.zero, Vector3.up, 40 * Time.deltaTime);
            }
        }

        if (Stage == 2 && StageState == RageStageState.plaing)
        {
            foreach (var item in circles)
            {
                item.transform.RotateAround(Vector3.zero, Vector3.up, 40 * Time.deltaTime);
            }
        }

        if (Stage == 3 && StageState == RageStageState.plaing)
        {
            foreach (var item in circles)
            {
                item.transform.RotateAround(Vector3.zero, Vector3.up, 60 * Time.deltaTime);
            }
        }

        if (StageState == RageStageState.plaing)
        {
            if (!circles.Any())
            {
                Stage++;
            }
        }

        if (Stage == maxStage - 1 && StageState == RageStageState.end)
        {
            RaiseRageDone();
        }
    }*/
}

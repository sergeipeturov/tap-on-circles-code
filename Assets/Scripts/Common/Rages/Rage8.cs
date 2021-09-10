using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage8 : Rage
{
    void Start()
    {
        rageIndex = 7;
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

            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 1, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 2, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 3, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 4, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 5, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 6, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, 7, true));
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 1, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 2, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 3, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 4, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 5, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 6, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.05f, 0.2f, 7, true));
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            if (curOrderForFirstStage == 1)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 2)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 3)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }

            currentTimeBetweenCircles++;
            if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInFirstStage) return;
            currentTimeBetweenCircles = 0.0f;

            if (curOrderForFirstStage == 4)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 5)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 6)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }
            if (curOrderForFirstStage == 7)
            {
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.mirror, 0.025f, 0.2f, curOrderForFirstStage, true));
                curOrderForFirstStage++;
            }

            if (!circles.Any() && tappedsForFirstStage >= 7)
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

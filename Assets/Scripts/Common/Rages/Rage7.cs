using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage7 : Rage
{
    void Start()
    {
        rageIndex = 6;
        maxStage = 5;
        maxTimeBetweenStages = 10.0f;
        BonusPoints = 1000;
        _uIManager.SetBonusPointsTextRage(BonusPoints);
    }

    void Update()
    {
        if (Stage == 1 && StageState == RageStageState.setup)
        {
            curOrderForFirstStage = 0;
            maxTimeBetweenCirclesInFirstStage = 25.0f;
            currentTimeBetweenCircles = 22.0f;
            maxOrderForFirstStage = 6;
            tappedsForFirstStage = 0;
            StageState = RageStageState.plaing;
        }

        if (Stage == 2 && StageState == RageStageState.setup)
        {
            curOrderForSecondStage = 0;
            maxTimeBetweenCirclesInSecondStage = 15.0f;
            currentTimeBetweenCircles = 12.0f;
            maxOrderForSecondStage = 6;
            tappedsForSecondStage = 0;
            StageState = RageStageState.plaing;
        }

        if (Stage == 3 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.03f, 0.2f, 1, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.03f, 0.2f, 2, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.03f, 0.2f, 3, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.03f, 0.2f, 4, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.03f, 0.2f, 5, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.03f, 0.2f, 6, true));
            StageState = RageStageState.plaing;
        }

        if (Stage == 4 && StageState == RageStageState.setup)
        {
            currentTimeBetweenStages++;
            if (currentTimeBetweenStages <= maxTimeBetweenStages) return;

            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, 1, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, 2, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, 3, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, 4, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, 5, true));
            circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, 6, true));
            StageState = RageStageState.plaing;
        }

        if (Stage == 1 && StageState == RageStageState.plaing)
        {
            if (curOrderForFirstStage < maxOrderForFirstStage)
            {
                currentTimeBetweenCircles++;
                if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInFirstStage) return;
                currentTimeBetweenCircles = 0.0f;
                curOrderForFirstStage++;
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, curOrderForFirstStage, true));
            }

            if (!circles.Any() && tappedsForFirstStage >= maxOrderForFirstStage)
            {
                Stage++;
            }
        }

        if (Stage == 2 && StageState == RageStageState.plaing)
        {
            if (curOrderForSecondStage < maxOrderForSecondStage)
            {
                currentTimeBetweenCircles++;
                if (currentTimeBetweenCircles <= maxTimeBetweenCirclesInSecondStage) return;
                currentTimeBetweenCircles = 0.0f;
                curOrderForSecondStage++;
                circles.Add(InstantiateCircleObjectRandomPositionInAdditionalMode(circles, AdditionalModeType.geometric, 0.05f, 0.2f, curOrderForSecondStage, true));
            }

            if (!circles.Any() && tappedsForSecondStage >= maxOrderForSecondStage)
            {
                Stage++;
            }
        }

        if (Stage != 1 && Stage != 2 && StageState == RageStageState.plaing)
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
        //if (Stage == 3) tappedsForThirdStage++;
        base.Rage_CircleEventNotify(gameObject, isTapEvent);
    }

    private int tappedsForFirstStage;
    private int tappedsForSecondStage;
    //private int tappedsForThirdStage;
    private int curOrderForFirstStage;
    private int curOrderForSecondStage;
    //private int curOrderForThirdStage;
    private int maxOrderForFirstStage;
    private int maxOrderForSecondStage;
    private float currentTimeBetweenCircles;
    private float maxTimeBetweenCirclesInFirstStage;
    private float maxTimeBetweenCirclesInSecondStage;
    //private float maxTimeBetweenCirclesInThirdStage;
    //private bool thirdStageFlag = false;
}

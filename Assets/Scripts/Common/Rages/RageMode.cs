using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageMode : MonoBehaviour
{
    private CirclesInstantiator _circlesInstantiator;
    private UIManager _uIManager;
    private AchievementsModel _achievementsModel;
    private SoundManager _soundManager;

    public Rage[] Rages;

    public void SetModel(CirclesInstantiator circlesInstantiator, UIManager uIManager, AchievementsModel achievementsModel, SoundManager soundManager)
    {
        _circlesInstantiator = circlesInstantiator; _uIManager = uIManager; _achievementsModel = achievementsModel; _soundManager = soundManager;
        foreach (var rage in Rages)
        {
            rage.SetModel(_circlesInstantiator, _uIManager, _achievementsModel, _soundManager);
        }
    }

    public Rage GetRandomRage(int tapCost)
    {
        int rageIndex = Mathf.FloorToInt(Random.Range(0, Rages.Length));
        while (rageIndex == lastRageIndex)
        {
            rageIndex = Mathf.FloorToInt(Random.Range(0, Rages.Length));
        }
        lastRageIndex = rageIndex;
        //rageIndex = 9; //test
        var res = Rages[rageIndex];
        res.SetTapCost(tapCost);
        _achievementsModel.CollectPlayedRage(rageIndex);
        return res;
        //return Rages[5];
    }

    private int lastRageIndex = -1;
}

public enum RageModeResult: int
{
    fail = 0,
    done,
    ideal
}

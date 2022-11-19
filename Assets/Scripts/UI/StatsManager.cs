using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public CharacterMovement Player;
    public Slider OxygenLevel;
    public Slider HeatLevel;

    void Start()
    {
        Player = FindObjectOfType<CharacterMovement>();
        OxygenLevel.maxValue = Player.MaxAir;
        HeatLevel.maxValue = Player.MaxHeat;
    }

    void Update()
    {
        OxygenLevel.value = Player.AirCapacity;
        HeatLevel.value = Player.HeatMeter;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class PowerupController : MonoBehaviour
{
    private TankData data;

    public List<Powerups> powerups = new List<Powerups>();

    void Start()
    {
        data = GetComponent<TankData>();
    }

    void Update()
    {
        List<Powerups> expired = new List<Powerups>();

        foreach(Powerups power in powerups)
        {
            power.duration -= Time.deltaTime;

            if (power.duration <= 0)
                expired.Add(power);
        }

        foreach(Powerups expPower in expired)
        {
            expPower.OnDeactivate(data);
            powerups.Remove(expPower);
        }

        expired.Clear();
    }

    //Adds powerups, only tracks temp
    public void AddPowerup(Powerups power)
    {
        power.OnActivate(data);

        if (!power.isPerm)
            powerups.Add(power);
    }
}
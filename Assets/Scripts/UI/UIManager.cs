using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public List<GameObject> tankShells = new List<GameObject>();
    public List<GameObject> tankLives = new List<GameObject>();

    public Slider tankHealth;
    public Slider tankFuel;

    private TankData data;
    private PlayerScore score;

    private bool hasStarted = false;

    private void Update()
    {
        StartUpCode();
        HealthAndFuel();
        StatChange();
    }

    private void StartUpCode()
    {
        if (GameManager.Instance.players.Count != 0 && hasStarted == false)
        {
            data = GameManager.Instance.players[0].GetComponent<TankData>();

            tankHealth.maxValue = data.maxHealth;
            tankFuel.maxValue = data.maxFuel;

            LivesAndBullets(tankShells, data.ammo);
            LivesAndBullets(tankLives, GameManager.Instance.lives[0]);

            hasStarted = true;
        }
    }

    private void LivesAndBullets(List<GameObject> list, int max)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i < max)
                list[i].SetActive(true);
            else
                list[i].SetActive(false);
        }
    }

    private void HealthAndFuel()
    {
        tankFuel.value = data.curFuel;
        tankHealth.value = data.curHealth;
    }

    public void StatChange()
    {
        LivesAndBullets(tankShells, data.ammo);
        LivesAndBullets(tankLives, GameManager.Instance.lives[0]);
    }
}

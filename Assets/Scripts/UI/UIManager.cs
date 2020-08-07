using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    //lists of images for shells and remaining lives
    public List<GameObject> tankShells = new List<GameObject>();
    public List<GameObject> tankLives = new List<GameObject>();

    //health and fuel bars
    public Slider tankHealth;
    public Slider tankFuel;

    //Text for score to change
    public TextMeshProUGUI scoreText;

    //scripts
    private TankData data;
    private PlayerScore score;

    //For startupcode
    private bool hasStarted = false;

    //Calls all the functions
    private void Update()
    {
        StartUpCode();
        HealthAndFuel();
        StatChange();
        scoreText.text = "Score: " + score.playerScoreData.playerScore.ToString("N0");
        Debug.Log(score.playerScoreData.playerScore.ToString("N0"));
    }

    //Runs the startup code, I tried putting in start, but no matter where i put it 
    //in the execution order it did not work
    private void StartUpCode()
    {
        if (GameManager.Instance.players.Count != 0 && hasStarted == false)
        {
            data = GameManager.Instance.players[0].GetComponent<TankData>();
            score = GameManager.Instance.players[0].GetComponent<PlayerScore>();

            tankHealth.maxValue = data.maxHealth;
            tankFuel.maxValue = data.maxFuel;

            LivesAndBullets(tankShells, data.ammo);
            LivesAndBullets(tankLives, GameManager.Instance.lives[0]);

            hasStarted = true;
        }
    }

    //updates the bullets remaining and the lives
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

    //updates the health and fuel bars
    private void HealthAndFuel()
    {
        tankFuel.value = data.curFuel;
        tankHealth.value = data.curHealth;
    }

    //changes stats from outside script
    public void StatChange()
    {
        LivesAndBullets(tankShells, data.ammo);
        LivesAndBullets(tankLives, GameManager.Instance.lives[0]);
    }
}

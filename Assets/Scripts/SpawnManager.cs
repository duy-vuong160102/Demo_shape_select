using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles, buttonPanels, players, grounds;

    [SerializeField] private float timeBetweenSpawns, timeIncrease, spawnPositionX;

    private Vector3 spawnPos;
    private int countOfSpawns = 0;
    private bool spawnChanged = false;

    [HideInInspector]
    public int spawnType = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        buttonPanels[0].SetActive(true);
        Spawn();
    }

    public void Spawn()
    {
        switch (spawnType)
        {
            case 0:
                Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
                break;
            case 1:
                if (!spawnChanged)
                {
                    // cho 2 button 
                    players[1].SetActive(true);
                    grounds[1].SetActive(true);
                    spawnChanged = true;
                    PanelSwitch1();
                    timeBetweenSpawns += timeIncrease * 1.4f;
                }
                else
                {
                    spawnPos = transform.position;
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
                    spawnPos.x = 0f - spawnPositionX;
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
                }
                break;

        }

        if (!FindObjectOfType<GameManager>().gameIsOver)
        {
            Invoke("Spawn", timeBetweenSpawns);
        }

        ChooseSpawnType();
        countOfSpawns++;
    }

    public void ChooseSpawnType()
    {
        if (countOfSpawns < 5)
        {
            spawnType = 0;
        }
        else
        {
            spawnType = 1;
        }
    }

    private void PanelSwitch1()
    {
        buttonPanels[0].SetActive(false);
        buttonPanels[1].SetActive(true);
    }
    private void PanelSwitch2()
    {
        buttonPanels[1].SetActive(false);
        buttonPanels[2].SetActive(true);
    }
}

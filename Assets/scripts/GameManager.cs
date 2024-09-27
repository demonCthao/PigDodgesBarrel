using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    private bool gameStart = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStart )
        {
            StartSpawning();
            gameStart = true;
            tapText.SetActive(false);
            scoreText.gameObject.SetActive(true);
            
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock",0.5f,spawnRate);
       
    }
    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        GameObject newspawn = Instantiate(block, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
        Destroy(newspawn,4);
    }

    
}

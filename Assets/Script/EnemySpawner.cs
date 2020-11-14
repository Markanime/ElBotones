using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Point
{
    public GameObject enemy;
    float time = 20;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Playing & !GameManager.GameOver)
        {
            if (time <= 0)
            {
                PutAGameObject(transform, enemy);
                time = Random.Range(GameManager.Level.enemySpawner - 10, GameManager.Level.enemySpawner);
            }
            time -= Time.deltaTime;
        }
    }
}

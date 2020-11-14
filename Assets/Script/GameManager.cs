using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance ?? (_instance = new GameObject(typeof(GameManager).Name).AddComponent(typeof(GameManager)) as GameManager);
    private static GameManager _instance;

    public static void Restart() => Instance.Restart_();
    public static void Pause() => Time.timeScale = Time.timeScale == 1 ? 0 : 1;
    public static void Stop() => Instance.playing = false;
    public static void Play() => Instance.playing = true;
    //Level info
    public static bool Playing => Instance.playing;
    public static Level Level => Instance.level;
    public static bool GameOver => Instance.gameOver;
    public static void ClearLevel(int score) => Instance.Clear_(score);
    public static void Fail() => Instance.FailComited();

    public Level level = new Level { speed = 20, throwDis = new Vector3(15,0,0), chekpointDis = new Vector3(15, 0, 0), enemySpawner = 20f};
    public bool playing = true;
    public bool gameOver = false;
    public int score = 0;
    public float time = 30;
    public int tries = 4;

    public void Restart_()
    {
        level = new Level { speed = 20, throwDis = new Vector3(15, 0, 0), chekpointDis = new Vector3(15, 0, 0), enemySpawner = 20f };
        playing = true;
        gameOver = false;
        score = 0;
        time = 30;
        tries = 4;
    }

public void Clear_(int score = 0)
    {
        time += 10 + (score*3);
        //level.angle -= level.angle > 4 ? 0.1f: 0;
        level.speed += 0.1f;
        level.chekpointDis += new Vector3(level.throwDis.x * 2f, 0, 0);
        level.enemySpawner -= level.enemySpawner > 5 ? 1 : 0;
    }
    public void FailComited()
    {
        tries--;
        this.score-= this.score > 0 ? 1 : 0;
    }
   
    void CheckGameOver()
    {
        gameOver = tries <= 0 | time <= 0;
        if (gameOver)
        {
            Stop();
            Debug.Log("Game Over");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
    }

    private void Start()
    {
        if (!_instance) _instance = this;
    }

    void Update()
    {
        if (playing)
        {
            time = time > 0 ? time - Time.deltaTime : 0;
            CheckGameOver();
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
[Serializable]
public struct Level
{
   // public float angle;
    public float speed;
    public Vector3 throwDis;
    public Vector3 chekpointDis;
    public float enemySpawner;
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource MusicGO;
    public AudioSource Ready;
    public AudioSource Go;
    public List<Text> mainTexts;
    public GameObject tutorial;
    public GameObject gameOver;
    public Text time;
    public Text life;
    public Text score;

    // Update is called once per frame
    void Update()
    {
        if (!gameOver.activeInHierarchy)
        {
            StartGame();
            time.text = GameManager.Instance.time.ToString("000");
            life.text = PrintHearts(GameManager.Instance.tries);
            score.text = string.Format("{0}$", GameManager.Instance.score * 5);
            if (GameManager.GameOver) gameOver.SetActive(true);
            Tutorial();
        }
        else
        {
            if (Music.isPlaying)
            {
                Music.volume -= Time.deltaTime;
                if (Music.volume <= 0)
                {
                    Music.Stop();
                    MusicGO.Play();
                }
            }
        }
    }

    float tutorial_time = 3;
    bool tutorial_show = true;
    void Tutorial()
    {
        if (GameManager.Playing & tutorial_show)
        {
            tutorial_time -= Time.deltaTime;
            if (tutorial_time < 0) tutorial.SetActive(true);
            if (Input.GetButton("boton") | Input.GetButtonDown("boton"))
            {
                tutorial_show = false;
                tutorial.SetActive(false);
            }
        }
    }

    bool gameStarted = false;
    float ready_time = 2;
    float go_time = 1;
    void StartGame()
    {
        if (!gameStarted) {
            if (GameManager.Playing)
                GameManager.Stop();
            if (ready_time > 1 & ready_time < 1.5f & !Ready.isPlaying)
                Ready.Play();
            ready_time -= Time.deltaTime;
            if (ready_time > 0)
                mainTexts.ForEach(t => t.text = "READY?");
            else
            {

                if (go_time >= 1) Go.Play();
                mainTexts.ForEach(t => t.text = "GO!");
                go_time -= Time.deltaTime;
                if (go_time <= 0)
                {
                    gameStarted = true;
                    mainTexts.ForEach(t => t.gameObject.SetActive(false));
                    Music.Play();
                    Music.volume = 0.5f;
                    GameManager.Play();
                }
            }
        }
    }

    string PrintHearts(int number=0)
    {
        string res = string.Empty;
        char heart = '❤';
        for (int i = 0; i < number; i++)
            res += heart;
        return res;
    }

    public void TryAgain()
    {
        GameManager.Restart();
        SceneFade.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

}

using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{
    public string text = "YOUR SCORE IS {0}";
    public float speed = 25;
    float score = 0;
    float finalscore = 0;
    float wait = 1;
    Text label;
    AudioSource sound;
    private void OnEnable()
    {
        finalscore = GameManager.Instance.score * 5;
        wait = 1;
        label = GetComponent<Text>();
        label.text = string.Format(text, 0);
        score = 0;
        sound = GetComponent<AudioSource>();
    }

    int scoreInt = 0;
    void Update()
    {
        if (wait <= 0)
        {
            score = score <= finalscore ? score + Time.deltaTime * speed : finalscore;
            if(sound.isActiveAndEnabled)
                if (scoreInt < (int)score) sound.Play();
            scoreInt = (int)score;
            label.text = string.Format(text, scoreInt);
        }
        else
        {
            wait -= Time.deltaTime;
        }

    }
}

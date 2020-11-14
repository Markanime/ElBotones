using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator botones;
    float speed = 0;
    public AudioSource carritoClip;
    float maxVolumen = 0.7f;
    private void Update()
    {
        if (GameManager.GameOver)
        {
            speed = Mathf.MoveTowards(speed, 0, 1);
        }
        else if (GameManager.Playing)
        {
            if (Input.GetButton("boton") |Input.GetButtonDown("boton"))
            {
                speed = Mathf.MoveTowards(speed,GameManager.Level.speed,1);
            }
            else
            {
                speed = Mathf.MoveTowards(speed,0, 1); 
            }
        }
        if (speed > 0)
        {
            carritoClip.volume += carritoClip.volume < maxVolumen ?  Time.deltaTime : 0;
        }
        else
        {
            carritoClip.volume -= carritoClip.volume >= 0 ? Time.deltaTime : 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
        botones.SetFloat("speed", speed);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}

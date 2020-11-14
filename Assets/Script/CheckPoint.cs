using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : Point
{
    public GameObject showthis;
    public Transform showPoint;
    private List<GameObject> joints;
    private Animator current;
    private void Start()
    {
        joints = new List<GameObject>();
        Show();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            GameManager.Stop();
            player.GetComponent<Player>().SetSpeed(3);
            clear = true;
        }
        if(other.tag == "Joint")
        {
            if (!other.GetComponent<JointIt>().fallen)
            {
                other.GetComponent<JointIt>().cantfall = true;
                if (!joints.Contains(other.gameObject))
                    joints.Add(other.gameObject);
            }
        }
    }
    bool clear = false;
    GameObject player = null;
    private void Update()
    {
        if (clear)
        {
            if(player.transform.position.x > transform.position.x)
            {
                player.GetComponent<Player>().SetSpeed(0);
                clear = false;
                StartCoroutine(Clear(joints,current));
                joints = new List<GameObject>();
            }
        }
    }
    IEnumerator Clear(List<GameObject> joints, Animator anim)
    {
        int score = 0;
        foreach (GameObject joint in joints)
        {
            yield return new WaitForSeconds(0.25f);
            Destroy(joint);
            anim.SetTrigger("dollar");
            score++;
            GameManager.Instance.score++;
        }
        yield return new WaitForSeconds(0.5f);
        GameManager.ClearLevel(score);
        GameManager.Play();
        anim.SetTrigger("clear");
        MovePoint(GameManager.Level.chekpointDis);
        Show();
    }

    void Show()
    {
        var anim = PutAGameObject(showPoint, showthis).GetComponent<Animator>();
        if (anim) current = anim;
    }

}

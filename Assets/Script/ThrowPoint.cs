using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPoint : Point
{
    public GameObject throwthis;
    public GameObject showthis;
    public Transform throwPoint;
    public Transform showPoint;
    Animator current;
    private void Start()
    {
        Show();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (current) current.SetTrigger("open");
            Throw();
            Show();
        }
    }

    void Throw()
    {
        if (throwPoint & throwthis)
        {
            PutAGameObject(throwPoint, throwthis);
            MovePoint(GameManager.Level.throwDis);
        }
    }

    void Show()
    {
        if (showPoint & showthis)
        {
            GameObject ngo = PutAGameObject(showPoint, showthis);
            Animator anim = ngo.GetComponentInChildren<Animator>();
            if (anim)
                current = anim;
        }
    }
}


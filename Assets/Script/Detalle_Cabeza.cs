using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detalle_Cabeza : MonoBehaviour
{
    public Animator anim;
    GameObject current;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Joint")
        {
            if (current ? other.gameObject != current : true)
            {
                anim.SetTrigger("touch");
                current = other.gameObject;
            }
        }
    }

    public void Hit()
    {
        anim.SetTrigger("touch");
    }
}

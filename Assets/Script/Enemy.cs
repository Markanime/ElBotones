using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float force = 100;
    public float speed = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Joint")
        {
            var audio = GetComponent<AudioSource>();
            if (audio) if (!audio.isPlaying) audio.Play();
            var jointit = other.GetComponent<JointIt>();
            var hinge = other.GetComponent<HingeJoint>();
            if (hinge)
            {
                Destroy(hinge);
                var rigibody = other.GetComponent<Rigidbody>();
                if (rigibody)
                {
                    rigibody.AddExplosionForce(force, other.transform.position, force);
                }
                if (jointit)
                    jointit.exploded = 1;
            }
        }
        if(other.tag == "PlayerSon")
        {
            var parent = other.GetComponentInParent<Detalle_Cabeza>();
            var children = other.GetComponentInParent<Detalle_Cabeza>();
            if (parent)
                parent.Hit();
            else if (children)
                children.Hit();
        }
    }

    private void Update()
    {
        if (GameManager.Playing) transform.position += Vector3.down * Time.deltaTime * speed; 
    }
}

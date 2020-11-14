using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.position += new Vector3(1000, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Joint")
        {
            if (!collision.gameObject.GetComponent<JointIt>().cantfall)
            {
                collision.gameObject.GetComponent<JointIt>().fallen = true;
                GameManager.Fail();
            }
        }
    }
}

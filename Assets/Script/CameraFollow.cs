using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform toFollow;
    public float speed = 0;
    Transform me;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Transform>();
        offset = me.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        var nextPos = toFollow.position + offset;
        if (Vector3.Distance(me.position, nextPos) > 0.5f)
            me.position = Vector3.MoveTowards(me.position, nextPos, speed * Time.deltaTime);
        else
            me.position = nextPos;
    }
}

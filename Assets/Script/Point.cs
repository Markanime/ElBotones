using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    protected void MovePoint(Vector3 sum)
    {
        foreach (Point point in GameObject.FindObjectsOfType<Point>())
        {
            var next = transform.position + sum;
            if(!point.gameObject.Equals(this.gameObject) &&
                Vector3.Distance(next,point.transform.position) < 0.5f)
                MovePoint(sum * 2);
            else
                transform.position = next;
        }
    }

    protected GameObject PutAGameObject(Transform t, GameObject go)
    {
        Vector3 pos = t.position;
        GameObject ngo = Instantiate(go) as GameObject;
        ngo.transform.position = pos;
        return ngo;
    }
}

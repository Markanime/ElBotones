using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphic : MonoBehaviour
{
    Renderer render;
    bool apeared = false;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        if (!render)
            render = GetComponentInChildren<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (apeared) {
            if (!render.isVisible)
            {
                if (GetComponent<JointIt>())
                {
                    if(!GetComponent<JointIt>().cantfall)
                        GameManager.Fail();
                }
                Destroy(gameObject);
            }
        }
        else
        {
            if (render.isVisible)
                apeared = true;
        }
    }
}

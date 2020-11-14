using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]
public class RandomizeMaterial : MonoBehaviour
{
    public Material[] materials;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer render = GetComponent<MeshRenderer>();
        List<Material> mat = new List<Material>();
        for(int i=0; i < render.materials.Length; i++)
        {
            if (i == index)
                mat.Add(materials[Random.Range(0, materials.Length)]);
            else
                mat.Add(render.materials[i]);
        }
        GetComponent<MeshRenderer>().materials = mat.ToArray();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField]
    private Color[] colors;

    [SerializeField]
    private Shader[] shaders;

    [SerializeField]
    private Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        materials = GetComponent<MeshRenderer>().materials;

        colors = new Color[materials.Length];
        shaders = new Shader[materials.Length];

        for (int i = 0; i < materials.Length; i++)
        {
            shaders[i] = materials[i].shader;
            if (materials[i].HasProperty("_Color"))
                colors[i] = materials[i].color;
            materials[i].shader = Shader.Find("Custom/OutlineShader");
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

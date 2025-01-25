using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Material material;
    public float roationAngleX = 10.0f;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        material = Renderer.material;
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        transform.Rotate(roationAngleX * Time.deltaTime, 0.0f, 0.0f);
        InvokeRepeating("ChangeColor", 5, 10f);
    }

    void ChangeColor()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);
        float a = Random.Range(0.0f, 1.0f);
        material.color = new Color(r, g, b, a);
    }
}

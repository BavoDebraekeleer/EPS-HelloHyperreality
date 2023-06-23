using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMushroomColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void changeColor()
    {
        if (rend.material.name.Contains(material.name))
        {
            rend.material = material2;
        }
        else if (rend.material.name.Contains(material2.name))
        {
            rend.material = material3;
        }
        else if (rend.material.name.Contains(material3.name))
        {
            rend.material = material4;
        }
        else if (rend.material.name.Contains(material4.name))
        {
            rend.material = material5;
        }
        else if (rend.material.name.Contains(material5.name))
        {
            rend.material = material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

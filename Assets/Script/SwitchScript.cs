using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Color hitColor;
    private Color originalColor;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            

            if(renderer.material.color.Equals(originalColor))
            {
                renderer.material.color = hitColor;
            }
            else
            {
                renderer.material.color = hitColor;
            }
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            renderer.material.color = hitColor;
        }
    }

   
   
}

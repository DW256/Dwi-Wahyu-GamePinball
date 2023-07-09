using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Color hitColor;
    private Color originalColor;
    private Renderer ren;

    private void Start()
    {
        ren = GetComponent<Renderer>();
        originalColor = ren.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            

            if(ren.material.color.Equals(originalColor))
            {
                ren.material.color = hitColor;
            }
            else
            {
                ren.material.color = hitColor;
            }
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ren.material.color = hitColor;
        }
    }

   
   
}

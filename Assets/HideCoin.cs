using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCoin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Setelah bola bertabrakan dengan coin, nonaktifkan coin
            
            gameObject.SetActive(false);

        }
    }



}
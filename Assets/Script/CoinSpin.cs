using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void Update()
    {
        if(gameObject.activeInHierarchy== true || gameObject.activeInHierarchy == false)
        {
            // Mengatur rotasi koin pada sumbu x
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
        
    }
}

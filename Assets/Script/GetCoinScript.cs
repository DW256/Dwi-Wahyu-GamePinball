using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoinScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            audioSource.Play();
            
        }
    }
}

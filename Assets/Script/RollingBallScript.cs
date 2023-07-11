using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallScript : MonoBehaviour
{
    public AudioClip rollingClip;
    private AudioSource audioSource;
    private Rigidbody rb;
    private bool isRolling;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        isRolling = false;
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0f && !isRolling)
        {
            audioSource.time = 1f;
            audioSource.clip = rollingClip;
            audioSource.PlayScheduled(audioSource.time);
            
            audioSource.loop = true;
           
            isRolling = true;

        }
        else if (rb.velocity.magnitude == 0f && isRolling)
        {
            
            audioSource.Stop();
            isRolling = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BallReturner"))
        {
            audioSource.Stop();
            isRolling = false;
        }
    }


}

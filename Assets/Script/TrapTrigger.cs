using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{


    Vector3 ballPosition;

    private void Start()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        ballPosition = ball.transform.position;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            collision.gameObject.transform.position = ballPosition;

            gameObject.SetActive(false);


        }
    }
}

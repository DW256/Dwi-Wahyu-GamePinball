using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public float minForce = 100f; // Kekuatan minimum peluncuran
    public float maxForce = 500f; // Kekuatan maksimum peluncuran
    public float maxHoldDuration = 3f; // Durasi maksimum menahan tombol
    public float minYScale = 0.5f; // Skala minimum pada sumbu Y
    public float maxYScale = 1f; // Skala maksimum pada sumbu Y

    public Collider ball;
    public Transform pivot;

    private bool isLaunching = false;
    private float holdDuration = 0f;
    private Rigidbody ballRigidbody;
    private Vector3 initialScale;

    private bool isActive = false;

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider != ball) return;

        isActive = true;

        //Debug.Log("Enter");
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.collider != ball) return;

        isActive = false;

        //Debug.Log("Exit");
    }

    private void Start()
    {
        ballRigidbody = ball.attachedRigidbody;
        initialScale = pivot.localScale;
    }

    private void Update()
    {
        if (!isActive) return;

        if (Input.GetKeyDown(KeyCode.Space) && !isLaunching)
        {
            isLaunching = true;
            holdDuration = 0f;
        }

        if (Input.GetKey(KeyCode.Space) && isLaunching)
        {
            holdDuration += Time.deltaTime;
            holdDuration = Mathf.Clamp(holdDuration, 0f, maxHoldDuration);
            ScaleLauncher();
        }

        if (Input.GetKeyUp(KeyCode.Space) && isLaunching)
        {
            LaunchBall();
            isLaunching = false;
            ResetLauncherScale();
        }
    }

    private void ScaleLauncher()
    {
        float scale = Mathf.Lerp(minYScale, maxYScale, holdDuration / maxHoldDuration);
        Vector3 newScale = new Vector3(pivot.localScale.x, scale, pivot.localScale.z);
        pivot.localScale = newScale;
    }

    private void ResetLauncherScale()
    {
        pivot.localScale = initialScale;
    }

    private void LaunchBall()
    {
        float force = Mathf.Lerp(minForce, maxForce, holdDuration / maxHoldDuration);
        Vector3 launchDirection = pivot.up;
        ballRigidbody.AddForce(launchDirection * force);
    }
}

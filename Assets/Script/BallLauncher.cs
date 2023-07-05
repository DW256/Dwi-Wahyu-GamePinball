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

    private bool isLaunching = false;
    private float holdDuration = 0f;
    public Rigidbody ballRigidbody;
    private Vector3 initialScale;

    private void Start()
    {
       
        initialScale = transform.localScale;
    }

    private void Update()
    {
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
        Vector3 newScale = new Vector3(transform.localScale.x, scale, transform.localScale.z);
        transform.localScale = newScale;
    }

    private void ResetLauncherScale()
    {
        transform.localScale = initialScale;
    }

    private void LaunchBall()
    {
        float force = Mathf.Lerp(minForce, maxForce, holdDuration / maxHoldDuration);
        Vector3 launchDirection = transform.up;
        ballRigidbody.AddForce(launchDirection * force);
    }
}

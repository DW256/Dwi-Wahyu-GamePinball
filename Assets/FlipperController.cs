using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public KeyCode leftFlipperKey = KeyCode.A;
    public KeyCode rightFlipperKey = KeyCode.D;
    public float flipperForce = 1000f;
    public float maxRotationAngle = 45f;

    public Rigidbody leftFlipperRigidbody;
    public Rigidbody rightFlipperRigidbody;

   

    private void Update()
    {
        if (Input.GetKeyDown(leftFlipperKey))
        {
            leftFlipperRigidbody.AddTorque(Vector3.up * flipperForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(rightFlipperKey))
        {
            rightFlipperRigidbody.AddTorque(Vector3.up * -flipperForce, ForceMode.Impulse);
        }

        LimitFlipperRotation(leftFlipperRigidbody, -maxRotationAngle, 0f);
        LimitFlipperRotation(rightFlipperRigidbody, 0f, maxRotationAngle);
    }

    private void LimitFlipperRotation(Rigidbody flipperRigidbody, float minAngle, float maxAngle)
    {
        Quaternion rotation = Quaternion.Euler(0f, Mathf.Clamp(flipperRigidbody.rotation.eulerAngles.y, minAngle, maxAngle), 0f);
        flipperRigidbody.MoveRotation(rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public KeyCode flipperKey;
    public float flipperForce = 1000f;
    public float flipperRestPosition = 0f;
    public float flipperPressedPosition = 45f;

    private HingeJoint hingeJoint;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    private void Update()
    {
        if (Input.GetKey(flipperKey))
        {
            ApplyFlipperForce();
        }
        else
        {
            ResetFlipperPosition();
        }
    }

    private void ApplyFlipperForce()
    {
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = flipperForce;
        jointSpring.damper = 0f;
        jointSpring.targetPosition = flipperPressedPosition;
        hingeJoint.spring = jointSpring;
    }

    private void ResetFlipperPosition()
    {
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = flipperForce;
        jointSpring.damper = 0f;
        jointSpring.targetPosition = flipperRestPosition;
        hingeJoint.spring = jointSpring;
    }

}

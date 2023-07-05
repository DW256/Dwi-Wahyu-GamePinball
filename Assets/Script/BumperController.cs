using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    public float multiplier;

    public Color color;

    private Renderer r;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        r = GetComponent<Renderer>();
     
        r.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != ballCollider) return;

        Rigidbody ballRigidbody = collision.collider.attachedRigidbody;
        ballRigidbody.velocity *= multiplier;
        animator.SetTrigger("hit");
    }

}

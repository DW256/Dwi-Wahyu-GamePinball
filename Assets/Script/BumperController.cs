using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    public float multiplier;

    public Color[] color;
    public int colorIndex = 0;

    private Renderer r;
    private Animator animator;

    [SerializeField] private ScoringController scoring;

    public int point;

    private void Start()
    {
        animator = GetComponent<Animator>();
        r = GetComponent<Renderer>();

        r.material.color = color[colorIndex]; //set default color
        //r.material.SetColor("_Color", color[colorIndex]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != ballCollider) return;

        Rigidbody ballRigidbody = collision.collider.attachedRigidbody;
        ballRigidbody.velocity *= multiplier;
        animator.SetTrigger("hit");

        colorIndex = colorIndex + 1 < color.Length ? colorIndex + 1 : 0;
        r.material.color = color[colorIndex];


        scoring.AddScore(point);
    }

}

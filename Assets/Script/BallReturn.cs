using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 initialPosition;

    [SerializeField] private ScoringController scoring;
    void Start()
    {
        GameObject BallTransform = GameObject.FindGameObjectWithTag("Ball");
        initialPosition = BallTransform.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            scoring.ReduceLives();
            other.gameObject.transform.position = initialPosition;
        }
    }
}

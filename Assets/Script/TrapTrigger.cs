using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{

    public TrapSpawner spawner;
    Vector3 ballPosition;

    [SerializeField] private ScoringController scoring;


    private void Awake()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        ballPosition = ball.transform.position;

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.position = ballPosition;

            scoring.ReduceLives();

            //gameObject.SetActive(false);
            spawner.Despawn(gameObject);

        }
    }

    private void OnEnable()
    {
        StartCoroutine(AutoDespawn());
    }

    private IEnumerator AutoDespawn()
    {
        //Debug.Log(gameObject.name + " Start : " + Time.time);
        yield return new WaitForSeconds(spawner.inactiveDuration);
        //Debug.Log(gameObject.name + " End : " + Time.time);
        spawner.Despawn(gameObject);
    }

}

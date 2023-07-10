using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HideCoin : MonoBehaviour
{
    public CoinSpawner spawner;
    [SerializeField] private ScoringController scoring;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            scoring.AddScore(spawner.coinPoint);

            // Setelah bola bertabrakan dengan coin, nonaktifkan coin
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

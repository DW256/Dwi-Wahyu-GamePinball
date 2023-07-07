using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HideCoin : MonoBehaviour
{
    public CoinSpawner spawner;
    public float lifetime = 10f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
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
        yield return new WaitForSeconds(lifetime);
        //Debug.Log(gameObject.name + " End : " + Time.time);
        spawner.Despawn(gameObject);
    }


}

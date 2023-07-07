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

    private void Start()
    {
        StartCoroutine(AutoDespawn());
    }

    private IEnumerator AutoDespawn()
    {
        yield return new WaitForSeconds(lifetime);
        spawner.Despawn(gameObject);
    }


}

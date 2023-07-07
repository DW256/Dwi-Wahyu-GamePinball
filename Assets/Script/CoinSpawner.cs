using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coins;
    public float spawnInterval = 3f;
    public float inactiveDuration = 10f;
    public Transform spawnPoint;

    private float duration;


    private void Awake()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i].SetActive(false);
        }
    }


    private void Update()
    {
       duration = inactiveDuration - Time.deltaTime;

        if(duration <= 0)
        {
            inactiveDuration = 10f;

            
        }

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            // Cek jika masih ada coin yang aktif
            int activeCoinCount = 0;
            foreach (GameObject coin in coins)
            {
                if (coin.activeSelf)
                    activeCoinCount++;
            }

            // Spawn coin jika jumlah aktif kurang dari maksimal
            if (activeCoinCount < 3)
            {
                // Random coin dari array
                int randomIndex = Random.Range(0, coins.Length);
                GameObject coinToSpawn = coins[randomIndex];

                if(coinToSpawn.activeInHierarchy == false)
                {
                    coinToSpawn.SetActive(true);
                }

                if (duration <= 0)
                {
                    coinToSpawn.SetActive(false);
                    activeCoinCount--;
                }
                
            }

            // Jeda sebelum melakukan spawn kembali
            yield return new WaitForSeconds(spawnInterval);
        }
    }



}

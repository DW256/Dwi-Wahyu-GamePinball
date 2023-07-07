using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int maxCoin = 3;
    public float spawnInterval = 3f;
    public float inactiveDuration = 10f;
    public Transform spawnPoint;

    public List<GameObject> coins; //pool
    [SerializeField] private List<GameObject> coinsActive;


    private void Awake()
    {
        //Make sure all coins are deactivated
        for (int i = 0; i < coins.Count; i++)
        {
            coins[i].SetActive(false);
        }
    }

    public void Despawn(GameObject obj)
    {
        coinsActive.Remove(obj);
        obj.SetActive(false);
        coins.Add(obj);

        //respawn
        StartCoroutine(Respawn());
    }

    private void Spawn()
    {
        if (coinsActive.Count >= maxCoin) return;

        //Random coin dari list
        int rand = Random.Range(0, coins.Count);

        coins[rand].SetActive(true);
        coinsActive.Add(coins[rand]);
        coins.Remove(coins[rand]);

    }

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < maxCoin; i++)
        {
            yield return new WaitForSeconds(spawnInterval);
            Spawn();
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(spawnInterval);
        Spawn();
    }

    //private void Update()
    //{
    //   duration = inactiveDuration - Time.deltaTime;

    //    if(duration <= 0)
    //    {
    //        inactiveDuration = 10f;


    //    }

    //    StartCoroutine(SpawnCoins());
    //}

    //private IEnumerator SpawnCoins()
    //{
    //    while (true)
    //    {
    //        // Cek jika masih ada coin yang aktif
    //        int activeCoinCount = 0;
    //        foreach (GameObject coin in coins)
    //        {
    //            if (coin.activeSelf)
    //                activeCoinCount++;
    //        }

    //        // Spawn coin jika jumlah aktif kurang dari maksimal
    //        if (activeCoinCount < 3)
    //        {
    //            // Random coin dari array
    //            int randomIndex = Random.Range(0, coins.Count);
    //            GameObject coinToSpawn = coins[randomIndex];

    //            if(coinToSpawn.activeInHierarchy == false)
    //            {
    //                coinToSpawn.SetActive(true);
    //            }

    //            if (duration <= 0)
    //            {
    //                coinToSpawn.SetActive(false);
    //                activeCoinCount--;
    //            }

    //        }

    //        // Jeda sebelum melakukan spawn kembali
    //        yield return new WaitForSeconds(spawnInterval);
    //    }
    //}



}

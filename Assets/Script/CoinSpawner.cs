using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public int maxCoin = 3;
    public int coinPoint = 100;
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

}

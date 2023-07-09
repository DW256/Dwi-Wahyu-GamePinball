using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public int maxTrap = 3;
    public float spawnInterval = 3f;
    public float inactiveDuration = 10f;
    public Transform spawnPoint;

    public List<GameObject> traps; //pool
    [SerializeField] private List<GameObject> coinsActive;


    private void Awake()
    {
        //Make sure all coins are deactivated
        for (int i = 0; i < traps.Count; i++)
        {
            traps[i].SetActive(false);
        }
    }

    public void Despawn(GameObject obj)
    {
        coinsActive.Remove(obj);
        obj.SetActive(false);
        traps.Add(obj);

        //respawn
        StartCoroutine(Respawn());
    }

    private void Spawn()
    {
        if (coinsActive.Count >= maxTrap) return;

        //Random coin dari list
        int rand = Random.Range(0, traps.Count);

        traps[rand].SetActive(true);
        coinsActive.Add(traps[rand]);
        traps.Remove(traps[rand]);

    }

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < maxTrap; i++)
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

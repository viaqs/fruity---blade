using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider spawnArea;
    public GameObject[] fruits;
    public GameObject BombPrefab;
    public float BombChance = 0.005f;
    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 18f;
    public float maxForce = 22f;
    public float maxLifetime = 5f;

    public AudioSource audioSource;
    public AudioClip spawnSound;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
        
    }

    public void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (enabled)
           
        {   audioSource.PlayOneShot(spawnSound);
            audioSource.pitch = Random.Range(1f, 1.1f);
            GameObject prefab = fruits[Random.Range(0, fruits.Length)];

            if(Random.value < BombChance)
            {
                prefab = BombPrefab;
            }

            Vector3 position = new Vector3
            {
                x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            };

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject fruit = Instantiate(prefab, position, rotation);
            Destroy(fruit, maxLifetime);

            float force = Random.Range(minForce, maxForce);
            fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
}



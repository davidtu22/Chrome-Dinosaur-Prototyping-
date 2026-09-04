using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float spawnRate = 2f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCactus();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCactus();
            timer = 0;
        }
    }

    void SpawnCactus()
    {
        Instantiate(cactusPrefab, transform.position, transform.rotation);
    }



    }

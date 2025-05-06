using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 6;
    public float startDelay = 2;
    public float repeatRate = 2;

    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObjects", startDelay, repeatRate);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObjects() 
    {
        GameObject objects = ObjectPool.Instance.RequestObjects();
        objects.transform.position = GenerateSpawnPosition();
        gameManager.UpdateScore(1);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}

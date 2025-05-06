using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    public int poolSize = 10;
    [SerializeField] private List<GameObject> objectList;

    private static ObjectPool instance;

    public static ObjectPool Instance {  get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddObjectsToPool(poolSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddObjectsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject objects = Instantiate(objectPrefab);
            objects.SetActive(false);
            objectList.Add(objects);
            objects.transform.parent = transform;
        }
    }

    public GameObject RequestObjects()
    {
        for(int i = 0; i < objectList.Count; i++)
        {
            if (!objectList[i].activeSelf)
            {
                objectList[i].SetActive(true);
                return objectList[i];
            }
        }
        return null;
    }
}

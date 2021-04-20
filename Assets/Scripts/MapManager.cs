using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Chunk Variable")]
    [SerializeField] private GameObject[] chunks;
    [SerializeField] private Transform chunkParent;
    [SerializeField] private float mapSpeed;
    [SerializeField] private List<GameObject> chunkList = new List<GameObject>();
    [SerializeField] private Vector3 firstChunkSpawnLocation;

    [SerializeField] private float zLocation;
    [Header("Timer")]
    [SerializeField] private float timer;
    private float time;

    public bool bossFight = false;


    void Start()
    {
        SpawnFirstChunk();
        SpawnChunk();
    }

    void Update()
    {
        if (bossFight == false)
        {
            time = time + Time.deltaTime;
        }

        if(time >= timer)
        {
            SpawnChunk();
            time = 0;
        }

        StopMoving();

        DeSpawnChunks();
    }

    private void SpawnFirstChunk()
    {
        int random = Random.Range(0, chunks.Length);
        GameObject temp = chunks[random];
        GameObject GO = Instantiate(temp);

        Debug.Log(GO);
        GO.transform.position = firstChunkSpawnLocation;

        GO.name = "Chunk " + random;
        chunkList.Add(GO);

        Rigidbody rb = GO.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, mapSpeed), ForceMode.Impulse);

    }

    private void SpawnChunk()
    {
        int random = Random.Range(0, chunks.Length);
        GameObject temp = chunks[random];
        GameObject GO = Instantiate(temp);

        GO.transform.parent = chunkParent.transform;
        GO.transform.position = chunkParent.position;

        GO.name = "Chunk " + random;
        chunkList.Add(GO);

        Rigidbody rb = GO.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,0,mapSpeed), ForceMode.Impulse);

    }

    private void DeSpawnChunks()
    {
        for (int i = 0; i < chunkList.Count; i++)
        {
            if (chunkList[i] != null)
            {

                if (chunkList[i].transform.position.z >= zLocation)
                {
                    Debug.Log("despawning " + chunkList[i].name);
                    DestroyImmediate(chunkList[i]);
                    chunkList.Remove(chunkList[i--]);
                    continue;
                }
            }
            if (chunkList[i] == null)
            {
                chunkList.Remove(chunkList[i--]);
            }
        }
    }

    private void StopMoving()
    {
        if (bossFight == true)
        {
            for (int i = 0; i < chunkList.Count; i++)
            {
                Rigidbody rb = chunkList[i].GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}

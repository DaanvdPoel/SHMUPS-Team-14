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

    [Header("Camera Variable")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rect screenBounds = new Rect(0, 0, 1, 1f);

    [Header("Timer")]
    [SerializeField] private float timer;
    private float time;


    void Start()
    {
        SpawnFirstChunk();
        SpawnChunk();
    }

    void Update()
    {

        time = time + Time.deltaTime;

        if(time >= timer)
        {
            SpawnChunk();
            time = 0;
        }

        DeSpawnChunks();
    }

    private void SpawnFirstChunk()
    {
        int random = Random.Range(0, chunks.Length - 1);
        GameObject temp = chunks[random];
        GameObject GO = Instantiate(temp);

        GO.transform.position = firstChunkSpawnLocation;

        GO.name = "Chunk " + random;
        chunkList.Add(GO);

        Rigidbody rb = GO.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, mapSpeed), ForceMode.Impulse);

    }

    private void SpawnChunk()
    {
        int random = Random.Range(0, chunks.Length - 1);
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
                Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(chunkList[i].transform.position);

                if (viewPortPosition.y > screenBounds.y)
                {
                    DestroyImmediate(chunkList[i]);
                    chunkList.Remove(chunkList[i--]);
                    Debug.Log("despawning " + chunkList[i].name);
                    continue;
                }
            }
            if (chunkList[i] == null)
            {
                chunkList.Remove(chunkList[i--]);
            }
        }
    }
}

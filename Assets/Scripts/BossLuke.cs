using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLuke : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject tentacle;
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject warningArea;

    private float summonTimer;
    private float areaTimer;
    private int randomX;
    private int randomZ;
    private bool canWarn;
    private bool canWarnArea;
    private Vector3 tentPos;
    private Vector3 warnPos;
    private Vector3 areaPos;
    private Quaternion rotation;

    void Start()
    {
        canWarn = true;
        summonTimer = 5;
        areaTimer = 7;
    }

    void Update()
    {
        if (summonTimer < 0)
        {
            Summon();
            summonTimer = 10;
            canWarn = true;
        }
        else
        {
            summonTimer = summonTimer - Time.deltaTime;
        }

        if (summonTimer <= 5 && canWarn == true)
        {
            Warning();
            canWarn = false;
        }

        if (areaTimer < 0)
        {
            areaTimer = 20;
            canWarnArea = true;
        }
        else
        {
            areaTimer = areaTimer - Time.deltaTime;
        }

        if (areaTimer <= 7 && canWarnArea == true)
        {
            AOE();
            canWarnArea = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
        }
    }

    private void Summon()
    {
        rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(tentacle, tentPos, rotation);
    }

    private void Warning()
    {
        int randomX = Random.Range(-18, 18);
        int randomZ = Random.Range(-5, -20);
        tentPos = new Vector3(gameObject.transform.position.x + randomX, gameObject.transform.position.y, gameObject.transform.position.z + randomZ);
        warnPos = new Vector3(tentPos.x, tentPos.y - 3.5f, tentPos.z);
        Instantiate(warning, warnPos, rotation);
    }

    private void AOE()
    {
        RandomizeArea();
        Instantiate(warningArea, areaPos, rotation);
        RandomizeArea();
        Instantiate(warningArea, areaPos, rotation);
        RandomizeArea();
        Instantiate(warningArea, areaPos, rotation);
        RandomizeArea();
        Instantiate(warningArea, areaPos, rotation);
        RandomizeArea();
        Instantiate(warningArea, areaPos, rotation);
    }

    private void RandomizeArea()
    {
        int randomX = Random.Range(-18, 18);
        int randomZ = Random.Range(-5, -20);
        areaPos = new Vector3(gameObject.transform.position.x + randomX, gameObject.transform.position.y - 3.5f, gameObject.transform.position.z + randomZ);
    }
}

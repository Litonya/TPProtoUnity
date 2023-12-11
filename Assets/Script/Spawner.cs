using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject agentPrefab;
    [SerializeField]
    private int agentNumber;
    [SerializeField]
    private GameObject medusaPrefab;
    [SerializeField]
    private int medusaNumber;

    private Collider spawnArea;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void Start()
    {
        spawnAgent();
        spawnMedusa();
    }

    private void spawnAgent()
    {
        for (int i = 0; i < agentNumber; i++)
        {
            Vector3 spawnPoint = getRandomSpawnPoint(1);
            Instantiate(agentPrefab, spawnPoint, Quaternion.identity);
        }
    }

    private void spawnMedusa()
    {
        for (int i = 0;i < medusaNumber; i++)
        {
            Vector3 spawnPoint = getRandomSpawnPoint(4);
            Instantiate(medusaPrefab, spawnPoint, Quaternion.identity);
        }
    }

    private Vector3 getRandomSpawnPoint(int areaMask)
    {
        NavMeshHit hit;
        float maxX = spawnArea.bounds.max.x;
        float minX = spawnArea.bounds.min.x;

        float maxZ = spawnArea.bounds.max.z;
        float minZ = spawnArea.bounds.min.z;

        Debug.Log("SpawnArea: ("+minX+","+maxX+");("+minZ+","+maxZ+")");

        Vector3 spawnVector = new Vector3(Random.Range(minX,maxX), 10, Random.Range(minZ,maxZ));
        NavMesh.SamplePosition(spawnVector, out hit, 20f, areaMask);

        Debug.Log("Hit position: " + hit.position);

        return hit.position;
    }
}

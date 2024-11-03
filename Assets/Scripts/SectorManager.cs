using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour
{
    public GameObject[] sectorPrefabs;
    public float zSpawn = 0;
    public float sectorLength = 500;
    public int numberOfSectors = 5;

    private List<GameObject> activeSectors = new List<GameObject>();
    private int deletePastSectorLength = 550;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSectors; i++)
        {
            if (i == 0)
            {
                SpawnSector(0);
            }
            else
            {
                SpawnSector(Random.Range(0, numberOfSectors));
            }    
        }
       /* SpawnSector(0);
        SpawnSector(2);
        SpawnSector(3);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z  - deletePastSectorLength > zSpawn - (numberOfSectors * sectorLength))
        {
            SpawnSector(Random.Range(0, sectorPrefabs.Length));
            DeleteSector();
        }
    }

    public void SpawnSector(int sectorIndex)
    {
       GameObject goSpawnTiles = Instantiate(sectorPrefabs[sectorIndex], transform.forward * zSpawn, transform.rotation);
        activeSectors.Add(goSpawnTiles);
        zSpawn += sectorLength;
    }

    private void DeleteSector()
    {
        Destroy(activeSectors[0]);
        activeSectors.RemoveAt(0);
    }
}

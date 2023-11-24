using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject[] tiles;
    public float tileLength = 24;
    public int maxTiles = 4;
    private float zLocation = 0;
    private List<GameObject> liveTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateTile(0);
        for (int i = 0; i < maxTiles-1; i++)
        {
            CreateTile(Random.Range(0, tiles.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - tileLength * 1.5 > zLocation - (maxTiles * tileLength))
        {
            CreateTile(Random.Range(0, tiles.Length));
            Destroy(liveTiles[0]);
            liveTiles.RemoveAt(0);
        }
    }

    public void CreateTile(int index)
    {
        GameObject temp = Instantiate(tiles[index], transform.forward * zLocation, transform.rotation);
        liveTiles.Add(temp);
        zLocation += tileLength;

    }
}

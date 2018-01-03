using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPerlinNoise : MonoBehaviour {

    public int width = 100;
    public int height = 100;
    public int depth = 10;
    public float scale = 10.0f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    float[,] heights = new float[100, 100];

    // Use this for initialization
    void Start () {
        offsetX = Random.Range(0, 9999f);
        offsetY = Random.Range(0, 9999f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());

        //float[,,] map = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, terrainData.alphamapLayers];

        //// For each point on the alphamap...
        //for (int y = 0; y < terrainData.alphamapHeight; y++)
        //{
        //    for (int x = 0; x < terrainData.alphamapWidth; x++)
        //    {
        //        // Get the normalized terrain coordinate that
        //        // corresponds to the the point.
        //        float normX = (float)x * 1.0f / ((float)terrainData.alphamapWidth - 1);
        //        float normY = (float)y * 1.0f / ((float)terrainData.alphamapHeight - 1);

        //        // Get the steepness value at the normalized coordinate.
        //        float angle = terrainData.GetSteepness(normX, normY);

        //        // Steepness is given as an angle, 0..90 degrees. Divide
        //        // by 90 to get an alpha blending value in the range 0..1.
        //        float frac = angle / 90.0f;
        //        map[x, y, 0] = frac;
        //        map[x, y, 1] = 1 - frac;
        //    }
        //}

        //terrainData.SetAlphamaps(0, 0, map);

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        

        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}

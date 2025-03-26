using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float[] probabilities = { 1f, 5f, 1f, 13f, 10f, 50f, 10f, 10f };
    private float[] cumulativeProbabilities;

    public Transform generator;
    public int cellsPerRow = 13;
    public float segmentWidth = 2.0f;
    public float spawnOffset = 10f;
    public float moveSpeed = 1.0f;
    public float xOffset = 0f;

    public int maxRows = 16;
    public float cleanupY = -20f;

    private List<GameObject> rows = new List<GameObject>();
    private float highestRowY;
    private int rowCount = 0;

    void Start()
    {
        cumulativeProbabilities = new float[probabilities.Length];
        float sum = 0f;
        for (int i = 0; i < probabilities.Length; i++)
        {
            sum += probabilities[i];
            cumulativeProbabilities[i] = sum;
        }

        highestRowY = generator.position.y + spawnOffset;
        SpawnRow(highestRowY);
        rowCount = 1;
        generator.position = new Vector3(generator.position.x, highestRowY, generator.position.z);
    }

    void Update()
    {
        for (int i = 0; i < rows.Count; i++)
        {
            rows[i].transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        generator.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (rowCount < maxRows)
        {
            float targetY = generator.position.y + spawnOffset;
            highestRowY = targetY;
            SpawnRow(highestRowY);
            rowCount++;
            generator.position = new Vector3(generator.position.x, highestRowY, generator.position.z);
        }

        for (int i = rows.Count - 1; i >= 0; i--)
        {
            if (rows[i].transform.position.y < cleanupY)
            {
                Destroy(rows[i]);
                rows.RemoveAt(i);
                rowCount--;
            }
        }
    }

    void SpawnRow(float yPos)
    {
        GameObject row = new GameObject("Row");
        row.transform.position = new Vector3(generator.position.x + xOffset, yPos, generator.position.z);

        for (int i = 0; i < cellsPerRow; i++)
        {
            int typeIndex = WeightedRandom();
            if (typeIndex >= 0 && typeIndex < objectPrefabs.Length)
            {
                Vector3 cellPos = new Vector3(i * segmentWidth, 0, 0);
                Instantiate(objectPrefabs[typeIndex], row.transform.position + cellPos, Quaternion.identity, row.transform);
            }
        }
        rows.Add(row);
    }

    int WeightedRandom()
    {
        float r = Random.Range(0f, 100f);
        for (int i = 0; i < cumulativeProbabilities.Length; i++)
        {
            if (r < cumulativeProbabilities[i])
                return i;
        }
        return cumulativeProbabilities.Length - 1;
    }
}

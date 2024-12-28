using UnityEngine;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
    [Header("Maze Settings")]
    public int width = 10;
    public int height = 10;

    [Header("Prefabs")]
    public GameObject wallPrefab;
    public GameObject floorPrefab;

    private int[,] maze;

    private void Start()
    {
        GenerateMaze();
        BuildMaze();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];

        // Initialize maze with walls (1 = wall, 0 = path)
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = 1;
            }
        }

        // Start carving from a random cell
        CarvePath(1, 1);
    }

    void CarvePath(int x, int y)
    {
        maze[x, y] = 0;

        // Randomize directions (N, S, E, W)
        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(0, 1), // North
            new Vector2Int(0, -1), // South
            new Vector2Int(1, 0), // East
            new Vector2Int(-1, 0) // West
        };
        Shuffle(directions);

        foreach (Vector2Int dir in directions)
        {
            int nx = x + dir.x * 2;
            int ny = y + dir.y * 2;

            if (IsInBounds(nx, ny) && maze[nx, ny] == 1)
            {
                maze[x + dir.x, y + dir.y] = 0; // Carve path between cells
                CarvePath(nx, ny);
            }
        }
    }

    bool IsInBounds(int x, int y)
    {
        return x > 0 && y > 0 && x < width - 1 && y < height - 1;
    }

    void Shuffle<T>(IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    void BuildMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x, 0, y);
                if (maze[x, y] == 1)
                {
                    Instantiate(wallPrefab, position, Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(floorPrefab, position, Quaternion.identity, transform);
                }
            }
        }
    }
}
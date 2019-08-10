using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimMaze : MonoBehaviour
{
    public GameObject[] Walls;
    public GameObject[] Floors;

    public int height = 51;
    public int width = 51;
    public float complexity = 0.7f;
    public float density = 0.5f;

    int[,] Map;

    void Start()
    {
        Map = new int[height, width];
        GeneratePrimMaze(height, width, complexity, density);
        InstantiateMap();

    }
    /*
 * def maze(width=81, height=51, complexity=.75, density=.75):
# Only odd shapes
shape = ((height // 2) * 2 + 1, (width // 2) * 2 + 1)
# Adjust complexity and density relative to maze size
complexity = int(complexity * (5 * (shape[0] + shape[1]))) # number of components
density    = int(density * ((shape[0] // 2) * (shape[1] // 2))) # size of components
# Build actual maze
Z = numpy.zeros(shape, dtype=bool)
# Fill borders
Z[0, :] = Z[-1, :] = 1
Z[:, 0] = Z[:, -1] = 1
# Make aisles
for i in range(density):
    x, y = rand(0, shape[1] // 2) * 2, rand(0, shape[0] // 2) * 2 # pick a random position
    Z[y, x] = 1
    for j in range(complexity):
        neighbours = []
        if x > 1:             neighbours.append((y, x - 2))
        if x < shape[1] - 2:  neighbours.append((y, x + 2))
        if y > 1:             neighbours.append((y - 2, x))
        if y < shape[0] - 2:  neighbours.append((y + 2, x))
        if len(neighbours):
            y_,x_ = neighbours[rand(0, len(neighbours) - 1)]
            if Z[y_, x_] == 0:
                Z[y_, x_] = 1
                Z[y_ + (y - y_) // 2, x_ + (x - x_) // 2] = 1
                x, y = x_, y_
return Z*/
    public void GeneratePrimMaze(int height, int width, float complexity, float density)
    {
        //odd shapes only
        width = (width / 2) * 2 + 1;
        height = (height / 2) * 2 + 1;

        complexity = complexity * (2 * (height + width)); //number of components
        density = density * (width / 2) * (height / 2); //size of components
        //make the borders unwalkable
        for(int i = 0; i < height; ++i)
        {
            for(int j = 0; j < width; ++j)
            {
                if (i == 0 || i == width-1 || j == 0 || j == height-1)
                    Map[i, j] = 1;
            }
        }

        for (int d = 0; d < density; ++d)
        {
            int x = Random.Range(0, width / 2) * 2;
            int y = Random.Range(0, height / 2) * 2;
            Map[y,x] = 1;

            for(int c = 0; c < complexity; ++c)
            {
                List<Vector2> neighbors = new List<Vector2>();

                if (x > 1)
                    neighbors.Add(new Vector2(x - 2, y));
                if (y > 1)
                    neighbors.Add(new Vector2(x, y - 2));
                if (x < width - 2)
                    neighbors.Add(new Vector2(x + 2, y));
                if (y < height - 2)
                    neighbors.Add(new Vector2(x, y + 2));

                if (neighbors.Count > 0)
                {
                    Vector2 randNeighbor = neighbors[Random.Range(0,neighbors.Count)];
                    int x1 = (int)randNeighbor.x;
                    int y1 = (int)randNeighbor.y;

                    if(Map[y1,x1] == 0)
                    {
                        Map[y1, x1] = 1; //not walkable

                        Map[y1 + (y - y1) / 2, x1 + (x - x1) / 2] = 1;
                        x = x1;
                        y = y1;
                    }
                }
            }
        }
    }

    private void printMap()
    {
        Debug.Log("Printing Map...");
        for (int i = 0; i < height; ++i)
        {
            string row = "";
            for (int j = 0; j < width; ++j)
                row += Map[i, j];

            Debug.Log(row);
        }
    }

    private void InstantiateMap()
    {
        for (int i = 0; i < height; ++i)
        {
            for (int j = 0; j < width; ++j)
                if (Map[i, j] == 1)
                    Instantiate(Walls[0], new Vector3(i*7, 0,j*7), Quaternion.identity,this.transform);
                else
                    Instantiate(Floors[0], new Vector3(i*7, 0, j*7), Quaternion.identity,this.transform);
        }           
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveMap : MonoBehaviour
{
    public int Height;
    public int Width;

    public Vector2 MinimumRoomSize = new Vector2(1, 1);

    int[,] Map;

    // Start is called before the first frame update
    void Start()
    {
        Map = new int[Height,Width];
        GenerateChamber(0,Height,0,Width);
    }

    int minVert = 0;
    int minHorizontal = 0;
    private void GenerateChamber(int startX, int endX, int startY, int endY)
    {
        int verticalWall = 0;
        int horizontalWall = 0;
        //if 
        if (endX - startX > MinimumRoomSize.x)
            verticalWall = Random.Range((int)MinimumRoomSize.x, endY);

        if (endY - startY < MinimumRoomSize.y)
            horizontalWall = Random.Range((int)MinimumRoomSize.y, endX);


        GenerateVerticalWall(verticalWall, startY, endY);
        GenerateHorizontalWall(horizontalWall, startX, endX);

        GenerateDoors(verticalWall, horizontalWall);


        GenerateChamber(horizontalWall, verticalWall);
    }

    private void GenerateDoors(int vertWall, int horizontalWall)
    {
        Map[vertWall, Random.Range(0, Height)] = 0;
        Map[Random.Range(0, vertWall),horizontalWall] = 0;
        Map[Random.Range(vertWall, Width), horizontalWall] = 0;

    }

    private void GenerateVerticalWall(int verticalX, int startY, int endY)
    {
        if (verticalX <= 0) return;
        for (int i = startY; i < endY; ++i)
        {
            Map[i, verticalX] = 1;
        }
    }

    private void GenerateHorizontalWall(int horizontalY, int startX, int endX)
    {
        if (horizontalY <= 0) return;
        for (int i = startX; i < endX; ++i)
        {
            Map[horizontalY, i] = 1;
        }
    }
}

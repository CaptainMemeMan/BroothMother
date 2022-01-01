using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType {PATH, GRASS, START, GOAL};

public class AStar : MonoBehaviour
{
    private TileType tileType;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private LayerMask layerMask;

    private Vector3Int startPos, goalPos;

    private Node current;

    private HashSet<Node> openList, closedList;

    private Stack<Vector3Int> path;

    private Dictionary<Vector3Int, Node> allNodes = new Dictionary<Vector3Int, Node>();

    /*private void Awake()
    {
        Algorithm();
    }*/

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
            //Debug.Log("click");

            if(hit.collider != null)
            {
                Vector3 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int clickPos = tilemap.WorldToCell(mouseWorldPos);

                //ChangeTile(clickPos);
                if(tileType == TileType.START)
                {
                    startPos = clickPos;
                    Debug.Log("start placed "+clickPos);
                }
                else if(tileType == TileType.GOAL)
                {
                    goalPos = clickPos;
                    Debug.Log("goal placed "+clickPos);
                }
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            tileType = TileType.PATH;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            tileType = TileType.GRASS;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            tileType = TileType.START;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            tileType = TileType.GOAL;
        }

    }

    private void Initialize()
    {
        startPos = new Vector3Int(-9, 3, 0);

        goalPos = new Vector3Int(8, 2, 0);

        current = GetNode(startPos);
        Debug.Log("start added");

        openList = new HashSet<Node>();

        closedList = new HashSet<Node>();

        openList.Add(current);
    }

    public void Algorithm()
    {
        if(current == null)
        {
            Initialize();
        }

        while(openList.Count > 0 && path == null)
        {
            List<Node> neighbors = FindNeighbors(current.Position);
            //Debug.Log(neighbors.Count);

            ExamineNeighbors(neighbors, current);

            UpdateCurrentTile(ref current);

            path = GeneratePath(current);
        }
    }

    private List<Node> FindNeighbors(Vector3Int parentPosition)
    {
        List<Node> neighbors = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                Vector3Int neighborPosition = new Vector3Int(parentPosition.x - x, parentPosition.y - y, parentPosition.z);

                if(x != 0 || y != 0)
                {
                    if(neighborPosition != startPos && tilemap.GetTile(neighborPosition))
                    {
                        if(!(x == 1 && y == 1) && !(x == 1 && y == -1) && !(x == -1 && y == 1) && !(x == -1 && y == -1))
                        {
                            Node neighbor = GetNode(neighborPosition);
                            neighbors.Add(neighbor);
                        }
                    }
                }
            }
        }

        return neighbors;
    }

    private void ExamineNeighbors(List<Node> neighbors, Node current)
    {
        for(int i = 0; i < neighbors.Count; i++)
        {
            Node neighbor = neighbors[i];

            int gScore = DetermineGScore(neighbors[i].Position, current.Position);

            if (openList.Contains(neighbor))
            {
                if(current.G + gScore < neighbor.G)
                {
                    CalcValues(current, neighbor, gScore);
                }
            }
            else if (!closedList.Contains(neighbor))
            {
                CalcValues(current, neighbor, gScore);

                openList.Add(neighbor);
                Debug.Log("neighbor found at " + neighbor.Position);

            }
        }
    }

    private void CalcValues(Node parent, Node neighbor, int cost)
    {
        neighbor.Parent = parent;

        neighbor.G = parent.G + cost;

        neighbor.H = ((Math.Abs((neighbor.Position.x - goalPos.x)) + Math.Abs((neighbor.Position.y - goalPos.y))) * 10);

        neighbor.F = neighbor.G + neighbor.H;
    }

    private int DetermineGScore(Vector3Int neighbor, Vector3Int current)
    {
        int gScore = 0;

        int x = current.x = neighbor.x;
        int y = current.y - neighbor.y;

        if(Math.Abs(x-y) % 2 == 1)
        {
            gScore = 10;
        }
        else
        {
            gScore = 14;
        }

        return gScore;
    }

    private void UpdateCurrentTile(ref Node current)
    {
        openList.Remove(current);

        closedList.Add(current);

        if(openList.Count > 0)
        {
            current = openList.OrderBy(x => x.F).First();
        }
    }

    private Node GetNode(Vector3Int position)
    {
        if (allNodes.ContainsKey(position))
        {
            return allNodes[position];
        }
        else
        {
            Node node = new Node(position);
            allNodes.Add(position, node);
            return node;
        }
    }

    private void ChangeTile(Vector3Int clickPos)
    {
        tilemap.SetTile(clickPos, tiles[(int)tileType]);
    }

    private Stack<Vector3Int> GeneratePath(Node current)
    {
        if(current.Position == goalPos)
        {
            Stack<Vector3Int> finalPath = new Stack<Vector3Int>();

            while(current.Position != startPos)
            {
                finalPath.Push(current.Position);
                Debug.Log("Added "+current.Position+" to final path");

                current = current.Parent;
            }
            finalPath.Push(startPos);

            Debug.Log("Path Found");
            return finalPath;
        }

        return null;
    }

    public Stack<Vector3Int> GetFinalPath()
    {
        return path;
    }

}

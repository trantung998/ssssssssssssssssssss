using System;
using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class AStarPathFinding
    {
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;

        private MapGrid _mapGrid;
        private Vector2Int[] _neighbourOffsetArray;
        private List<AStarMaoNode> _nodes;

        public AStarPathFinding()
        {
            _neighbourOffsetArray = new[]
            {
                new Vector2Int(-1, 1), new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(-1, 0), new Vector2Int(1, 0), new Vector2Int(-1, -1), new Vector2Int(0, -1),
                new Vector2Int(1, -1),
            };
        }

        public void SetGridData(MapGrid grid, MapNode startNode, MapNode endNode)
        {
            _mapGrid = grid;

            _nodes = new List<AStarMaoNode>();

            for (int i = 0; i < grid.width; i++)
            {
                for (int j = 0; j < grid.height; j++)
                {
                    AStarMaoNode node = new AStarMaoNode();
                    node.x = i;
                    node.y = j;
                    node.index = GetNodeIndex(i, j, grid.width);
                    node.isWalkable = true;
                    node.cameFromNodeIndex = -1;
                    node.gCost = Int32.MaxValue;
                    node.hCost = CalculateHCos(startNode, endNode);
                    node.CalculateFCost();

                    node.cameFromNodeIndex = -1;
                    node.isWalkable = grid.data[node.index] == 0;
                    _nodes.Add(node);
                }
            }
        }

        public void FindPath(MapNode startNode, MapNode endNode)
        {
            for (var i = 0; i < _nodes.Count; i++)
            {
                _nodes[i].gCost = Int32.MaxValue;
            }
        }

        private int CalculateHCos(MapNode startNode, MapNode endNode)
        {
            int xDis = Math.Abs(startNode.x - endNode.x);
            int yDis = Math.Abs(startNode.y - endNode.y);
            int remaining = Math.Abs(xDis - yDis);
            return MOVE_STRAIGHT_COST * Math.Min(xDis, yDis) + MOVE_STRAIGHT_COST * remaining;
        }

        private int GetNodeIndex(int x, int y, int mapWidth)
        {
            return x + y * mapWidth;
        }
    }
}
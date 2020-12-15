namespace PathFinding
{
    public class MapNode
    {
        public int x, y;
        public bool isWalkable;
    }

    public class AStarMaoNode : MapNode
    {
        public int gCost; //distance to start node 
        public int hCost; //distance to end node

        public int fCost; // gcost + hcost
        
        public int index;
        public int cameFromNodeIndex;
        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }
    }
}
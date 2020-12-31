using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeansClustering
{
    class Cluster
    {
        private List<Node> nodes;
        public List<Node> Nodes
        {
            get { return nodes; } 
        }
        public int CenterX, CenterY;
        public bool HasChanged;
        public Cluster(int centerX, int centerY)
        {
            nodes=new List<Node>();
            this.CenterX=centerX;
            this.CenterY=centerY;
            HasChanged=false;
        }
        public void ReCalculateCenter()
        {
            if (nodes.Count > 0)
            {
                int smallestX = nodes[0].X;
                for (int i = 1; i < nodes.Count; i++)
                {
                    Node node = nodes[i];
                    if (smallestX > node.X)
                        smallestX = node.X;
                }
                int biggestX = nodes[0].X;
                for (int i = 1; i < nodes.Count; i++)
                {
                    Node node = nodes[i];
                    if (biggestX < node.X)
                        biggestX = node.X;
                }
                int centerX = (biggestX + smallestX) / 2;
                if (centerX != this.CenterX)
                    HasChanged = true;
                this.CenterX = centerX;
                int smallestY = nodes[0].Y;
                for (int i = 1; i < nodes.Count; i++)
                {
                    Node node = nodes[i];
                    if (smallestY > node.Y)
                        smallestY = node.Y;
                }
                int biggestY = nodes[0].Y;
                for (int i = 1; i < nodes.Count; i++)
                {
                    Node node = nodes[i];
                    if (biggestY < node.Y)
                        biggestY = node.Y;
                }
                int centerY = (smallestY + biggestY) / 2;
                if (centerY != this.CenterY)
                    HasChanged = true;
                this.CenterY = centerY;
            }
        }
        public void Add(Node node)
        {
            nodes.Add(node);
        }
        public bool Contains(Node node)
        {
            return nodes.Contains(node);
        }
        public void Remove(Node node)
        {
            nodes.Remove(node);
        }
    }
}

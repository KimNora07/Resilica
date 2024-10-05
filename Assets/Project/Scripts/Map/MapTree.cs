namespace Resilica.Map
{
    using UnityEngine;
    using UnityEngine.UI;
    
    public class MapTree
    {
        public MapNode RootNode { get; set; }   // �Ѹ����

        /// <summary>
        /// �̾��� ��带 ����
        /// </summary>
        /// <param name="node">�ڽ� ���</param>
        /// <param name="parentNode">�θ� ���</param>
        public void AddNode(MapNode node, MapNode parentNode)
        {
            parentNode.AddConnection(node);
        }

        /// <summary>
        /// Ʈ�� ���
        /// </summary>
        /// <param name="node">���</param>
        /// <param name="indent"></param>
        public void PrintTree(MapNode node, string indent = "")
        {
            if(node == null) return;
            

            Debug.Log($"{indent}{node.Name}");
            foreach(var connectedNode in node.ConnectedNodes)
            {

                PrintTree(connectedNode, indent + "  ");
            }
        }
    }
}


namespace Resilica.Map
{
    using UnityEngine;
    using UnityEngine.UI;
    
    public class MapTree
    {
        public MapNode RootNode { get; set; }   // 뿌리노드

        /// <summary>
        /// 이어줄 노드를 결정
        /// </summary>
        /// <param name="node">자식 노드</param>
        /// <param name="parentNode">부모 노드</param>
        public void AddNode(MapNode node, MapNode parentNode)
        {
            parentNode.AddConnection(node);
        }

        /// <summary>
        /// 트리 출력
        /// </summary>
        /// <param name="node">노드</param>
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


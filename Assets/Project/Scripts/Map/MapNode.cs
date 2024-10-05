namespace Resilica.Map
{
    using System.Collections.Generic;

    public class MapNode
    {
        public string MapID { get; set; }   // 맵의 번호
        public string Name { get; set; }    // 맵의 이름
        public int Difficulty { get; set; } // 맵의 난이도
        public List<MapNode> ConnectedNodes { get; set; } = new List<MapNode>();    // 맵에 이어지는 노드들

        /// <summary>
        /// 리스트에 없는지 확인하고 맵 노드를 추가 하는 메소드
        /// </summary>
        /// <param name="node">맵 노드</param>
        public void AddConnection(MapNode node)
        {
            if (!ConnectedNodes.Contains(node))
            {
                ConnectedNodes.Add(node);
            }
        }
    }
}


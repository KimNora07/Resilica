namespace Resilica.Map
{
    using UnityEngine;
    using UnityEngine.UI;

    public class MapTreeGenerator : MonoBehaviour
    {
        public GameObject nodePrefab; // UI에서 노드를 표현할 프리팹 (Image, Text 포함)
        public RectTransform canvas;  // 트리를 그릴 캔버스

        private void Start()
        {
            // 노드 생성
            MapNode node1 = CreateNode("1", "Map 1", 1);
            MapNode node2 = CreateNode("2", "Map 2", 2);
            MapNode node3 = CreateNode("3", "Map 3", 3);
            MapNode node4 = CreateNode("4", "Map 4", 4);
            MapNode node5 = CreateNode("5", "Map 5", 5);
            MapNode node6 = CreateNode("6", "Map 6", 6);
            MapNode node7 = CreateNode("7", "Map 7", 7);

            // 트리 생성
            MapTree mapTree = new MapTree { RootNode = node1 };

            // 노드 연결
            mapTree.AddNode(node2, node1);
            mapTree.AddNode(node3, node1);
            mapTree.AddNode(node4, node1);
            mapTree.AddNode(node5, node2);
            mapTree.AddNode(node6, node3);
            mapTree.AddNode(node7, node4);
            //mapTree.AddNode(node3, node2);

            // 트리 출력
            Debug.Log("[ 트리 구조 ]");
            mapTree.PrintTree(mapTree.RootNode);

            // UI로 트리 표현
            VisualizeTree(mapTree.RootNode, new Vector2(0, 0), 600f);
        }

        /// <summary>
        /// 노드 생성
        /// </summary>
        /// <param name="id">맵 인덱스</param>
        /// <param name="name">맵 이름</param>
        /// <param name="difficulty">맵 난이도</param>
        /// <returns></returns>
        private MapNode CreateNode(string id, string name, int difficulty)
        {
            return new MapNode
            {
                MapID = id,
                Name = name,
                Difficulty = difficulty,
            };
        }

        /// <summary>
        /// 시각적으로 볼 수 있는 UI 트리 생성
        /// </summary>
        /// <param name="node">노드</param>
        /// <param name="position">노드의 위치</param>
        /// <param name="horizontalSpacing">가로 간격</param>
        private void VisualizeTree(MapNode node, Vector2 position, float horizontalSpacing)
        {
            if (node == null) return;

            // UI 노드 생성
            GameObject nodeUI = Instantiate(nodePrefab, canvas);
            RectTransform rectTransform = nodeUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = position;

            // 노드 이름 설정
            Text nodeNameText = nodeUI.GetComponentInChildren<Text>();
            if (nodeNameText != null)
            {
                nodeNameText.text = node.Name;
            }

            // 연결된 노드를 표현하기 위해 하위 노드의 UI 생성
            float childOffset = 0f; // 각 하위 노드의 새로 간격

            foreach (var childNode in node.ConnectedNodes)
            {
                Vector2 childPosition = position + new Vector2(horizontalSpacing, childOffset);
                VisualizeTree(childNode, childPosition, horizontalSpacing);

                childOffset -= 200f; // 다음 하위 노드는 아래쪽으로 배치
            }
        }
    }
}


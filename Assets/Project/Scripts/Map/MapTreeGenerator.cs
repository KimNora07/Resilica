namespace Resilica.Map
{
    using UnityEngine;
    using UnityEngine.UI;

    public class MapTreeGenerator : MonoBehaviour
    {
        public GameObject nodePrefab; // UI���� ��带 ǥ���� ������ (Image, Text ����)
        public RectTransform canvas;  // Ʈ���� �׸� ĵ����

        private void Start()
        {
            // ��� ����
            MapNode node1 = CreateNode("1", "Map 1", 1);
            MapNode node2 = CreateNode("2", "Map 2", 2);
            MapNode node3 = CreateNode("3", "Map 3", 3);
            MapNode node4 = CreateNode("4", "Map 4", 4);
            MapNode node5 = CreateNode("5", "Map 5", 5);
            MapNode node6 = CreateNode("6", "Map 6", 6);
            MapNode node7 = CreateNode("7", "Map 7", 7);

            // Ʈ�� ����
            MapTree mapTree = new MapTree { RootNode = node1 };

            // ��� ����
            mapTree.AddNode(node2, node1);
            mapTree.AddNode(node3, node1);
            mapTree.AddNode(node4, node1);
            mapTree.AddNode(node5, node2);
            mapTree.AddNode(node6, node3);
            mapTree.AddNode(node7, node4);
            //mapTree.AddNode(node3, node2);

            // Ʈ�� ���
            Debug.Log("[ Ʈ�� ���� ]");
            mapTree.PrintTree(mapTree.RootNode);

            // UI�� Ʈ�� ǥ��
            VisualizeTree(mapTree.RootNode, new Vector2(0, 0), 600f);
        }

        /// <summary>
        /// ��� ����
        /// </summary>
        /// <param name="id">�� �ε���</param>
        /// <param name="name">�� �̸�</param>
        /// <param name="difficulty">�� ���̵�</param>
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
        /// �ð������� �� �� �ִ� UI Ʈ�� ����
        /// </summary>
        /// <param name="node">���</param>
        /// <param name="position">����� ��ġ</param>
        /// <param name="horizontalSpacing">���� ����</param>
        private void VisualizeTree(MapNode node, Vector2 position, float horizontalSpacing)
        {
            if (node == null) return;

            // UI ��� ����
            GameObject nodeUI = Instantiate(nodePrefab, canvas);
            RectTransform rectTransform = nodeUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = position;

            // ��� �̸� ����
            Text nodeNameText = nodeUI.GetComponentInChildren<Text>();
            if (nodeNameText != null)
            {
                nodeNameText.text = node.Name;
            }

            // ����� ��带 ǥ���ϱ� ���� ���� ����� UI ����
            float childOffset = 0f; // �� ���� ����� ���� ����

            foreach (var childNode in node.ConnectedNodes)
            {
                Vector2 childPosition = position + new Vector2(horizontalSpacing, childOffset);
                VisualizeTree(childNode, childPosition, horizontalSpacing);

                childOffset -= 200f; // ���� ���� ���� �Ʒ������� ��ġ
            }
        }
    }
}


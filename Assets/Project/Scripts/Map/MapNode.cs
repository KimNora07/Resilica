namespace Resilica.Map
{
    using System.Collections.Generic;

    public class MapNode
    {
        public string MapID { get; set; }   // ���� ��ȣ
        public string Name { get; set; }    // ���� �̸�
        public int Difficulty { get; set; } // ���� ���̵�
        public List<MapNode> ConnectedNodes { get; set; } = new List<MapNode>();    // �ʿ� �̾����� ����

        /// <summary>
        /// ����Ʈ�� ������ Ȯ���ϰ� �� ��带 �߰� �ϴ� �޼ҵ�
        /// </summary>
        /// <param name="node">�� ���</param>
        public void AddConnection(MapNode node)
        {
            if (!ConnectedNodes.Contains(node))
            {
                ConnectedNodes.Add(node);
            }
        }
    }
}


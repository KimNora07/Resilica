using Resilica.Map;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MapNode", menuName = "Data/Map")]
public class MapData : ScriptableObject
{
    public List<MapNode> nodes;
}

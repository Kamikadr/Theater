using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Placement", menuName = "Placement", order = 52)]
public class PlacementScriptableObject : ScriptableObject
{
    [SerializeField]
    public PlacementObject placementObject;
}

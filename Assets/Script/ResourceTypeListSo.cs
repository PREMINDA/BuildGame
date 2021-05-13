using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects / ResourceTypeList")]
public class ResourceTypeListSo : ScriptableObject
{
    public List<ResourceTypeSo> list;
}

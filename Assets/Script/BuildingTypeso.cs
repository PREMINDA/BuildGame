using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/BuildingType")]
public class BuildingTypeso : ScriptableObject {

    public string nameString;
    public Transform prefabs;
    public ResourceGeneratData resourceGeneratData;
    public Sprite sprite;
    public ResourceAmount[] BuildingResourceCostArray;
    public int maxHealthl;

    public string GetToolTipInfor()
    {
        string str = "";
        foreach(ResourceAmount resourceAmount in BuildingResourceCostArray)
        {
            str += resourceAmount.resourceTypeSo.nameString + " : " + resourceAmount.amount + " ";
        }

        return str;
    }
}

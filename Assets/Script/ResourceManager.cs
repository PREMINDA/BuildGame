using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSo, int> resourceAmountdictonary;
    public static ResourceManager Instance { get; private set; }
    public event EventHandler OnResourceAmounChange;


    private void Awake(){
        Instance = this;
        resourceAmountdictonary = new Dictionary<ResourceTypeSo, int>();

        ResourceTypeListSo resourceTypeList = Resources.Load<ResourceTypeListSo>(typeof(ResourceTypeListSo).Name);
        
        foreach(ResourceTypeSo resourcetype in resourceTypeList.list) {
            resourceAmountdictonary[resourcetype] = 0;
           
        }

    }

      
    void Update(){
        if (Input.GetKeyDown(KeyCode.L)){
            ResourceTypeListSo resourceTypeList = Resources.Load<ResourceTypeListSo>(typeof(ResourceTypeListSo).Name);
            AddResource(resourceTypeList.list[0], 5);
        }
        
    }

    public void AddResource(ResourceTypeSo resourceType,int val){
        resourceAmountdictonary[resourceType] += val;
        OnResourceAmounChange?.Invoke(this, EventArgs.Empty);
    }
    public int GetResource(ResourceTypeSo retype){
        return resourceAmountdictonary[retype];
    }

    public bool CanAfford(ResourceAmount[] resourceAmountsArray)
    {
        Debug.Log(resourceAmountsArray.Length);
        foreach (ResourceAmount resourceAmount in resourceAmountsArray)
        {
            
            if (GetResource(resourceAmount.resourceTypeSo) >= resourceAmount.amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public void SpendResourse(ResourceAmount[] resourceAmountsArray)
    {
        foreach (ResourceAmount resourceAmount in resourceAmountsArray)
        {
            resourceAmountdictonary[resourceAmount.resourceTypeSo] -= resourceAmount.amount;
        }
        
    }
}

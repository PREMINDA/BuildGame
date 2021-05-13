using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ResourceUI : MonoBehaviour
{ 
    
    private ResourceTypeListSo resourceTypeList;
    private Dictionary<ResourceTypeSo, int> resourceAmountdictonary;
    public TextMeshProUGUI[] text;


    private void Awake()
    {
        ResourceManager.Instance.OnResourceAmounChange += RespurceManager_OnResourceAmounChange;     
    }

   
    void Start()
    {
        resourceTypeList = Resources.Load<ResourceTypeListSo>(typeof(ResourceTypeListSo).Name);
    }

    void Update()
    {
   
    }

    private void UpdateResourseToUI()
    {
        int index = 0;
        foreach(ResourceTypeSo retype in resourceTypeList.list)
        {
            text[index].text = ResourceManager.Instance.GetResource(retype).ToString();
            index++;
        }
    }
    private void RespurceManager_OnResourceAmounChange(object sender, EventArgs e)
    {
        UpdateResourseToUI();
    }
}

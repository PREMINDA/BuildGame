using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float timerMax;
    private ResourceGeneratData resourceGeneratData;
    private bool isEnabled;
    

    private void Awake() 
    {
        
        resourceGeneratData = GetComponent<BuildingTypeHolder>().buildingType.resourceGeneratData;
        timerMax = resourceGeneratData.timeMax;
    }

    private void Start()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, resourceGeneratData.resourceGeneratorRadius);

        int resourseCounter = 0;

        foreach (Collider2D collider2D in collider2DArray)
        {  
            ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if(resourceNode != null)
            {
                if(resourceNode.resourceType == resourceGeneratData.resourceType)
                {
                    resourseCounter++;
                }
            }
        }
        resourseCounter = Mathf.Clamp(resourseCounter,0,resourceGeneratData.maxResource);
       

        if(resourseCounter == 0)
        {
            isEnabled = false;
        }
        else
        {
            isEnabled = true;
            timerMax = (timerMax / 2f) + timerMax * (1 - (float)resourseCounter / resourceGeneratData.maxResource);
        }
    }


    private void Update()
    {
        if (isEnabled)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                timer += timerMax;
                ResourceManager.Instance.AddResource(resourceGeneratData.resourceType, 1);

            }
        }
    }
    public ResourceGeneratData GetResourceGeneratData()
    {
        return resourceGeneratData;
    }
    public float GetTimerNormalize()
    {
        return timer / timerMax;
    }
    public float GetAmountPerSec()
    {
        return Mathf.Round(1 / timerMax);
    }
}

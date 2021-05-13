using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverLayer : MonoBehaviour
{
    [SerializeField]private ResourceGenerator resourceGenerator;
    private Transform barTransform;
    void Start()
    {
        ResourceGeneratData resourceGeneratData = resourceGenerator.GetResourceGeneratData();

        transform.Find("Resource").GetComponent<SpriteRenderer>().sprite = resourceGeneratData.resourceType.sprite;
        barTransform = transform.Find("Bar");
        transform.Find("Amount").GetComponent<TextMeshPro>().SetText(resourceGenerator.GetAmountPerSec().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        barTransform.localScale = new Vector3(resourceGenerator.GetTimerNormalize(), 1, 1);
    }
}

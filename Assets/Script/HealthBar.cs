using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private HealthSystem healthSystem;
    private Transform barTransform;

    private void Awake()
    {
        barTransform = transform.Find("Bar");
    }

    private void Start()
    {
        healthSystem.OnDamage += HealthSystem_OnDamage;
        
        
    }

    private void HealthSystem_OnDamage(object sender, System.EventArgs e)
    {
        UpadateBar();
    }

    private void UpadateBar()
    {
        barTransform.localScale = new Vector3(healthSystem.GetNormalizedHealth(),1,1);
        
    }
}

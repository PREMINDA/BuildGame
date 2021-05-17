using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamage;
    public event EventHandler OnDide;
    private int healtAmountMax;
    private int healthAmount;
    private BuildingTypeso buildingTypeso;

    private void Awake()
    {
        buildingTypeso = GetComponent<BuildingTypeHolder>().buildingType;
        healtAmountMax = buildingTypeso.maxHealthl;
        healthAmount = healtAmountMax;
    }

    public void Damage(int damageAmount)
    {
        healthAmount -= damageAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healtAmountMax);
        OnDamage?.Invoke(this, EventArgs.Empty);
        if (IsDead())
        {
            OnDide?.Invoke(this,EventArgs.Empty);
        }
    }

    public bool IsDead()
    {
        return healthAmount == 0;
    }

    public int GetHealthAmount()
    {
        return healthAmount;
    }

    public float GetNormalizedHealth(){

        return (float)healthAmount / healtAmountMax;
    }
   
}

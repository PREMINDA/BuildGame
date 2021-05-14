using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int healtAmountMax;
    private int healthAmount;

    private void Awake()
    {
        healthAmount = healtAmountMax;
    }
    public void Damage(int damageAmount)
    {
        healthAmount -= damageAmount;
        healthAmount = Mathf.Clamp(healthAmount,0,healtAmountMax);
    }
    public bool IsDead()
    {
        return healthAmount == 0;
    }
    public int  GetHealthAmount()
    {
        return healthAmount;
    }
}

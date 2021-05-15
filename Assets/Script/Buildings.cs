using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    // Start is called before the first frame update
    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDide += HealthSystem_OnDide;
    }

    private void HealthSystem_OnDide(object sender, System.EventArgs e)
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            healthSystem.Damage(10);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePositionsortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool runOnce;
    [SerializeField] private float postionOffSetY;
   
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }
    

    private void LateUpdate()
    {
        float multiplier = 5f;
        spriteRenderer.sortingOrder = (int)(-(transform.position.y + postionOffSetY)*multiplier);

       
        if (runOnce)
        {
            Destroy(this);
        }
    }
}

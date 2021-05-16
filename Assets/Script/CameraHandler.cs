using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamer;
    
    private float orthographicSize;
    private float moveSpeed = 10f;
    private float zoomamount = 2f;
    private float targetOrthographicSize;
    private float zoomSpeed=5f;

    private void Start()
    {
        orthographicSize = cinemachineVirtualCamer.m_Lens.OrthographicSize;
        targetOrthographicSize = orthographicSize;
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
        
    }
    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movePostion = new Vector3(x, y).normalized;
        transform.position += movePostion * moveSpeed * Time.deltaTime;
        targetOrthographicSize -= Input.mouseScrollDelta.y * zoomamount;
    }

    private void HandleZoom()
    {
        targetOrthographicSize = Mathf.Clamp(targetOrthographicSize, 10, 30);

        orthographicSize = Mathf.Lerp(orthographicSize, targetOrthographicSize, Time.deltaTime * zoomSpeed);

        cinemachineVirtualCamer.m_Lens.OrthographicSize = orthographicSize;
    }
}

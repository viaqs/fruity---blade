using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Blade : MonoBehaviour
{   private Camera mainCamera;
    private Collider col;
    private bool slicing;
    private TrailRenderer trailRenderer;
    
    public Vector3 direction { get; private set; }
    public float sliceForce = 5f;

    private void Awake()
    {
        mainCamera = Camera.main;
        col = GetComponent<Collider>();
        trailRenderer = GetComponent<TrailRenderer>();
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0)) 
        { 
            StopSlicing();
        }
        else if (slicing)
        {
            ContinueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        transform.position = newPosition;
        slicing = true;
        col.enabled = true;
        trailRenderer.enabled = true;
        trailRenderer.Clear();
    }
    public void OnEnable()
    {
       StopSlicing();
    }
    public void OnDisable()
    {
        StopSlicing();
    }
    private void StopSlicing()
    {
        slicing = false;
        col.enabled = false;
        trailRenderer.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        
        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        col.enabled = velocity > 0f;

        transform.position = newPosition;
    }

}



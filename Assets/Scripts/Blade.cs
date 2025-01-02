using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{ private Camera mainCamera;
    private Collider col;
    private bool slicing;


    private void Awake()
    {
        mainCamera = Camera.main;
        col = GetComponent<Collider>();
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
        slicing = true;
        col.enabled = true;
    }

    private void StopSlicing()
    {
        slicing = false;
        col.enabled = false;
    }

    private void ContinueSlicing()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        
    }

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody rb;
    private Collider fruitCol;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fruitCol = GetComponent<Collider>();
    }
    private void Slice(Vector3 direction,Vector3 position,float force)
    {
        whole.SetActive(false);
        sliced.SetActive(true);
        fruitCol.enabled = false;

        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f,0f,angle);
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slices)
        {
            slice.velocity = rb.velocity;
            slice.AddForceAtPosition(direction*force,position, ForceMode.Impulse);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction,blade.transform.position, blade.sliceForce);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<UiManager>().Explosion();
                FindObjectOfType<Misses>().LoseLife();
                Destroy(gameObject);
                
              
            }
       
    }
}

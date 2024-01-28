using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    [SerializeField] private GameObject destryedObject;
    [SerializeField] private float health;
    private float currentHealth;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Break();
        }
    }

    private void Break()
    {
        Instantiate(destryedObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantBase : MonoBehaviour
{
    protected float health = 100;
    protected float currentHealth;
    protected bool isGrow = false;
    protected Animator plantAni;
    protected BoxCollider2D plantCollider;

    protected virtual void Start()
    {
        plantCollider = GetComponent<BoxCollider2D>();
        plantCollider.enabled = false;
        plantAni = GetComponent<Animator>();
        plantAni.speed = 0;
    }
    public virtual float changeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        return currentHealth; 
    }

    public virtual void setPlantState()
    {
        isGrow = true;
        plantCollider.enabled = true;
        plantAni.speed = 1;
    }
}

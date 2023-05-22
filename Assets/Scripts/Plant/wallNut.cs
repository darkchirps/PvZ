using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallNut : plantBase
{
    protected override void Start()
    {
        base.Start();
        health = Utils.GetPlantData().wallNut.health;
        currentHealth = health;
    }

    public override float changeHealth(float num)
    {
        float currenHealth = base.changeHealth(num);
        plantAni.SetFloat("health", (float)currenHealth / health);
        return currenHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : healthBase
{
    public float moveSpeed;//僵尸的移动速度
    Rigidbody2D zombieBody;
    Animator zombieAni;

    float eatTime = 0.5f;//僵尸每次伤害的间隔时间
    float eatTimer = 0f;//伤害计时器

    private GameObject head;

    private void Start()
    {
        base.health = Utils.GetZombieData().general.health;
        zombieBody = GetComponent<Rigidbody2D>();
        zombieAni = GetComponent<Animator>();

    }
    private void Update()
    {
        zombieBody.velocity = new Vector2(-Time.deltaTime* moveSpeed, 0);

    }

    public void dieState()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "plant")
        {
            moveSpeed = 0.1f;
            zombieAni.SetInteger("state", 1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "plant")
        {
            eatTimer += Time.deltaTime;
            if (eatTimer >= eatTime)
            {
                eatTimer = 0f;
                collision.GetComponent<PeaShooter>().changeHealth(-5,Utils.GetPlantData().peaShooter.health);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "plant")
        {
            moveSpeed = 20f;
            zombieAni.SetInteger("state", 0);
        }
    }
}

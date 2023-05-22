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
    private bool lostHead=false;
    private bool isDie=false;


    bool isWark=true;

    private void Start()
    {
        base.healthMax = Utils.GetZombieData().general.health;
        base.health = base.healthMax;
        zombieBody = GetComponent<Rigidbody2D>();
        zombieAni = GetComponent<Animator>();
        head = transform.Find("head").gameObject;

    }
    private void Update()
    {
        if (isDie) return;
        if (isWark)
        {
            //zombieBody.velocity = new Vector2(-Time.deltaTime * moveSpeed, 0);
            transform.position +=new Vector3(-1,0,0)* moveSpeed * Time.deltaTime;
        }
    }

    public void dieState()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) return;
        if (collision.tag == "plant")
        {
            isWark = false;
            zombieAni.SetBool("walk", false);
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
                plantBase plant = collision.GetComponent<plantBase>();
                float newHealth = plant.changeHealth(-5);
                if (newHealth<=0)
                {
                    isWark = true;
                    zombieAni.SetBool("walk",true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "plant")
        {
            isWark = true;
            zombieAni.SetBool("walk", true);
        }
    }

    public void changeZombieHealth(int post, int max)
    {
        int lostHeadHealth = Utils.GetZombieData().general.lostHeadHealth;
        health = Mathf.Clamp(health + post, 0, Utils.GetZombieData().general.health);
        if (health < lostHeadHealth&&!lostHead)
        {
            lostHead = true;
            zombieAni.SetBool("lostHead", true);
            head.SetActive(true);
        }
        if (health <= 0)
        {
            if (isDie) return;
            zombieAni.SetTrigger("die");
            isDie = true;
        }
    }

    public void dieAniEnd()
    {
        zombieAni.enabled = false;
        Destroy(gameObject);
    }
}

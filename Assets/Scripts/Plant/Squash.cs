using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None,
    Down,
    Up,
    Over,
}

public class Squash : plantBase
{
    public float findZombieDistance;
    private int line;
    private Vector3 attackPos;
    private State squashState = State.None;
    public int damage;
    protected override void Start()
    {
        base.Start();
    }

    public override void setPlantState()
    {
        isGrow = true;
        plantCollider.enabled = false;
        plantAni.speed = 1;
        // 种植完先不启动触发器
        // boxCollider2D.enabled = true;
        // 种植完成后才启动
        InvokeRepeating("CheckZombieInRange", 1, 0.5f);
        line = gameManager.instance.GetPlantLine(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (squashState)
        {
            case State.Down:
                break;
            case State.Up:
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(attackPos.x, attackPos.y + 2), Time.deltaTime * 20);
                break;
            case State.Over:
                plantCollider.enabled = true;
                transform.position = Vector2.MoveTowards(transform.position, attackPos, Time.deltaTime * 20);
                break;
            default:
                break;
        }
    }

    public void CheckZombieInRange()
    {
        // 找到攻击对象后，不在check
        if (attackPos != Vector3.zero) return;
        List<GameObject> zombies = gameManager.instance.GetLineZombies(line);
        if (zombies.Count <= 0) return;
        // 拿到距离最近的僵尸，并且判断距离是否在范围内
        float minDis = findZombieDistance;
        GameObject nearZombie = null;
        for (int i = 0; i < zombies.Count; i++)
        {
            GameObject zombie = zombies[i];
            float dis = Vector2.Distance(gameObject.transform.position, zombie.transform.position);
            if (dis < minDis)
            {
                minDis = dis;
                nearZombie = zombie;
            }
        }
        if (nearZombie == null) return;
        // 找到僵尸，选择攻击落点
        attackPos = nearZombie.transform.position;
        DoSquashLook();
    }

    public void DoSquashLook()
    {
        string LookName = "Right";
        if (attackPos.x < transform.position.x)
        {
            LookName = "Left";
        }
        plantAni.SetTrigger(LookName);
    }

    public void SetAttackUp()
    {
        squashState = State.Up;
        plantAni.SetTrigger("AttackUp");
    }

    public void SetAttackOver()
    {
        squashState = State.Over;
        plantAni.SetTrigger("AttackOver");
    }

    public void DoReallyAttack()
    {
        plantCollider.enabled = true;
        Destroy(gameObject, 0.5f);
    }

    public override float changeHealth(float num)
    {
        return health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("zombie"))
        {
            other.GetComponent<ZombieNormal>().changeZombieHealth(-damage);
        }
    }
}

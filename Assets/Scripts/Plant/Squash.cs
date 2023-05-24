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
        plantCollider.enabled = true;
        plantAni.speed = 1;

        // ��ֲ���Ȳ�����������
        // boxCollider2D.enabled = true;

        // ��ֲ��ɺ������
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
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(attackPos.x, attackPos.y + 100), Time.deltaTime * 200);
                break;
            case State.Over:
                transform.position = Vector2.MoveTowards(transform.position, attackPos, Time.deltaTime * 200);
                break;
            default:
                break;
        }
    }

    public void CheckZombieInRange()
    {
        // �ҵ���������󣬲���check
        if (attackPos != Vector3.zero)
            return;

        List<GameObject> zombies = gameManager.instance.GetLineZombies(line);
        if (zombies.Count <= 0)
            return;
        // �õ���������Ľ�ʬ�������жϾ����Ƿ��ڷ�Χ��
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
        if (nearZombie == null)
            return;
        // �ҵ���ʬ��ѡ�񹥻����
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
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<ZombieNormal>().changeZombieHealth(-damage);
        }
    }
}

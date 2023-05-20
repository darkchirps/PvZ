using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    public Vector3 direction;//�㶹�ӵ�����ķ���
    public float speed;//������ٶ�

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "zombie")
        {
            collision.GetComponent<ZombieNormal>().changeHealth(-5, Utils.GetZombieData().general.health);
            Destroy(gameObject);
        }
    }
}
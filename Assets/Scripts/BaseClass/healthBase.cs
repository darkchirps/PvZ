using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBase : MonoBehaviour
{
    /// <summary>
    /// 总血量
    /// </summary>
    public int healthMax;
    /// <summary>
    /// 血量
    /// </summary>
    public int health;
    /// <summary>
    /// 改变血量
    /// </summary>
    public void changeHealth(int post,int max)
    {
        health = Mathf.Clamp(health + post, 0, max);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

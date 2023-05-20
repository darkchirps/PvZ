using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBase : MonoBehaviour
{
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBase : MonoBehaviour
{
    /// <summary>
    /// Ѫ��
    /// </summary>
    public int health;
    /// <summary>
    /// �ı�Ѫ��
    /// </summary>
    public void changeHealth(int post,int max)
    {
        health = Mathf.Clamp(health + post, 0, max);
    }
}

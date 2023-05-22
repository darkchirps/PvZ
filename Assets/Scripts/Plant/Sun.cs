using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float placeTime;//̫�����
    public float placeTimer;//̫��ʱ��

    private void Update()
    {
        placeTimer += Time.deltaTime;
        if (placeTimer>=placeTime)
        {
                Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        gameManager.instance.changeSunNum(25);
        Destroy(gameObject);
    }
}

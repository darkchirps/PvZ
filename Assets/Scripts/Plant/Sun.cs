using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float placeTime;//Ì«Ñô¼ä¸ô
    public float placeTimer;//Ì«ÑôÊ±¼ä

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

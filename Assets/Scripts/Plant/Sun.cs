using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float placeTime;//Ì«Ñô¼ä¸ô
    public float placeTimer;//Ì«ÑôÊ±¼ä
    public Vector3 targetPos=new Vector3(0,0,1);
    private void Start()
    {
        //this.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }
    private void Update()
    {
        if (transform.position.y>= targetPos.y)
        {
            transform.position += Vector3.down * 0.5f * Time.deltaTime;
        }
        else
        {
            placeTimer = 1f;
            targetPos.z = 1f;
        }
        placeTimer += Time.deltaTime;
        if (targetPos.z >0f && placeTimer > placeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.instance.changeSunNum(25);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jalapeno : plantBase
{
    public GameObject firePrefab;
    private int line;
    protected override void Start()
    {
        base.Start();
    }

    public override void setPlantState()
    {
        isGrow = true;
        plantCollider.enabled = false;
        plantAni.speed = 1;
        // 种植完成后才启动
        InvokeRepeating("CheckZombieInRange", 1, 0.5f);
        line = gameManager.instance.GetPlantLine(gameObject);
    }
    public void blowAniEnd()
    {
        GameObject fireP = Instantiate(firePrefab);
        Vector3 worldPos = transform.TransformPoint(Vector3.zero);
        fireP.transform.localPosition = new Vector3(-0.77f, worldPos.y+0.15f);
        fireP.GetComponent<JalapenoFire>().line = line;
        Destroy(gameObject);
    }
}

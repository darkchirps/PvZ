using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public GameObject bornParent;
    public GameObject zombiePrefab;
    public int sunNum;

    private int zOrderIndex=0;
    private void Start()
    {
        //µ¥Àý¹ÜÀíÆ÷
        instance = this;
        UIManager.instance.InitUI();
        StartCoroutine(creatZombie());
    }

    public void changeSunNum(int changeNum)
    {
        sunNum += changeNum;
        if (sunNum <= 0)
        {
            sunNum = 0;
        }

        UIManager.instance.UpdateUI();
    }

    IEnumerator creatZombie()
    {
        while (true)
        {
            GameObject zombie = Instantiate(zombiePrefab);
            int index = Random.Range(0, 5);
            Transform zombieP = bornParent.transform.Find("born" + index.ToString());
            zombie.transform.parent = zombieP;
            zombie.transform.localPosition = Vector3.zero;
            zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
            zOrderIndex += 1;
            yield return new WaitForSeconds(1);
        }
    }
}

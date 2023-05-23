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
    //HideInInspector是一个属性修饰符，用于隐藏Inspector面板中的某个变量或字段。当一个变量或字段被标记为HideInInspector时，它将不会在Inspector面板中显示，但是仍然可以在脚本中使用
    [HideInInspector]
    public LevelData levelData;
    [HideInInspector]
    public LevelInfo levelInfo;
    public bool gameStart;
    public int curLevelId = 1;
    public int curProgressId = 1;
    public List<GameObject> curProgressZombie;
    private void Awake()
    {
        //单例管理器
        instance = this;
    }
    private void Start()
    {
        UIManager.instance.InitUI();
        StartCoroutine(infiniteCreatZombie());
        InvokeRepeating("sunMoveDown", 5, 5);
        SoundManager.instance.PlayBGM(Globals.BGM1);
    }
  
    void sunMoveDown()
    {
        GameObject sunPrefab = Resources.Load("Prefabs/Bullet/Sun") as GameObject;
        float x = Random.Range(-4f, 2.25f);
        Vector3 spawnPosition = new Vector3(x, 4f, 0.0f);
        float y = Random.Range(-2.2f, -1.8f);
        GameObject sun = Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
        sun.GetComponent<Sun>().SetTargetPos(new Vector3(x, y, 0));
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

    //随机僵尸
    IEnumerator infiniteCreatZombie()
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
            yield return new WaitForSeconds(3);
        }
    }

}

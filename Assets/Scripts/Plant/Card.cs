using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Card : MonoBehaviour
{
    public GameObject objectPre;//��Ƭ��Ӧ������Ԥ����
    GameObject curGamePre;//��¼��ǰ������Ԥ����

    GameObject darkBg;
    GameObject progressBar;
    public float waitTime;//��Ҫ�ȴ���ʱ��
    public float waitTimer;//��ʱ��
    public int useSun;

    private void Start()
    {
        //��һ�ֻ�ȡ����ķ�ʽ��������
        darkBg = transform.Find("dark").gameObject;
        progressBar = transform.Find("progress").gameObject;
    }

    private void Update()
    {
        waitTimer += Time.deltaTime;
        updateProgress();
        updateDarkBg();
    }

    void updateProgress()
    {
        float per = Mathf.Clamp(waitTimer/waitTime,0,1);
        progressBar.GetComponent<Image>().fillAmount = 1 - per;
    }

    void updateDarkBg()
    {
        if (progressBar.GetComponent<Image>().fillAmount == 0&&gameManager.instance.sunNum>=useSun)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    } 
    //��ק��ʼ
    public void OnBeginDrag(BaseEventData data)
    {
        if (darkBg.activeSelf) return;
        PointerEventData pointData = data as PointerEventData;
        curGamePre = Instantiate(objectPre);
        curGamePre.transform.position = Utils.TranlateScreenToworld(pointData.position);
        
    }
    public void OnDrag(BaseEventData data)
    {
        if (curGamePre == null) return;
        PointerEventData pointData = data as PointerEventData;
        curGamePre.transform.position = Utils.TranlateScreenToworld(pointData.position);
    }
    public void OnEndDrag(BaseEventData data)
    {
        if (curGamePre == null) return;
        PointerEventData pointData = data as PointerEventData;
        Collider2D [] col = Physics2D.OverlapPointAll(Utils.TranlateScreenToworld(pointData.position));
     
        foreach(Collider2D c in col)
        {
            if (c.tag == "land")
            {
                if (c.transform.childCount == 0)
                {
                    curGamePre.transform.parent = c.transform;
                    curGamePre.GetComponent<Renderer>().sortingLayerName = "land";
                    curGamePre.transform.localPosition = Vector3.zero;
                    curGamePre.GetComponent<plantBase>().setPlantState();
                    curGamePre = null;
                    gameManager.instance.changeSunNum(-useSun);
                    waitTimer = 0;
                    break;
                }
                else
                {
                    Destroy(curGamePre);
                    curGamePre = null; 
                    break;
                }
            }
        }
    }
}

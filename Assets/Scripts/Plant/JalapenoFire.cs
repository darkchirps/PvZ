using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JalapenoFire : MonoBehaviour
{
    public int line;


    public void playZombieAni()
    {
        CheckZombieInRange();
    }
    public void fireAniEnd()
    {
        Destroy(gameObject);
    }

    public void CheckZombieInRange()
    {
        List<GameObject> zombies = gameManager.instance.GetLineZombies(line);
        if (zombies.Count <= 0) return;
        for (int i = 0; i < zombies.Count; i++)
        {
            GameObject zombie = zombies[i];
            zombie.GetComponent<Animator>().SetTrigger("borm");
        }
    }
}

using UnityEngine;
using System.Collections;
public class Switch : MonoBehaviour
{
    public int curNumGun; 
    public GameObject[] ObjGuns;
    public GameObject curGun;
    public SkinnedMeshRenderer playerSkin;
    //public int AttackPlayer;
    //public int DefendPlayer;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            curNumGun+= 1;
            if (curNumGun == 3)
            {
                curNumGun = 0;
            }

            if (ObjGuns[curNumGun]!= null)
            {
                if (curGun!= null)
                {
                    Destroy(curGun);
                }

                curGun = Instantiate(ObjGuns[curNumGun]);
                curGun.transform.SetParent(playerSkin.transform.parent);
                SkinnedMeshRenderer[] renderers = curGun.GetComponentsInChildren<SkinnedMeshRenderer>();
                if (renderers.Length > 0)
                {
                    for (int i = 0; i < renderers.Length; i++)
                    {
                        renderers[i].bones=playerSkin.bones;
                        renderers[i].rootBone=playerSkin.rootBone;
                    }
                }
                //AttackPlayer = curGun.GetComponent<Obj>().Attacks;
                //DefendPlayer = curGun.GetComponent<>().Defends;
            }
        }
    }
}

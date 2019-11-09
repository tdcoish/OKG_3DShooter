/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PJ_Gren : PJ_Base
{
    public EX_Gren                                  PF_Explosion;

    void Update()
    {
        if(GetComponent<UT_LifeTime>()._lifeOver){
            Instantiate(PF_Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

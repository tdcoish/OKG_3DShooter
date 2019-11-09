/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PJ_Plas : PJ_Base
{

    void Update()
    {
        if(cLifetime._lifeOver){
            Destroy(gameObject);
        }       
    }
}

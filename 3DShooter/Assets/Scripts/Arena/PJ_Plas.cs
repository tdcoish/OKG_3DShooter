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

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.GetComponent<EN_Rusher>()){
            Destroy(gameObject);
        }

    }
}

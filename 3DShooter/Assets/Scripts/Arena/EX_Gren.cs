/*************************************************************************************

*************************************************************************************/
using UnityEngine;

[RequireComponent(typeof(UT_LifeTime))]
public class EX_Gren : MonoBehaviour
{
    void Update()
    {
        if(GetComponent<UT_LifeTime>()._lifeOver){
            Destroy(gameObject);
        }
    }
}

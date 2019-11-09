/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PJ_Bolt : PJ_Base
{

    void Update()
    {
        // Rotates to the direction he moves.
        Vector3 vDir = cRigid.velocity.normalized;
        transform.rotation = Quaternion.Euler(vDir);

        if(cLifetime._lifeOver){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<PC_Cont>()){
            Destroy(gameObject);
        }
    }
}

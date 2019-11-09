/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PC_Gun : WP_Base
{

    public PJ_Plas                          PF_Plasmoid;

    public void FRun()
    {
        if(Input.GetMouseButton(0)){
            if(_ammo > 0){
                if(Time.time - _lastFireTime > _fireInterval)
                {
                    PC_Cam c = GetComponentInChildren<PC_Cam>();
                    PJ_Plas p = Instantiate(PF_Plasmoid, rFirePoint.transform.position, transform.rotation);
                    p.FFireDirection(c.transform.forward);
                    _lastFireTime = Time.time;
                    _ammo--;
                }
            }
        }
    }

}

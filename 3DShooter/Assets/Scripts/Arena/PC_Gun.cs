/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PC_Gun : WP_Base
{
    private AD_PC                           cAudio;

    public PJ_Plas                          PF_Plasmoid;
    public ParticleSystem                   PF_MuzzleFlash;

    protected override void Start()
    {
        base.Start();
        cAudio = GetComponentInChildren<AD_PC>();
    }

    public void FRun()
    {
        if(Input.GetMouseButton(0)){
            if(_ammo > 0){
                if(Time.time - _lastFireTime > _fireInterval)
                {
                    PC_Cam c = GetComponentInChildren<PC_Cam>();
                    PJ_Plas p = Instantiate(PF_Plasmoid, rFirePoint.transform.position, transform.rotation);
                    Instantiate(PF_MuzzleFlash, rFirePoint.transform.position, transform.rotation);
                    p.FFireDirection(c.transform.forward);
                    cAudio.FFireGun();
                    _lastFireTime = Time.time;
                    _ammo--;
                }
            }
        }
    }

}

/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class AN_Rusher : MonoBehaviour
{

    private EN_Rusher                           cRusher;
    private Animator                            cAnim;

    void Start()
    {
        cRusher = GetComponent<EN_Rusher>();
        cAnim = GetComponentInChildren<Animator>();
    }

    public void FRunAnimations()
    {
        SetAllBoolsToFalse();

        switch(cRusher._state){
            case EN_Rusher.STATE.S_CHARGING: cAnim.SetBool("isCharging", true); break;
            case EN_Rusher.STATE.S_RECOVERING: cAnim.SetBool("isStumbling", true); break;
            case EN_Rusher.STATE.S_TRACKING: cAnim.SetBool("isTracking", true); break;
        }
    }

    void SetAllBoolsToFalse()
    {
        cAnim.SetBool("isTracking", false);
        cAnim.SetBool("isCharging", false);
        cAnim.SetBool("isStumbling", false);
    }

}

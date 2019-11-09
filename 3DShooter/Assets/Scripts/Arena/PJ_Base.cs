/*************************************************************************************

*************************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UT_LifeTime))]
public class PJ_Base : MonoBehaviour
{
    protected Rigidbody                           cRigid;
    protected UT_LifeTime                           cLifetime;

    public float                                    _spd;

    void Awake()
    {
        cLifetime = GetComponent<UT_LifeTime>();   
        cRigid = GetComponent<Rigidbody>();    
    }

    public void FFireDirection(Vector3 vDir)
    {
        vDir = Vector3.Normalize(vDir);
        vDir *= _spd;
        cRigid.velocity = vDir;
    }
}

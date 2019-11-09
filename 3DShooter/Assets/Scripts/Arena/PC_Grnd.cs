/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class PC_Grnd : MonoBehaviour
{

    public float                                _fireInterval;
    private float                               _lastFireTime;
    public PJ_Gren                              PF_Grenade;
    public WP_FirePoint                         rFirePoint;

    void Start()
    {
        _lastFireTime = _fireInterval * -1f;
    }

    public void FRun()
    {
        if(Input.GetMouseButton(1)){
            if(Time.time - _lastFireTime > _fireInterval)
            {
                PJ_Gren p = Instantiate(PF_Grenade, rFirePoint.transform.position, transform.rotation);
                Vector3 vDir = GetComponentInChildren<PC_Cam>().transform.forward;
                p.FFireDirection(vDir);
                _lastFireTime = Time.time;
            }
        }
    }
}

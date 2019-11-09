/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class EN_Tur : EN_Base
{

    public PJ_Bolt                      PF_Bolt;

    private float                       _lastShot;
    public float                        _shotInterval = 2f;
    public WP_FirePoint                 rFirePoint;

    void Update()
    {
        Vector3 vDir = rPC.transform.position - transform.position;
        vDir.y = 0f;
        vDir = Vector3.Normalize(vDir);
        transform.forward = vDir;
        // transform.rotation = Quaternion.Euler(vDir);

        if(Time.time - _lastShot > _shotInterval)
        {
            PJ_Bolt b = Instantiate(PF_Bolt, rFirePoint.transform.position, transform.rotation);
            vDir = rPC.transform.position - rFirePoint.transform.position;
            b.FFireDirection(vDir);
            _lastShot = Time.time;
        }
    }
}

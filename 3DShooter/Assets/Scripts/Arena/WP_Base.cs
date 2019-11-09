/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class WP_Base : MonoBehaviour
{
    public WP_FirePoint                 rFirePoint;

    public int                          _maxAmmo;
    public int                          _ammo;

    public float                        _fireInterval;
    protected float                     _lastFireTime;

    void Start()
    {
        _ammo = _maxAmmo;
    }
}

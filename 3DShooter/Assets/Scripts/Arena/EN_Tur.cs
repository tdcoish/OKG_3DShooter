/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public enum STATE_TUR {SFIRING, SCOOLDOWN}

public class EN_Tur : EN_Base
{

    public PJ_Bolt                      PF_Bolt;

    private float                       _lastShot;
    public float                        _shotInterval = 2f;
    private float                       _coolDownStartTime;
    public float                        _coolDownTime = 2f;
    public int                          _volleyAmount = 5;
    public int                          _volleyCurShot = 0;

    public STATE_TUR                    _state = STATE_TUR.SFIRING;
    public WP_FirePoint                 rFirePoint;

    void Update()
    {
        switch(_state)
        {
            case STATE_TUR.SFIRING: RUN_FIRING_STATE(); break;
            case STATE_TUR.SCOOLDOWN: RUN_COOLDOWN_STATE(); break;
        }
    }

    void RUN_FIRING_STATE()
    {
        // Eventually want to make the turret have rotational speed. For now just snap to player.
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

            _volleyCurShot++;
            if(_volleyCurShot >= _volleyAmount)
            {
                _state = STATE_TUR.SCOOLDOWN;
                _coolDownStartTime = Time.time;
            }
        }
    }

    void RUN_COOLDOWN_STATE()
    {
        if(Time.time - _coolDownStartTime > _coolDownTime){
            _state = STATE_TUR.SFIRING;
            _volleyCurShot = 0;
        }
    }
}

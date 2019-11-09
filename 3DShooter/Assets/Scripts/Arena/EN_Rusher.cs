/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class EN_Rusher : EN_Base
{
    public enum STATE{
        S_TRACKING,
        S_CHARGING,
        S_RECOVERING
    }
    public STATE                        _state;

    private float                       _chargeStartTime;
    public float                        _maxChargeDis = 2f;
    public float                        _chargeSpdBoost = 3f;
    public float                        _chargeTime = 2f;

    private float                       _recoveryStartTime;
    public float                        _recoveryTime = 1f;

    void Start()
    {
        base.Start();
        _state = STATE.S_TRACKING;
    }

    void Update()
    {

        switch(_state){
            case STATE.S_TRACKING: RUN_TRACKING(); break;
            case STATE.S_CHARGING: RUN_CHARGING(); break;
            case STATE.S_RECOVERING: RUN_RECOVERING(); break;
        }

        if(_health <= 0f){
            KillYourself();
        }
    }

    private void ENTER_TRACKING(){
        _state = STATE.S_TRACKING;
    }
    private void RUN_TRACKING()
    {
        Vector3 vDif = rPC.transform.position - transform.position;
        vDif.y = 0f;
        vDif = Vector3.Normalize(vDif);
        cRigid.velocity = vDif * _spd;

        if(Vector3.Distance(transform.position, rPC.transform.position) < _maxChargeDis){
            ENTER_CHARGING();
        }
    }
    private void ENTER_CHARGING(){
        _state = STATE.S_CHARGING;
        cRigid.velocity *= 3f;
        _chargeStartTime = Time.time;
    }
    private void RUN_CHARGING()
    {
        if(Time.time - _chargeStartTime > _chargeTime){
            ENTER_RECOVERING();
        }
    }
    private void ENTER_RECOVERING()
    {
        _state = STATE.S_RECOVERING;
        _recoveryStartTime = Time.time;
        cRigid.velocity = Vector3.zero;
    }
    private void RUN_RECOVERING()
    {
        if(Time.time - _recoveryStartTime > _recoveryTime){
            ENTER_TRACKING();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<EN_Rusher>()){
            _health = 0f;
        }
        if(other.gameObject.GetComponent<PJ_Base>()){
            _health = 0f;
        }

    }
}

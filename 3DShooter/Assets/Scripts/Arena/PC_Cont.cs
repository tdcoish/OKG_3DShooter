/*************************************************************************************
Give em a gun.
*************************************************************************************/
using UnityEngine;

public class PC_Cont : MonoBehaviour
{
    private Rigidbody                   cRigid;
    private PC_Cam                      cCam;
    private PC_Gun                      cGun;
    private PC_Grnd                     cGrnd;
    private PC_Shields                  cShields;

    public UI_PC                        rUI;

    public float                        _accRate = 100f;
    public float                        _maxSpd = 10f;
    public float                        _sideSpd = 0.5f;
    public float                        _backSpd = 0.25f;
    public float                        _maxHealth = 100f;
    public float                        _health;

    void Start()
    {
        cRigid = GetComponent<Rigidbody>();
        cCam = GetComponentInChildren<PC_Cam>();
        cGun = GetComponent<PC_Gun>();
        cGrnd = GetComponent<PC_Grnd>();
        cShields = GetComponent<PC_Shields>();

        _health = _maxHealth;
    }

    void Update()
    {
        HandleMouseRotations();

        cGun.FRun();
        cGrnd.FRun();

        CheckAndHandleDeath();
        rUI.fSetHealthBarSize(_health, _maxHealth);
        rUI.FSetShieldBarSize(cShields._val, cShields._maxVal);
        rUI.FSetAmmoBarSize(cGun._ammo, cGun._maxAmmo);
        rUI.FSetTimeText(Time.time);
    }

    void FixedUpdate()
    {
        cRigid.velocity = FindVelFromInput(cRigid.velocity);
        // cRigid.velocity = FindVelFromJumpingInput(cRigid.velocity);
    }

    private void HandleMouseRotations()
    {
        // want to get rid of y component of the cameras rotation.
        float mouseX = Input.GetAxis("Mouse X") * 1f;
        float mouseY = Input.GetAxis("Mouse Y") * 1f;
        // look sensitivity between 0.5 - 1.5

        // rotate camera view around y axis.
        transform.RotateAround(transform.position, Vector3.up, mouseX);
        Vector3 xAx = Vector3.Cross(transform.forward, Vector3.up);
        cCam.transform.RotateAround(transform.position, xAx, mouseY);
    }


    /***************************************************************************************
    The player does not move forwards, backwards, and side to side at the same speed. But we 
    also can't let them move faster diagonally. 
    ***************************************************************************************/
    private Vector3 FindVelFromInput(Vector3 vCurSpd)
    {
        Vector3 vVel = new Vector3();

        bool moveForOrBack = false; bool moveSide = false;

        if(Input.GetKey(KeyCode.A)){
            vVel += transform.right * -_maxSpd * _sideSpd;
            moveSide = true;
        }
        if(Input.GetKey(KeyCode.D)){
            vVel += transform.right * _maxSpd * _sideSpd;
            moveSide = true;
        }
        if(Input.GetKey(KeyCode.W)){
            vVel += transform.forward * _maxSpd;
            moveForOrBack = true;
        }
        if(Input.GetKey(KeyCode.S)){
            vVel += transform.forward * -_maxSpd * _backSpd;
            moveForOrBack = true;
        }

        // Normalize vectors, then add them together, get dot product. Normalize, multiply by averaged magnitude.   
        if(moveForOrBack && moveSide)
        {
            vVel *= 0.75f;
        }
        
        return vVel;
    }

    private Vector3 FindVelFromJumpingInput(Vector3 vCurVel)
    {
        // Actually need to test if they're on the ground.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            vCurVel.y += 20f;
            return vCurVel;
        }else{
            return vCurVel;
        }
    }

    private void CheckAndHandleDeath()
    {
        if(_health <= 0f){
            TDC_EventManager.FBroadcast(TDC_GE.GE_PCDeath);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PJ_Bolt>()){

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<PJ_Bolt>())
        {
            _health -= cShields.FTakeDamageGiveRemainder(60f);
        }
        if(other.gameObject.GetComponent<EX_Gren>()){
            _health -= cShields.FTakeDamageGiveRemainder(20f);
        }
        if(other.gameObject.GetComponent<EN_Rusher>())
        {
            _health -= cShields.FTakeDamageGiveRemainder(80f);
        }
    }
}

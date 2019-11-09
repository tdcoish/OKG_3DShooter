/*************************************************************************************
Give em a gun.
*************************************************************************************/
using UnityEngine;

public class PC_Cont : MonoBehaviour
{
    private Rigidbody                   cRigid;
    private PC_Cam                      cCam;
    private PC_Gun                      cGun;

    public float                        _accRate = 100f;
    public float                        _maxSpd = 10f;

    void Start()
    {
        cRigid = GetComponent<Rigidbody>();
        cCam = GetComponentInChildren<PC_Cam>();
        cGun = GetComponent<PC_Gun>();
    }

    void Update()
    {
        // want to get rid of y component of the cameras rotation.
        float mouseX = Input.GetAxis("Mouse X") * 1f;
        float mouseY = Input.GetAxis("Mouse Y") * 1f;
        // look sensitivity between 0.5 - 1.5

        // rotate camera view around y axis.
        transform.RotateAround(transform.position, Vector3.up, mouseX);
        Vector3 xAx = Vector3.Cross(transform.forward, Vector3.up);
        cCam.transform.RotateAround(transform.position, xAx, mouseY);

        cGun.FRun();
    }

    void FixedUpdate()
    {
        cRigid.velocity = FindVelFromInput(cRigid.velocity);
        // cRigid.velocity = FindVelFromJumpingInput(cRigid.velocity);
    }

    private Vector3 FindVelFromInput(Vector3 vCurSpd)
    {
        float fSideAcc = 0f;
        float fForAcc = 0f;

        if(Input.GetKey(KeyCode.A)){
            fSideAcc -= _accRate * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            fSideAcc += _accRate * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.W)){
            fForAcc += _accRate * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            fForAcc -= _accRate * Time.fixedDeltaTime;
        }

        if(Mathf.Abs(fForAcc) + Mathf.Abs(fSideAcc) > _accRate)
        {
            fForAcc *= 0.707f;
            fSideAcc *= 0.707f;
        }


        Vector3 vVel = vCurSpd;
        // basically, if we're not accelerating, then make our velocity lowered.
        // other wise do so normally.
        if(Mathf.Abs(fForAcc) + Mathf.Abs(fSideAcc) < 0.1f)
        {
            // say we'll stop over 1 second, or so.
            vVel -= vVel * Time.fixedDeltaTime * _maxSpd;
            // and if we go too far, then just set vel to zero.
            if(Vector3.Dot(vVel, vCurSpd) <= 0f)
            {
                return Vector3.zero;
            }
        }
        else
        {
            vVel += fForAcc * transform.forward;
            vVel += fSideAcc * transform.right;
        }
        if(Vector3.Magnitude(vVel) > _maxSpd)
        {
            vVel *= _maxSpd / Vector3.Magnitude(vVel);
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
}

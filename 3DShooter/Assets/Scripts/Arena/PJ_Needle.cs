using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************
I want two different behaviours from the needler. First, the Halo:CE behaviour. Easy to dodge projectiles that have enough space between 
shots to let the player weave between. This makes it an excellent long range weapon, since the 

Second, I want a needle that calculates an intercept path. It needs to be very slow turning to compensate though. Maybe not. But that 
would prevent the player from just strafing in the same direction the entire time.
*******************************/

public class PJ_Needle : MonoBehaviour
{
    public float            _angleChangePerSec = 10f;
    public float            _spd = 2f;

    PC_Cont                 rPC;

    UT_LifeTime             cLifeTime;
    public Rigidbody        cRigid;

    void Start()
    {
        rPC = FindObjectOfType<PC_Cont>();
        if(rPC == null){
            Debug.Log("No PC in scene");
        }
        cRigid = GetComponent<Rigidbody>();
        if(cRigid == null){
            Debug.Log("No rigidbody");
        }
        cLifeTime = GetComponent<UT_LifeTime>();
        if(cLifeTime == null){
            Debug.Log("No Lifetime");
        }
        cRigid.velocity = rPC.transform.position - transform.position;
        cRigid.velocity = cRigid.velocity.normalized * _spd;
    }

    // Update velocity towards player each frame.
    void Update()
    {
        if(rPC == null){
            Debug.Log("No PC in scene");
        }

        Vector3 vDirToPC = rPC.transform.position - transform.position;
        vDirToPC = Vector3.Normalize(vDirToPC);
        // we just want to find the new angle that is rotated towards the player.
        Vector3 vCurHeading = cRigid.velocity.normalized;
        float singleStep = _angleChangePerSec * Mathf.Deg2Rad * Time.deltaTime;
        Vector3 vNewHeading = Vector3.RotateTowards(vCurHeading, vDirToPC, singleStep, 0.0f);

        cRigid.velocity = vNewHeading * _spd;
        cRigid.rotation = Quaternion.LookRotation(cRigid.velocity.normalized * -1, Vector3.up);


        if(cLifeTime._lifeOver){
            Destroy(gameObject);
        }
    }
}

﻿/*************************************************************************************

*************************************************************************************/
using UnityEngine;

public class GM_Man : MonoBehaviour
{

    public float                                _spawnInterval = 4f;
    private float                               _lastSpawnTime;
    public GM_EN_Spawn[]                        _spawners;
    public EN_Rusher                            PF_Rusher;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
    }

    void Update()
    {
        if(Time.time - _lastSpawnTime > _spawnInterval)
        {
            for(int i=0; i<_spawners.Length; i++){
                Instantiate(PF_Rusher, _spawners[i].transform.position, transform.rotation);
            }
            _lastSpawnTime = Time.time;
        }
    }
}

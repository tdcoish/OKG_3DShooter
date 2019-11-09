﻿/*************************************************************************************

*************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_Man : MonoBehaviour
{

    public float                                _spawnInterval = 4f;
    private float                               _lastSpawnTime;
    public GM_EN_Spawn[]                        _spawners;
    public EN_Rusher                            PF_Rusher;

    void Awake()
    {
        TDC_EventManager.FRemoveAllHandlers();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;   

        TDC_EventManager.FAddHandler(TDC_GE.GE_PCDeath, E_PlayerDied); 

        _lastSpawnTime = _spawnInterval * -1f;
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


        // ------------ Pause Menu Stuff
        if(Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void E_PlayerDied()
    {
        SceneManager.LoadScene("Death");
    }
}

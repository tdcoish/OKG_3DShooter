/*************************************************************************************

*************************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MN_Main : MonoBehaviour
{
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
  
    public void BT_Play()
    {
        SceneManager.LoadScene("Arena");
    }
    public void BT_Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void BT_Quit()
    {
        Application.Quit();
    }
}

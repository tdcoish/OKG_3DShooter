/*************************************************************************************

*************************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MN_Death : MonoBehaviour
{
    public Text                         _txtScore;

    void Start()
    {
        _txtScore.text = "SCORE: " + 1000;
    }

    public void BT_PlayAgain()
    {
        SceneManager.LoadScene("Arena");        
    }
    public void BT_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

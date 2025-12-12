using UnityEngine;
using UnityEngine.SceneManagement;


public class Help : MonoBehaviour
{
    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Start()
    {
        //if (!GameManager.Instance.IsMainMenuRun)
        if (!Globals.IsMainMenuCalled)
        {
            SceneManager.LoadScene("MainMenuScene");
            return;
        }

        //this._windowRect.x = (Screen.width  - this._windowRect.width ) / 2;
        //this._windowRect.y = (Screen.height - this._windowRect.height) / 2;
        //this._playImage    = Resources.Load<Texture2D>("Shared/Sprites/audio_start");

    }   // Start()
    #endregion


}   // class Help

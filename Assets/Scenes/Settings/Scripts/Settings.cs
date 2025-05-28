using UnityEngine;
using UnityEngine.SceneManagement;


public class Settings : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   guiSkin
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public GUISkin guiSkin;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _windowRect
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    private Rect _windowRect = new(0, 0, 400, 400);

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // --------------
    // -------------------------------------------------------------------------


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   DoWindow()
    //   OnGUI()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  DoWindow()  .
    // -------------------------------------------------------------------------
    //  Method.......:  DoWindow()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void DoWindow(int id)
    {
        if (GUI.Button(new Rect(100, 260, 200, 50), "MAIN MENU"))
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        GUI.DragWindow(new Rect(0, 0, 10000, 10000));

    }   // DoWindow()
    #endregion


    #region .  OnGUI()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnGUI()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void OnGUI()
    {
        GUI.skin = guiSkin;
        this._windowRect = GUI.Window(0, this._windowRect, DoWindow, "SETTINGS");

    }   // OnGUI()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  
    //  Parameters...:  asteroid
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Start()
    {
        this._windowRect.x = (Screen.width  - this._windowRect.width ) / 2;
        this._windowRect.y = (Screen.height - this._windowRect.height) / 2;

    }   // Start()
    #endregion


}   // Class Settings

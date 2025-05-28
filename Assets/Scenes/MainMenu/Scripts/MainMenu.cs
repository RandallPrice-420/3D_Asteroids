using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
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
    //   Quit()
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
        if (GUI.Button(new Rect(100, 100, 200, 50), "PLAY"))
        {
            SceneManager.LoadScene("GameScene");
        }

        if (GUI.Button(new Rect(100, 180, 200, 50), "SETTINGS"))
        {
            SceneManager.LoadScene("SettingsScene");
        }

        if (GUI.Button(new Rect(100, 260, 200, 50), "QUIT"))
        {
            this.Quit();
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
        this._windowRect = GUI.Window(0, this._windowRect, DoWindow, "MAIN MENU");

    }   // OnGUI()
    #endregion


    #region .  Quit()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Quit()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Quit()
    {
        Debug.Log("QUIT !");

    }   // Quit()
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


}   // Class MainMenu

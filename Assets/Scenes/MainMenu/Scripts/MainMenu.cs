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
    //   //_toggleMusic
    //   _modalRect
    //   _windowRect
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    //private readonly bool _toggleMusic = true;
    private Rect _modalRect  = new(0f, 0f, 400f, 200f);
    private Rect _windowRect = new(0f, 0f, 400f, 400f);

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   Help()
    //   Play()
    //   Quit()
    //   Settings()
    // -------------------------------------------------------------------------

    #region .  Help()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Help()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void Help()
    {
        SceneManager.LoadScene("HelpScene");

    }   // Help()
    #endregion


    #region .  Play()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Play()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void Play()
    {
        SceneManager.LoadScene("GameScene");

    }   // Play()
    #endregion


    #region .  Quit()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Quit()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }   // Quit()
    #endregion


    #region .  Settings()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Settings()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void Settings()
    {
        SceneManager.LoadScene("SettingsScene");

    }   // Settings()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   DoModalWindow()      --  COMMENTED OUT
    //   DoWindow()           --  COMMENTED OUT
    //   OnApplicationQuit()  --  DOES NOTHING YET
    //   OnGUI()              --  COMMENTED OUT
    //   Start()
    // -------------------------------------------------------------------------

    #region .  DoModalWindow()      --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  DoModalWindow()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void DoModalWindow(int id)
    //{
    //    GUI.Label(new Rect( 5f, 25f, 420f, 20f), "____________________________________________________________", guiSkin.customStyles[(int)Globals.CustomStyles.Underline]);

    //    GUILayout.BeginVertical();
    //        GUILayout.Space(50f);
    //        GUILayout.BeginHorizontal();
    //            GUILayout.Label("Are you sure you want to quit?");
    //        GUILayout.EndHorizontal();
    //        GUILayout.Space(50f);
    //        GUILayout.BeginHorizontal();
    //            if (GUILayout.Button("YES"))
    //            {
    //                Debug.Log("YES");
    //            }
    //            if (GUILayout.Button("NO"))
    //            {
    //                Debug.Log("NO");
    //            }
    //        GUILayout.EndHorizontal();
    //    GUILayout.EndVertical();



    //    //if (GUI.Button(new Rect(50f, 120f, 150f, 60f), "YES"))
    //    //{
    //    //    //SceneManager.LoadScene("GameScene");
    //    //}

    //    //if (GUI.Button(new Rect(200f, 120f, 150f, 60f), "NO"))
    //    //{
    //    //    //SceneManager.LoadScene("SettingsScene");
    //    //}

    //    GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

    //}   // DoModalWindow()
    #endregion


    #region .  DoWindow()           --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  DoWindow()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void DoWindow(int id)
    //{
    //    GUI.Label(new Rect(5f, 25f, 420f, 20f), "____________________________________________________________", guiSkin.customStyles[(int)Globals.CustomStyles.Underline]);

    //    if (GUI.Button(new Rect(100f, 100f, 200f, 60f), "PLAY"))
    //    {
    //        SceneManager.LoadScene("GameScene");
    //    }

    //    if (GUI.Button(new Rect(100f, 190f, 200f, 60f), "SETTINGS"))
    //    {
    //        SceneManager.LoadScene("SettingsScene");
    //    }

    //    if (GUI.Button(new Rect(100f, 280f, 200f, 60f), "QUIT"))
    //    {
    //        this.Quit();
    //    }

    //    GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

    //}   // DoWindow()
    #endregion


    #region .  OnApplicationQuit()  --  DOES NOTHING YET  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  OnApplicationQuit()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void OnApplicationQuit()
    //{

    //}   // OnApplicationQuit()
    #endregion


    #region .  OnGUI()              --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  OnGUI()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void OnGUI()
    //{
    //    GUI.skin = guiSkin;
    //    this._windowRect = GUI.Window(0, this._windowRect, DoWindow, "MAIN MENU");

    //    //this._modalRect = GUI.ModalWindow(1, this._modalRect, DoModalWindow, "Quit Game?");

    //}   // OnGUI()
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
        Debug.Log($"Screen.width:  {Screen.width}, Screen.height:  {Screen.height}");

        this._modalRect.x = (Screen.width  - this._modalRect.width ) / 2f;
        this._modalRect.y = (Screen.height - this._modalRect.height) / 2f;

        //this._windowRect.x = (Screen.width  - this._windowRect.width ) / 2f;
        //this._windowRect.y = (Screen.height - this._windowRect.height) / 2f;

        MusicPlayer.Instance.PlayRandom();

        //GameManager.Instance.IsMainMenuRun = true;
        Globals.IsMainMenuCalled = true;

    }   // Start()
    #endregion


}   // Class MainMenu

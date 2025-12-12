using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class PanelSettings : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   audioSource
    //   guiSkin
    //   AudioClipTestMusic
    //   AudioClipTestSFX
    //   ButtonMusicOff
    //   ButtonMusicOn
    //   ButtonMusicPlay
    //   ButtonMusicStop
    //   ButtonSpaceships
    //   ButtonSFXOff
    //   ButtonSFXOn
    //   ButtonSFXPlay
    //   ButtonSFXStop
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public string      AssetsPath = "Assets/Shared/Prefabs/Spaceships";
    public AudioSource audioSource;
    public GUISkin     guiSkin;
    public AudioClip   AudioClipTestMusic;
    public AudioClip   AudioClipTestSFX;
    public Button      ButtonMusicOff;
    public Button      ButtonMusicOn;
    public Button      ButtonMusicPlay;
    public Button      ButtonMusicStop;
    public Button      ButtonSpaceships;
    public Button      ButtonSFXOff;
    public Button      ButtonSFXOn;
    public Button      ButtonSFXPlay;
    public Button      ButtonSFXStop;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _buttonBackSettings
    //   _buttonSave
    //   _buttonSpaceships
    //   _buttonPlayImage
    //   _buttonStopImage
    //   _currentSpaceship
    //   _sliderMusicValue
    //   _sliderSFXValue
    //   _toggleMusic
    //   _toggleSFX
    //   _windowRect
    //   _assetsPath
    //   _spaceship
    //   _spaceshipsList
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    private Button                   _buttonBackSettings;
    private Button                   _buttonSave;
    private Button                   _buttonSpaceships;
    
    private Texture2D                _buttonPlayImage;
    private Texture2D                _buttonStopImage;
    //private readonly int             _currentSpaceship = 0;
    //private readonly float           _sliderMusicValue = 0.0f;
    //private readonly float           _sliderSFXValue   = 0.0f;
    //private readonly bool            _toggleMusic      = true;
    //private readonly bool            _toggleSFX        = true;
    private Rect                     _windowRect       = new(0, 0, 400, 400);

    private readonly Spaceship       _spaceship;
    private readonly List<Spaceship> _spaceshipsList   = new();

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // --------------
    //   PlayClip()
    //   StopClip()
    // -------------------------------------------------------------------------

    #region .  PlayClip()  .
    // -------------------------------------------------------------------------
    //  Method.......:  PlayClip()
    //  Description..:  
    //  Parameters...:  AudioClip - the AudioClip to play.
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void PlayClip(AudioClip audioClip)
    {
        this.audioSource.PlayOneShot(audioClip);

    }   // PlayClip()
    #endregion


    #region .  StopClip()  .
    // -------------------------------------------------------------------------
    //  Method.......:  StopClip()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void StopClip()
    {
        this.audioSource.Stop();

    }   // StopClip()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   DoWindow()  --  COMMENTED OUT
    //   OnGUI()     --  COMMENTED OUT
    //   Awake()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  DoWindow()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  DoWindow()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void DoWindow(int id)
    //{
    //    GUI.Label(new Rect(5f, 25f, 420f, 20f), "____________________________________________________________", guiSkin.customStyles[(int)Globals.CustomStyles.Underline]);
    //    GUI.Label(new Rect(20f, 90f, 75f, 20f), "SOUND:");

    //    // Music controls.
    //    _toggleMusic = GUI.Toggle(new Rect(25f, 125f, 100f, 30f), _toggleMusic, "Music");
    //    _sliderMusicValue = GUI.HorizontalSlider(new Rect(120f, 128f, 225f, 30f), _sliderMusicValue, 0f, 10f);
    //    if (GUI.Button(new Rect(362f, 122f, 30f, 30f), "", guiSkin.customStyles[(int)Globals.CustomStyles.ButtonPlay]))
    //    {
    //        SceneManager.LoadScene("MainMenuScene");
    //    }


    //    // SFX controls.
    //    _toggleSFX = GUI.Toggle(new Rect(25f, 165f, 100f, 30f), _toggleSFX, "SFX");
    //    _sliderSFXValue = GUI.HorizontalSlider(new Rect(120f, 167f, 225f, 30f), _sliderSFXValue, 0f, 10f);
    //    if (GUI.Button(new Rect(362f, 162f, 30f, 30f), "", guiSkin.customStyles[(int)Globals.CustomStyles.ButtonPlay]))
    //    {
    //        SceneManager.LoadScene("MainMenuScene");
    //    }

    //    if (GUI.Button(new Rect(100f, 280f, 200f, 60f), "MAIN MENU"))
    //    {
    //        SceneManager.LoadScene("MainMenuScene");
    //    }

    //    GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));

    //}   // DoWindow()
    #endregion


    #region .  OnGUI()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  OnGUI()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void OnGUI()
    //{
    //    GUI.skin = guiSkin;
    //    this._windowRect = GUI.Window(0, this._windowRect, DoWindow, "SETTINGS");

    //}   // OnGUI()
    #endregion


    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Awake()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Awake()
    {
        ////if (!GameManager.Instance.IsMainMenuRun)
        //if (!Globals.IsMainMenuCalled)
        //{
        //    SceneManager.LoadScene("MainMenuScene");
        //    return;
        //}

        this._windowRect.x       = (Screen.width  - this._windowRect.width)  / 2;
        this._windowRect.y       = (Screen.height - this._windowRect.height) / 2;

        this._buttonBackSettings = GameObject.Find("ButtonBackSettings").GetComponent<Button>();
        this._buttonSave         = GameObject.Find("ButtonSave"        ).GetComponent<Button>();
        this._buttonSpaceships   = GameObject.Find("ButtonSpaceships"  ).GetComponent<Button>();

        this._buttonPlayImage    = Resources.Load<Texture2D>("Shared/Sprites/audio_start");
        this._buttonStopImage    = Resources.Load<Texture2D>("Shared/Sprites/audio_stop");

    }   // Awake()
    #endregion


    #region .  Start()  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  Start()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void Start()
    //{

    //}   // Start()
    #endregion


}   // Class PanelSettings

using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PanelSpaceships : Singleton<PanelSpaceships>
{
    // ------------------------------------------------------------------------ 
    // Public Properties:
    // ------------------
    //   AllowRotation
    //   CanvasSpaceship
    //   CurrentRotation
    //   RotationSpeed
    //   SpaceshipContainer
    //   TMP_ButtonPause
    //   TMP_CountCannons
    //   TMP_CountGuns
    //   TMP_CountLasers
    //   TMP_CountSpaceship
    //   TMP_NameSpaceship
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public bool       AllowRotation = true;
    public Canvas     CanvasSpaceship;
    public Vector3    CurrentRotation;
    public float      RotationSpeed = 50f;
    public GameObject SpaceshipContainer;
    public TMP_Text   TMP_ButtonPause;
    public TMP_Text   TMP_CountCannons;
    public TMP_Text   TMP_CountGuns;
    public TMP_Text   TMP_CountLasers;
    public TMP_Text   TMP_CountSpaceship;
    public TMP_Text   TMP_NameSpaceship;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    ////   _axis
    ////   _pressed
    //
    //   _countCannons
    //   _countGuns
    //   _countLasers
    //   _currentSpaceshipIndex
    //   _currentSpaceshipPrefab
    //   _spaceshipsList
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    //[SerializeField] private InputAction _axis;
    //[SerializeField] private InputAction _pressed;

    private          int                 _countCannons           = 0;
    private          int                 _countGuns              = 0;
    private          int                 _countLasers            = 0;
    private          GameObject          _currentSpaceship       = null;
    private          int                 _currentSpaceshipIndex  = 0;
    //private readonly Spaceship           _currentSpaceshipPrefab = null;
    private readonly List<Spaceship>     _spaceshipsList         = new();

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // --------------
    //   ButtonBackOnClick()
    //   ButtonPauseOnClick()
    //   ButtonSaveOnClick()
    //   ButtonSpaceshipsOnClick()
    //   ShowSpaceship()
    // -------------------------------------------------------------------------

    #region .  ButtonBackOnClick()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ButtonBackOnClick()
    //  Description..:  Pause or resume the spaceship automatic rotation..
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void ButtonBackOnClick()
    {
        //SceneManager.LoadScene("SettingsScene");

    }   // ButtonBackOnClick()
    #endregion


    #region .  ButtonPauseOnClick()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ButtonPauseOnClick()
    //  Description..:  Pause or resume the spaceship automatic rotation..
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void ButtonPauseOnClick()
    {
        this.AllowRotation        = !this.AllowRotation;
        this.TMP_ButtonPause.text = (this.AllowRotation) ? "Pause" : "Resume";

    }   // ButtonPauseOnClick()
    #endregion


    #region .  ButtonSaveOnClick()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ButtonSaveOnClick()
    //  Description..:  Pause or resume the spaceship automatic rotation..
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void ButtonSaveOnClick()
    {
        this.AllowRotation = !this.AllowRotation;
        this.TMP_ButtonPause.text = (this.AllowRotation) ? "Pause" : "Resume";

    }   // ButtonSaveOnClick()
    #endregion


    #region .  ShowSpaceship()  .
    // -------------------------------------------------------------------------
    //  Method.......:  ShowSpaceship()
    //  Description..:  Select the previous or next spaceship.
    //  Parameters...:  int : 0 = none, 1 = next spaceship, -1 = previous spaceship.
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void ShowSpaceship(int index)
    {
        this.SpaceshipContainer.transform.GetChild(this._currentSpaceshipIndex).gameObject.SetActive(false);

        int length = this.SpaceshipContainer.transform.childCount - 1;

        this._currentSpaceshipIndex += index;
        this._currentSpaceshipIndex = (this._currentSpaceshipIndex < 0)      ? length
                                    : (this._currentSpaceshipIndex > length) ? 0
                                    :  this._currentSpaceshipIndex;

        this._currentSpaceship = this.SpaceshipContainer.transform.GetChild(this._currentSpaceshipIndex).gameObject;
        this._currentSpaceship.SetActive(true);

        this.UpdateSpaceshipInfo();

    }   // ShowSpaceship()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   LoadSpaceships()  --  COMMENTED OUT
    //   Start()
    //   Update()
    //   UpdateSpaceshipInfo()
    // -------------------------------------------------------------------------

    #region .  LoadSpaceships()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  LoadSpaceships()
    ////  Description..:  
    ////  Parameters...:  label
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void LoadSpaceships()
    //{
    //    this._spaceshipsList = Utils.LoadSpaceshipAssets(this.AssetsPrefabsPath);

    //    Transform  parent    = this.SpaceshipContainer.transform;
    //    Vector3    position  = new(960.0f, 530.0f, -925.0f);
    //    Quaternion rotation  = Quaternion.Euler(0.0f, 125.0f, -30.0f);

    //    for (int index = 0; index < this._spaceshipsList.Count; index++)
    //    {
    //        Spaceship spaceship = Instantiate(this._spaceshipsList[index], position, rotation, parent);
    //        spaceship.gameObject.SetActive(false);

    //        // Set the Canvas as the parent.
    //        spaceship.transform.localPosition = position;
    //        spaceship.transform.localScale    = new(0.05f, 0.05f, 0.05f);
    //        spaceship.transform.localRotation = rotation;
    //    }

    //}   // LoadSpaceships()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Start()
    {
        this.ShowSpaceship(0);

    }   // Start()
    #endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Update()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Update()
    {
        this.CurrentRotation = new Vector3(0f, this.RotationSpeed * Time.deltaTime, 0f);

    }   // Update()
    #endregion


    #region .  UpdateSpaceshipInfo()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateSpaceshipInfo()
    //  Description..:  Update the information text values for the currently
    //                  selected spaceship.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void UpdateSpaceshipInfo()
    {
        this._countCannons = 0;
        this._countLasers  = 0;
        this._countGuns    = 0;

        // Loop through the child components of the current spaceship and use
        // the tag properties to count the number of cannons, guns and lasers.
        foreach (Transform child in this._currentSpaceship.transform)
        {
            if (child.CompareTag("Cannon")) this._countCannons++;
            if (child.CompareTag("Laser" )) this._countLasers++;
            if (child.CompareTag("Gun"   )) this._countGuns++;
        }

        // Update the text values.
        this.TMP_NameSpaceship.text  =    this._currentSpaceship.name;
        this.TMP_CountSpaceship.text = $"{this._currentSpaceshipIndex + 1} of {this.SpaceshipContainer.transform.childCount}";
        this.TMP_CountCannons.text   =    this._countCannons.ToString();
        this.TMP_CountGuns.text      =    this._countGuns   .ToString();
        this.TMP_CountLasers.text    =    this._countLasers .ToString();

    }   // UpdaUpdateSpaceshipInfote()
    #endregion


}   // Class PanelSpaceships

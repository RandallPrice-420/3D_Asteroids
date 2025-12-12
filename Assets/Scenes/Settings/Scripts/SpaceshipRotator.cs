using UnityEngine;
using UnityEngine.InputSystem;


public class SpaceshipRotator : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   RotationSpeed
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public float RotationSpeed = 50;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _axis
    //   _pressed
    //   _isRotateAllowed
    //   _rotation
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private InputAction _axis;
    [SerializeField] private InputAction _pressed;

    private readonly bool    _isRotateAllowed;
    private          Vector2 _rotation;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()   --  COMMENTED OUT
    //   Rotate()  --  COMMENTED OUT
    //   Start()   --  COMMENTED OUT
    //   Update()
    // -------------------------------------------------------------------------

    #region .  Awake()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  Awake()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void Awake()
    //{
    //    this._pressed.Enable();
    //    this._pressed.performed += _ => { StartCoroutine(Rotate()); };
    //    this._pressed.canceled  += _ => { this._isRotateAllowed = false; };

    //    this._axis.Enable();
    //    this._axis.performed += context => { this._rotation = context.ReadValue<Vector2>(); };

    //}   // Awake()
    #endregion


    #region .  Rotate()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  Rotate()
    ////
    ////   Description..:  Rotate an object with the mouse..
    ////
    ////   Parameters...:  
    ////
    ////   Returns......:  Vector3 with the z coordinate set to zero.
    //// -------------------------------------------------------------------------
    //private IEnumerator Rotate()
    //{
    //    this._isRotateAllowed = true;

    //    while (this._isRotateAllowed)
    //    {
    //        this._rotation *= this.RotationSpeed;
    //        this.transform.Rotate(Vector3.up,    this._rotation.x * Time.deltaTime, Space.World);
    //        this.transform.Rotate(Vector3.right, this._rotation.y * Time.deltaTime, Space.World);

    //        yield return null;
    //    }

    //}   // Rotate()
    #endregion


    #region .  Start()  --  COMMENTED OUT  .
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


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Update()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Update()
    {
        // Rotation on Y axis.
        //this._currentRotation = new Vector3(0f, this.RotationSpeed * Time.deltaTime, 0f);
        //this.transform.Rotate(this._currentRotation);

        if (PanelSpaceships.Instance.AllowRotation)
        {
            this.transform.Rotate(PanelSpaceships.Instance.CurrentRotation);
        }

    }   // Update()
    #endregion


}   // class SpaceshipRotator

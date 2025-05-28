using System;
using System.Linq;
using UnityEngine;


public class Spaceship : Singleton<Spaceship>
{
    // -------------------------------------------------------------------------
    // Public Events:
    // --------------
    //   //OnSpaceshipCollision
    //   //OnSpaceshipCreated
    //   //OnSpaceshipDestroyed
    //   OnSpaceshipLeaveScreen
    //   OnSpaceshipMoved
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    //public static event Action<Collision> OnSpaceshipCollision   = delegate { };
    //public static event Action<Spaceship> OnSpaceshipCreated     = delegate { };
    //public static event Action<Spaceship> OnSpaceshipDestroyed   = delegate { };
    public static event Action<Spaceship> OnSpaceshipLeaveScreen = delegate { };
    public static event Action<Spaceship> OnSpaceshipMoved       = delegate { };

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _cooldown
    //   _movementSpeed
    //   _rotationSpeed
    //   _laser
    //   _weapons
    //   _currentCannon
    //   _time
    //   _cameaMain
    //   _colliders
    //   _rigidBody
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private float        _cooldown = 1f;
    [SerializeField] private float        _movementSpeed;
    [SerializeField] private float        _rotationSpeed;
    [SerializeField] private GameObject   _laser;
    [SerializeField] private GameObject[] _weapons;

    private int        _currentCannon = 0;
    private float      _time          = 0f;
    private Camera     _cameaMain;
    private Collider[] _colliders;
    private Rigidbody  _rigidBody;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   FixedUpdate()
    //   IsPlayerInvisible()  --  COMMENTED OUT
    //   OnTriggerEnter()     --  COMMENTED OUT
    //   Start()
    //   Update()
    // -------------------------------------------------------------------------

    #region .  FixedUpdate()  .
    // -------------------------------------------------------------------------
    //   Method.......:  FixedUpdate()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void FixedUpdate()
    {
        // Fire this event.
        OnSpaceshipMoved?.Invoke(this);

    }   // FixedUpdate()
    #endregion


    #region .  IsPlayerInvisible()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  IsPlayerInvisible()
    ////   Description..:  
    ////   Parameters...:  None
    ////   Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private bool IsPlayerInvisible()
    //{
    //    Collider collider    = this._colliders.First(it => it.isTrigger);
    //    Plane[]  planes      = GeometryUtility.CalculateFrustumPlanes(this._cameaMain);
    //    bool     isInvisible = !GeometryUtility.TestPlanesAABB(planes, collider.bounds);

    //    return isInvisible;

    //}   // IsPlayerInvisible()
    #endregion


    #region .  OnTriggerEnter()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  OnTriggerEnter()
    ////   Description..:  
    ////   Parameters...:  None
    ////   Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (other.CompareTag("Asteroid"))
    //    //{
    //    //    Destroy(other.gameObject);
    //    //    Destroy(this.gameObject);
    //    //}

    //}   // OnTriggerEnter()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Start()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        this._cameaMain = Camera.main;
        this._colliders = GetComponents<Collider>();
        this._rigidBody = GetComponent<Rigidbody>();

    }   // Start()
    #endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        // ---------------------------------------
        // Laser movement.
        // ---------------------------------------
        if (this._time > 0f)
        {
            this._time -= Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            var laserOriginTransform = this.transform;

            // Make laser originate from alternate weapons on each shot.
            if (this._weapons.Length > 0)
            {
                laserOriginTransform  = this._weapons[_currentCannon++].transform;
                this._currentCannon  %= this._weapons.Length;
            }

            Instantiate(this._laser, laserOriginTransform.TransformPoint(Vector3.forward * 2), this.transform.rotation);
            this._time = this._cooldown;

            SoundManager.Instance.PlaySound(SoundManager.Sounds.Laser_Shoot);
        }


        // ---------------------------------------
        // Spaceship movement.
        // ---------------------------------------
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            this._rigidBody.AddForce(this._movementSpeed * Time.deltaTime * this.transform.forward);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            this._rigidBody.AddForce(-this._movementSpeed * Time.deltaTime * this.transform.forward);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(this._rotationSpeed * Time.deltaTime * Vector3.down);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(this._rotationSpeed * Time.deltaTime * Vector3.up);
        }


        // ---------------------------------------
        // Check for spaceship moves offscreen.
        // ---------------------------------------

        if (ScreenManager.Instance.IsOffScreen(this.transform))
        {
            // If so, wrap it to the opposite side.
            this.transform.position = ScreenManager.Instance.GetWrapVector(this.transform);
        }

        //// Move through screen borders.    <== Original code, the above method works better.
        //if (IsPlayerInvisible())
        //{
        //    var transformPosition   = this.transform.position;
        //    var screenCenter        = this._cameaMain.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f));
        //    this.transform.position = new Vector3(screenCenter.x - transformPosition.x, screenCenter.y - transformPosition.y, 0.0f);
        //}

    }   // Update()
    #endregion


}   // class Spaceship

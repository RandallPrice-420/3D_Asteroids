using System;
using UnityEngine;


public class Asteroid : Singleton<Asteroid>
{
    // -------------------------------------------------------------------------
    // Public Events:
    // --------------
    //   OnAsteroidCollisionEnter
    //   OnAsteroidCreated
    //   OnAsteroidLeavesScreen
    //   OnAsteroidTriggerEnter
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    public static event Action<Asteroid, Collision> OnAsteroidCollisionEnter = delegate { };
    public static event Action<Asteroid>            OnAsteroidCreated        = delegate { };
    public static event Action<Asteroid>            OnAsteroidDestroyed      = delegate { };
    public static event Action<Asteroid>            OnAsteroidLeavesScreen   = delegate { };
    public static event Action<Asteroid, Collider>  OnAsteroidTriggerEnter   = delegate { };

    #endregion


    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   CurrentHealth
    //   DamagePerHit
    //   Health
    //   Points
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public int CurrentHealth;
    public int DamagePerHit =  25;
    public int Health       = 100;
    public int Points       =  25;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _rigidbody
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    private Rigidbody _rigidbody;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   Die()  --  COMMENTED OUT
    //   OnCollisionEnter()
    //   OnTriggerEnter()
    //   Start()
    //   Update()
    // -------------------------------------------------------------------------

    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Awake()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Awake()
    {
        this.CurrentHealth = this.Health;
        this._rigidbody    = GetComponent<Rigidbody>();

        // Fire this event.
        OnAsteroidCreated?.Invoke(this);

    }   // Awake()
    #endregion


    #region .  Die()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  Die()
    ////   Description..:  Fires the OnAsteroidDestroyed event and destroys the
    ////                   asteroid GameObject if it exists.
    ////   Parameters...:  None
    ////   Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private void Die(int points = 0)
    //{
    //    // Fire this event.
    //    OnAsteroidDestroyed?.Invoke(this, points);

    //    if (this.gameObject != null)
    //    {
    //        Destroy(this.gameObject);
    //    }

    //}   // Die()
    #endregion


    #region .  OnCollisionEnter()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnCollisionEnter()
    //   Description..:  Fires the OnAsteroidCollisionEnter event when the
    //                   asteroid collides with the another GameObject.
    //   Parameters...:  Collision - the GameObject the asteroid collides with.
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnCollisionEnter(Collision otherCollision)
    {
        // Fire this event.
        OnAsteroidCollisionEnter?.Invoke(this, otherCollision);

    }   // OnCollisionEnter()
    #endregion


    #region .  OnTriggerEnter()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnTriggerEnter()
    //   Description..:  This fires when the laser collides with the asteroid.
    //   Parameters...:  Collider - the GameObject the asteroid collides with.
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Laser"))
        {
            // Fire this event.
            OnAsteroidTriggerEnter?.Invoke(this, otherCollider);
        }

    }   // OnTriggerEnter()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Start()
    //   Description..:  Adds force to move the asteroid in a random direction.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        Vector3 randomDirection3D = Utils.RandomDirection3D();
        this._rigidbody.AddForce(randomDirection3D);

    }   // Start()
    #endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  Checks for the asteroid moving off the screen and if
    //                   so, fires the OnAsteroidLeavesScreen event.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        // Check if the asteroid moves off the screen.
        if (ScreenManager.Instance.IsOffScreen(this.transform))
        {
            // Fire this event.
            OnAsteroidLeavesScreen?.Invoke(this);
        }

    }   // Update()
    #endregion


}   // class Asteroid

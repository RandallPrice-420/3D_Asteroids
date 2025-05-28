using UnityEngine;


public class Cube : MonoBehaviour
{
    [SerializeField] private Camera    mainCamera;      // Reference to the camera
    [SerializeField] private LayerMask groundLayer;     // Layer to raycast against

    private float _yPosition;


    private void Awake()
    {
        this._yPosition = this.transform.position.y;

    }   // Awake()


    private void Update()
    {
        Debug.Log(this.transform.position);

        //Vector3 mouseScreenPosition = Input.mousePosition;
        //Ray ray = mainCamera.ScreenPointToRay(mouseScreenPosition); // Create a ray
        //RaycastHit hit;

        //// Perform the raycast and check for collisions on the ground layer
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        //{
        //    transform.position = hit.point; // Move object to the hit point
        //}

        Vector3 hitPoint   = Utils.GetMouseWorldPosition3D(mainCamera, groundLayer);

        if (hitPoint != Vector3.zero)
        {
            hitPoint.y = this._yPosition;
            transform.position = hitPoint; // Move object to the hit point
        }

    }   // Update()


}   // class Cube

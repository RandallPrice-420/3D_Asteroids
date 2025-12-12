using UnityEngine;


public class CarAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;

    private Vector3 initialPosition;


    private void Awake()
    {
        initialPosition = transform.position;

    }   // Awake()


    private void OnDisable()
    {
        transform.position = initialPosition;

    }   // OnDisable()


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);

    }   // Update()


}   // class CarAnimation

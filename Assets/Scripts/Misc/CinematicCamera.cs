using UnityEngine;

public class CinematicCamera : MonoBehaviour
{
    private Vector3 startLocation;
    private Vector3 endLocation;

    [SerializeField] private Vector3 linearMovementVector;
    
    private void Start()
    {
        startLocation = gameObject.transform.position;
        endLocation = startLocation + linearMovementVector;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, endLocation, Time.deltaTime);
    }
}

using UnityEngine;

public class PickupOBJ : MonoBehaviour
{
    bool pickup = false;
    Rigidbody rb;
    public Transform destinationOBJ;
    public AudioClip pickupClip;
    public AudioClip dropClip;
    public AudioSource source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pickup()
    {
        pickup = !pickup;

        if (pickup)
        {
            source.PlayOneShot(pickupClip);
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.position = destinationOBJ.position;
            transform.parent = destinationOBJ.transform;
        }
        else
        {
            source.PlayOneShot(dropClip);
            rb.useGravity = true;
            rb.isKinematic = false;
            transform.parent = null;
        }
    }
}

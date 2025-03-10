using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Camera cam;
    private Vector3 origin;
    public float camSpeed = 2f;
    private Rigidbody rb;
    private bool launched = false;
    private static int count = 0;
    private float projSpeed;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        origin = cam.transform.position;
    }

    void Update()
    {
        if(!launched && rb.linearVelocity.magnitude > .5f){
            GetComponent<AudioSource>().Play();
            launched = true;
            count++;
            Debug.Log("Count: " + count);
        }

        if(launched && rb.linearVelocity.magnitude < .1f){
            camMovement();
            Destroy(gameObject, 2f);
        }
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Barrier"))
        {
            camMovement();
            Destroy(gameObject);
        }
    }

    public int getCount(){
        return count;
    }
    
    public static void resetCount(){
        count = 0;
    }

    void camMovement(){
        while(Vector3.Distance(cam.transform.position, origin) > .1f){
                cam.transform.position = Vector3.Lerp(cam.transform.position, origin, Time.deltaTime 
                * camSpeed);
            }
            cam.transform.position = origin;
    }
}
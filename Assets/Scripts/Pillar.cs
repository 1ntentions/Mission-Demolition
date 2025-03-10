using UnityEngine;

public class Pillar : MonoBehaviour
{
    private bool knocked = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xRotation = transform.rotation.eulerAngles.x;
        float zRotation = transform.rotation.eulerAngles.z;
        if (xRotation > 180){
            xRotation -= 360;
        }
        if (zRotation > 180){
            zRotation -= 360;
        }

        if(Mathf.Abs(xRotation) > 45f || Mathf.Abs(zRotation) > 45f){
            knocked = true;
        }
    }

    public bool isKnocked(){
        return knocked;
    }
}

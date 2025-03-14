using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    [Header("Set in inspector")]
    public float easing = .05f;
    public Vector2 minXY = Vector2.zero;
    [Header("Set dynamically")]
    public float camZ;

    private void Awake(){
        camZ = this.transform.position.z;
    }

    private void FixedUpdate(){
        if(POI == null){
            return;
        }
        Vector3 destination = POI.transform.position;
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

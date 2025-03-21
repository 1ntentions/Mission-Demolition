using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject projectilePrefab;
    public float velocityMult = 5f;
    public LineRenderer lineRenderer;

    [Header("Set dynamically")]
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimMode;
    public GameObject launchPoint;
    private Rigidbody projectileRigidbody;

    private void Awake(){
        launchPoint = GameObject.Find("LaunchPoint");
        launchPos = launchPoint.transform.position;

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null){
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.enabled = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(!aimMode){
            return;
        }

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude){
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 newPos = launchPos + mouseDelta;
        projectile.transform.position = newPos;

        lineRenderer.SetPosition(0, launchPos);
        lineRenderer.SetPosition(1, newPos);

        if(Input.GetMouseButtonUp(0)){
            aimMode = false;
            projectileRigidbody.isKinematic = false;
            if(Random.Range(0f, 1f) < .2f){
                velocityMult *= 2.0f;
                projectile.GetComponent<Renderer>().material.color = Color.red;
            }
            projectileRigidbody.linearVelocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;

            lineRenderer.enabled = false;
        }
    }
    
    private void OnMouseDown(){
        aimMode = true;
        projectile = Instantiate(projectilePrefab) as GameObject;
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        lineRenderer.enabled = true;
    }
}

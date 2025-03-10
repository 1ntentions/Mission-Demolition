using UnityEngine;

public class CloudMaker : MonoBehaviour
{
    [Header("Set in inspector")]
    public int numClouds = 40;
    public GameObject cloudPrefab;
    public Vector3 posMin = new Vector3(-50, -5, 10);
    public Vector3 posMax = new Vector3(150, 100, 10);
    public float scaleMin = 1;
    public float scaleMax = 3;
    public float speedMult = .5f;
    private GameObject[] instances;

    private void Awake(){
        instances = new GameObject[numClouds];
        GameObject anchor = GameObject.Find("CloudAnchor");
        GameObject cloud;
        for(int i = 0; i < numClouds; i++){
            cloud = Instantiate<GameObject>(cloudPrefab);
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(posMin.x, posMax.x);
            pos.y = Random.Range(posMin.y, posMax.y);
            float scaleU = Random.value;
            float scaleVal = Mathf.Lerp(scaleMin, scaleMax, scaleU);
            pos.y = Mathf.Lerp(posMin.y, pos.y, scaleU);
            pos.z = 100 - 90 * scaleU;
            cloud.transform.position = pos;
            cloud.transform.localScale = Vector3.one * scaleVal;
            cloud.transform.SetParent(anchor.transform);
            instances[i] = cloud;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        foreach(GameObject cloud in instances){
            float scaleVal = cloud.transform.localScale.x;
            Vector3 pos = cloud.transform.position;
            pos.x -= scaleVal * Time.deltaTime * speedMult;
            if(pos.x <= posMin.x){
                pos.x = posMax.x;
            }
            cloud.transform.position = pos;
        }
    }
}

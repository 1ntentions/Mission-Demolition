using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cloud : MonoBehaviour
{
    [Header("Set in inspector")]
    public GameObject cloudSphere;
    public int minSpheres = 6;
    public int maxSpheres = 10;
    public Vector3 offsetScale = new Vector3(5, 2, 1);
    public Vector2 scaleRangeX = new Vector2(4, 8);
    public Vector2 scaleRangeY = new Vector2(3, 4);
    public Vector2 scaleRangeZ = new Vector2(2, 4);
    public float yMin = 2f;

    private List<GameObject> spheres;

    void Start()
    {
        spheres = new List<GameObject>();
        int num = Random.Range(minSpheres, maxSpheres);
        for(int i = 0; i < num; i++){
            GameObject sp = Instantiate<GameObject>(cloudSphere);
            spheres.Add(sp);
            Transform spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            Vector3 offset = Random.insideUnitSphere;
            offset.x *= offsetScale.x;
            offset.y *= offsetScale.y;
            offset.z *= offsetScale.z;
            spTrans.localPosition = offset;

            Vector3 scale = Vector3.one;
            scale.x = Random.Range(scaleRangeX.x, scaleRangeX.y);
            scale.y = Random.Range(scaleRangeY.x, scaleRangeY.y);
            scale.z = Random.Range(scaleRangeZ.x, scaleRangeZ.y);

            scale.y *= 1 - (Mathf.Abs(offset.x) / offsetScale.x);
            scale.y = Mathf.Max(scale.y, yMin);

            spTrans.localScale = scale;
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Restart();
        }
    }

    void Restart(){
        foreach(GameObject sp in spheres){
            Destroy(sp);
        }
        Start();
    }
}

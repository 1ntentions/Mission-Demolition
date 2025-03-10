using UnityEngine;

public class Castle : MonoBehaviour
{
    public GameObject[] pillars;
    private bool knocked = false;

    void Start()
    {
        Debug.Log("Castle script started");
        pillars = GameObject.FindGameObjectsWithTag("Pillar");
    }

    void Update()
    {
        knocked = true;
        foreach(GameObject pillar in pillars){
            Pillar pillarScript = pillar.GetComponent<Pillar>();
            if(pillarScript != null && !pillarScript.isKnocked()){
                knocked = false;
                break;
            }
        }
    }

    public bool allKnocked(){
        return knocked;
    }
}
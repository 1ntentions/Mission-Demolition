using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene3Controller : MonoBehaviour
{
    public Projectile projectileScript;
    public Castle castleScript;

    void Start(){
        Projectile.resetCount();
    }

    void Update()
    {
        if(projectileScript.getCount() <= 4 && castleScript.allKnocked()){
            Projectile.resetCount();
            SceneManager.LoadScene("Level4");
        }
        else if(projectileScript.getCount() >= 5 && !castleScript.allKnocked()){
            SceneManager.LoadScene("GameOver");
        }
    }
}

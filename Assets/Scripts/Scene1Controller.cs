using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Scene1Controller : MonoBehaviour
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
            SceneManager.LoadScene("Level2");
        }
        else if(projectileScript.getCount() > 4 && !castleScript.allKnocked()){
            SceneManager.LoadScene("GameOver");
        }
    }
}

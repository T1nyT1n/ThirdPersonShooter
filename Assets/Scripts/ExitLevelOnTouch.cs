using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelOnTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

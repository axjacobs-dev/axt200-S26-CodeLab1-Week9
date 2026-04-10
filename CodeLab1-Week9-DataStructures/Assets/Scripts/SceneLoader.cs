using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        // checks to see if a key is pressed
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Poetry Generator");
        }
    }
}

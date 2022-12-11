using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    int index;
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;

    }
    public void Restart()
    {
        SceneManager.LoadScene(index);
    }
}

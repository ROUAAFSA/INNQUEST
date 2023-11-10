using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadsc : MonoBehaviour
{
    public Animator transition;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Load(sceneName));
    }

    IEnumerator Load(string sceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1); // Adjust the time for your animation.

        SceneManager.LoadScene(sceneName);
    }
}

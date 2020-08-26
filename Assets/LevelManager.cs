using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour
{
    public void RestartScenes()
    {
        StartCoroutine(RestartScenesCoroutune());
    }

    private IEnumerator RestartScenesCoroutune()
    {

        yield return new WaitForSeconds(1f);
        LoadScene(getActiveIndex());

    }

    public void NextLevel()
    {
        LoadScene(getActiveIndex() + 1);
    }

    private void LoadScene(int buildIndex)

    {
        SceneManager.LoadScene(buildIndex);
    }

    private int getActiveIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}

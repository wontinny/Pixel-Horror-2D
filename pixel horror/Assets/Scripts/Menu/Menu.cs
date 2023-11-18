using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour



{

    public TestScriptableObject healthObject;

    public TestScriptableObject bookCount;

    public void PlayGame()
    {
        StartCoroutine(WaitForAnimation());
        healthObject.changeCurrHealth(100);
        bookCount.changeCurrHealth(0);
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

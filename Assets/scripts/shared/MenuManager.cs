using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject loadSaveScreen;

    public void showLoadSaveScreen()
    {
        loadSaveScreen.SetActive(true);
    }
    public void quitLoadSaveScreen()
    {
        loadSaveScreen.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showOptionScreen()
    {
        // later
        Debug.Log("Options");
    }

    public void showCharacterCreationScreen()
    {
        //later
        Debug.Log("This goes into new game button");
    }


}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int _numberGameScene = 1;
    public void Play()
    {
        SceneManager.LoadScene(_numberGameScene);
    }

    public void AboutUs()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}

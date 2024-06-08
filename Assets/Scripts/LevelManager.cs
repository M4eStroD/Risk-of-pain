using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.OnDeath += RestartLevel;
    }

    private void OnDisable()
    {
        _player.OnDeath -= RestartLevel;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

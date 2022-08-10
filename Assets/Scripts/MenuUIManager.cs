using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TMP_Text _bestScoreText;
    [SerializeField] TMP_InputField _playerNameText;

    private void Start()
    {
        _bestScoreText.text = PersistentManager.Instance.BestScoreText;
        _playerNameText.text = PersistentManager.Instance.BestScore.PlayerName;
    }

    public void StartGame()
    {
        PersistentManager.Instance.PlayerName = _playerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

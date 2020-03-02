
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField]
    private string gameScene;

    [SerializeField]
    private TextMeshProUGUI confirmationUI;

    public void NewGameConfirmBtn()
    {
        if (confirmationUI != null)
        {
            confirmationUI.gameObject.SetActive(true);
        }
    }

    public void NewGameBtn()
    {
        GameManager.ResetGame();
        GameManager.SaveGame();
        SceneManager.LoadScene(gameScene);
    }

    public void LoadGameBtn()
    {
        bool loaded = GameManager.LoadGame();
        if (loaded)
        {
            SceneManager.LoadScene(gameScene);
        } else
        {
            Debug.LogError("Could not load data at this time!");
        }
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}

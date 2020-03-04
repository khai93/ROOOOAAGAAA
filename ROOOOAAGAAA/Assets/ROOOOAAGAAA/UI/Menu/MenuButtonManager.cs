using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using ROOOOAAGAAA.Core;

namespace ROOOOAAGAAA.UI
{
    public class MenuButtonManager : MonoBehaviour
    {
        [SerializeField]
        private string gameScene;

        [SerializeField]
        private TextMeshProUGUI confirmationUI;

        public void NewGameConfirmBtn()
        {
            confirmationUI?.gameObject.SetActive(true);
        }

        public void NewGameBtn()
        {
            GameManager.ResetGame();
            GameManager.SaveGame();
            SceneManager.LoadScene(gameScene);
        }

        public void LoadGameBtn()
        {
            try
            {
                GameManager.LoadGame();
                SceneManager.LoadScene(gameScene);
            }
            catch (FileNotFoundException)
            {
                Debug.LogError("Could not load data at this time!");
            }

        }

        public void ExitGameBtn()
        {
            Application.Quit();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Character.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject panelPause, panelAreYouSure;

        public void ResumeGame()
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;   
        }

        public void ExitAreYouSure()
        {
            panelPause.SetActive(false);
            panelAreYouSure.SetActive(true);
        }

        public void ReturnToPauseMenu()
        {
            panelAreYouSure.SetActive(false);
            panelPause.SetActive(true);
        }

        public void ExitToMainMenu()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
        
    }
}

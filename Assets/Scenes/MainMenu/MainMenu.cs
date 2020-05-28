using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.MainMenu
{
    public class MainMenu : MonoBehaviour
    {


        public void StartGame()
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }

        public void EditDeck()
        {
            SceneManager.LoadScene("DeckBuilder/DeckBuilder");
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void OpenSettings()
        {
        
        }
    
    
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public class MainMenuScene : MonoBehaviour
    {
        public void LoadGameSetupScene()
        {
            SceneManager.LoadScene(Scene.GameSetup);
        }

        public void ExitGame()
        {
            Application.Quit(0);
        }
    }
}
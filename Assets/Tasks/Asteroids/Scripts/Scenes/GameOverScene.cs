using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids
{
    public class GameOverScene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMain;
        [SerializeField] private TextMeshProUGUI textShadow;
        [SerializeField] private TextMeshProUGUI textPoints;

        private void Start()
        {
            textMain.SetText(GameManager.Instance.gameOverType.Equals(GameOver.StateWin) ? GameOver.TextYouWin : GameOver.TextYouLose);
            textShadow.SetText(GameManager.Instance.gameOverType.Equals(GameOver.StateWin) ? GameOver.TextYouWin : GameOver.TextYouLose);
            //textPoints.SetText($"{GameOver.TextScore}: {GameManager.Instance.score}");
        }

        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(Scene.MainMenu);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(Scene.Game);
        }
    }
}
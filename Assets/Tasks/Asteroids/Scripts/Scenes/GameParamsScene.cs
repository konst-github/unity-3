using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids
{
    public class GameParamsScene: MonoBehaviour
    {
        [SerializeField] private Button shipButton1;
        [SerializeField] private Button shipButton2;
        [SerializeField] private Button shipButton3;

        [SerializeField] private TextMeshProUGUI textShipName;

        [SerializeField] private Button gameModeButton1;
        [SerializeField] private Button gameModeButton2;
        [SerializeField] private Button gameModeButton3;

        private const float shipButtonScale = 2f;
        private const float gameModeButtonScale = 1.3f;

        private string selectedShip = Spaceship.ship1;
        private string selectedGameMode = GameMode.Scorer;

        private void Start()
        {
            UpdateUI();
        }

        public void SelectShipType(Button button)
        {
            selectedShip = button.tag;
            UpdateUI();
        }

        public void SelectGameMode(Button button)
        {
            selectedGameMode = button.tag;
            UpdateUI();
        }

        public void StartGame()
        {
            GameManager.Instance.ConfigureGame(selectedShip, selectedGameMode);
            SceneManager.LoadScene(Scene.Game);
        }
        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(Scene.MainMenu);
        }

        private void UpdateUI()
        {
            shipButton1.transform.localScale = Vector2.one * (selectedShip.Equals(Spaceship.ship1) ? shipButtonScale : 1);
            shipButton2.transform.localScale = Vector2.one * (selectedShip.Equals(Spaceship.ship2) ? shipButtonScale : 1);
            shipButton3.transform.localScale = Vector2.one * (selectedShip.Equals(Spaceship.ship3) ? shipButtonScale : 1);

            textShipName.SetText(selectedShip);

            gameModeButton1.transform.localScale = Vector2.one * (selectedGameMode.Equals(GameMode.Scorer) ? gameModeButtonScale : 1);
            gameModeButton2.transform.localScale = Vector2.one * (selectedGameMode.Equals(GameMode.Speeder) ? gameModeButtonScale : 1);
            gameModeButton3.transform.localScale = Vector2.one * (selectedGameMode.Equals(GameMode.DieHard) ? gameModeButtonScale : 1);
        }
    }
}
using UnityEngine;

public class StartMenu : MonoBehaviour {
  [SerializeField] private GameObject window;

  public void StartGame() {
    GameManager.Singleton.StartGame();
    this.window.SetActive(false);
  }

  public void Exit() {
    Application.Quit();
  }
}

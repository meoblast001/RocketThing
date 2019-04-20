using System;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {
  [SerializeField] private GameObject window;

  void Start() {
    this.window.SetActive(false);

    EventSystem.Subscribe(
      GameManager.GameStateChangeEvent,
      this.OnGameStateChangeEvent);
  }

  void OnDestroy() {
    EventSystem.Unsubscribe(
      GameManager.GameStateChangeEvent,
      this.OnGameStateChangeEvent);
  }

  public void RestartGame() {
    GameManager.Singleton.StartGame();
    this.window.SetActive(false);
  }

  public void Exit() {
    Application.Quit();
  }

  private void OnGameStateChangeEvent(object sender, EventArgs e) {
    this.window.SetActive(!GameManager.Singleton.Running);
  }
}

using UnityEngine;

public class GameManager : MonoBehaviour {
  public const string GameStateChangeEvent = "GameManager.GameStateChange";
  public const string PassedDiscEvent = "GameManager.PassedDisc";

  public static GameManager Singleton { get; private set; }

  public bool Running { get; private set; }
  public int PassedDiscs { get; private set; }

  private float restoreTimeScale;

  void Awake() {
    Singleton = this;
    this.Running = false;
    this.PassedDiscs = 0;
  }

  void Start() {
    this.restoreTimeScale = Time.timeScale;
    Time.timeScale = 0f;
  }

  void Update() {
    if (Input.GetButtonDown("Cancel"))
      this.StopGame();
  }

  void OnDestroy() {
    Singleton = null;
  }

  public void StartGame() {
    foreach (var disc in GameObject.FindGameObjectsWithTag(Tags.Disc)) {
      GameObject.Destroy(disc);
    }

    this.PassedDiscs = 0;
    Time.timeScale = this.restoreTimeScale;
    this.Running = true;
    this.SetCursorLock(true);
    EventSystem.Publish(this, GameStateChangeEvent);
    EventSystem.Publish(this, PassedDiscEvent);
  }

  public void StopGame() {
    Time.timeScale = 0f;
    this.Running = false;
    this.SetCursorLock(false);
    EventSystem.Publish(this, GameStateChangeEvent);
  }

  public void PassedDisc() {
    ++this.PassedDiscs;
    EventSystem.Publish(this, PassedDiscEvent);
  }

  private void SetCursorLock(bool locked) {
    Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
    Cursor.visible = !locked;
  }
}

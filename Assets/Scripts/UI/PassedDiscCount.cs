using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PassedDiscCount : MonoBehaviour {
  private Text textField;

  void Start() {
    this.textField = this.GetComponent<Text>();

    this.textField.text = GameManager.Singleton.PassedDiscs.ToString();
    EventSystem.Subscribe(GameManager.PassedDiscEvent, this.OnPassedDiscEvent);
  }

  void Destroy() {
    EventSystem.Unsubscribe(
      GameManager.PassedDiscEvent,
      this.OnPassedDiscEvent);
  }

  private void OnPassedDiscEvent(object sender, EventArgs e) {
    this.textField.text = GameManager.Singleton.PassedDiscs.ToString();
  }
}

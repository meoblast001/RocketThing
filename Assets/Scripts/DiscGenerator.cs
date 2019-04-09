using System;
using UnityEngine;

public class DiscGenerator : MonoBehaviour {
  [SerializeField] private GameObject[] discPrefabs;
  [SerializeField] private float beginEmitFrequency = 5f;
  [SerializeField] private float endEmitFrequency = 2f;
  [SerializeField] private float emitFrequncyChangeRate = 0.05f;
  [SerializeField] private float beginDiscSpeed = -6f;
  [SerializeField] private float endDiscSpeed = -10f;
  [SerializeField] private float discSpeedChangeRate = 0.05f;

  private float currentEmitFrequency;
  private float currentDiscSpeed;
  private float timeSinceEmit = 0f;

  void Start() {
    this.currentEmitFrequency = this.beginEmitFrequency;
    this.currentDiscSpeed = this.beginDiscSpeed;

    EventSystem.Subscribe(
      GameManager.GameStateChangeEvent,
      this.OnGameStateChangeEvent);
  }

  void Destroy() {
    EventSystem.Unsubscribe(
      GameManager.GameStateChangeEvent,
      this.OnGameStateChangeEvent);
  }

  void Update() {
    if (this.currentEmitFrequency > this.endEmitFrequency)
      this.currentEmitFrequency -= this.emitFrequncyChangeRate * Time.deltaTime;
    else
      this.currentEmitFrequency = this.endEmitFrequency;

    if (this.currentDiscSpeed > this.endDiscSpeed)
      this.currentDiscSpeed -= this.discSpeedChangeRate * Time.deltaTime;
    else
      this.currentDiscSpeed = this.endDiscSpeed;

    this.timeSinceEmit += Time.deltaTime;
    if (this.timeSinceEmit > this.currentEmitFrequency) {
      Emit();
      this.timeSinceEmit = 0f;
    }
  }

  private void Emit() {
    var idx = new System.Random().Next() % this.discPrefabs.Length;
    var discPrefab = this.discPrefabs[idx];

    var discInstanceObj = GameObject.Instantiate(
      discPrefab,
      this.transform.position,
      this.transform.rotation);
    var discInstance = discInstanceObj.GetComponent<DiscMovement>();
    if (discInstance != null)
      discInstance.zMovement = this.currentDiscSpeed;
    else
      Debug.LogError("Disc instance created by generator does not have "
        + nameof(DiscMovement));
  }

  private void OnGameStateChangeEvent(object sender, EventArgs e) {
    this.currentEmitFrequency = this.beginEmitFrequency;
  }
}

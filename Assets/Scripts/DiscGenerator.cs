using UnityEngine;

public class DiscGenerator : MonoBehaviour {
  [SerializeField] private GameObject[] discPrefabs;
  [SerializeField] private float beginEmitFrequency = 5f;
  [SerializeField] private float endEmitFrequency = 1.5f;
  [SerializeField] private float emitFrequncyChangeRate = 0.05f;

  private float currentEmitFrequency;
  private float timeSinceEmit = 0f;

  void Start() {
    this.currentEmitFrequency = this.beginEmitFrequency;
  }

  void Update() {
    if (this.currentEmitFrequency > this.endEmitFrequency)
      this.currentEmitFrequency -= this.emitFrequncyChangeRate * Time.deltaTime;
    else
      this.currentEmitFrequency = this.endEmitFrequency;

    this.timeSinceEmit += Time.deltaTime;
    if (this.timeSinceEmit > this.currentEmitFrequency) {
      Emit();
      this.timeSinceEmit = 0f;
    }
  }

  private void Emit() {
    var idx = new System.Random().Next() % this.discPrefabs.Length;
    var discPrefab = this.discPrefabs[idx];

    GameObject.Instantiate(
      discPrefab,
      this.transform.position,
      this.transform.rotation);
  }
}

using UnityEngine;

public class UIWinScreen : MonoBehaviour {
	private void Awake() {
		GameCore.OnStartGame += OnStartGame;
		GameCore.OnWinGame += OnWinGame;
	}

	private void OnDestroy() {
		GameCore.OnStartGame -= OnStartGame;
		GameCore.OnWinGame -= OnWinGame;
	}

	private void OnWinGame() {
		gameObject.SetActive(true);
	}

	private void OnStartGame() {
		gameObject.SetActive(false);
	}
}

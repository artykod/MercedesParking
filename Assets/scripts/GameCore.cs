using UnityEngine;

public class GameCore : MonoBehaviour {

	[System.NonSerialized]
	private static bool initialized = false;

	public static bool IsGameStarted {
		get;
		private set;
	}

	public static event System.Action OnWinGame;
	public static event System.Action OnStartGame;

	public static void WinGame() {
		IsGameStarted = false;

		if (OnWinGame != null) {
			OnWinGame();
		}
	}

	public static void StartGame() {
		IsGameStarted = true;

        if (OnStartGame != null) {
			OnStartGame();
		}
	}

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize() {
		if (!Application.isPlaying || initialized) {
			return;
		}

		initialized = true;

		Application.targetFrameRate = 60;

		DebugConsole.Initialize();
		Config.Load();

#if !UNITY_ANDROID && !UNITY_IPHONE
		Debug.LogFormat("Set resolution: {0}x{1} fullscreen: {2}", Config.ScreenWidth, Config.ScreenHeight, Config.Fullscreen);
		Screen.SetResolution(Config.ScreenWidth, Config.ScreenHeight, Config.Fullscreen);
#endif
	}

	private void Awake() {
		Initialize();
	}
}

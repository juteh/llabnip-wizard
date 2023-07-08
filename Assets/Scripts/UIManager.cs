using UnityEngine;

public class UIManager : MonoBehaviour {
    public void ExitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void RestartLevel() {
        GameSystem.Instance.points = 0;
        SceneController.Instance.LoadSceneByName("SampleScene");
    }
}

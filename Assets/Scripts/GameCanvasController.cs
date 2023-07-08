using TMPro;
using UnityEngine;

public class GameCanvasController : MonoBehaviour {
    [SerializeField] TextMeshProUGUI gameScoreText;

    void Update() {
        gameScoreText.text = GameSystem.Instance.points + " Points";
    }
}

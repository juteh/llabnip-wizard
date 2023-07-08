using TMPro;
using UnityEngine;

public class FinishCanvasController : MonoBehaviour {

    [SerializeField] TextMeshProUGUI finishScoreText;

    void Start() {
        finishScoreText.text = "" + GameSystem.Instance.points;
    }
}

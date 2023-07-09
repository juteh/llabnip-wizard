using TMPro;
using UnityEngine;

public class GameCanvasController : MonoBehaviour {
    [SerializeField] TextMeshProUGUI gameScoreText;

    [SerializeField] TextMeshProUGUI boostText;

    void Update() {
        gameScoreText.text = GameSystem.Instance.points + " Points";
        if (GameSystem.Instance.chargeStatus == ChargeStatus.NOT_LOADING) {
            boostText.text = "Boost: NOT LOADED";
            boostText.color = Color.red;
        } else if (GameSystem.Instance.chargeStatus == ChargeStatus.LOADING) {
            boostText.text = "Boost: LOADING...";
            boostText.color = Color.yellow;
        } else if (GameSystem.Instance.chargeStatus == ChargeStatus.READY) {
            boostText.text = "Boost: READY!";
            boostText.color = Color.green;
        }
    }
}

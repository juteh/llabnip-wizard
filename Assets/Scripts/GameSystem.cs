using UnityEngine;

public class GameSystem : MonoBehaviour {

    public bool gameIsFinished { get; set; } = false;

    public int points { get; set; } = 0;

    public ChargeStatus chargeStatus { get; set; } = ChargeStatus.NOT_LOADING;

    public static GameSystem Instance {
        get; private set;
    }

    void Awake() {
        if (Instance != null) {
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void AddPoints(int points) {
        this.points += points;
    }
}

using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreText;

    public bool gameIsFinished { get; set; } = false;

    public int points { get; set; } = 0;

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

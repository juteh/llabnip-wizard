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

    void Start() {
        if (scoreText != null) {
            scoreText.text = points + " Points";
        }
    }

    public void AddPoints(int points) {
        this.points += points;
        scoreText.text = this.points + " Points";
    }
}

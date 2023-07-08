using UnityEngine;

public class GameSystem : MonoBehaviour {

    public bool gameIsFinished { get; set; } = false;

    public static GameSystem Instance {
        get; private set;
    }

    void Awake() {
        if (Instance != null) {
            return;
        }

        Instance = this;
    }


}

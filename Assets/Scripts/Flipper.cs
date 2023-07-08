using UnityEngine;

enum Direction {
    LEFT,
    RIGHT,
}

public class Flipper : MonoBehaviour {

    private Rigidbody2D rbFlipper;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Direction direction = Direction.LEFT;

    void Start() {
        rbFlipper = GetComponent<Rigidbody2D>();
    }
    void Update() {
        if (direction == Direction.LEFT) {
            if (Input.GetKey(KeyCode.K)) {
                rbFlipper.AddTorque(speed, ForceMode2D.Impulse);
            } else {
                rbFlipper.AddTorque(-speed, ForceMode2D.Impulse);
            }
        } else {
            if (Input.GetKey(KeyCode.L)) {
                rbFlipper.AddTorque(-speed, ForceMode2D.Impulse);
            } else {
                rbFlipper.AddTorque(speed, ForceMode2D.Impulse);
            }
        }
    }

}

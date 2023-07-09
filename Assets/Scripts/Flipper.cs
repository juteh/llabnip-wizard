using System.Collections;
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
        //StartCoroutine(MoveDown());
        StartMoving();
    }

    public void StartMoving() {
        StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp() {
        if (direction == Direction.LEFT) {
            rbFlipper.AddTorque(speed * 10, ForceMode2D.Impulse);
            yield return new WaitForFixedUpdate();
        } else {
            rbFlipper.AddTorque(-speed * 10, ForceMode2D.Impulse);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoveDown());
    }

    private IEnumerator MoveDown() {
        if (direction == Direction.LEFT) {
            rbFlipper.AddTorque(-speed * 3, ForceMode2D.Impulse);
            yield return new WaitForFixedUpdate();
        } else {
            rbFlipper.AddTorque(speed * 3, ForceMode2D.Impulse);
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
    }
}

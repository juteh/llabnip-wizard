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
        StartCoroutine(MoveDown());
    }
    void FixedUpdate() {
        if (direction == Direction.LEFT) {
            if (Input.GetKey(KeyCode.K)) {
                //rbFlipper.AddTorque(speed, ForceMode2D.Impulse);
                StartCoroutine(MoveUp());
            } else {
                //rbFlipper.AddTorque(-speed, ForceMode2D.Impulse);
            }
        } else {
            if (Input.GetKey(KeyCode.L)) {
                StartCoroutine(MoveUp());
                //rbFlipper.AddTorque(-speed, ForceMode2D.Impulse);
            } else {
                //rbFlipper.AddTorque(speed, ForceMode2D.Impulse);
            }
        }
    }


    public void StartMoving() {
        StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp() {
        while (gameObject.transform.eulerAngles.z > 136) {
            if (direction == Direction.LEFT) {
                rbFlipper.AddTorque(speed, ForceMode2D.Impulse);
            } else {
                rbFlipper.AddTorque(-speed, ForceMode2D.Impulse);
            }
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoveDown());
    }

    private IEnumerator MoveDown() {
        while (gameObject.transform.eulerAngles.z < 209) {
            if (direction == Direction.LEFT) {
                rbFlipper.AddTorque(-speed, ForceMode2D.Impulse);
            } else {
                rbFlipper.AddTorque(speed, ForceMode2D.Impulse);
            }
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);
    }
}

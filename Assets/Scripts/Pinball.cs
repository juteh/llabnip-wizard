using UnityEngine;

public class Pinball : MonoBehaviour {


    [SerializeField]
    private float thrust = 1f;

    [SerializeField]
    private float thrustPlunger = 1f;

    private Rigidbody2D rbPinball;
    private bool onPlunger = false;

    void Start() {
        rbPinball = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) {
            rbPinball.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * thrust);
        } else if (onPlunger && Input.GetKeyDown(KeyCode.Space)) {
            rbPinball.AddForce(transform.up * thrustPlunger);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Plunger") {
            onPlunger = true;
        } else if (collision.gameObject.tag == "Deathzone") {
            Debug.Log("FINISH");
            GameSystem.Instance.gameIsFinished = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Plunger") {
            onPlunger = false;
        }
    }
}

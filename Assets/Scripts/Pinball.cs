using System.Collections;
using UnityEngine;

public class Pinball : MonoBehaviour {


    [SerializeField]
    private float thrust = 1f;

    [SerializeField]
    private float thrustPlunger = 1f;

    [SerializeField]
    private GameObject rightFlipper;

    [SerializeField]
    private GameObject leftFlipper;

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
        if (collision.gameObject.CompareTag("Plunger")) {
            onPlunger = true;
            StartCoroutine(UsePlunger());
        } else if (collision.gameObject.CompareTag("Deathzone")) {
            GameSystem.Instance.gameIsFinished = true;
            SceneController.Instance.LoadSceneByName("FinishScene");
        } else if (collision.gameObject.CompareTag("RightFlipper")) {
            Debug.Log("RightFlipper");
            rightFlipper.GetComponent<Flipper>().StartMoving();
        } else if (collision.gameObject.CompareTag("LeftFlipper")) {
            Debug.Log("LeftFlipper");
            leftFlipper.GetComponent<Flipper>().StartMoving();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Plunger")) {
            StopAllCoroutines();
            onPlunger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            GameSystem.Instance.AddPoints(collision.gameObject.GetComponent<Obstacle>().points);
        }
    }

    private IEnumerator UsePlunger() {
        yield return new WaitForSeconds(0.5f);
        rbPinball.AddForce(transform.up * thrustPlunger);
    }
}

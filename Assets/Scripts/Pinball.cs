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

    [SerializeField]
    private float maxSpeedBall = 50;

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
        rbPinball.velocity = new Vector3(Mathf.Clamp(rbPinball.velocity.x, -maxSpeedBall, maxSpeedBall), Mathf.Clamp(rbPinball.velocity.y, -maxSpeedBall, maxSpeedBall));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Plunger")) {
            onPlunger = true;
            StartCoroutine(UsePlunger());
        } else if (collision.gameObject.CompareTag("Deathzone")) {
            AudioManager.Instance.PlayBallOut();
            GameSystem.Instance.gameIsFinished = true;
            SceneController.Instance.LoadSceneByName("FinishScene");
        } else if (collision.gameObject.CompareTag("RightFlipper")) {
            AudioManager.Instance.PlayflipperMove();
            rightFlipper.GetComponent<Flipper>().StartMoving();
        } else if (collision.gameObject.CompareTag("LeftFlipper")) {
            AudioManager.Instance.PlayflipperMove();
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
            AudioManager.Instance.BumperCollision();
            GameSystem.Instance.AddPoints(collision.gameObject.GetComponent<Obstacle>().points);

        } else if (collision.gameObject.CompareTag("Flipper")) {
            AudioManager.Instance.PlayFlipperCollision();
        } else {
            AudioManager.Instance.PlayEnviromentCollision();
        }
    }

    private IEnumerator UsePlunger() {
        yield return new WaitForSeconds(0.5f);
        rbPinball.AddForce(transform.up * thrustPlunger);
    }
}

using System.Collections;
using UnityEngine;

public enum ChargeStatus {
    NOT_LOADING,
    LOADING,
    READY,
}

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

    [SerializeField]
    private float megaThrust = 50f;

    [SerializeField]
    private float holdTime = 0.5f;

    private Rigidbody2D rbPinball;
    private SpriteRenderer srPinball;
    private float startTime = 0f;

    private bool megaThrustReady = false;

    void Start() {
        rbPinball = GetComponent<Rigidbody2D>();
        srPinball = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (!Input.GetKey(KeyCode.LeftShift) && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)) {
            rbPinball.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * thrust);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            startTime = Time.time;
            GameSystem.Instance.chargeStatus = ChargeStatus.LOADING;
            srPinball.color = Color.yellow;
        } else
        if (Input.GetKey(KeyCode.LeftShift)) {
            if (startTime + holdTime < Time.time) {
                GameSystem.Instance.chargeStatus = ChargeStatus.READY;
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                megaThrustReady = true;
            }
        } else
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            if (megaThrustReady) {
                megaThrustReady = false;
                AudioManager.Instance.PlayBoost();
                rbPinball.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * megaThrust);
            }
            GameSystem.Instance.chargeStatus = ChargeStatus.NOT_LOADING;
            srPinball.color = Color.white;

        }
        rbPinball.velocity = new Vector3(Mathf.Clamp(rbPinball.velocity.x, -maxSpeedBall, maxSpeedBall), Mathf.Clamp(rbPinball.velocity.y, -maxSpeedBall, maxSpeedBall));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Plunger")) {
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

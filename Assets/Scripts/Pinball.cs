using UnityEngine;

public class Pinball : MonoBehaviour {

    Rigidbody2D _rigidbody;

    [SerializeField]
    private float _thrust = 1f;

    [SerializeField]
    private float _thrustPlunger = 1f;

    // Start is called before the first frame update
    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        //print(Input.GetAxisRaw("Vertical"));
        //print(Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) {
            _rigidbody.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _thrust);
        } else if (Input.GetKeyDown(KeyCode.Space)) {
            _rigidbody.AddForce(transform.up * _thrustPlunger);
        }

        print(_rigidbody.velocity);

    }
}

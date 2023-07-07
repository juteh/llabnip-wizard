using UnityEngine;

public class Flipper : MonoBehaviour {

    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //if (Input.GetKey(KeyCode.Backspace)) {

        //transform.Rotate(0, 0, 1, Space.Self);


        rb.AddTorque(speed, ForceMode2D.Force);
        //}
    }

}

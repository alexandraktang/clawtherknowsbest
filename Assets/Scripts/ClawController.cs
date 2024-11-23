using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;

    float clawMoveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveClawPosition();
    }

    void MoveClawPosition() {
        float spd = Time.deltaTime * clawMoveSpeed;

        // move claw further away
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("Move Back!!");
            rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z + spd));
        }
        // move claw left
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("Move Left!!");
            rigidbody.MovePosition(new Vector3(transform.position.x - spd, transform.position.y, transform.position.z));
        }
        // move claw closer
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log("Move Forward!!");
            rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z - spd));
        }
        // move claw right
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Move Right!!");
            rigidbody.MovePosition(new Vector3(transform.position.x + spd, transform.position.y, transform.position.z));
        }
    }
}

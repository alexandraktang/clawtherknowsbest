using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    [SerializeField] Rigidbody holderRigidbody;

    float maxXRotation = 180f;
    float maxYRotation = 180f;
    float maxZRotation = 180f;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float descendSpeed = .8f;

    [SerializeField] Rigidbody frontClawRb;
    Quaternion frontRot = Quaternion.identity;
    [SerializeField] Rigidbody leftClawRb;
    Quaternion leftRot = Quaternion.identity;
    [SerializeField] Rigidbody rightClawRb;
    Quaternion rightRot = Quaternion.identity;
    [SerializeField] Rigidbody backClawRb;
    Quaternion backRot = Quaternion.identity;

    bool clawDescended = false;

    // Start is called before the first frame update
    void Start()
    {
        frontClawRb.useGravity = false;
        frontClawRb.angularVelocity = Vector3.zero;

        leftClawRb.useGravity = false;
        leftClawRb.angularVelocity = Vector3.zero;

        rightClawRb.useGravity = false;
        rightClawRb.angularVelocity = Vector3.zero;

        backClawRb.useGravity = false;
        backClawRb.angularVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveClawPosition();
    }

    void MoveClawPosition() {
        float moveSpd = Time.fixedDeltaTime * moveSpeed;
        float descendSpd = Time.fixedDeltaTime * descendSpeed;

        // move claw further away
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("Move Back!!");
            holderRigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpd));
        }
        // move claw left
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("Move Left!!");
            holderRigidbody.MovePosition(new Vector3(transform.position.x - moveSpd, transform.position.y, transform.position.z));
        }
        // move claw closer
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log("Move Forward!!");
            holderRigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z - moveSpd));
        }
        // move claw right
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("Move Right!!");
            holderRigidbody.MovePosition(new Vector3(transform.position.x + moveSpd, transform.position.y, transform.position.z));
        }

        if (Input.GetKey(KeyCode.Space) && ! clawDescended) {
            Debug.Log("Going Down!!");
            Debug.Log(transform.position.y);
            OpenClaw();
            holderRigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y - descendSpd, transform.position.z));
        }
        if (Input.GetKey(KeyCode.Return) && ! clawDescended) {
            Debug.Log("Going Up!!");
            Debug.Log(transform.position.y);
            CloseClaw();
            holderRigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y + descendSpd, transform.position.z));
        }
    }

    void OpenClaw() {
        frontRot = Quaternion.Euler(17, frontClawRb.rotation.y, frontClawRb.rotation.z);
        leftRot = Quaternion.Euler(leftClawRb.rotation.x, leftClawRb.rotation.y, -17);
        rightRot = Quaternion.Euler(rightClawRb.rotation.x, rightClawRb.rotation.y, 17);
        backRot = Quaternion.Euler(-17, backClawRb.rotation.y, backClawRb.rotation.z);

        frontClawRb.rotation = frontRot;
        leftClawRb.rotation = leftRot;
        rightClawRb.rotation = rightRot;
        backClawRb.rotation = backRot;
    }

    void CloseClaw() {
        frontRot = Quaternion.Euler(0, frontClawRb.rotation.y, frontClawRb.rotation.z);
        leftRot = Quaternion.Euler(leftClawRb.rotation.x, leftClawRb.rotation.y, 0);
        rightRot = Quaternion.Euler(rightClawRb.rotation.x, rightClawRb.rotation.y, 0);
        backRot = Quaternion.Euler(0, backClawRb.rotation.y, backClawRb.rotation.z);

        frontClawRb.rotation = frontRot;
        leftClawRb.rotation = leftRot;
        rightClawRb.rotation = rightRot;
        backClawRb.rotation = backRot;
    }
}

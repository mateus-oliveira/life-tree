using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour {
    private bool jumpMove, isGrounded;
    private PlayerController controller;
    [SerializeField] private GameObject player;

    void Start() {
        controller = player.GetComponent<PlayerController>();
    }

    void Update() {
        jumpMove = (Input.GetKeyDown(KeyCode.Space) || Input.GetAxisRaw("Fire1") != 0);
        if (jumpMove && isGrounded) {
            Debug.Log("Jumping");
            controller.SetJumpAnimation(true);
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        isGrounded = true;
        controller.SetJumpAnimation(false); 
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Ambar")) {
            controller.SetDelayed(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Ambar")) {
            controller.SetDelayed(false);
        }
    }
}

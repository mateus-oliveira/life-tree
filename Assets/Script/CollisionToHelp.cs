using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CollisionToHelp : MonoBehaviour {
    private float speed;
    private bool isNextToPlayer, isPressingH, helpFinished;
    private Animator animator;
    [SerializeField] private bool isAnimal;
    [SerializeField] private Slider slider;
    [SerializeField] private Text helpMessageText;
    [SerializeField] private string helpMessage = "";

    private void Start() {
        isNextToPlayer = false;
        isPressingH = false;
        helpFinished = false;
        helpMessageText.text = helpMessage;
        slider.gameObject.SetActive(isPressingH && isNextToPlayer);
        speed = 30f;
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (!helpFinished) {
            if (isNextToPlayer) {
                if (isPressingH) {
                    helpMessageText.text = "";
                    slider.value += speed * Time.deltaTime;

                } else {
                    helpMessageText.text = "Pressione H para ajudar";
                    slider.value -= speed * Time.deltaTime;
                }
            } else {
                helpMessageText.text = helpMessage;
            }

            slider.gameObject.SetActive(isPressingH && isNextToPlayer);
            isPressingH = Input.GetKey(KeyCode.H);
        }

        slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);
        if (slider.value >= slider.maxValue) {
            helpFinished = true;
        }

        if (helpFinished) {
            slider.gameObject.SetActive(false);
            if (!isAnimal) {
                helpMessageText.text = "Obrigado!";
                this.SetDestroyAnimation();
            } else {
                this.SelfDestroy();
            }

        }
    }

    public void OnTriggerEnter(Collider collision) {
        Debug.Log("Entrando na colisão...");
        if (collision.gameObject.CompareTag("Player")) {
            isNextToPlayer = true;
        }
    }

    public void OnTriggerExit(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isNextToPlayer = false;
        }
    }

    private void SetDestroyAnimation() {
        animator.SetBool("Waving", true);
    }

    public void SelfDestroy() {
        Destroy(gameObject);
    }

}

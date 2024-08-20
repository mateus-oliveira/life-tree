using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollisionToHelp : MonoBehaviour
{
    private bool isNextToPlayer, isPressingH;
    [SerializeField] private Slider slider;
    [SerializeField] private Text helpMessage;
    private float speed;

    private void Start()
    {
        isNextToPlayer = false;
        isPressingH = false;
        helpMessage.text = "Ajude por favor!!";
        slider.gameObject.SetActive(isPressingH && isNextToPlayer);
        speed = 30f;
    }
    private void Update()
    {
        if (isNextToPlayer)
        {
            if (isPressingH)
            {
                helpMessage.text = "";
                slider.value += speed * Time.deltaTime;

            }
            else
            {
                helpMessage.text = "Pressione H para ajudar";
                slider.value -= speed * Time.deltaTime;
            }
        }
        else
        {
            helpMessage.text = "Ajude por favor!!";
        }

        slider.gameObject.SetActive(isPressingH && isNextToPlayer);
        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("Pressionando H");
            isPressingH = true;
        }
        else
        {
            isPressingH = false;
        }

        slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entrando na colisão...");
        if (collision.gameObject.CompareTag("Player"))
        {
            isNextToPlayer = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        Debug.Log("Entrando na colisão...");
        if (collision.gameObject.CompareTag("Player"))
        {
            isNextToPlayer = false;
        }
    }

}

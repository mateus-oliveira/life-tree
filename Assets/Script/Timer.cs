using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTime;
    [SerializeField] private float timeValue;


    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("DecreaseTime", 1f, 1f/60);
    }

    // Update is called once per frame
    void Update(){
        if(this.txtTime.Equals("00.00")){
        }
    }

    private void DecreaseTime(){
        if(timeValue <= 0f){
            this.Success();
            return;
        }

        timeValue--;
        DisplayTime(timeValue);
    }

    /*private void IncreaseTime(){
        if(timeValue < 0f){
            return;
        }
        
        timeValue++;
        DisplayTime(timeValue);
    }*/

    private void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0f){
            timeToDisplay = 0f;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay/60);
        float seconds = Mathf.FloorToInt(timeToDisplay%60);

        txtTime.text = string.Format("{0:00}.{1:00}", minutes, seconds);
    }

    private void Success() {
        SceneManager.LoadScene("Success");
    }
}

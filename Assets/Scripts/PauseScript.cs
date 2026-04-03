using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [Header("Pause UI")]
    public GameObject pauseMenu;
    public bool pauseToggle;

    [Header("References")]
    public TimerScript timerScript;
    public CharacterController characterController;
    public FPMovement movementScript;
    public MouseLook lookScript1;
    public MouseLook lookScript2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseToggle()
    {
        //FlipToggle
        pauseToggle = !pauseToggle;

        pauseMenu.SetActive(pauseToggle);

        timerScript.PauseTimeToggle(pauseToggle);
        lookScript1.enabled = !pauseToggle;
        lookScript2.enabled = !pauseToggle;
        characterController.enabled = !pauseToggle;
        movementScript.enabled = !pauseToggle;



    }
}

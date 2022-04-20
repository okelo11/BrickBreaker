using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   public int rangeOfBackgroundGreen; 
    Color firstColorOfCamera;
    public float colorChangeTimer;
    private void Start()
    {
        firstColorOfCamera = Camera.main.backgroundColor;
        Time.timeScale = 1;
        

    }
    private void Update()
    {
        colorChangeTimer += Time.deltaTime;
        if(colorChangeTimer<3f)
        { 
        ToNewColorOfCam();
        }
        if (colorChangeTimer > 3) 
        { 
            ToFirstColorOfCam();
            if (colorChangeTimer > 6) 
            {
                colorChangeTimer = 0;
            }
        }

    }
    void ToFirstColorOfCam()
    {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, firstColorOfCamera, 0.001f);


    }
    void ToNewColorOfCam()
    {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, new Color(1f, 0.663f, 0.452f, 1), 0.001f);


    }
   
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;

    }
    public void ExitButton()
    {
        Application.Quit();
    }
    
}

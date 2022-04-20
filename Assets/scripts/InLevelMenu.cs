using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InLevelMenu : MonoBehaviour
{
    public float tripleTapTimer;
    public bool isTripleTabBegan = false;
    public bool istripleTapTimerBegan = false;
    public int tapCount;
    public float timeExtendValue = 0f;
    float timeExtend ;
    public float defaultTime=2f;
    public CanvasGroup inGameCanvasFade;
    public Canvas inGameCanvas;
    [Range(0f,0.1f)]
    public float fadeSpeed; 

    private void Update()
    {
        TripleTap();

    }

    void TripleTap()
    {
        if (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject == null && Time.timeScale != 0) 
        { 
           if( Input.GetMouseButtonDown(0))
           {
            Debug.Log("tikladim");
            isTripleTabBegan = true;
            timeExtend += timeExtendValue;

           }
           if (isTripleTabBegan)
           {
            tripleTapTimer += Time.deltaTime;
            
            if(tripleTapTimer<=defaultTime + timeExtend)
            { 
                if (Input.GetMouseButtonDown(0))
                {
                 Debug.Log(timeExtend);
                 tapCount += 1;
                     if (tapCount == 3)
                     {
                        inGameCanvas.gameObject.SetActive(true);
                        tapCount = 0;
                        tripleTapTimer = 0;
                        timeExtend = 0f;
                       
                        isTripleTabBegan = false;
                        //ara sahane yükle
                    



                     }
                }

            }
            if(tripleTapTimer >defaultTime + timeExtend)
            {
                tapCount = 0;
                tripleTapTimer = 0;
                timeExtend = 0f;
                isTripleTabBegan = false;
                


            }

           }
        }
        if (inGameCanvas.gameObject.activeSelf)
        {
            inGameCanvasFade.alpha = Mathf.Lerp(inGameCanvasFade.alpha, 1, fadeSpeed);//it is not effected by time.timescale=0 while using 0.01f
            Time.timeScale = 0;
        }




    }
    public void ResumeButton()
    {
        inGameCanvas.gameObject.SetActive(false);
      
        Time.timeScale = 1;
    }
    public void HomeButton()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}

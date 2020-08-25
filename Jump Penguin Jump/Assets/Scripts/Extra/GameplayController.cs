using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText;
    //[SerializeField]
    //private Text highScoreText;
    
    private int score;
    //private int HighScore;
    public Animator anim1,anim2,anim3,anim4,anim5;

    void Awake()
    {       
        if (instance == null)
            instance = this;

        //anim=GetComponent<Animator>();
    }

    public void IncrementScore()
    {   
        score++;
        scoreText.text="x" + score.ToString();

        anim1.SetBool("score",false);
        anim2.SetBool("score",false);
        anim3.SetBool("score",true);
        anim4.SetBool("score",false);
        anim5.SetBool("score",true);
        
        if( score % 20 == 0 )
            {
            SoundManager.instance.ClapSound();
                anim1.SetBool("score",true);
                anim2.SetBool("score",true);
                anim3.SetBool("score",false);
                anim4.SetBool("score",true);
                anim5.SetBool("score",false);
            }
       // UpdateHighScore();

    }

    /*public void UpdateHighScore()
    {
        if(score > HighScore)
        {
            HighScore=score;
            highScoreText.text=":" + HighScore.ToString();
        }
    }*/


    public void RestartGame()
    {
        Invoke("ReloadGame",3f);
    }
    void ReloadGame()
    {   
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}//class

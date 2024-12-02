using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Game_Cool : MonoBehaviour
{
    public static Game_Cool i;
    public Ball ball;
    public float radius;
    bool isResetting;
    public int score;
    public TMP_Text scoreText;
    public float lerpSpeed;
    public Animator textAnimator;
    public Animator zombie;

    void Awake()
    {
        i = this;
        zombie.Play("Base Layer.wave");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if(Vector2.Distance(ball.transform.position, Vector2.zero) > radius && !isResetting)
        {
            StartCoroutine(BallResetCoroutine());
        }

        scoreText.transform.localScale = Vector2.Lerp(scoreText.transform.localScale, Vector2.one, lerpSpeed * Time.deltaTime);
    }

    IEnumerator BallResetCoroutine()
    {
        isResetting = true;

        ball.GetComponent<Ball>().StopBall();
        yield return new WaitForSeconds(1);
        ball.transform.position = Vector2.zero;    
        isResetting = false;
        ball.GetComponent<Ball>().ResetBall();
        textAnimator.Play("Base Layer.textDefault");
        ResetScore();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreText.transform.localScale = Vector2.one * 2;
        if(score > 5) textAnimator.Play("Base Layer.textShow");
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
}

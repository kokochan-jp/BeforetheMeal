using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 5;
    public Animator hitanim;
    public Image hitImage;
    public Sprite hitSprite;
    public Sprite missSprite;
    
    public Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void NoteHit()
    {
        hitImage.gameObject.SetActive(true);
        Debug.Log("Hit On Time");
        hitImage.sprite = hitSprite;
        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
        hitanim.SetTrigger("Hit");
    }

    public void NoteMissed()
    {
        hitImage.sprite = missSprite;
        Debug.Log("Missed Note");
        hitanim.SetTrigger("Hit");
    }
    
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

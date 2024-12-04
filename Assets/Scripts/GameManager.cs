using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic; // Music to sync beats with
    public bool startPlaying; // Flag to check if music has started
    public BeatScroller theBS; // Reference to the BeatScroller
    public static GameManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 150;
    public int scorePerPerfectNote = 250;
    public int scorePerStellarNote = 1500;
    public Text scoreText;

    public float totalNotes;
    public float MissedNotes;
    public float HitNotes;
    public float GoodNotes;
    public float GreatNotes;
    public float PerfectNotes;

    public GameObject resultsScreen;
    public Text AccuracyText, normalsText, goodsText, greatsText, perfectsText, missesText, rankText, finalScoreText;
    void Start(){
        instance = this;
        scoreText.text = "Score: 0";
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }
    // Update is called once per frame
    void Update(){
        if (!startPlaying){
            // Start playing music and scrolling on key press
            if (Input.anyKeyDown){
                startPlaying = true;
                theMusic.Play();
                theBS.StartScrolling();
            } else {
                if(!theMusic.isPlaying && resultsScreen.activeInHierarchy){
                    resultsScreen.SetActive(true);
                    normalsText.text = "" + HitNotes;
                    goodsText.text = GoodNotes.ToString();
                    perfectsText.text = PerfectNotes.ToString();
                    missesText.text = "" + MissedNotes;

                    float totalHits = HitNotes + GoodNotes + GreatNotes + PerfectNotes;
                    float percentHit = (totalHits/totalNotes) * 100f;

                    AccuracyText.text = percentHit.ToString("F1") + "%";

                    string rankVal = "F";
                    if(percentHit > 99){
                     rankVal = "Lunatic";
                    } else if(percentHit > 90){
                        rankVal = "S";
                    } else if(percentHit > 80){
                        rankVal = "A";
                    } else if(percentHit > 70){
                        rankVal = "B";
                    } else if(percentHit > 50){
                        rankVal = "C";
                    } else {
                        rankVal = "D";
                    }
                    rankText.text = rankVal;
                
                    finalScoreText.text = currentScore.ToString();
                }
            }

        }
    }
    public void NoteHit(){
        Debug.Log("Hit On time");
        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
    }
    public void NormalHit(){
        currentScore += scorePerNote;
        NoteHit();
        HitNotes++;
    }
    public void GoodHit(){
        currentScore += scorePerGoodNote;
        NoteHit();
        GoodNotes++;
    }
    public void PerfectHit(){
        currentScore += scorePerPerfectNote;
        NoteHit();
        GreatNotes++;
    }
    public void StellarHit(){
        currentScore += scorePerStellarNote;
        NoteHit();
        PerfectNotes++;
    }
    public void NoteMissed(){
        Debug.Log("Missed Note");
        MissedNotes++;
    }
}
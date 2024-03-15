using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public int score;
    public Text puntos;
    
    public void AddScore()
    {
        score++;
        puntos.text = "Score = " + score.ToString();
    }
}

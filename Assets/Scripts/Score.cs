using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    private int bombCounter = 0;

    void Update()
    {
        scoreText.text = ( (int)Time.fixedTime + (bombCounter * 10)).ToString();
    }

    public void addBomb(int bombNum)
    {
        bombCounter = bombNum;
    }
}

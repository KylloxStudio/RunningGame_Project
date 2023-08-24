using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public List<Enemy> enemyGroup;
    public float spawnPercent;

    public Text scoreText;
    public GameObject gameoverPanel;

    public float timer = 0f;
    public bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (player.isGameOver)
            {
                Time.timeScale = 0f;
                isPlaying = false;
                gameoverPanel.SetActive(true);
            }
            timer += Time.deltaTime;
            scoreText.text = "Score: " + timer.ToString("N2");
            float random = Random.Range(0f, 100f);
            if (random <= spawnPercent)
            {
                Enemy e = Instantiate(enemy);
                enemyGroup.Add(e);
                e.transform.position = new Vector3(Random.Range(10f, 15f), Random.Range(-1.5f, -3.3f));
            }
        }
    }
}

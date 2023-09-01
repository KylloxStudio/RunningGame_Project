using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public Enemy enemy;
    public List<Enemy> enemyGroup;

    public Text scoreText;
    public GameObject gameoverPanel;

    public float score = 0f;
    public float spawnPerTimer = 5f;
    public bool isPlaying = true;
    public float spawnTime = 0.4f;
    public int maxSpawnCount = 3;
    public float spawnPercent = 0.4f;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
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
            score += Time.deltaTime;
            scoreText.text = "Score: " + score.ToString("N2");
            spawnPerTimer -= Time.deltaTime;
            if (spawnPerTimer <= 0)
            {
                spawnPercent += 0.1f;
                maxSpawnCount += 1;
                spawnPerTimer = 5f;
            }
            spawnTime -= Time.deltaTime;
            float random = Random.Range(0f, 100f);
            if (random <= spawnPercent)
            {
                if (enemyGroup.Count <= maxSpawnCount && spawnTime <= 0)
                {
                    Enemy e = Instantiate(enemy);
                    enemyGroup.Add(e);
                    e.transform.position = new Vector3(Random.Range(10f, 15f), Random.Range(-1f, -3.3f));
                    spawnTime = 0.4f;
                }
            }
        }
    }
}

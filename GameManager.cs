using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public int score = 0;

    private float pulpitSpawnTime;
    private float minPulpitDestroyTime;
    private float maxPulpitDestroyTime;

    private string jsonData = "{\"player_data\":{\"speed\":3},\"pulpit_data\":{\"min_pulpit_destroy_time\":4,\"max_pulpit_destroy_time\":5,\"pulpit_spawn_time\":2.5}}";
    private PlayerData playerData;
    private PulpitData pulpitData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Parse JSON data
        ParseJsonData();
    }

    void ParseJsonData()
    {
        // Parse JSON data
        Dictionary<string, object> jsonDataObject = JsonUtility.FromJson<Dictionary<string, object>>(jsonData);

        // Extract player and pulpit data
        playerData = JsonUtility.FromJson<PlayerData>(jsonDataObject["player_data"].ToString());
        pulpitData = JsonUtility.FromJson<PulpitData>(jsonDataObject["pulpit_data"].ToString());

        // Extract individual values
        pulpitSpawnTime = pulpitData.pulpit_spawn_time;
        minPulpitDestroyTime = pulpitData.min_pulpit_destroy_time;
        maxPulpitDestroyTime = pulpitData.max_pulpit_destroy_time;
    }

    void Start()
    {
        // Initialize score text
        scoreText.text = "Score: 0";

        // Start spawning pulpits
        StartCoroutine(SpawnPulpits());
    }

    IEnumerator SpawnPulpits()
    {
        while (true)
        {
            // Spawn a new pulpit
            GameObject pulpit = Instantiate(Resources.Load<GameObject>("Pulpit"));
            pulpit.transform.position = GetRandomPulpitPosition();

            // Set pulpit destroy timer
            pulpit.GetComponent<Pulpit>().destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);

            // Wait for pulpit spawn time
            yield return new WaitForSeconds(pulpitSpawnTime);
        }
    }

    Vector3 GetRandomPulpitPosition()
    {
        // Get a random position adjacent to the previous pulpit
        GameObject previousPulpit = GameObject.Find("Pulpit");
        Vector3 position = previousPulpit.transform.position + new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2));
        return position;
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // Show game over screen
        GameObject gameOverScreen = GameObject.Find("GameOverScreen");
        gameOverScreen.SetActive(true);
    }
}

[System.Serializable]
public class PlayerData
{
    public float speed;
}

[System.Serializable]
public class PulpitData
{
    public float min_pulpit_destroy_time;
    public float max_pulpit_destroy_time;
    public float pulpit_spawn_time;
}
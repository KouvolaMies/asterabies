using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private asteroid asteroidprefab;
    public int asteroidcount = 0;
    public int scorenum = 0;
    public int hpnum = 3;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text hp;
    [SerializeField] private TMP_Text gameovertxt;
    void Update()
    {
        if(asteroidcount == 0){
            int asteroidnum = Random.Range(2, 5);
            for(int i = 0; i < asteroidnum; i += 1){
                SpawnAsteroid();
            }
        }

        score.text = "Score: " + scorenum;
        hp.text = "HP: " + hpnum;
    }
    void SpawnAsteroid(){
        float offset = Random.Range(0f, 1f);
        Vector2 viewspawn = Vector2.zero;
        int edge = Random.Range(0, 3);
        if(edge == 0){
            viewspawn = new Vector2(offset, 0);
        }
        else if(edge == 1){
            viewspawn = new Vector2(offset, 1);
        }
        else if(edge == 2){
            viewspawn = new Vector2(0, offset);
        }
        else if(edge == 3){
            viewspawn = new Vector2(1, offset);
        }
        Vector2 worldspawn = Camera.main.ViewportToWorldPoint(viewspawn);
        asteroid asteroid = Instantiate(asteroidprefab, worldspawn, Quaternion.identity);
        asteroid.gameManager = this;
    }

    public void GameOver(){
        gameovertxt.text = "GAME OVER";
        StartCoroutine(Restart());
    }

    private IEnumerator Restart(){
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        yield return null;
    }
}
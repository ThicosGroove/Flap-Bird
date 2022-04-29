using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject inimigo;

    public Text highScore;
    public Text scoreText;
    public Text textoInicial;

    int pontos;

    private void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
       
        textoInicial.text = "Clique para iniciar";
    }


    void Comecou()
    {
        InvokeRepeating("CriaInimigo", 0f, 2f);
        Destroy(textoInicial);
    }

    void Acabou()
    {
        CancelInvoke("CriaInimigo");
    }

    void CriaInimigo()
    {
        float alturaAleatoria = 10.0f * Random.value - 5.5f;
        GameObject Novoinimigo = Instantiate(inimigo);
        Novoinimigo.transform.position = new Vector2(15.0f, alturaAleatoria);
    }

    void MarcaPonto()
    {
        pontos += 100;
        scoreText.text = "Score: " + pontos.ToString();

        if (pontos > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", pontos);
        }
    }

    void GameOver()
    {         
            Invoke("RestartScene", 1.5f);
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

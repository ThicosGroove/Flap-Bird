using UnityEngine;

public class Inimigo : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;
    GameObject jogador;
    GameObject gameEngine;

    bool marcouPonto;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.velocity = new Vector2(-4, 0);

        gameEngine = GameObject.FindGameObjectWithTag("MainCamera");
        jogador = GameObject.FindGameObjectWithTag("Player");       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < - 15)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (jogador != null && this.transform.position.x < jogador.transform.position.x)
            {
                if (!marcouPonto)
                {
                    marcouPonto = true;

                    col.enabled = false;
                    rb.isKinematic = false;
                    rb.velocity = Vector2.zero;
                    rb.AddForce(new Vector2(-300f, 0));
                    rb.AddTorque(300f);
                    GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);

                    gameEngine.SendMessage("MarcaPonto");
                }
            }
        }
    }
}

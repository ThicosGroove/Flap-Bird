using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;

    GameObject gameEngine;

    bool start;
    bool end;
    Vector2 forceImpulse = new Vector2(0, 400f);

    // Start is called before the first frame update
    void Start()
    {
        gameEngine = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!end && PauseMenu.isGamePaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!start)
                {
                    start = true;
                    gameEngine.SendMessage("Comecou");
                    rb.isKinematic = false;
                }

                rb.velocity = new Vector2(0, 0);
                rb.AddForce(forceImpulse);
            }

            float alturaJogadorEmPixels = Camera.main.WorldToScreenPoint(transform.position).y;

            if (alturaJogadorEmPixels > Screen.height || alturaJogadorEmPixels < 0)
            {
                end = true;
                EfeitoMorte();
                gameEngine.SendMessage("Acabou");
                gameEngine.SendMessage("GameOver");
            }

            transform.rotation = Quaternion.Euler(0, rb.velocity.y * 1.5f, 0f);
        }
    }

    private void OnCollisionEnter2D()
    {
        if (!end)
        {
            end = true;
            EfeitoMorte();
            gameEngine.SendMessage("Acabou");
            gameEngine.SendMessage("GameOver");
        }       
    }

    void EfeitoMorte()
    {
        col.enabled = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(-300f, 0));
        rb.AddTorque(300f);
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);
    }

}

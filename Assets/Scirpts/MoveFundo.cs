using UnityEngine;

public class MoveFundo : MonoBehaviour
{
    float alturaTela;
    float larguraTela;

    // Start is called before the first frame update
    void Start()
    {
        
        SpriteRenderer grafico = GetComponent<SpriteRenderer>();

        alturaTela = Camera.main.orthographicSize * 2;
        larguraTela = alturaTela / Screen.height * Screen.width;
      
        float larguraImagem = grafico.sprite.bounds.size.x;
        float alturaImagem = grafico.sprite.bounds.size.y;

        Vector2 novaEscala = transform.localScale;
        novaEscala.x = larguraTela / larguraImagem + 0.0075f;
        novaEscala.y = alturaTela / alturaImagem;
        transform.localScale = novaEscala;

        if (this.name == "ImagemFundoB")
        {
            transform.position = new Vector2(larguraTela, 0f);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -larguraTela)
        {
            transform.position = new Vector2(larguraTela, 0f);
        }


    }
}

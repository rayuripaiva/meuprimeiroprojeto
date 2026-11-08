using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public bool Player1 = true;
    public float Speed = 7f;
    public float LimitY = 4.5f;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        
        var save = SaveController.Instance;
        if (spriteRenderer != null && save != null)
        {
           
            spriteRenderer.color = Player1 ? save.colorPlayer : save.colorEnemy;
        }
    }

    void Update()
    {
       
        if (spriteRenderer != null)
        {
            var save = SaveController.Instance;
            spriteRenderer.color = Player1 ? save.colorPlayer : save.colorEnemy;
        }

        
        float move = 0f;
        if (Player1)
        {
            if (Input.GetKey(KeyCode.W)) move = 1f;
            if (Input.GetKey(KeyCode.S)) move = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) move = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) move = -1f;
        }

        transform.Translate(0f, move * Speed * Time.deltaTime, 0f);

        var pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -LimitY, LimitY);
        transform.position = pos;
    }

}

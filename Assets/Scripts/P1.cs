using UnityEngine;

public class P1 : MonoBehaviour
{
    public float moveSpeed;

    public float minY = -4f;
    public float maxY = 4f;

    void Update()
    {
        bool isPressingUp = Input.GetKey(KeyCode.W);
        bool isPressingDown = Input.GetKey(KeyCode.S);

        if (isPressingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }

        if (isPressingDown)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }

        // Ограничиваем положение ракетки
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
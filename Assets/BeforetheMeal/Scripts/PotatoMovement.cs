using UnityEngine;

public class PotatoMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        float zDistance = -Camera.main.transform.position.z;
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, zDistance));
        if (transform.position.x > topRight.x + 1f)
        {
            gameObject.SetActive(false);
        }
    }
}

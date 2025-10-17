using UnityEngine;

public class PotatoDeactiivator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -8f) // adjust to your scene bounds
            gameObject.SetActive(false);
    }

}

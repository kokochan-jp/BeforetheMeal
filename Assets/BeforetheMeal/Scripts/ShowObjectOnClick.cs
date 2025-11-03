using UnityEngine;

public class ShowObjectOnClick : MonoBehaviour
{
    public GameObject objectToShow;

    public void ShowObject()
    {
        objectToShow.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

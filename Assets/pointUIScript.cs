using UnityEngine;
using UnityEngine.UI;


public class pointUIScript : MonoBehaviour
{
    public Pointholder pointholder;
    public Text points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        points.text = "Points: " + pointholder.Score;
    }




}

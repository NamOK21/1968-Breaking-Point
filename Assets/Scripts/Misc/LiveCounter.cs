using UnityEngine;
using UnityEngine.UI;

public class LiveCounter : MonoBehaviour
{
    public static int liveValue = 2;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Lives: " + liveValue;
    }
}

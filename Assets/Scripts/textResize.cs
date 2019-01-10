using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textResize : MonoBehaviour
{
    public float scale; //value from 0 to 1

    private void Awake()
    {
        StartCoroutine("resize");
    }

    void Start()
    {

    }

    IEnumerator resize()
    {
        yield return new WaitForEndOfFrame();
        Text myText = gameObject.GetComponent<Text>();
        myText.fontSize = (int)(gameObject.GetComponent<RectTransform>().rect.height * scale);
    }

    void Update()
    {

    }
}

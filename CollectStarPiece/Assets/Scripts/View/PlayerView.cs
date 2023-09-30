using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Sprite _normal;
    [SerializeField] private Sprite _pray;
    [SerializeField] private Sprite _get;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().sprite = _normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPray()
    {
        return this.GetComponent<Image>().sprite == _pray;
    }

    public void ChangePrayImage()
    {
        StartCoroutine(ChangeImage(_pray));
    }

    public void ChangeGetImage()
    {
        StartCoroutine(ChangeImage(_get));
    }

    private IEnumerator ChangeImage(Sprite image)
    {
        this.GetComponent<Image>().sprite = image;
        yield return new WaitForSeconds(1.0f);
        this.GetComponent<Image>().sprite = _normal;
    }
}

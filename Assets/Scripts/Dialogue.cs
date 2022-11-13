using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private Image talkerImage;
    [SerializeField] private TMP_Text talkerText;


    private void Start()
    {
        DOTween.Init();
    }


    public void ShowMessage(Sprite talkerImg, string talkerTxt)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
        talkerImage.GetComponent<Image>().sprite = talkerImg;
        talkerText.text =talkerTxt;
        Debug.Log("I am showing message");
    }

    public void CloseMessage()
    {
        StartCoroutine(MessageScreenCloser());
    }
    
    
    private IEnumerator MessageScreenCloser()
    {
        yield return new WaitForSeconds(0.3f);
        transform.DOScale(new Vector3(0f, 0f, 0f), 0.5f);
    }
}

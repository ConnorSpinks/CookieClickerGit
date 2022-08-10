using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnBall : MonoBehaviour
{

    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject _surpriseImage;
    [SerializeField] private Vector3 _position;
    [SerializeField] private TMP_Text _text;

    private int _ballCount = 1;

    private void Start()
    {
        _text.text = "1";
    }

    public void SpawnOnButton()
    {
        Debug.Log("We have activated the Button");

        float randomX = Random.Range(-0.1f, 0.1f);

        _position.x += randomX;

        Instantiate(ballPrefab, _position, Quaternion.identity);

        _ballCount++;
        _text.text = _ballCount.ToString();

        if (_ballCount > 49)
        {
            _surpriseImage.SetActive(true);
        }
    }
}

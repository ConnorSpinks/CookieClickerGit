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

    [SerializeField] private List<GameObject> _ballList;

    private void Start()
    {
        _text.text = "1";

        _ballList = new List<GameObject>();

        for (int x = 0; x < 10; x++)
        {
            SpawnOnButton();
        }

        //GameObject destroyThisBall = _ballList[2];

        //_ballList.Remove(destroyThisBall);

        //Destroy(destroyThisBall);

        //_ballList.RemoveAt(0);
        
    }
 
      public void DeleteOnButton()
    {
        Destroy(_ballList[0]);
        _ballList.RemoveAt(0);
    }
    
    public void DeleteAllOnButton()
    {
        for (int x = _ballList.Count - 1; x >= 0; x--)
        {
            Destroy(_ballList[x]);
            _ballList.RemoveAt(x);
        }
    }

    public void SpawnOnButton()
    {
        Debug.Log("We have activated the Button");

        float randomX = Random.Range(-0.1f, 0.1f);

        _position.x += randomX;

        GameObject newBall = Instantiate(ballPrefab, _position, Quaternion.identity);
        _ballList.Add(newBall);

        _ballCount++;
        _text.text = _ballCount.ToString();

        if (_ballCount > 49)
        {
            _surpriseImage.SetActive(true);
        }
    }
}

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
    [SerializeField] private List<GameObject> _ballList;

    private int _ballCount = 0;

    private void Start()
    {

        _ballList = new List<GameObject>();

        for (int x = 0; x < 10; x++)
        {
            SpawnOnButton();
        }
        
    }
 
      public void DeleteOnButton()
    {
        Destroy(_ballList[0]);
        _ballList.RemoveAt(0);
        _ballCount--;
        _text.text = _ballCount.ToString();
        Debug.Log("Ball Deleted");
    }
    
    public void DeleteAllOnButton()
    {
        for (int x = _ballList.Count - 1; x >= 0; x--)
        {
            Destroy(_ballList[x]);
            _ballList.RemoveAt(x);
            _ballCount--;
            _text.text = _ballCount.ToString();
            Debug.Log("All Balls Deleted");
        }
    }

    public void SpawnOnButton()
    {
        Debug.Log("Spawned Ball");

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

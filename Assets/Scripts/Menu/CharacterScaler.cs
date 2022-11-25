using UnityEngine;

public class CharacterScaler : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private float _screenHeight;
    private float _seventeen = 17;
    private float _twenty = 20;
    private float _twentyFive = 25;
    private float _thirtyFive = 35;
    private float _fourtyFive = 45;
    private float _seventy = 70;
    private float _sixHundred = 600;
    private float _sevenHundred = 700;
    private float _eightHundred = 800;
    private float _nineHundred = 900;
    private float _oneThousandOneHundreed = 1100;
    private float _oneThousandFiveHundred = 1500;
    private float _twoThousandTwoHundred = 2200;

    private void Start()
    {
        _screenHeight = Screen.height;

        if (_screenHeight <= _sevenHundred && _screenHeight >= _sixHundred)
        {
            _transform.localScale = new Vector3(_seventeen, _seventeen, _seventeen);
        }
        if (_screenHeight <= _eightHundred && _screenHeight >= _sevenHundred)
        {
            _transform.localScale = new Vector3(_twenty, _twenty, _twenty);
        }
        if (_screenHeight <= _nineHundred && _screenHeight >= _eightHundred)
        {
            _transform.localScale = new Vector3(_twentyFive, _twentyFive, _twentyFive);
        }
        if (_screenHeight <= _oneThousandOneHundreed && _screenHeight >= _nineHundred)
        {
            _transform.localScale = new Vector3(_thirtyFive, _thirtyFive, _thirtyFive);
        }
        if (_screenHeight <= _oneThousandFiveHundred && _screenHeight >= _oneThousandOneHundreed)
        {
            _transform.localScale = new Vector3(_fourtyFive, _fourtyFive, _fourtyFive);
        }
        if (_screenHeight <= _twoThousandTwoHundred && _screenHeight >= _oneThousandFiveHundred)
        {
            _transform.localScale = new Vector3(_seventy, _seventy, _seventy);
        }
    }
}

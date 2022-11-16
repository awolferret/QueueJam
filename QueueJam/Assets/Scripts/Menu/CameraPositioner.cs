using UnityEngine;

public class CameraPositioner : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private int _index;

    private void Update()
    {
        if (Screen.width > Screen.height)
        {
            switch (_index)
            {
                case (5):
                    FiveByFiveHorizontal();
                    break;
                case (6):
                    SixBySixHorizontal();
                    break;
                default:
                    Horizontal();
                    break;
            }
        }
        else
        {
            switch (_index)
            {
                case (3):
                    Horizontal();
                    break;
                case (4):
                    FourByFour();
                    break;
                case (5):
                    FiveByFive();
                    break;
                case (6):
                    SixBySix();
                    break;
                default:
                    break;
            }
        }
    }

    private void Horizontal()
    {
        _mainCamera.transform.position = new Vector3(6.7f,7.96f,-3.87f);
    }

    private void FourByFour()
    {
        _mainCamera.transform.position = new Vector3(6.8f, 9.52f, -3.87f);
    }

    private void FiveByFive()
    {
        _mainCamera.transform.position = new Vector3(6.8f, 11.73f, -3.87f);
    }

    private void FiveByFiveHorizontal()
    {
        _mainCamera.transform.position = new Vector3(5.9f, 7.96f, -3.11f);
    }

    private void SixBySix()
    {
        _mainCamera.transform.position = new Vector3(6.8f, 13.8f, -3.87f);
    }

    private void SixBySixHorizontal()
    {
        _mainCamera.transform.position = new Vector3(6.23f, 9.08f, -2.71f);
    }
}

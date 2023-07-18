using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassed : MonoBehaviour
{
    [SerializeField] private GameObject _conveyor;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;

    public void RemoveConveyor()
    {
        _conveyor.transform.position = Vector3.right  * Time.deltaTime;
        _image.gameObject.SetActive(false);
        _nextLevelButton.gameObject.SetActive(true);
        _text.gameObject.SetActive(true);
        if (_conveyor.transform.position.x <= 5)
        {
            Destroy(_conveyor);
        }
    }
}

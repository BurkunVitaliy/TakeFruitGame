using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassed : MonoBehaviour
{
    [SerializeField] 
    private GameObject conveyor;
    [SerializeField] 
    private Button nextLevelButton;
    [SerializeField] 
    private TMP_Text text;
    [SerializeField] 
    private Image image;

    public void RemoveConveyor()
    {
        conveyor.transform.position = Vector3.right  * Time.deltaTime;
        image.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        if (conveyor.transform.position.x <= 5)
        {
            Destroy(conveyor);
        }
    }
}

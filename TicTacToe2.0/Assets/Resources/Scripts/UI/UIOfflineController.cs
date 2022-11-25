using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIOfflineController : MonoBehaviour
{
    //Serialized Fields
    [Header("Components"), Space(10)]

    [SerializeField]
    private List<TextMeshProUGUI> _upperUIPieceCountText = new List<TextMeshProUGUI>();
    [SerializeField]
    private List<TextMeshProUGUI> _lowerUIPieceCountText = new List<TextMeshProUGUI>();
    [SerializeField]
    private List<Button> _upperUIPieceButton = new List<Button>();
    [SerializeField]
    private List<Button> _lowerUIPieceButton = new List<Button>();
    [SerializeField]
    private Image _upperUITimer, _lowerUITimer;
    [SerializeField]
    private Text _upperUITimerText, _lowerUITimerText;
    [SerializeField]
    private Sprite _blueBar, _pinkBar;

    [Header("Variables"), Space(10)]

    [SerializeField]
    private float _maxTimeForEachTure = 10f;


    //Private Variables
    private float _timer = 0f;
}

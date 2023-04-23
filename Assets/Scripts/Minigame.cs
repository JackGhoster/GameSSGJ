using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minigame : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> _texts;

    [SerializeField]
    private List<Image> _imagesToChange = new List<Image>();
    [SerializeField]
    private List<Sprite> _spriteArrows = new List<Sprite>();

    int _arrowIndex = 0;
    private bool _timeEnded = false;



    //private Dictionary<string, Vector2> _variations = new Dictionary<string, Vector2>()
    //{
    //    { "Up",new Vector2(x: 0, y: 1) },
    //    { "Down", new Vector2(x: 0, y: -1) },
    //    { "Right", new Vector2(x: 1, y: 0) },
    //    { "Left", new Vector2(x: -1, y: 0) }
    //};

    [SerializeField]
    private Dictionary<Vector2, Sprite> _imageVariations = new Dictionary<Vector2, Sprite>();
    //{
    //    { new Vector2(x: 0, y: 1), null },
    //    { new Vector2(x: 0, y: -1), null },
    //    { new Vector2(x: 1, y: 0), null },
    //    { new Vector2(x: -1, y: 0), null }
    //};


    /// <summary>
    /// List of variations in order: up arrow, down arrow, right arrow, left arrow
    /// </summary>
    private List<Vector2> _variations = new List<Vector2>()
    {
        //up
        new Vector2(x: 0, y: 1),
        //down
        new Vector2(x: 0, y: -1),
        //right
        new Vector2(x: 1, y: 0),
        //left
        new Vector2(x: -1, y: 0)
    };

    private List<Vector2> _arrows = new List<Vector2>();

    private int _amount = 6;


    private void Start()
    {
        EventManager.Instance.OnArrowKeyPressed += CheckForInput;
        EventManager.Instance.OnHidingInputPressed += ExitMinigame;
        EventManager.Instance.OnMinigameTimerEnded += TimeEnded;
    }

    private void FillSpriteDict()
    {
        for (int i = 0; i < _variations.Count; i++)
        {
            _imageVariations.Add(_variations[i], _spriteArrows[i]);
        }
    }
    private void GenerateArrowList()
    {
        for (int i = 0; i < _amount; i++)
        {
            _arrows.Add(_variations[Random.Range(0, _variations.Count)]);
        }
        _arrowIndex = 0;
        FillSpriteDict();
        Resort();
    }

    private void Resort()
    {
        for (int i = 0; i < _amount; i++)
        {
            _texts[i].text = $"{_arrows[i].x}:{_arrows[i].y}";
            _imagesToChange[i].sprite = _imageVariations[_arrows[i]];
        }
    }

    private void CheckForInput()
    {
        if (InputManager.Instance.ArrowsVector2 == _arrows[0])
        {
            EventManager.Instance.CorrectArrowPressed();
            if (_arrows.Count > 1)
            {
                _arrows.RemoveAt(0);
                //Destroy(_texts[_arrowIndex].gameObject.transform.parent.gameObject);
                Destroy(_imagesToChange[_arrowIndex]);
                _arrowIndex++;
                //Resort();
                //print(_arrows[0]);
            }
            else if (_arrowIndex == _amount - 1 )
            {
                print("Won");
                EventManager.Instance.WonMiniGame();
                Destroy(gameObject);
            }
        }
        else
        {
            EventManager.Instance.WrongArrowPressed();
            Destroy(gameObject);
        }
    }
    private void TimeEnded()
    {
        _timeEnded = true;
        GameManager.Instance.Hiding = false;
        ExitMinigame();
    }

    private void ExitMinigame()
    {
        if (GameManager.Instance.Hiding == false || _timeEnded == true)
        {
            Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        EventManager.Instance.OnArrowListRefill += GenerateArrowList;
        EventManager.Instance.RefillArrowList();
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnHidingInputPressed -= ExitMinigame;
        EventManager.Instance.OnMinigameTimerEnded -= TimeEnded;
        EventManager.Instance.OnArrowListRefill -= GenerateArrowList;
        EventManager.Instance.OnArrowKeyPressed -= CheckForInput;
    }
}


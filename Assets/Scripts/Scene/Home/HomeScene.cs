using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    public static UnityAction OnMainMenu;
    [SerializeField] private Button _playButton, _creditButton, _optionButton, _exitButton;
    [SerializeField] private GameObject _creditPopup, _optionPopuop, _exitPopup;
    [SerializeField] private string _nextScene;

    private void Start()
    {
        OnMainMenu?.Invoke();
        _playButton.onClick.AddListener(StartGame);
        _optionButton.onClick.AddListener(Option);
        _exitButton.onClick.AddListener(Exit);
        _creditButton.onClick.AddListener(Credit);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(_nextScene);
    }

    private void Credit()
    {
        _creditPopup.gameObject.SetActive(true);
    }

    private void Option()
    {
        _optionPopuop.gameObject.SetActive(true);
    }

    private void Exit()
    {
        _exitPopup.gameObject.SetActive(true);
    }
}

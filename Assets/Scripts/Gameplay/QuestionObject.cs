using UnityEngine;
using System.Collections;

public class QuestionObject {
    public string question = string.Empty;
    public string[] answers = null;
    public int correctanswerindex;
    public string correctanswer = string.Empty;
    public AudioClip correct = null, prompt = null, wrong=null;
    public AudioSource _audioSource = null;
    private bool _hasPrompted = false;
    public QuestionObject(string _q, string[] _a , int _ansindex)
    {
        this.question = _q;
        this.answers = _a;
        if(_ansindex < this.answers.Length)
        this.correctanswer = this.answers[_ansindex];
        this.correctanswerindex = _ansindex;
        if (_audioSource == null)_audioSource = FnGlobal.GetAudioSource();
        if (correct == null) correct = FnGlobal.GetUiSFX("correct");
        if (wrong == null) wrong = FnGlobal.GetUiSFX("wrong");
        if (prompt == null) prompt = FnGlobal.GetUiSFX("prompt_001");
    }
    public void promptFx()
    {
        if (!_hasPrompted)
        {
            _audioSource.PlayOneShot(prompt);
            _hasPrompted = true;
        }
    }
    public bool checkAnswer(int _answerIndex)
    {
        Debug.Log("correct index is " + this.correctanswerindex + " you chose: " + _answerIndex);
        if (this.correctanswerindex == _answerIndex)
        {
            if (_audioSource != null) _audioSource.PlayOneShot(correct);
            return true;
        }
        if (_audioSource != null) _audioSource.PlayOneShot(wrong);
        return false;
    }
}

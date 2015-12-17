using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class QuestionController : Controller {

    public QuestionDictionary questions = null;
    private PlayerObject _pObject = null;
    public QuestionObject _currentQuestion = null;
    public GameObject AnswerResult = null;
    private bool isCorrect = false;
    private bool isShowing = true;
    public int combo = 0;

    System.Random rand = new System.Random();
    public List<QuestionObject> _questionList;
    public GUISkin skin = null;
    float startx = -Screen.width * 0.6f;
    float starty = -Screen.height * 0.05f;
    float endx = 0;
    float endy = Screen.height * 0.05f;
    Rect questionBreakPos = new Rect(-Screen.width * 0.7f, -Screen.height * 0.05f,  Screen.width - (Screen.width * 0.6f) / 2, Screen.height * 0.15f);
    float w = Screen.width * 0.6f, h = Screen.height * 0.15f;
    float cw = 0, ch = 0;
    float timer = 0;
    const float questionBreakWindow = 3;

    public Texture left = null;

    public GameObject _victoryCanvas, _gameoverCanvas;
    int _countCorrectAnswer = 0, _countQuestionAnswered = 0;
    public int questionBreak = 1;
    int currentQb = 0;

    public override void Start (){
        base.Start();
        
        questions = new QuestionDictionary();
        questions.loadList("plant");
        print(questions.QuestionList.Count);
        _questionList = questions.QuestionList;
        _pObject = FnGlobal.GetPlayer<PlayerObject>();
        if (_pObject.type == PlayerObject.PlayerType.Player)
        {
            AnswerResult = Instantiate(AnswerResult) as GameObject;
            AnswerResult.GetComponent<CanvasGroup>().alpha = 0;
            AnswerResult.SetActive(false);
        }
        _victoryCanvas = Instantiate(_victoryCanvas) as GameObject;
        _victoryCanvas.SetActive(false);
	}
	public override void Update () {

        base.Update();
        if (!this.enabled) return;
        ShowAnswerResult();
        ManageQuestion(_pObject._turnStatus);
        if (_pObject.state == PlayerObject.PlayerState.Dead)
        {
            isShowing = true;
            AnswerResult.SetActive(true);
            RenderSettings.fogColor = Color.red;
            RenderSettings.fogDensity = 0.09f;
            RenderSettings.fog = true;
        }
   
	}
    void ManageQuestion(PlayerObject.TurnStatus _turnStatus)
    {
        switch (_turnStatus)
        {
            case PlayerObject.TurnStatus.Answering:
                if (_currentQuestion == null)
                {
                    int index = rand.Next(0, _questionList.Count - 1);
                    _currentQuestion = _questionList[index];
                    _questionList.RemoveAt(index);
                    _countQuestionAnswered += 1;
                }
                break;
            case PlayerObject.TurnStatus.QuestionBreakInteract:
                if (_currentQuestion == null)
                {
                    int index = rand.Next(0, _questionList.Count - 1);
                    _currentQuestion = _questionList[index];
                    _questionList.RemoveAt(index);
                    _countQuestionAnswered += 1;
                }
            break;
        }
    }
    void OnGUI()
    {
        if (!this.enabled) return;
        if (skin != null) if (GUI.skin != skin) GUI.skin = skin;
        if (_pObject.state == PlayerObject.PlayerState.Dead) return;
      
            ShowVictory();
            ShowCombo();
            ShowQuestionBreak();
      
        switch (_pObject._turnStatus)
        {
            case PlayerObject.TurnStatus.Idle:
                if (_countCorrectAnswer >= questionBreak) _countCorrectAnswer = 0;
                _pObject.state = PlayerObject.PlayerState.Normal;
            break;

            case PlayerObject.TurnStatus.Answering:

                if (_currentQuestion == null) return;
                _currentQuestion.promptFx();
                startx = Mathf.Lerp(startx, endx, Time.fixedDeltaTime * 3);
                cw = Mathf.Lerp(cw, w, Time.fixedDeltaTime * 3);
                ch = Mathf.Lerp(ch, h, Time.fixedDeltaTime * 3);
                GUI.Box(new Rect(0, 0, cw, ch), _currentQuestion.question);
                for (int x = 0; x < _currentQuestion.answers.Length; x++)
                {
                    if (left != null) GUI.DrawTexture(new Rect(10 + startx + (startx / 2 * x) + (Screen.width * 0.6f) / _currentQuestion.answers.Length, Screen.height * 0.2f + ((Screen.height * 0.1f * x) + 10) + 13 * x, (Screen.width * 0.05f), Screen.height * 0.1f), left);
                    if (GUI.Button(new Rect(startx + (startx / 2 * x), Screen.height * 0.2f + ((Screen.height * 0.1f * x) + 10) + 13 * x, (Screen.width * 0.6f) / _currentQuestion.answers.Length, Screen.height * 0.1f), _currentQuestion.answers[x]))
                    {
                        if (_currentQuestion.checkAnswer(x))
                        {
                            _pObject._turnStatus = PlayerObject.TurnStatus.Answered;
                            startx = -Screen.width * 0.6f;
                             AnswerResult.SetActive(true);
                            isCorrect = true;
                            isShowing = true;
                            _currentQuestion = null;
                            StartCoroutine(ToggleAnswerResult());
                            _countCorrectAnswer += 1;
                            if(!_pObject.useSpecial)
                            currentQb++;
                            if (combo < _pObject.maxCombo && !_pObject.useSpecial)
                            {
                                combo++;
                            }
                            return;
                        }
                        else
                        {
                            _pObject._turnStatus = PlayerObject.TurnStatus.Idle;
                            _currentQuestion = null;
                            startx = -Screen.width * 0.6f;
                            AnswerResult.SetActive(true);
                            isCorrect = false;
                            isShowing = true;
                            combo = 0;
                            StartCoroutine(ToggleAnswerResult());
                            return;
                        }
                    }
                }
                break;
            case PlayerObject.TurnStatus.QuestionBreakInteract:
                if (_currentQuestion == null) return;
                //Time Limit
                if (timer > 0) timer -= Time.fixedDeltaTime;
                else _pObject._turnStatus = PlayerObject.TurnStatus.Idle;
                //End Time Limit
                _currentQuestion.promptFx();
                startx = questionBreakPos.x = Mathf.Lerp(questionBreakPos.x, questionBreakPos.width, Time.fixedDeltaTime * 3);
                cw = Mathf.Lerp(cw, w, Time.fixedDeltaTime * 3);
                ch = Mathf.Lerp(ch, h, Time.fixedDeltaTime * 3);
                GUI.Box(new Rect(0, 0, cw, ch), _currentQuestion.question);
                for (int x = 0; x < _currentQuestion.answers.Length; x++)
                {
                    if (GUI.Button(new Rect(startx - ((Screen.width * 0.6f) / _currentQuestion.answers.Length / 2 * x), Screen.height * 0.2f + ((Screen.height * 0.1f * x) + 10) + 13 * x, (Screen.width * 0.6f) / _currentQuestion.answers.Length, Screen.height * 0.1f), _currentQuestion.answers[x]))
                    {
                        if (_currentQuestion.checkAnswer(x))
                        {
                            startx = -Screen.width * 0.6f;
                            AnswerResult.SetActive(true);
                            isCorrect = true;
                            isShowing = true;
                            _currentQuestion = null;
                            StartCoroutine(ToggleAnswerResult());
                            _countCorrectAnswer += 1;
                            _pObject._turnStatus = PlayerObject.TurnStatus.QuestionBreakAttack;
                            timer = questionBreakWindow + 0.5f;
                            return;
                        }
                        else
                        {
                            _pObject._turnStatus = PlayerObject.TurnStatus.Idle;
                            _currentQuestion = null;
                            startx = -Screen.width * 0.6f;
                            AnswerResult.SetActive(true);
                            isCorrect = false;
                            isShowing = true;
                            combo = 0;
                            StartCoroutine(ToggleAnswerResult());
                            return;
                        }
                    }
                }
                break;
            case PlayerObject.TurnStatus.MoveBack:
                if (combo == _pObject.maxCombo)
                {
                    combo = 0;
                    _pObject.useSpecial = true;
                }
                if (currentQb == questionBreak)
                {
                    _pObject.state = PlayerObject.PlayerState.Breaking;
                    _pObject._turnStatus = PlayerObject.TurnStatus.QuestionBreakSetup;
                    timer = questionBreakWindow;
                    currentQb = 0;
                }
                break;
           
        }
    }
    void ShowVictory()
    {
        if (_pObject._turnStatus == PlayerObject.TurnStatus.Victory)
        {
            _victoryCanvas.SetActive(true);
            float score = (float)_countCorrectAnswer / (float)this._countQuestionAnswered;
            score *= 3;
            _victoryCanvas.transform.Find("Text").GetComponent<Text>().text = "Victory\n Total score : " + (int)score + "/3 Stars\n" + "Total Answered Question: " + this._countQuestionAnswered + "\n Total Correct Answer: " + this._countCorrectAnswer;
        }
    }
    void ShowCombo()
    {
        GUI.Box(new Rect(Screen.width * 0.93f, Screen.height * 0.8f, Screen.width * 0.015f, -Screen.height * 0.7f), "", GUI.skin.GetStyle("slider_bg"));
        GUI.Box(new Rect(Screen.width * 0.933f, Screen.height * 0.8f, Screen.width * 0.007f, -(Screen.height * 0.7f * ((float)combo / (float)_pObject.maxCombo))), "", GUI.skin.GetStyle("slider_fg"));
        
    }
    void ShowQuestionBreak()
    {
        GUI.Box(new Rect(Screen.width * 0.97f, Screen.height * 0.8f, Screen.width * 0.02f, -Screen.height * 0.7f), "", GUI.skin.GetStyle("slider_bg"));
        GUI.Box(new Rect(Screen.width * 0.975f, Screen.height * 0.8f, Screen.width * 0.01f, -(Screen.height * 0.7f * ((float)currentQb / (float)questionBreak))), "", GUI.skin.GetStyle("slider_fg_red"));
        
    }

    IEnumerator ToggleAnswerResult()
    {
        yield return new WaitForSeconds(1);
        isShowing = false;
    }
    void ShowAnswerResult()
    {
        if (AnswerResult.activeInHierarchy)
        {
            if (isCorrect && _pObject.state != PlayerObject.PlayerState.Dead)
            {
                AnswerResult.transform.Find("img_correct").GetComponent<RawImage>().enabled = true;
                AnswerResult.transform.Find("img_wrong").GetComponent<RawImage>().enabled = false;
                AnswerResult.transform.Find("img_gameover").GetComponent<RawImage>().enabled = false;

            }
            else if (!isCorrect && _pObject.state != PlayerObject.PlayerState.Dead)
            {
                AnswerResult.transform.Find("img_wrong").GetComponent<RawImage>().enabled = true;
                AnswerResult.transform.Find("img_correct").GetComponent<RawImage>().enabled = false;
                AnswerResult.transform.Find("img_gameover").GetComponent<RawImage>().enabled = false;
            }
            else
            {
                AnswerResult.transform.Find("img_gameover").GetComponent<RawImage>().enabled = true;
                AnswerResult.transform.Find("img_correct").GetComponent<RawImage>().enabled = false;
                AnswerResult.transform.Find("img_wrong").GetComponent<RawImage>().enabled = false;
            }

            if (isShowing)
            {
                if (AnswerResult.GetComponent<CanvasGroup>().alpha <= 1)
                    AnswerResult.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(AnswerResult.GetComponent<CanvasGroup>().alpha, 1, Time.fixedDeltaTime);
            }
            else if (!isShowing)
            {
                if (AnswerResult.GetComponent<CanvasGroup>().alpha >= 0f)
                    AnswerResult.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(AnswerResult.GetComponent<CanvasGroup>().alpha, 0, Time.fixedDeltaTime);
                else
                {
                    AnswerResult.SetActive(false);
                    AnswerResult.GetComponent<CanvasGroup>().alpha = 0;
                    isShowing = true;
                }
            }
        }
    }
}

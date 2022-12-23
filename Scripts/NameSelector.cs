using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NameSelector : MonoBehaviour
{
    [SerializeField]
    List<Text> LettersAvaliable = new List<Text>();
    List<Text> LettersGone = new List<Text>();

    IEnumerable<KeyCode> keys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
    
    void Update()
    {
        if (LettersAvaliable.Count > 0)
        {
            foreach (KeyCode k in keys)
            {
                if (Input.GetKeyDown(k) && ((int)k >= 97 && (int)k <= 122))
                {
                    Text currentLetter = LettersAvaliable[0];
                    currentLetter.text = k.ToString();
                    LettersGone.Add(LettersAvaliable.ElementAt(0));
                    LettersAvaliable.RemoveAt(0);
                }
                else if (LettersGone.Count - 1 >= 0 && Input.GetKeyDown(KeyCode.Backspace))
                {
                    LettersGone.ElementAt(LettersGone.Count - 1).text = "";
                    LettersAvaliable.Insert(0, LettersGone.ElementAt(LettersGone.Count - 1));
                    LettersGone.RemoveAt(LettersGone.Count - 1);
                    break;
                }
            }
        }
        else
        {
            if (LettersGone.Count - 1 >= 0 && Input.GetKeyDown(KeyCode.Backspace))
            {
                LettersGone.ElementAt(LettersGone.Count - 1).text = "";
                LettersAvaliable.Insert(0, LettersGone.ElementAt(LettersGone.Count - 1));
                LettersGone.RemoveAt(LettersGone.Count - 1);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.SET_PLAYER_NAME(CondenseListToString(LettersGone));
            }

        }

    }
    private string CondenseListToString(List<Text> list)
    {
        string str = "";
        foreach(Text text in list)
        {
            str += text.text;
        }
        return str;
    }
}

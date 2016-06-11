using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public void ShowResult()
    {
        GameObject canvas;
        Text text;

        float[] ScoreArray = new float[4];
        int iBuf;

        //Continue Menuを非表示
        canvas = GameObject.Find("Canvas_Continue");
        canvas.GetComponent<Canvas>().enabled = false;

        //Pause Buttonを無効化
        GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = false;

        //1~3位のデータと今回のデータを配列に書き込む
        ScoreArray[0] = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score1st, 0);
        ScoreArray[1] = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score2nd, 0);
        ScoreArray[2] = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score3rd, 0);
        ScoreArray[3] = Score.instance.score;

        //データを降順で並び替える
        Array.Sort(ScoreArray);
        Array.Reverse(ScoreArray);

        //データを前詰めにする
        //(一番目のデータが0=前詰めする必要があるときのみ行う）
        if (ScoreArray[0] == 0){
            for (int i = 0; i < 4; i++){
                //0ではないデータが見つかった場合
                if (ScoreArray[i] != 0){
                    iBuf = i;   //データの入っている先頭の番号
                    for (int j = i; j < 4; j++){
                        //番号分だけ前に移動
                        ScoreArray[j - iBuf] = ScoreArray[j];
                        //移動したところには0を入れておく
                        ScoreArray[j] = 0;
                    }
                    break;
                }
            }
        }

        //データを書き込む
        PlayerPrefs.SetFloat(GlobalVariableScript.Prefs_Score1st, ScoreArray[0]);
        PlayerPrefs.SetFloat(GlobalVariableScript.Prefs_Score2nd, ScoreArray[1]);
        PlayerPrefs.SetFloat(GlobalVariableScript.Prefs_Score3rd, ScoreArray[2]);

        //保存する
        PlayerPrefs.Save();

        //Result Menuを表示
        canvas = GameObject.Find("Canvas_Result");
        canvas.GetComponent<Canvas>().enabled = true;

        //ランクを取得
        for (iBuf = 0; iBuf < 4; iBuf++)
        {
            if (ScoreArray[iBuf] == Score.instance.score)
            {
                //現在のランクを取得したら終了
                break;
            }
        }

        //ランクをセット
        text = GameObject.Find("Canvas_Result/Rank/Text").GetComponent<Text>();

        if (iBuf == 0)
        {
            text.text = "1st";
        }
        else if (iBuf == 1)
        {
            text.text = "2nd";
        }
        else if (iBuf == 2)
        {
            text.text = "3rd";
        }
        else
        {
            text.text = "-";
        }

        //スコアをセット
        text = GameObject.Find("Canvas_Result/Score/Text").GetComponent<Text>();
        text.text = Score.instance.score.ToString();
    }

    public void ClearResult()
    {
        PlayerPrefs.DeleteKey(GlobalVariableScript.Prefs_Score1st);
        PlayerPrefs.DeleteKey(GlobalVariableScript.Prefs_Score2nd);
        PlayerPrefs.DeleteKey(GlobalVariableScript.Prefs_Score3rd);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;
using System.Text;
using System.Windows;

public class Hangle : MonoBehaviour
{
    TextMesh test_t;
    //Text test_t;
    public Text f_text;
    string save_text;
 
    // 초성, 중성, 종성 테이블.
    private static string mFirstWordTbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    private static string mMiddleWordTbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string mLastWordTbl = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    private static ushort mUniCodeHangleBase = 0xAC00;
    private static ushort mUniCodeHangleLast = 0xD79F;
    private static string mFirstWord;
    private static string mMiddleWord;
    private static string mLastWord;    

    void Start()
    {
        test_t = GetComponent<TextMesh>();
    

    }

    private void Sum_WordBreak()
    {
        for (int i = 0; i < test_t.text.Length; i++)
        {
            WordBreak(test_t.text[i]);
            f_text.text = f_text.text + save_text;
        }
    }

    private void Update()
    {
        
        Sum_WordBreak();
    }

    public static string WordSum(string sFirstWord, string sMiddleWord, string sLastWord)
    {
        int i_FristPos, i_MiddlePos, i_LastWord;
        int iUniCode;
        i_FristPos = mFirstWordTbl.IndexOf(sFirstWord);   // 초성 위치
        i_MiddlePos = mMiddleWordTbl.IndexOf(sMiddleWord);   // 중성 위치
        i_LastWord = mLastWordTbl.IndexOf(sLastWord);   // 종성 위치
                                       // 앞서 만들어 낸 계산식
        iUniCode = mUniCodeHangleBase + (i_FristPos * 21 + i_MiddlePos) * 28 + i_LastWord;
        // 코드값을 문자로 변환
        char temp = System.Convert.ToChar(iUniCode);
        return temp.ToString();
    }

    public void WordBreak(char OneWord)
    {
        int One_FirstIdx, One_MiddleIdx, One_LastIdx; // 초성,중성,종성의 인덱스
        ushort uTempCode = 0x0000;       // 임시 코드용
                                         //Char을 16비트 부호없는 정수형 형태로 변환 - Unicode
        uTempCode = System.Convert.ToUInt16(OneWord);
        
        // 캐릭터가 한글이 아닐 경우 처리
        if ((uTempCode < mUniCodeHangleBase) || (uTempCode > mUniCodeHangleLast))
        {
            mFirstWord = ""; mMiddleWord = ""; mLastWord = "";
        }
        // iUniCode에 한글코드에 대한 유니코드 위치를 담고 이를 이용해 인덱스 계산.
        int iUniCode = uTempCode - mUniCodeHangleBase;
        One_FirstIdx = iUniCode / (21 * 28);
        iUniCode = iUniCode % (21 * 28);
        One_MiddleIdx = iUniCode / 28;
        iUniCode = iUniCode % 28;
        One_LastIdx = iUniCode;

        mFirstWord = new string(mFirstWordTbl[One_FirstIdx], 1);
        mMiddleWord = new string(mMiddleWordTbl[One_MiddleIdx], 1);
        mLastWord = new string(mLastWordTbl[One_LastIdx], 1);

        save_text = mFirstWord + " " + mMiddleWord + " " + mLastWord;
        
    }

}






using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;
using System.Text;
using System.Windows;

public class Hangle : MonoBehaviour
{
    //check on/off
    public bool check_break = true;

    public Transform tr;
    private Transform cam;

    Vector3 voice_dir;

    TextMesh test_t;
    //Text test_t;
    public Text f_text;
    string save_text;
 



    // 초성, 중성, 종성 테이블.
    private static string mFirstWordTbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    private static string mMiddleWordTbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string mLastWordTbl = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

    private static GameObject[] m3D_FirstWordTbl;
    private static GameObject[] m3D_MiddleWordTbl;
    private static GameObject[] m3D_LastWordTbl;


    private static ushort mUniCodeHangleBase = 0xAC00;
    private static ushort mUniCodeHangleLast = 0xD79F;
    private static string mFirstWord;
    private static string mMiddleWord;
    private static string mLastWord;    

    void Start()
    {

        test_t = GetComponent<TextMesh>();
        m3D_FirstWordTbl = new GameObject[19];
        m3D_MiddleWordTbl = new GameObject[21];
        m3D_LastWordTbl = new GameObject[28];

        voice_dir = new Vector3(0, 0, 19);
        cam = this.GetComponent<Transform>();

        for (int i = 0; i < m3D_FirstWordTbl.Length; i++)
        {
               m3D_FirstWordTbl[i] = Resources.Load<GameObject>(new string(mFirstWordTbl[i], 1));
  
        }

        for (int i = 0; i < m3D_MiddleWordTbl.Length; i++)
        {
            m3D_MiddleWordTbl[i] = Resources.Load<GameObject>(new string(mMiddleWordTbl[i], 1));
        }

        for (int i = 0; i < m3D_LastWordTbl.Length; i++)
        {
            m3D_LastWordTbl[i] = Resources.Load<GameObject>(new string(mLastWordTbl[i], 1));
        }


    }

    private void Update()
    {
        if (check_break == false)
        {
            check_break = !check_break;
            Matching_WordBreak();

        }
    }




    private void Matching_WordBreak()
    {


        for (int i = 0; i < test_t.text.Length; i++)
        {
            WordBreak(test_t.text[i]);
    
            switch (save_text[0]) // 초성파트
            { 
                case 'ㄱ':
                    Debug.Log("3D텍스트 ㄱ");
                    Instantiate(m3D_FirstWordTbl[0]);

                    m3D_FirstWordTbl[0].transform.position = cam.position;
                    //m3D_FirstWordTbl[0].transform.position = cam.position;

                    //Vector3 pos_now = m3D_FirstWordTbl[0].transform.position;
                    //m3D_FirstWordTbl[0].transform.SetParent(null);

                    break;
                case 'ㄲ':
                    Debug.Log("3D텍스트 ㄲ");
                    Instantiate(m3D_FirstWordTbl[1]);
                    break;
                case 'ㄴ':
                    Debug.Log("3D텍스트 ㄴ");
                    Instantiate(m3D_FirstWordTbl[2]);
                    break;
                case 'ㄷ':
                    Debug.Log("3D텍스트 ㄷ");
                    Instantiate(m3D_FirstWordTbl[3]);
                    break;
                case 'ㄸ':
                    Debug.Log("3D텍스트 ㄸ");
                    Instantiate(m3D_FirstWordTbl[4]);
                    break;
                case 'ㄹ':
                    Debug.Log("3D텍스트 ㄹ");
                    Instantiate(m3D_FirstWordTbl[5]);
                    break;
                case 'ㅁ':
                    Debug.Log("3D텍스트 ㅁ");
                    Instantiate(m3D_FirstWordTbl[6]);
                    break;
                case 'ㅂ':
                    Debug.Log("3D텍스트 ㅂ");
                    Instantiate(m3D_FirstWordTbl[7]);
                    break;
                case 'ㅃ':
                    Debug.Log("3D텍스트 ㅃ");
                    Instantiate(m3D_FirstWordTbl[8]);
                    break;
                case 'ㅅ':
                    Debug.Log("3D텍스트 ㅅ");
                    Instantiate(m3D_FirstWordTbl[9]);
                    break;
                case 'ㅆ':
                    Debug.Log("3D텍스트 ㅆ");
                    Instantiate(m3D_FirstWordTbl[10]);
                    break;
                case 'ㅇ':
                    Debug.Log("3D텍스트 ㅇ");
                    Instantiate(m3D_FirstWordTbl[11]);
                    break;
                case 'ㅈ':
                    Debug.Log("3D텍스트 ㅈ");
                    Instantiate(m3D_FirstWordTbl[12]);
                    break;
                case 'ㅉ':
                    Debug.Log("3D텍스트 ㅉ");
                    Instantiate(m3D_FirstWordTbl[13]);
                    break;
                case 'ㅊ':
                    Debug.Log("3D텍스트 ㅊ");
                    Instantiate(m3D_FirstWordTbl[14]);
                    break;
                case 'ㅋ':
                    Debug.Log("3D텍스트 ㅋ");
                    Instantiate(m3D_FirstWordTbl[15]);
                    break;
                case 'ㅌ':
                    Debug.Log("3D텍스트 ㅌ");
                    Instantiate(m3D_FirstWordTbl[16]);
                    break;
                case 'ㅍ':
                    Debug.Log("3D텍스트 ㅍ");
                    Instantiate(m3D_FirstWordTbl[17]);
                    break;
                case 'ㅎ':
                    Debug.Log("3D텍스트 ㅎ");
                    Instantiate(m3D_FirstWordTbl[18]);
                    break;

            }

            switch (save_text[1]) // 중성파트
            {
                case 'ㅏ':
                    Debug.Log("3D텍스트 ㅏ");
                    Instantiate(m3D_MiddleWordTbl[0]);
                    m3D_MiddleWordTbl[0].transform.position = cam.position;

                    break;
                case 'ㅐ':
                    Debug.Log("3D텍스트 ㅐ");
                    Instantiate(m3D_MiddleWordTbl[1]);
                    break;
                case 'ㅑ':
                    Debug.Log("3D텍스트 ㅑ");
                    Instantiate(m3D_MiddleWordTbl[2]);
                    break;
                case 'ㅒ':
                    Debug.Log("3D텍스트 ㅒ");
                    Instantiate(m3D_MiddleWordTbl[3]);
                    break;
                case 'ㅓ':
                    Debug.Log("3D텍스트 ㅓ");
                    Instantiate(m3D_MiddleWordTbl[4]);
                    break;
                case 'ㅔ':
                    Debug.Log("3D텍스트 ㅔ");
                    Instantiate(m3D_MiddleWordTbl[5]);
                    break;
                case 'ㅕ':
                    Debug.Log("3D텍스트 ㅕ");
                    Instantiate(m3D_MiddleWordTbl[6]);
                    break;
                case 'ㅖ':
                    Debug.Log("3D텍스트 ㅖ");
                    Instantiate(m3D_MiddleWordTbl[7]);
                    break;
                case 'ㅗ':
                    Debug.Log("3D텍스트 ㅗ");
                    Instantiate(m3D_MiddleWordTbl[8]);
                    break;
                case 'ㅘ':
                    Debug.Log("3D텍스트 ㅘ");
                    Instantiate(m3D_MiddleWordTbl[9]);
                    break;
                case 'ㅙ':
                    Debug.Log("3D텍스트 ㅙ");
                    Instantiate(m3D_MiddleWordTbl[10]);
                    break;
                case 'ㅚ':
                    Debug.Log("3D텍스트 ㅚ");
                    Instantiate(m3D_MiddleWordTbl[11]);
                    break;
                case 'ㅛ':
                    Debug.Log("3D텍스트 ㅛ");
                    Instantiate(m3D_MiddleWordTbl[12]);
                    break;
                case 'ㅜ':
                    Debug.Log("3D텍스트 ㅜ");
                    Instantiate(m3D_MiddleWordTbl[13]);
                    break;
                case 'ㅝ':
                    Debug.Log("3D텍스트 ㅝ");
                    Instantiate(m3D_MiddleWordTbl[14]);
                    break;
                case 'ㅞ':
                    Debug.Log("3D텍스트 ㅞ");
                    Instantiate(m3D_MiddleWordTbl[15]);
                    break;
                case 'ㅟ':
                    Debug.Log("3D텍스트 ㅟ");
                    Instantiate(m3D_MiddleWordTbl[16]);
                    break;
                case 'ㅠ':
                    Debug.Log("3D텍스트 ㅠ");
                    Instantiate(m3D_MiddleWordTbl[17]);
                    break;
                case 'ㅡ':
                    Debug.Log("3D텍스트 ㅡ");
                    Instantiate(m3D_MiddleWordTbl[18]);
                    break;
                case 'ㅢ':
                    Debug.Log("3D텍스트 ㅢ");
                    Instantiate(m3D_MiddleWordTbl[19]);
                    break;
                case 'ㅣ':
                    Debug.Log("3D텍스트 ㅣ");
                    Instantiate(m3D_MiddleWordTbl[20]);
                    break;
            }

            switch (save_text[2]) // 종성파트
            {
                case 'ㄱ':
                    Debug.Log("3D텍스트 ㄱ");
                    Instantiate(m3D_LastWordTbl[0]);
                    break;
                case 'ㄲ':
                    Debug.Log("3D텍스트 ㄲ");
                    Instantiate(m3D_LastWordTbl[1]);
                    break;
                case 'ㄳ':
                    Debug.Log("3D텍스트 ㄳ");
                    Instantiate(m3D_LastWordTbl[2]);
                    break;
                case 'ㄴ':
                    Debug.Log("3D텍스트 ㄴ");
                    Instantiate(m3D_LastWordTbl[3]);
                    break;
                case 'ㄵ':
                    Debug.Log("3D텍스트 ㄵ");
                    Instantiate(m3D_LastWordTbl[4]);
                    break;
                case 'ㄶ':
                    Debug.Log("3D텍스트 ㄶ");
                    Instantiate(m3D_LastWordTbl[5]);
                    break;
                case 'ㄷ':
                    Debug.Log("3D텍스트 ㄷ");
                    Instantiate(m3D_LastWordTbl[6]);
                    break;
                case 'ㄹ':
                    Debug.Log("3D텍스트 ㄹ");
                    Instantiate(m3D_LastWordTbl[7]);
                    break;
                case 'ㄺ':
                    Debug.Log("3D텍스트 ㄺ");
                    Instantiate(m3D_LastWordTbl[8]);
                    break;
                case 'ㄻ':
                    Debug.Log("3D텍스트 ㄻ");
                    Instantiate(m3D_LastWordTbl[9]);
                    break;
                case 'ㄼ':
                    Debug.Log("3D텍스트 ㄼ");
                    Instantiate(m3D_LastWordTbl[10]);
                    break;
                case 'ㄽ':
                    Debug.Log("3D텍스트 ㄽ");
                    Instantiate(m3D_LastWordTbl[11]);
                    break;
                case 'ㄾ':
                    Debug.Log("3D텍스트 ㄾ");
                    Instantiate(m3D_LastWordTbl[12]);
                    break;
                case 'ㄿ':
                    Debug.Log("3D텍스트 ㄿ");
                    Instantiate(m3D_LastWordTbl[13]);
                    break;
                case 'ㅀ':
                    Debug.Log("3D텍스트 ㅀ");
                    Instantiate(m3D_LastWordTbl[14]);
                    break;
                case 'ㅁ':
                    Debug.Log("3D텍스트 ㅁ");
                    Instantiate(m3D_LastWordTbl[15]);
                    break;
                case 'ㅂ':
                    Debug.Log("3D텍스트 ㅂ");
                    Instantiate(m3D_LastWordTbl[16]);
                    break;
                case 'ㅄ':
                    Debug.Log("3D텍스트 ㅄ");
                    Instantiate(m3D_LastWordTbl[17]);
                    break;
                case 'ㅅ':
                    Debug.Log("3D텍스트 ㅅ");
                    Instantiate(m3D_LastWordTbl[18]);
                    break;
                case 'ㅆ':
                    Debug.Log("3D텍스트 ㅆ");
                    Instantiate(m3D_LastWordTbl[19]);
                    break;
                case 'ㅇ':
                    Debug.Log("3D텍스트 ㅇ");
                    Instantiate(m3D_LastWordTbl[20]);
                    break;
                case 'ㅈ':
                    Debug.Log("3D텍스트 ㅈ");
                    Instantiate(m3D_LastWordTbl[21]);
                    break;
                case 'ㅊ':
                    Debug.Log("3D텍스트 ㅊ");
                    Instantiate(m3D_LastWordTbl[22]);
                    break;
                case 'ㅋ':
                    Debug.Log("3D텍스트 ㅋ");
                    Instantiate(m3D_LastWordTbl[23]);
                    break;
                case 'ㅌ':
                    Debug.Log("3D텍스트 ㅌ");
                    Instantiate(m3D_LastWordTbl[24]);
                    break;
                case 'ㅍ':
                    Debug.Log("3D텍스트 ㅍ");
                    Instantiate(m3D_LastWordTbl[25]);
                    break;
                case 'ㅎ':
                    Debug.Log("3D텍스트 ㅎ");
                    Instantiate(m3D_LastWordTbl[26]);
                    break;
                default:
                    break;

            }

            //f_text.text = f_text.text + save_text;
        }
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

        save_text = mFirstWord +  mMiddleWord + mLastWord;
        
    }

}






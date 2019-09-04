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
    private Transform subcam_01;
    private Transform subcam_02;
    Vector3 voice_dir;

    TextMesh test_t;
    //Text test_t;
    public Text f_text;
    string save_text;

    public GameObject word_1st;
    public GameObject word_2nd;
    public GameObject word_3rd;



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
        test_t.text = test_t.text.Replace(" ", "");
        Debug.Log(test_t.text);
        voice_dir = new Vector3(0, 0, 19);
        cam = this.GetComponent<Transform>();
        //cam.position = cam.position + new Vector3(0,30,0);//모르겄다
     //   subcam_01.position = cam.position + new Vector3(10, 0, 0);
 
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
                    word_1st = m3D_FirstWordTbl[0];
                    word_1st = Instantiate(m3D_FirstWordTbl[0], cam.position, this.transform.rotation);
                    break;
                case 'ㄲ':
                    Debug.Log("3D텍스트 ㄲ");
                    word_1st = m3D_FirstWordTbl[1];
                    word_1st = Instantiate(m3D_FirstWordTbl[1], cam.position, this.transform.rotation);
                    break;
                case 'ㄴ':
                    Debug.Log("3D텍스트 ㄴ");
                    word_1st = m3D_FirstWordTbl[2];
                    word_1st = Instantiate(m3D_FirstWordTbl[2], cam.position, this.transform.rotation);
                    break;
                case 'ㄷ':
                    Debug.Log("3D텍스트 ㄷ");
                    word_1st = m3D_FirstWordTbl[3];
                    word_1st = Instantiate(m3D_FirstWordTbl[3], cam.position, this.transform.rotation);
                    break;
                case 'ㄸ':
                    Debug.Log("3D텍스트 ㄸ");
                    word_1st = m3D_FirstWordTbl[4];
                    word_1st = Instantiate(m3D_FirstWordTbl[4], cam.position, this.transform.rotation);
                    break;
                case 'ㄹ':
                    Debug.Log("3D텍스트 ㄹ");
                    word_1st = m3D_FirstWordTbl[5];
                    word_1st = Instantiate(m3D_FirstWordTbl[5], cam.position, this.transform.rotation);
                    break;
                case 'ㅁ':
                    Debug.Log("3D텍스트 ㅁ");
                    word_1st = m3D_FirstWordTbl[6];
                    word_1st = Instantiate(m3D_FirstWordTbl[6], cam.position, this.transform.rotation);
                    break;
                case 'ㅂ':
                    Debug.Log("3D텍스트 ㅂ");
                    word_1st = m3D_FirstWordTbl[7];
                    word_1st = Instantiate(m3D_FirstWordTbl[7], cam.position, this.transform.rotation);
                    break;
                case 'ㅃ':
                    Debug.Log("3D텍스트 ㅃ");
                    word_1st = m3D_FirstWordTbl[8];
                    word_1st = Instantiate(m3D_FirstWordTbl[8], cam.position, this.transform.rotation);
                    break;
                case 'ㅅ':
                    Debug.Log("3D텍스트 ㅅ");
                    word_1st = m3D_FirstWordTbl[9];
                    word_1st = Instantiate(m3D_FirstWordTbl[9], cam.position, this.transform.rotation);
                    break;
                case 'ㅆ':
                    Debug.Log("3D텍스트 ㅆ");
                    word_1st = m3D_FirstWordTbl[10];
                    word_1st = Instantiate(m3D_FirstWordTbl[10], cam.position, this.transform.rotation);
                    break;
                case 'ㅇ':
                    Debug.Log("3D텍스트 ㅇ");
                    word_1st = m3D_FirstWordTbl[11];
                    word_1st = Instantiate(m3D_FirstWordTbl[11], cam.position, this.transform.rotation);
                    break;
                case 'ㅈ':
                    Debug.Log("3D텍스트 ㅈ");
                    word_1st = m3D_FirstWordTbl[12];
                    word_1st = Instantiate(m3D_FirstWordTbl[12], cam.position, this.transform.rotation);
                    break;
                case 'ㅉ':
                    Debug.Log("3D텍스트 ㅉ");
                    word_1st = m3D_FirstWordTbl[13];
                    word_1st = Instantiate(m3D_FirstWordTbl[13], cam.position, this.transform.rotation);
                    break;
                case 'ㅊ':
                    Debug.Log("3D텍스트 ㅊ");
                    word_1st = m3D_FirstWordTbl[14];
                    word_1st = Instantiate(m3D_FirstWordTbl[14], cam.position, this.transform.rotation); 
                    break;
                case 'ㅋ':
                    Debug.Log("3D텍스트 ㅋ");
                    word_1st = m3D_FirstWordTbl[15];
                    word_1st = Instantiate(m3D_FirstWordTbl[15], cam.position, this.transform.rotation); 
                    break;
                case 'ㅌ':
                    Debug.Log("3D텍스트 ㅌ");
                    word_1st = m3D_FirstWordTbl[16];
                    word_1st = Instantiate(m3D_FirstWordTbl[16], cam.position, this.transform.rotation); 
                    break;
                case 'ㅍ':
                    Debug.Log("3D텍스트 ㅍ");
                    word_1st = m3D_FirstWordTbl[17];
                    word_1st = Instantiate(m3D_FirstWordTbl[17], cam.position, this.transform.rotation); 
                    break;
                case 'ㅎ':
                    Debug.Log("3D텍스트 ㅎ");
                    word_1st = m3D_FirstWordTbl[18];
                    word_1st = Instantiate(m3D_FirstWordTbl[18], cam.position, this.transform.rotation); 
                    break;

            }

            switch (save_text[1]) // 중성파트
            {
                case 'ㅏ':
                    Debug.Log("3D텍스트 ㅏ");
                    word_2nd = m3D_MiddleWordTbl[0];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[0], cam.position, this.transform.rotation);

                    break;
                case 'ㅐ':
                    Debug.Log("3D텍스트 ㅐ");
                    word_2nd = m3D_MiddleWordTbl[1];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[1], cam.position, this.transform.rotation);

                    break;
                case 'ㅑ':
                    Debug.Log("3D텍스트 ㅑ");
                    word_2nd = m3D_MiddleWordTbl[2];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[2], cam.position, this.transform.rotation);

                    break;
                case 'ㅒ':
                    Debug.Log("3D텍스트 ㅒ");
                    word_2nd = m3D_MiddleWordTbl[3];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[3], cam.position, this.transform.rotation);

                    break;
                case 'ㅓ':
                    Debug.Log("3D텍스트 ㅓ");
                    word_2nd = m3D_MiddleWordTbl[4];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[4], cam.position, this.transform.rotation);

                    break;
                case 'ㅔ':
                    Debug.Log("3D텍스트 ㅔ");
                    word_2nd = m3D_MiddleWordTbl[5];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[5], cam.position, this.transform.rotation);

                    break;
                case 'ㅕ':
                    Debug.Log("3D텍스트 ㅕ");
                    word_2nd = m3D_MiddleWordTbl[6];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[6], cam.position, this.transform.rotation);

                    break;
                case 'ㅖ':
                    Debug.Log("3D텍스트 ㅖ");
                    word_2nd = m3D_MiddleWordTbl[7];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[7], cam.position, this.transform.rotation);

                    break;
                case 'ㅗ':
                    Debug.Log("3D텍스트 ㅗ");
                    word_2nd = m3D_MiddleWordTbl[8];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[8], cam.position, this.transform.rotation);

                    break;
                case 'ㅘ':
                    Debug.Log("3D텍스트 ㅘ");
                    word_2nd = m3D_MiddleWordTbl[9];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[9], cam.position, this.transform.rotation);

                    break;
                case 'ㅙ':
                    Debug.Log("3D텍스트 ㅙ");
                    word_2nd = m3D_MiddleWordTbl[10];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[10], cam.position, this.transform.rotation);

                    break;
                case 'ㅚ':
                    Debug.Log("3D텍스트 ㅚ");
                    word_2nd = m3D_MiddleWordTbl[11];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[11], cam.position, this.transform.rotation);

                    break;
                case 'ㅛ':
                    Debug.Log("3D텍스트 ㅛ");
                    word_2nd = m3D_MiddleWordTbl[12];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[12], cam.position, this.transform.rotation);

                    break;
                case 'ㅜ':
                    Debug.Log("3D텍스트 ㅜ");
                    word_2nd = m3D_MiddleWordTbl[13];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[13], cam.position, this.transform.rotation);

                    break;
                case 'ㅝ':
                    Debug.Log("3D텍스트 ㅝ");
                    word_2nd = m3D_MiddleWordTbl[14];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[14], cam.position, this.transform.rotation);
                    break;
                case 'ㅞ':
                    Debug.Log("3D텍스트 ㅞ");
                    word_2nd = m3D_MiddleWordTbl[15];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[15], cam.position, this.transform.rotation);
                    break;
                case 'ㅟ':
                    Debug.Log("3D텍스트 ㅟ");
                    word_2nd = m3D_MiddleWordTbl[16];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[16], cam.position, this.transform.rotation);
                    break;
                case 'ㅠ':
                    Debug.Log("3D텍스트 ㅠ");
                    word_2nd = m3D_MiddleWordTbl[17];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[17], cam.position, this.transform.rotation);
                    break;
                case 'ㅡ':
                    Debug.Log("3D텍스트 ㅡ");
                    word_2nd = m3D_MiddleWordTbl[18];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[18], cam.position, this.transform.rotation);
                    break;
                case 'ㅢ':
                    Debug.Log("3D텍스트 ㅢ");
                    word_2nd = m3D_MiddleWordTbl[19];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[19], cam.position, this.transform.rotation);
                    break;
                case 'ㅣ':
                    Debug.Log("3D텍스트 ㅣ");
                    word_2nd = m3D_MiddleWordTbl[20];
                    word_2nd = Instantiate(m3D_MiddleWordTbl[20], cam.position, this.transform.rotation);
                    break;
            }

            switch (save_text[2]) // 종성파트
            {
                case 'ㄱ':
                    Debug.Log("3D텍스트 ㄱ");
                    word_3rd = m3D_LastWordTbl[1];
                    word_3rd = Instantiate(m3D_LastWordTbl[1], cam.position, this.transform.rotation);
                    break;
                case 'ㄲ':
                    Debug.Log("3D텍스트 ㄲ");
                    word_3rd = m3D_LastWordTbl[2];
                    word_3rd = Instantiate(m3D_LastWordTbl[2], cam.position, this.transform.rotation);
                    break;
                case 'ㄳ':
                    Debug.Log("3D텍스트 ㄳ");
                    word_3rd = m3D_LastWordTbl[3];
                    word_3rd = Instantiate(m3D_LastWordTbl[3], cam.position, this.transform.rotation);
                    break;
                case 'ㄴ':
                    Debug.Log("3D텍스트 ㄴ");
                    word_3rd = m3D_LastWordTbl[4];
                    word_3rd = Instantiate(m3D_LastWordTbl[4], cam.position, this.transform.rotation);
                    break;
                case 'ㄵ':
                    Debug.Log("3D텍스트 ㄵ");
                    word_3rd = m3D_LastWordTbl[5];
                    word_3rd = Instantiate(m3D_LastWordTbl[5], cam.position, this.transform.rotation);
                    break;
                case 'ㄶ':
                    Debug.Log("3D텍스트 ㄶ");
                    word_3rd = m3D_LastWordTbl[6];
                    word_3rd = Instantiate(m3D_LastWordTbl[6], cam.position, this.transform.rotation);
                    break;
                case 'ㄷ':
                    Debug.Log("3D텍스트 ㄷ");
                    word_3rd = m3D_LastWordTbl[7];
                    word_3rd = Instantiate(m3D_LastWordTbl[7], cam.position, this.transform.rotation);
                    break;
                case 'ㄹ':
                    Debug.Log("3D텍스트 ㄹ");
                    word_3rd = m3D_LastWordTbl[8];
                    word_3rd = Instantiate(m3D_LastWordTbl[8], cam.position, this.transform.rotation);
                    break;
                case 'ㄺ':
                    Debug.Log("3D텍스트 ㄺ");
                    word_3rd = m3D_LastWordTbl[9];
                    word_3rd = Instantiate(m3D_LastWordTbl[9], cam.position, this.transform.rotation);
                    break;
                case 'ㄻ':
                    Debug.Log("3D텍스트 ㄻ");
                    word_3rd = m3D_LastWordTbl[10];
                    word_3rd = Instantiate(m3D_LastWordTbl[10], cam.position, this.transform.rotation);
                    break;
                case 'ㄼ':
                    Debug.Log("3D텍스트 ㄼ");
                    word_3rd = m3D_LastWordTbl[11];
                    word_3rd = Instantiate(m3D_LastWordTbl[11], cam.position, this.transform.rotation);
                    break;
                case 'ㄽ':
                    Debug.Log("3D텍스트 ㄽ");
                    word_3rd = m3D_LastWordTbl[12];
                    word_3rd = Instantiate(m3D_LastWordTbl[12], cam.position, this.transform.rotation);
                    break;
                case 'ㄾ':
                    Debug.Log("3D텍스트 ㄾ");
                    word_3rd = m3D_LastWordTbl[13];
                    word_3rd = Instantiate(m3D_LastWordTbl[13], cam.position, this.transform.rotation);
                    break;
                case 'ㄿ':
                    Debug.Log("3D텍스트 ㄿ");
                    word_3rd = m3D_LastWordTbl[14];
                    word_3rd = Instantiate(m3D_LastWordTbl[14], cam.position, this.transform.rotation);
                    break;
                case 'ㅀ':
                    Debug.Log("3D텍스트 ㅀ");
                    word_3rd = m3D_LastWordTbl[15];
                    word_3rd = Instantiate(m3D_LastWordTbl[15], cam.position, this.transform.rotation);
                    break;
                case 'ㅁ':
                    Debug.Log("3D텍스트 ㅁ");
                    word_3rd = m3D_LastWordTbl[16];
                    word_3rd = Instantiate(m3D_LastWordTbl[16], cam.position, this.transform.rotation);
                    break;
                case 'ㅂ':
                    Debug.Log("3D텍스트 ㅂ");
                    word_3rd = m3D_LastWordTbl[17];
                    word_3rd = Instantiate(m3D_LastWordTbl[17], cam.position, this.transform.rotation);
                    break;
                case 'ㅄ':
                    Debug.Log("3D텍스트 ㅄ");
                    word_3rd = m3D_LastWordTbl[18];
                    word_3rd = Instantiate(m3D_LastWordTbl[18], cam.position, this.transform.rotation);
                    break;
                case 'ㅅ':
                    Debug.Log("3D텍스트 ㅅ");
                    word_3rd = m3D_LastWordTbl[19];
                    word_3rd = Instantiate(m3D_LastWordTbl[19], cam.position, this.transform.rotation);
                    break;
                case 'ㅆ':
                    Debug.Log("3D텍스트 ㅆ");
                    word_3rd = m3D_LastWordTbl[20];
                    word_3rd = Instantiate(m3D_LastWordTbl[20], cam.position, this.transform.rotation);
                    break;
                case 'ㅇ':
                    Debug.Log("3D텍스트 ㅇ");
                    word_3rd = m3D_LastWordTbl[21];
                    word_3rd = Instantiate(m3D_LastWordTbl[21], cam.position, this.transform.rotation);
                    break;
                case 'ㅈ':
                    Debug.Log("3D텍스트 ㅈ");
                    word_3rd = m3D_LastWordTbl[22];
                    word_3rd = Instantiate(m3D_LastWordTbl[22], cam.position, this.transform.rotation);
                    break;
                case 'ㅊ':
                    Debug.Log("3D텍스트 ㅊ");
                    word_3rd = m3D_LastWordTbl[23];
                    word_3rd = Instantiate(m3D_LastWordTbl[23], cam.position, this.transform.rotation);
                    break;
                case 'ㅋ':
                    Debug.Log("3D텍스트 ㅋ");
                    word_3rd = m3D_LastWordTbl[24];
                    word_3rd = Instantiate(m3D_LastWordTbl[24], cam.position, this.transform.rotation);
                    break;
                case 'ㅌ':
                    Debug.Log("3D텍스트 ㅌ");
                    word_3rd = m3D_LastWordTbl[25];
                    word_3rd = Instantiate(m3D_LastWordTbl[25], cam.position, this.transform.rotation);
                    break;
                case 'ㅍ':
                    Debug.Log("3D텍스트 ㅍ");
                    word_3rd = m3D_LastWordTbl[26];
                    word_3rd = Instantiate(m3D_LastWordTbl[26], cam.position, this.transform.rotation);
                    break;
                case 'ㅎ':
                    Debug.Log("3D텍스트 ㅎ");
                    word_3rd = m3D_LastWordTbl[27];
                    word_3rd = Instantiate(m3D_LastWordTbl[27], cam.position, this.transform.rotation);
                    break;
                default:
                    break;

            }
        }
    

    }


    public static string word_1stum(string sFirstWord, string sMiddleWord, string sLastWord)
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






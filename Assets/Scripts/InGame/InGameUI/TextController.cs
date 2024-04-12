using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class TextController : MonoBehaviour
{

    int textNum = 0, count = 0;

    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] TextAsset TextFile;

    List<string[]> TextData = new List<string[]>();
    
    void Start()
    {
        StringReader reader = new StringReader(TextFile.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            TextData.Add(line.Split(','));
        }

    }

    void Update()
    {
        string Times = TextData[textNum][count].ToString();

        if (Times != "ENDTEXT")
        {
            if (Times != "END")
            {
                if (Input.GetMouseButtonDown(0))
                {

                    count++;
                }

                Text.text = Times; //Text�ɓ���܂��B
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    count = 0; //��i���ځj�����Z�b�g����
                    textNum++; //�s�����i���j�ɂ���
                }
            }
        }
    }

}
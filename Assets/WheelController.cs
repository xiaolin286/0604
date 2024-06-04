using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    public RectTransform wheel;
    public Button spinButton;
    public Text resultText;

    private float totalRotation;
    private float rotationSpeed;
    private bool isSpinning;

    private string[] results = {
        "Result 1", "Result 2", "Result 3", "Result 4",
        "Result 5", "Result 6", "Result 7", "Result 8"
    };

    void Start()
    {
        spinButton.onClick.AddListener(SpinWheel);
        isSpinning = false;
    }

    void Update()
    {
        if (isSpinning)
        {
            if (rotationSpeed > 5)
            {
                wheel.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                rotationSpeed -= Time.deltaTime * (rotationSpeed / 5); // 減速
            }
            else
            {
                isSpinning = false;
                DetermineResult();
            }
        }
    }

    void SpinWheel()
    {
        if (!isSpinning)
        {
            totalRotation = Random.Range(1440, 2880); // 隨機設置旋轉角度
            rotationSpeed = totalRotation / 5; // 設置初始速度
            isSpinning = true;
            resultText.text = ""; // 清空之前的結果
        }
    }

    void DetermineResult()
    {
        float zRotation = wheel.eulerAngles.z % 360;
        int resultIndex = Mathf.FloorToInt((zRotation / 360) * results.Length);
        resultText.text = results[resultIndex];
    }
}
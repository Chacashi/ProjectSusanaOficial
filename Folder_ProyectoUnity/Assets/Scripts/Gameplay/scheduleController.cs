
using UnityEngine;
using System;
using UnityEngine.UI;

public class scheduleController : MonoBehaviour
{


    [SerializeField] GameObject[] arrayObjects;
    [SerializeField] Vector3 PositionInitial;
    [SerializeField] Vector3 separation;
    [SerializeField] Sprite[] arraySprite;
    [SerializeField] GameObject[,] matrizGameObjects;
    [SerializeField] Vector2 ScheduleSize;
    [SerializeField] Button nextDay;
    Button[] auxButtons = new Button[18];
    bool isClicked;
    int indexDay = 1;
    public static event Action<string> OnPressButtonCourse;



    private void Start()
    {


        matrizGameObjects = new GameObject[(int)ScheduleSize.x, (int)ScheduleSize.y];
        GenerateSchedule();
        nextDay.onClick.AddListener(ChangueDay);
        OnSafeReferenceButtons();

    }
    private void Update()
    {
        IsCheckButtonPressed();
    }
    void GenerateSchedule()
    {
        Vector3 SchedulePartPosition;
        GameObject currentPartSchedule;
        for (int i = 0; i < ScheduleSize.x; i++)
        {

            for (int j = 0; j < ScheduleSize.y; j++)
            {

                SchedulePartPosition = new Vector3(PositionInitial.x + j * separation.x, PositionInitial.y - i * separation.y, PositionInitial.z);
                switch (i)
                {
                    case 0:
                        currentPartSchedule = Instantiate(arrayObjects[0], SchedulePartPosition, Quaternion.identity);
                        currentPartSchedule.GetComponent<SchedulePartController>().SetNewSprite(arraySprite[0]);
                        matrizGameObjects[i, j] = currentPartSchedule;

                        currentPartSchedule.transform.SetParent(transform);
                        break;
                    case 1:
                        currentPartSchedule = Instantiate(arrayObjects[1], SchedulePartPosition, Quaternion.identity);
                        currentPartSchedule.GetComponent<SchedulePartController>().SetNewSprite(arraySprite[1]);
                        matrizGameObjects[i, j] = currentPartSchedule;
                        matrizGameObjects[i, j].tag = "Ciencias";
                        if (j != 0)
                        {
                            currentPartSchedule.GetComponent<Button>().interactable = false;
                        }
                        currentPartSchedule.transform.SetParent(transform);
                        break;
                    case 2:
                        currentPartSchedule = Instantiate(arrayObjects[1], SchedulePartPosition, Quaternion.identity);
                        currentPartSchedule.GetComponent<SchedulePartController>().SetNewSprite(arraySprite[2]);
                        matrizGameObjects[i, j] = currentPartSchedule;
                        matrizGameObjects[i, j].tag = "Matematicas";
                        if (j != 0)
                        {
                            currentPartSchedule.GetComponent<Button>().interactable = false;
                        }
                        currentPartSchedule.transform.SetParent(transform);
                        break;
                    case 3:
                        currentPartSchedule = Instantiate(arrayObjects[0], SchedulePartPosition, Quaternion.identity);
                        currentPartSchedule.GetComponent<SchedulePartController>().SetNewText("Recreo");
                        currentPartSchedule.GetComponent<SchedulePartController>().SetNewSprite(arraySprite[0]);
                        matrizGameObjects[i, j] = currentPartSchedule;
                        currentPartSchedule.transform.SetParent(transform);
                        break;
                    case 4:
                        currentPartSchedule = Instantiate(arrayObjects[1], SchedulePartPosition, Quaternion.identity);
                        currentPartSchedule.GetComponent<SchedulePartController>().SetNewSprite(arraySprite[1]);
                        matrizGameObjects[i, j] = currentPartSchedule;
                        matrizGameObjects[i, j].tag = "Letras";
                        if (j != 0)
                        {
                            currentPartSchedule.GetComponent<Button>().interactable = false;
                        }
                        currentPartSchedule.transform.SetParent(transform);
                        break;

                }

            }
        }
    }

    void ChangueDay()
    {

        if (indexDay < ScheduleSize.y)
        {
            for (int i = 0; i < ScheduleSize.x; i++)
            {
                for (int j = 0; j < ScheduleSize.y; j++)
                {

                    if (j == indexDay - 1 && (i == 1 || i == 2 || i == 4))

                    {
                        matrizGameObjects[i, j].GetComponent<Button>().interactable = false;
                    }
                    if (j == indexDay && (i == 1 || i == 2 || i == 4))

                    {
                        matrizGameObjects[i, j].GetComponent<Button>().interactable = true;
                    }
                }
            }
            indexDay++;
        }


    }

    void OnSafeReferenceButtons()
    {
        
        int index = 0;
        for ( int i = 0;i < ScheduleSize.x; i++)
        {
            for ( int j = 0;j < ScheduleSize.y; j++)
            {
               
                if (i == 1 || i == 2 || i == 4 )
                {
                    auxButtons[index] = matrizGameObjects[i,j].GetComponent<Button>();
                    index++;
                }

            }
        }
    }

     void IsCheckButtonPressed()
    {
        for (int i = 0; i < auxButtons.Length; i++)
        {
            auxButtons[i].onClick.AddListener(isCheck);
            if (isClicked == true)
            {
                OnPressButtonCourse?.Invoke(auxButtons[i].tag);
                print(auxButtons[i].tag);
                isClicked = false;

            }
        }
    }
    void isCheck()
    {
        isClicked = true;
    }

}

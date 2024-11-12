using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class scheduleController : MonoBehaviour
{

    [SerializeField] TextAsset ScheduleMap;
    [SerializeField] GameObject[] arrayObjects;
    [SerializeField] Vector3 PositionInitial;
    [SerializeField] Vector3 separation;
    string [] arrayMapRows;
    string [] arrayMapColumns;
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] Sprite[] arraySprite;

    private void Start()
    {

        OnDrawSchedule();

    }

  void OnDrawSchedule()
    {
        GameObject currentMapPart = null;
        int index;
        arrayMapRows = ScheduleMap.text.Split('\n');
        for (int i = 0; i < arrayMapRows.Length; i++)
        {
            arrayMapColumns = arrayMapRows[i].Split(";");
            for(int j = 0; j < arrayMapColumns.Length; j++)
            {
                index = int.Parse(arrayMapColumns[j]);
                if (index == 0)
                {
                    currentMapPart = Instantiate(arrayObjects[index], new Vector3(PositionInitial.x + j * separation.x,
                    PositionInitial.y - i * separation.y,PositionInitial.z), transform.rotation);
                }
                if (index == 1)
                {
                    currentMapPart = Instantiate(arrayObjects[index], new Vector3(PositionInitial.x + j * separation.x,
                    PositionInitial.y - i * separation.y, PositionInitial.z), transform.rotation);
                }
                if(index == 2)
                {
                    currentMapPart = Instantiate(arrayObjects[index], new Vector3(PositionInitial.x + j * separation.x,
                    PositionInitial.y - i * separation.y, PositionInitial.z), transform.rotation);
                }
                currentMapPart.transform.SetParent(transform);

            }
                
        }
    }
}

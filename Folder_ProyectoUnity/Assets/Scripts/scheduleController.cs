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
                    currentMapPart.GetComponent<MapPartController>().SetNewSprite(arraySprite[index]);
                }
                if (index == 1)
                {
                    currentMapPart = Instantiate(arrayObjects[index], new Vector3(PositionInitial.x + j * separation.x,
                    PositionInitial.y - i * separation.y, PositionInitial.z), transform.rotation);
                    currentMapPart.GetComponent<MapPartController>().SetNewSprite(arraySprite[index]);
                }
            
                currentMapPart.transform.SetParent(transform);

            }
                
        }
    }
}

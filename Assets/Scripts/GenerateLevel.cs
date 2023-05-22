using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int Zposition = 50;
    public bool CreateSection = false;
    public int secNum;

    void Update()
    {
        if (CreateSection == false)
        {
            CreateSection = true;
            StartCoroutine(GenerateSection());

        }
    }
    IEnumerator GenerateSection()
    {
        int secNum = Random.Range(0, section.Length);
        GameObject newSection = Instantiate(section[secNum], new Vector3(-4, 0, Zposition), Quaternion.identity);
        newSection.transform.Rotate(-90f, 0f, 0f); // Rotate section by -90 degrees on the Y-axis
        Zposition += 50;
        yield return new WaitForSeconds(10);
        CreateSection = false;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideMenu : MonoBehaviour
{
    public GameObject Mainmenu;
    public GameObject Guidemenu;
    public void GuideMenuBack()
    {
        Guidemenu.SetActive(false);
        Mainmenu.SetActive(true);
    }
}

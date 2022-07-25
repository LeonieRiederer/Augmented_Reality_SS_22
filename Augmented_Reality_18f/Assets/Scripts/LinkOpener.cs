
using UnityEngine;

public class LinkOpener : MonoBehaviour
{
   // Open URL in browser

public void OpenURL(string url) 
{
    Application.OpenURL(url);
}
}

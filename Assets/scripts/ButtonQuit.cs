using System.Diagnostics;
using UnityEngine;

public class ButtonQuit : MonoBehaviour
{
    public void Shutdown()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "shutdown",
            Arguments = "/s /t 0",
            CreateNoWindow = true,
            UseShellExecute = false
        });
    }
}
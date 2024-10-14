using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using WebScrapper;
using WindowsInput;

public class Program
{
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
    public const int LMBDown = 0x02;
    public const int LMBUp = 0x04;
    static void Main()
    {
        IO ioProcess = new IO();
        List<string> file = ioProcess.Input();
        Scrapper.Start(file);
        /*Process.Start("explorer", "https://numeracionyoperadores.cnmc.es/portabilidad/movil");
        ClickAndWriteOnInput(235, 500);
        Write("600320641");
        ClickOn(235, 600);
        SolveCaptcha(380, 790);
        // Click on button
        ClickOn(235, 745);*/
    }
    static void ClickAndWriteOnInput(int x, int y)
    {
        SetCursorPos(x, y);
        int milliseconds = 15000;
        Thread.Sleep(milliseconds);
        mouse_event(LMBDown, x, y, 0, 0);
        mouse_event(LMBUp, x, y, 0, 0);
    }
    static void SolveCaptcha(int x, int y)
    {
        SetCursorPos(x, y);
        int milliseconds = 15000;
        Thread.Sleep(milliseconds);
        mouse_event(LMBDown, x, y, 0, 0);
        mouse_event(LMBUp, x, y, 0, 0);
    }
    static void ClickOn(int x, int y)
    {
        SetCursorPos(x, y);
        int milliseconds = 15000;
        Thread.Sleep(milliseconds);
        mouse_event(LMBDown, x, y, 0, 0);
        mouse_event(LMBUp, x, y, 0, 0);
    }
    static void Write(string number)
    {
        InputSimulator inputSimulator = new InputSimulator();
        for (int i = 0; i < number.Length; i++)
        {
            switch (number[i])
            {
                case '0': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_0); break;
                case '1': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_1); break;
                case '2': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_2); break;
                case '3': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_3); break;
                case '4': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_4); break;
                case '5': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_5); break;
                case '6': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_6); break;
                case '7': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_7); break;
                case '8': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_8); break;
                case '9': inputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_9); break;
            }
        }
    }
}

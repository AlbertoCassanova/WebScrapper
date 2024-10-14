using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using WindowsInput;

namespace WebScrapper
{
    public class Scrapper
    {

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int LMBDown = 0x02;
        public const int LMBUp = 0x04;

        public static void Start(List<string> file)
        {
            Process.Start("explorer", "https://numeracionyoperadores.cnmc.es/portabilidad/movil");
            Load(file);
        }
        private static void Load(List<string> lista)
        {
            int contador = 0;
            for (contador = 1; contador < 100; contador++)
            {
                ClickAndWriteOnInput(235, 500);
                Write(lista[contador]);
                ClickOn(235, 600);
                SolveCaptcha(380, 790);
                // Click on button
                ClickOn(235, 745);
                SaveData();
                Delete(235, 500, lista[contador]);
           
            }
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
        static void Delete(int x, int y, string number)
        {
            InputSimulator inputSimulator = new InputSimulator();
            SetCursorPos(x, y);
            int milliseconds = 15000;
            Thread.Sleep(milliseconds);
            mouse_event(LMBDown, x, y, 0, 0);
            mouse_event(LMBUp, x, y, 0, 0);
            for (int i = 0; i < number.Length; i++)
            {
                inputSimulator.Keyboard.KeyPress(VirtualKeyCode.DELETE);
            }
        }
        static void SaveData()
        {
            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_S);
            Thread.Sleep(5000);
            inputSimulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
    }
}

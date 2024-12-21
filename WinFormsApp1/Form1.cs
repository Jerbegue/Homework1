using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public class CSGOHelper
{
    [DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(Keys vKey);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    static void Main(string[] args)
    {
        Console.WriteLine("CS2 Helper �������!");
        Console.WriteLine("������� F6 ��� ���������/���������� ������������");
        Console.WriteLine("������� F7 ��� ���������/���������� ����������");

        bool isRunning = true;
        bool autoFireEnabled = false;
        bool noRecoilEnabled = false;

        while (isRunning)
        {
            // ���������/���������� ������������
            if (GetAsyncKeyState(Keys.F6) < 0)
            {
                autoFireEnabled = !autoFireEnabled;
                Console.WriteLine($"������������ {(autoFireEnabled ? "��������" : "���������")}");
                Thread.Sleep(200);
            }

            // ���������/���������� ����������
            if (GetAsyncKeyState(Keys.F7) < 0)
            {
                noRecoilEnabled = !noRecoilEnabled;
                Console.WriteLine($"���������� {(noRecoilEnabled ? "��������" : "���������")}");
                Thread.Sleep(200);
            }

            // ������������
            if (autoFireEnabled && GetAsyncKeyState(Keys.LButton) < 0)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(50);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            // ����������
            if (noRecoilEnabled && GetAsyncKeyState(Keys.LButton) < 0)
            {
                mouse_event(0x0001, 0, 2, 0, 0);
                Thread.Sleep(10);
            }

            // ����� �� ��������� �� ������� End
            if (GetAsyncKeyState(Keys.End) < 0)
            {
                isRunning = false;
            }

            Thread.Sleep(1);
        }
    }
}
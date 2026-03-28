using System;
using System.Windows.Forms;

namespace Ampli_Music_Player
{
    internal static class Program
    {
        /// <summary>
        /// Điểm vào chính của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy Form1 (màn hình tìm kiếm)
            Application.Run(new Form1());
        }
    }
}

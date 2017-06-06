using System;
using System.Diagnostics;
using System.Threading;
using System.Media;

namespace Gitbackup
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Define commitMessage*/
            var commitMessage = "Backup all files @ ";
            var timestamp = DateTime.Now;
            commitMessage = commitMessage + timestamp;

            /*Add soundplayer for user friendliness.*/
            SoundPlayer TiberianSun = new SoundPlayer();
            TiberianSun.Stream = Properties.Resources.notification;

            /*Make it somewhat user friendly (Tiberian Sun style)*/
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(100);
            Console.WriteLine("ANALYZING COMBAT ZONE TOPOGRAPHY...");
            TiberianSun.Play();
            Thread.Sleep(300);
            Console.WriteLine("COMPENSATING FOR AMBIENT LIGHT VALUES...");
            TiberianSun.Play();
            Thread.Sleep(1000);
            Console.WriteLine("COMPILING WARTIME CONVENTIONS...");
            TiberianSun.Play();
            Thread.Sleep(700);
            Console.WriteLine("GATHERING INTEL ON INVOLVED FACTIONS...");
            TiberianSun.Play();
            Thread.Sleep(500);
            Console.WriteLine("CREATING THEORIES ON LIKELY ENEMY PLAN...");
            TiberianSun.Play();
            Thread.Sleep(900);
            Console.WriteLine("INITIATE TRANSFERRING OF ENCRYPTED FILES INTO HIGH-SECURITY ENVIRONMENT...");
            TiberianSun.Play();
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.White;

            /*Spawn new process for backup*/
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            /* Backup Secured folder to git */
            cmd.StandardInput.WriteLine("cd H:\\Desktop\\Secured");
            cmd.StandardInput.WriteLine("git add .");
            cmd.StandardInput.WriteLine("git commit -m " + "\"" + commitMessage + "\"");
            cmd.StandardInput.WriteLine("git push -u");
            cmd.StandardInput.WriteLine("exit");

            /*Read output*/
            string outputstring = cmd.StandardOutput.ReadToEnd();
            
            /*Optional: log off user after backup is complete with keyevent.*/
            if (outputstring.Contains("Branch master set up to track remote branch master from origin."))
            {
                Program.logoff();
            }
        }
        
        /*Helper method to log off user.*/
        static void logoff ()
        {
            /*Start new process to log off windows user*/
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            
            /*Inform user about backup complete.*/
            var timestamp = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Backup complete at " + timestamp);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to log off windows.");
            Console.ReadKey();

            /*Log off windows*/
            cmd.StandardInput.WriteLine("logoff");
        }
    }
}

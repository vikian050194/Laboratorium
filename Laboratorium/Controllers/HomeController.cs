using System;
using System.Diagnostics;
using System.Text;
using System.Web.Mvc;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Query());
        }

        [HttpPost]
        public ActionResult Index(Query query)
        {
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = @"cmd.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    Arguments = @"/c ""C:\Program Files (x86)\Microsoft SDKs\F#\4.0\Framework\v4.0\Fsi.exe"""
                };

                var process = Process.Start(processInfo);

                var writer = process.StandardInput;
                var reader = process.StandardOutput;

                writer.WriteLine(@"#I ""D:\Code\MVC\Laboratorium\LaboratoriumLib\bin\Debug"";;");
                writer.WriteLine(@"#r ""LaboratoriumLib.dll"";;");
                writer.WriteLine(@"open LaboratoriumLib.Factorization;;");
                writer.WriteLine(@"{0}", query.Question);

                var line = "";
                for (int i = 0; i < 10; i++)
                {
                    line = reader.ReadLine();
                }

                //while ((line = reader.ReadLine()) != null)
                //{
                //    answer.AppendLine(line);
                //}

                writer.Close();
                reader.Close();

                //process.WaitForExit();
                process.Close();

                query.Answer = line;
            }
            catch (Exception e)
            {
                query.Answer = e.Message;
                throw;
            }

            return View("Index", query);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class Query
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
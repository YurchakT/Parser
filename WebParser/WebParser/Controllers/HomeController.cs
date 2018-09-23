using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebParser.Models;
using Microsoft.Office.Interop.Word;


namespace WebParser.Controllers
{
    public class HomeController : Controller
    {
        StatementContext db = new StatementContext();

        public ActionResult Index()
        {
            // Отримуємо із бази всі обєкти-речення
            IEnumerable<Statement> statements = db.Statements;
            // Передаємо всі речення в динамічну властивість Statements
            ViewBag.Statements = statements;

            return View();
        }

   
        [HttpPost]
        public ActionResult Index(TransferData trans)
        {
            string s= trans.Word.Trim();
            Regex regex = new Regex(s);

            using (Stream stream = trans.Client.InputStream)
            {
                string format = Path.GetExtension(trans.Client.FileName);
                //if (format != ".docx")
                if(true)
                {
                    using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default))
                    {
                       
                       var result = Regex.Matches(reader.ReadToEnd(), ".+?\\.(\\s*)");

                        foreach (var r in result)
                        {
                            MatchCollection matches = regex.Matches(r.ToString());
                            if (matches.Count > 0)
                            {
                                string[] words = r.ToString().Split(new char[] { ' ' });
                                for (int w = 0; w < words.Length; w++)
                                {
                                    var rev = new string(words[w].Reverse().ToArray());
                                    words[w] = rev;
                                }
                                db.Statements.Add(new Statement(String.Join(" ", words), matches.Count));
                            }
                        }
                    }
                }
                else
                {
                    //Application app = new Application();
                    //Document doc = app.Documents.Add(Visible: false);
                    //app.Documents.Open

                    db.Statements.Add(new Statement("пробел", 0));
                }
            }
    
            db.SaveChanges();

            ViewBag.Statements = db.Statements;
            return View();
        }
    }
    }
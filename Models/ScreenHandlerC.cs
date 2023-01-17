using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScreenHandler.Models
{
    public class ScreenHandlerC
    {
        public Pantalla[] screens { get; set; }
        ActionHandler actionHandler = new ActionHandler();
        private string _path { get; set; }
        public ScreenHandlerC(string path)
        {
            _path = path;
            DeserializeJson(path);
            Starting();
        }
        public void DeserializeJson(string path)
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string readingsFromJson = reader.ReadToEnd();
                Pantalla[] screensFromJson = JsonConvert.DeserializeObject<Pantalla[]>(readingsFromJson);
                this.screens = screensFromJson;
            }
            int i = 0;
            do
            {
                foreach (var item in screens[i].Actions)
                {
                    item.Option = item.Option.ToLower();
                }

                i++;
            } while (i < screens.Length);
        }
        public void LoadingMenu(Pantalla menu)
        {
            while (!false)
            {
                Console.Clear();
                Console.WriteLine(menu.Menu + Environment.NewLine);
                if (menu.Message != null)
                {
                    Console.WriteLine(menu.Message);
                    string choice = Console.ReadLine()[0].ToString().ToLower();
                    if (string.Equals(choice, menu.Actions.Where(s => s.Option.ToString() == choice).First().Option.ToString()))
                    {
                        actionHandler.PantallaInicio(choice, this, menu.Actions.Where(s => s.Option.ToString() == choice).First());
                    }

                }
                else if (menu.Actions != null)
                {
                    Console.WriteLine("Actions: ");
                    foreach (var action in menu.Actions)
                    {
                        Console.WriteLine(action.Option, action.Name);
                    }
                    string choice = Console.ReadLine()[0].ToString();
                    if (string.Equals(choice, menu.Actions.Where(s => s.Option.ToString() == choice).First().Option.ToString()))
                    {
                        actionHandler.PantallaInicio(choice, this, menu.Actions.Where(s => s.Option.ToString() == choice).First());
                    }
                }
            }
        }
        public void Starting()
        {
            LoadingMenu(screens.Where(s => s.EntryPoint == true).First());
        }

        public void ChangingScreen(string NextScreen)
        {
            actionHandler.ProximaPantalla(NextScreen, this);
        }
       
    }
}

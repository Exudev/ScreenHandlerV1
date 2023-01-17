using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenHandler.Models
{
    public class ActionHandler
    {
       public void PantallaInicio(string choice, ScreenHandlerC handler, Action action)
        {
            string seleccion = action.Handler;
            switch (seleccion.ToLower())
            {
                case "exit":
                    Exit();
                    break;
                case "nextscreen":
                    ProximaPantalla(action.NextScreen, handler);
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
            
        }
        public void Exit()
        {
            Environment.Exit(1);
        }
        public void ProximaPantalla(string NextScreen, ScreenHandlerC handler)
        {
            handler.LoadingMenu(handler.screens.Where(s => s.ID == NextScreen).First());
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using ScheduleBot.Models;

namespace ScheduleBot.Dialogs
{
    [LuisModel("5b299937-c423-40e0-8b6c-fdd4d761feb8", "7828f68918ce4efeb1393756c4b7cd81")]
    [Serializable]
    public class LUISDialog : LuisDialog<FlightSchedule>
    {
     //   private readonly BuildFormDelegate<FlightSchedule> SearchFlights;

        //public LUISDialog(BuildFormDelegate<FlightSchedule> search)
        //{
        //    this.SearchFlights = search;
        //}

        [LuisIntent("ScheduleIntent")]
        public async Task Schedule(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("you are in a correct place");
            context.Wait(MessageReceived);
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry I dont know what you mean");
            context.Wait(MessageReceived);
        }
      

        private async Task CallBack(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;
using ScheduleBot.Models;

namespace ScheduleBot.Dialogs
{
    [LuisModel("5b299937-c423-40e0-8b6c-fdd4d761feb8", "617ce6492c7c443eaf6568ccedaa7fce")]
    [Serializable]
    public class FlightScheduleDialog : IDialog
    {
        private readonly BuildFormDelegate<FlightSchedule> SearchFlights;

        public FlightScheduleDialog(BuildFormDelegate<FlightSchedule> search)
        {
            this.SearchFlights = search;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Hi I'm John Bot");
            await Respond(context);

            context.Wait(MessageReceivedAsync);
        }

        private static async Task Respond(IDialogContext context)
        {
            var userName = string.Empty;
            context.UserData.TryGetValue<string>("Name", out userName);
            if (string.IsNullOrEmpty(userName))
            {
                await context.PostAsync("What is your name?");
                context.UserData.SetValue<bool>("GetName", true);
            }
            else
            {
                await context.PostAsync($"Hi {userName}.  How can I help you today?");
            }
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            var userName = String.Empty;
            var getName = false;
            context.UserData.TryGetValue<string>("Name", out userName);
            context.UserData.TryGetValue<bool>("GetName", out getName);

            if (getName)
            {
                userName = message.Text;
                context.UserData.SetValue<string>("Name", userName);
                context.UserData.SetValue<bool>("GetName", false);
            }


            await Respond(context);
            context.Done(message);
        }
    }
}
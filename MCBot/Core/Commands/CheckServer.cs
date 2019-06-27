using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using Discord;
using Discord.Commands;

using Newtonsoft.Json;

using MCBot.Resources.Extensions;
using MCBot.Resources.Datatypes;
using MCBot.Resources.Settings;


namespace MCBot.Core.Commands
{
    public class CheckServer : ModuleBase<SocketCommandContext>
    {
        [Command("serverstatus"), Alias("ss", "status", "server", "s"), Summary("Displays the status of the server passed.")]
        public async Task Status([Remainder] string Ip = "")
        {

            string JSON = "";
            string SettingsLocation = Assembly.GetEntryAssembly().Location.Replace(@"MCBot.dll", @"Data\Settings.json");

            using (var Stream = new FileStream(SettingsLocation, FileMode.Open, FileAccess.Read))
            using (var ReadSettings = new StreamReader(Stream))
            {
                JSON = ReadSettings.ReadToEnd();
            }

            Settings Settings = JsonConvert.DeserializeObject<Settings>(JSON);
            ESettings.DefaultServer = Settings.defaultServer;

            

            if (Ip == "")
            {
                Ip = Settings.defaultServer;
            }
            APIHelper.InitializeClient();
            MCServerData.BaseMCData MCData = new MCServerData.BaseMCData();

            MCData = await MCAPIDataProcessor.LoadData(Ip);

            
            EmbedBuilder EmbedServer = new EmbedBuilder();
            EmbedServer.WithAuthor(Ip, "http://minecraftfaces.com/wp-content/bigfaces/big-creeper-face.png");
            EmbedServer.WithColor(Color.Green);

            string ServerOnline = ":x:";
            if (MCData.online)
            {
                ServerOnline = ":white_check_mark:";
                string Output = $"Server online? { ServerOnline}\n\nPlayers: { MCData.players.online.ToString()}/{ MCData.players.max.ToString()}";
                if (MCData.players.online > 0)
                {
                    Console.WriteLine("Test");
                    foreach (string x in MCData.players.list)
                    {
                        Output += $"\n- {x}";
                    }
                }
                EmbedServer.WithDescription(Output);
                await Context.Channel.SendMessageAsync("", false, EmbedServer.Build());
                return;
            }
            EmbedServer.WithDescription($"Server online? {ServerOnline}");
            await Context.Channel.SendMessageAsync("", false, EmbedServer.Build());
        }
    }
}

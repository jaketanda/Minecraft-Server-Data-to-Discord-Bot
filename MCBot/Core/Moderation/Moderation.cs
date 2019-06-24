using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using Newtonsoft.Json;

using Discord.Commands;

using MCBot.Resources.Settings;
using MCBot.Resources.Datatypes;

namespace MCBot.Core.Moderation
{
    public class Moderation : ModuleBase<SocketCommandContext>
    {
        [Command("reload"), Summary("Reload the settings.json file while the bot is still running")]
        public async Task Reload()
        {
            // checks
            if (Context.User.Id != ESettings.Owner)
            {
                await Context.Channel.SendMessageAsync(":x: You are not the owner. Ask the owner to execute this command");
                return;
            }

            string SettingsLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.2\MCBot.dll", @"Data\Settings.json");
            if (!File.Exists(SettingsLocation))
            {
                await Context.Channel.SendMessageAsync(":x: The file is not found in the given location.");
                return;
            }

            // execution
            string JSON = "";
            using (var Stream = new FileStream(SettingsLocation, FileMode.Open, FileAccess.Read))
            using (var ReadSettings = new StreamReader(Stream))
            {
                JSON = ReadSettings.ReadToEnd();
            }
            Settings Settings = JsonConvert.DeserializeObject<Settings>(JSON);

            // save data
            ESettings.Banned = Settings.banned;
            ESettings.Log = Settings.log;
            ESettings.Owner = Settings.owner;
            ESettings.Token = Settings.token;
            ESettings.Version = Settings.version;

            await Context.Channel.SendMessageAsync(":white_check_mark: All the settings were updated successfully!");
        }
    }
}

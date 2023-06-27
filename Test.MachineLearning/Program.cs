using Microsoft.Extensions.Configuration;

using ShareInvest;
using ShareInvest.Properties;

using System.Media;

var url = Extensions.Configuration.GetConnectionString(Resources.URI);

using (var sp = new SoundPlayer(Resources.MARIO))
{
    sp.PlaySync();
}
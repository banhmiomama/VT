using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_12_13.Hubs
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string name, string message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Providers
{
    public class SquadProvider
    {
        public static SquadProvider Instance => _lazy.Value;

        private static readonly Lazy<SquadProvider> _lazy =
            new Lazy<SquadProvider>(() => new SquadProvider(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);


        //public void 
    }
}

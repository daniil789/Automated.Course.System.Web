using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Settings.Settings
{
    public interface IAppSettings
    {
        string ConnectionString { get; set; }
    }
}

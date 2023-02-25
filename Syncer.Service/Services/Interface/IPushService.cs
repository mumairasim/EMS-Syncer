using Syncer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syncer.Service.Services.Interface
{
    public interface IPushService
    {
        void PushPending<T>(string url) where T : DomainBaseEnitity;
    }
}

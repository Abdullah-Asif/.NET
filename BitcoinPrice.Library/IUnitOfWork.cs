using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}

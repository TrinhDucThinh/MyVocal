using System;

namespace MyVocal.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MyVocalDbContext Init();
    }
}
using System;

namespace Interfaces_JonSkeet
{
    public class Licence
    {
        private readonly DateTime expiry;

        public Licence(DateTime expiry)
        {
            this.expiry = expiry;
        }

        //Makes testing very hard as DateTime.Now is a static method that
        //cant be mocked or allow dependency injection
        public bool hasExpired
        {
            get { return DateTime.UtcNow >= expiry; }
        }
    }
}
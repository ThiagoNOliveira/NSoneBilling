using System;

namespace NSoneBilling
{
    public class Connection : IDisposable
    {
        private ConnectionConfiguration _configuration;

        public Connection(ConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void Authenticaticate()
        {
        }

        public dynamic Hire(object contractModel)
        {
            return null;
        }

        public dynamic Cancel(object contractModel)
        {
            return null;
        }

        public dynamic Update(object contractModel)
        {
            return null;
        }

        public dynamic ChangePaymentMode(object contractModel)
        {
            return null;


        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
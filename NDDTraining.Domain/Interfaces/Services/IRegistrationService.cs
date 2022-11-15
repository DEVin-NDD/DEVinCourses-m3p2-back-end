using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface IRegistrationService
    {
        public void SendEMail();
        public void ValidateRegistration();

    }
}

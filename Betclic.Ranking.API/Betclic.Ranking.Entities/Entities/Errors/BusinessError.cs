using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betclic.Ranking.Entities.Entities.Errors
{
    public abstract class BusinessError
    {
        public abstract string GetMessage();
    }

    public abstract class PlayerBusinessError : BusinessError { }

    public class PlayerNotFound : PlayerBusinessError
    {
        public override string GetMessage() => "Player not found";
    }

    public class PlayerAlreadyExists : PlayerBusinessError
    {
        public override string GetMessage() => "Player already exist";
    }

    public class PlayerNameRequired : PlayerBusinessError 
    {
        public override string GetMessage() => "Player name required";
    }

    public class PlayerIdRequired : PlayerBusinessError
    {
        public override string GetMessage() => "Player id required";
    }

}

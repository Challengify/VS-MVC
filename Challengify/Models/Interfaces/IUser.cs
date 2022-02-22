using System;
using System.Collections.Generic;

namespace Challengify.Models.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> GetUsersInChallenge(Challenge challenge);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class Command
    {
        abstract public void execute(float deltaTime);
    }
}

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimeEvent : ManagerLink
    {

        public  TimeEvent()
            : base()
        {
            this.timeEventName = TimeEventNames.Not_Initialized;
            
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f; 
            
        }

        ~TimeEvent()
        {
           // this.Print("GameSprite: destoying->");            
            
        }

        public void Set(TimeEventNames name, Command command, float deltaTimeToTrigger)
        {
            this.timeEventName = name;
            
            this.pCommand = command;
            this.deltaTime = deltaTimeToTrigger;
            // set the trigger time
            this.triggerTime = TimerManager.GetCurrTime() + deltaTimeToTrigger; 
        }

        public void Process()
        {
            // make sure the command is valid
            Debug.Assert(this.pCommand != null);
            // fire off command
            this.pCommand.execute(deltaTime);
            
        }

        public override Enum getName()
        {

            return this.timeEventName;

        }

        public override Enum getIndex()
        {
            return this.index;
        }

        public void Print(String extra = null)
        {
            Debug.WriteLine(extra + "triggerTime " + triggerTime + "delta " + deltaTime);
        }

        //---------------data
        TimeEventNames timeEventName;
        public Command pCommand;
        public float triggerTime;
        public float deltaTime;
        public Index index;
    }

}

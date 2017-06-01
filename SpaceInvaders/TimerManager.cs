using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TimerManager : Manager
    {



        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);


            // initialize the singleton here
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new TimerManager(reserveNum, reserveGrow);
            }

        }

        public static void Destroy()
        {
            // Get the instance
            TimerManager pTimerMan = TimerManager.privInstance();

            pTimerMan.baseDestroy();
        }

        private TimerManager( int numReserve, int reserveGrow )
            : base(numReserve, reserveGrow)
        {
            // do nothing
            this.currTime = 0.0f;
        }


        public static void Add(TimeEventNames name, Command command, float deltaTimeToTrigger)
        {
            // Get the instance
            TimerManager pTimerManager = TimerManager.privInstance();

            // Go to Man, get a node from reserve, add to active, return it
            TimeEvent pTimeEvent = (TimeEvent)pTimerManager.baseAdd();

            // Initialize object
            pTimeEvent.Set(name, command, deltaTimeToTrigger);
        }


        // static method 
        public static TimeEvent Find(ImageNames name, Index index = Index.i0)
        {
            // get the instance pointer
            TimerManager timerManager = TimerManager.privInstance();
            //// get the head
            //Image pImage = (Image)imageManager.active;

            

            //call the base class function
            return (TimeEvent)timerManager.basefind(name, index);
        }

        public static void Remove(Image node)
        {
            // get the singleton
            TimerManager timerManager = TimerManager.privInstance();

            //call base class function
            timerManager.baseRemove(node);
        }

        public static void Update(float totalTime)
        {
            // Get the instance
            TimerManager pTimerMan = TimerManager.privInstance();

            // squirrel away
            pTimerMan.currTime = totalTime;

            // walk the list
            TimeEvent pEvent = (TimeEvent)pTimerMan.active;
            TimeEvent nextEvent = null;

            // Walk the list until there is no more list OR currTime is greater than timeEvent 
            while (pEvent != null && (pTimerMan.currTime >= pEvent.triggerTime))
            {
                // Difficult to walk a list and remove itself from the list
                // so squirrel away the next event now, use it at bottom of while
                nextEvent = (TimeEvent)pEvent.next;
                
                if (pTimerMan.currTime >= pEvent.triggerTime)
                {
                    
                    // call it
                    pEvent.Process();
                    //AlienHierarchy pGrid = (AlienHierarchy)GameObjManager.Find(GameObjectNames.Grid);
                    //pGrid.MoveGrid();

                    AlienGrid pGrid = (AlienGrid)GameObjManager.Find(GameObjectNames.Grid);
                    pGrid.privMoveBoxes();

                    
                    // remove from list
                    pTimerMan.baseRemove(pEvent);
                }

                // advance the pointer
                pEvent = nextEvent;
            }
        }

        private static TimerManager privInstance()
        {
            Debug.Assert(instance != null);
            
            return instance;
        }

        protected override object privGetNewObj()
        {
            object pObj = new TimeEvent();
            return pObj;
        }

        public static float GetCurrTime()
        {
            // Get the instance
            TimerManager pTimerMan = TimerManager.privInstance();

            // return time
            return pTimerMan.currTime;
        }

        public static void PrintActive()
        {
            // get the singleton
            TimerManager pTimerMan = TimerManager.privInstance();

            Debug.WriteLine("\nImageMan: (active list)");
            TimeEvent pTimeEvent = (TimeEvent)pTimerMan.active;
            while (pTimeEvent != null)
            {
                pTimeEvent.Print("    ");
                pTimeEvent = (TimeEvent)pTimeEvent.next;
            }

        }

        public static void PrintStats()
        {
            // get the singleton
            TimerManager pImageMan = TimerManager.privInstance();

            pImageMan.basePrintStats();
        }


        public static void decreaseCount()
        {
            //AlienRemoveObserver pA;
            //int a = pA.retAC();
        }

        public int retCount()
        {
            return AlienCount;
        }

        //public Enum WhichSound
        //{
        //    A,
        //    B
        //}

        //Data----------------
        private static TimerManager instance =  null;
        protected float currTime;
        int x = 1;
        private int AlienCount = 55;
        private AlienRemoveObserver pA;
        

    }
}

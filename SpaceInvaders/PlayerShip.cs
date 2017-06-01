using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerShip : PlayerShipCategory
    {
        

        public PlayerShip(GameObjectNames name, SpriteNames spriteName, float posX, float posY)
            : base(name, Index.i0, spriteName, PlayerShipCategory.Type.PlayerShip)
        {
            this.x = posX;
            this.y = posY;
            PushPosition();

            //// Do the initialization
            //if (instance == null)
            //{
            //    instance = new CollisionSpriteManager(reserveNum, reserveGrow);
            //    // instance.pNullSprite = new NullSprite(GameSprite.Name.NullObject);
            //}
        }

        public override void Update()
        {
            UpdatePositionOfShip();
        }

        

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an Missile
            // Call the appropriate collision reaction
            other.VisitPlayerShip(this);
        }


        public override void VisitBombRoot(BombRoot m)
        {
            // MissileRoot vs ShieldBrick
            // now go deeper on Missile root
            // ColPair.Collide((GameObject)m.child, this);
            ColPair.Collide((GameObject)m.child, this);
        }

        public override void VisitCrossBomb(CrossBomb m)
        {
            // AlienOctopus vs Missile
            Debug.WriteLine("collide: {0} with {1}", this, m);

            Debug.WriteLine(" ---> Done");

           // m.hit = true;

            ColPair pColPair = ColPairManager.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();

        }



        

        public ShipState StateOfShip
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                Console.WriteLine("StateOfShip: " + state.GetType().Name);
                Console.WriteLine("a = " + a);
            }
        }

        public void RequestState()
        {
             state.HandleTheChangeState(this);
        }

        public override void Process()
        {
            this.UpdatePositionOfShip();
        }

        public void UpdatePositionOfShip()
        {
            // to toggle collision boxed

            // toggle boxes on and off
            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_1))
            {
                SpriteBatchGroup pSpriteBatchGroup;
                // SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();
                pSpriteBatchGroup = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Boxes);
                pSpriteBatchGroup.DrawEnable = true;
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_2))
            {
                SpriteBatchGroup pSpriteBatchGroup;
                // SpriteBatchManager pSpriteBatchManager = SpriteBatchManager.privInstance();
                pSpriteBatchGroup = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Boxes);
                pSpriteBatchGroup.DrawEnable = false;
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_RIGHT))
            {
                //Debug.WriteLine("key right arrow is pressed++++++++++++++++++++++++++++++++++++++++++++++++++");

                if (this.x > 830)
                {

                }
                else
                {
                    this.x += 10;
                    PushPosition();
                }
            }

            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_LEFT))
            {
                //System.Console.WriteLine("key left arrow is pressed------------------------------------------");

                if (this.x < 66)
                {

                }
                else
                {
                    this.x -= 10;
                    PushPosition();
                }
                
            }

           // Console.ReadKey();
            
            {

                if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_SPACE))
                {
                    if (a == 1)
                    {
                        this.RequestState();
                       // a = 0;
                        
                        pMissile =(Missile) GameObjManager.Find(GameObjectNames.Missile);
                        Debug.WriteLine(" Missile assigned---------------------------------------------------------------");
                        pMissile.FireMissile();
                        Azul.Sound FireMissileSound;
                        FireMissileSound = Azul.Audio.playSound("shoot.wav", false, false, true);

                    }
                    
                        
                    
                }
            }
        }

        

        //data-------------------
        public ShipState state =  new ReadyToFireMode();
        public int a = 1;
        private static PlayerShip instance = null;
        public PlayerShipFiringStatus status = PlayerShipFiringStatus.ArmedAndReady;
        public Missile pMissile;
        


    }
}

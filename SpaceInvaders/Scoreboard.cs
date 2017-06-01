using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Scoreboard
    {
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            


            // initialize the singleton here
            Debug.Assert(instance == null);

            // Do the initialization
            if (instance == null)
            {
                instance = new Scoreboard();
                Scoreboard myScoreboard = Scoreboard.privInstance();
                myScoreboard.pSpriteBatchGroup = SpriteBatchManager.Find(SpriteBatchGroup.Name.SBG_Score);
                //instance.pScoreboard = new NullSprite(SpriteNames.NullObject);
            }

            // Sprite sprite = (Sprite)SpriteManager.privInstance().reserve;
       
        }

        public static Scoreboard privInstance()
        {
            Debug.Assert(instance != null);
            //if (instance == null)
            //{
            //    instance = new SpriteManager();
            //}
            return instance;
        }

       private Scoreboard()
          //  : base(GameObjectNames.Scoreboard, Index.i0, SpriteNames.NullObject)
        {
            
        }

        

        public static void ShowScore()
        {
            Scoreboard pScoreboard = Scoreboard.privInstance();
            //return  pScoreboard.message = new Azul.SpriteFont("Hi", Azul.AZUL_FONTS.Consolas24pt, 100, 700);
             pScoreboard.message = new Azul.SpriteFont("Hi", Azul.AZUL_FONTS.Consolas24pt, 100, 700);
             pScoreboard.PlayerOneScore_Letters = new Azul.SpriteFont("SCORE<1>", Azul.AZUL_FONTS.Consolas48pt, 50, 1000);
             pScoreboard.PlayerTwoScore_Letters = new Azul.SpriteFont("SCORE<2>", Azul.AZUL_FONTS.Consolas48pt, 680, 1000);
             pScoreboard.PlayerHiScore_Letters = new Azul.SpriteFont("HI-SCORE", Azul.AZUL_FONTS.Consolas48pt, 360, 1000);
             
             pScoreboard.PlayerOneScore_numbers = new Azul.SpriteFont("000000", Azul.AZUL_FONTS.Consolas48pt, 50,  950);
             pScoreboard.PlayerTwoScore_numbers = new Azul.SpriteFont("000000", Azul.AZUL_FONTS.Consolas48pt, 680, 950);
              pScoreboard.PlayerHiScore_numbers = new Azul.SpriteFont("000000", Azul.AZUL_FONTS.Consolas48pt, 360, 950);
              pScoreboard.PlayerLives = new Azul.SpriteFont("3", Azul.AZUL_FONTS.Consolas48pt, 20, 25);
              pScoreboard.UpdatePlayerScore();
        }

        public void UpdatePlayerScore()
        {
            Scoreboard pScoreboard = Scoreboard.privInstance();
            pScoreboard.PlayerOneScore_numbers.Update(this.p1Score.ToString());
            pScoreboard.PlayerTwoScore_numbers.Update(this.p2Score.ToString());
            pScoreboard.PlayerHiScore_numbers.Update(this.HiScore.ToString());
            pScoreboard.PlayerLives.Update(this.playerLivesCount.ToString());
        }

        //public override void Accept(ColVisitor other)
        //{
            
        //}

        //data --------------------------------------------------------

        private static Scoreboard instance = null;
      //  private NullSprite pScoreboard = null;
        public Azul.SpriteFont message;
        public SpriteBatchGroup pSpriteBatchGroup;
        public Azul.SpriteFont PlayerOneScore_Letters;
        public Azul.SpriteFont PlayerTwoScore_Letters;
        public Azul.SpriteFont PlayerHiScore_Letters;

        public Azul.SpriteFont PlayerOneScore_numbers;
        public Azul.SpriteFont PlayerTwoScore_numbers;
        public Azul.SpriteFont  PlayerHiScore_numbers;
        public Azul.SpriteFont PlayerLives;

        public int p1Score = 0;
        public int p2Score = 0;
        public int HiScore = 0;
        public int playerLivesCount = 3;
    }
}

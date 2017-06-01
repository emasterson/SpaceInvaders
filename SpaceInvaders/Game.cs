using System;
using Azul;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class Game : Azul.Engine
    {
        

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            Azul.Camera.setWindowSize(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            
            TextureManager.Create();
            ImageManager.Create();
            SpriteManager.Create();
            CollisionSpriteBoxManager.Create();
            SpriteBatchManager.Create();
            GameObjManager.Create();
            TimerManager.Create();
            DeathManager.Create(1,1);
            ColPairManager.Create();
            Scoreboard.Create();

            
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {

            setClearBufferColor(new Color(0.0f, 0.0f, 0.0f));
            


            // attempt to add my own code to work with managers
            

            TextureManager.Add(TextureNames.AliensTexture, "invaders-from-space.tga");
            TextureManager.Add(TextureNames.ShieldsTexture, "shield..tga");
            TextureManager.Add(TextureNames.AmmoTexture, "Ammo.tga");

            
            ImageManager.Add(ImageNames.Crab_0, TextureNames.AliensTexture, 136, 65, 85, 62);
            ImageManager.Add(ImageNames.Crab_1, TextureNames.AliensTexture, 250, 63, 87, 64);
            ImageManager.Add(ImageNames.Octopus_0, TextureNames.AliensTexture, 557, 62, 93, 65);
            ImageManager.Add(ImageNames.Octopus_1, TextureNames.AliensTexture, 23, 199, 98, 65);
            ImageManager.Add(ImageNames.Squid_0, TextureNames.AliensTexture, 367, 63, 65, 64);
            ImageManager.Add(ImageNames.Squid_1, TextureNames.AliensTexture, 464, 62, 62, 64);
            ImageManager.Add(ImageNames.PlayerShip, TextureNames.AliensTexture, 241, 494, 59, 41);
            ImageManager.Add(ImageNames.PlayerMissile, TextureNames.AliensTexture, 434, 486, 25, 44);
            ImageManager.Add(ImageNames.PlayerMissile2, TextureNames.AmmoTexture, 243, 73, 14, 118);
            ImageManager.Add(ImageNames.UFO, TextureNames.AliensTexture, 120, 489, 94, 47);
            ImageManager.Add(ImageNames.CrossBomb, TextureNames.AmmoTexture, 65, 72, 45, 118);
            ImageManager.Add(ImageNames.SquigglyBomb, TextureNames.AmmoTexture, 125, 87, 41, 105);
            ImageManager.Add(ImageNames.LongBrick, TextureNames.ShieldsTexture, 8, 85, 60, 25);

           // ImageManager.Add(ImageNames.Shield, TextureNames.ShieldsTexture, 8, 31, 248, 202);

            ImageManager.Add(ImageNames.Brick,           TextureNames.ShieldsTexture, 8, 85, 60, 25);
            ImageManager.Add(ImageNames.Brick_LeftTop0,  TextureNames.ShieldsTexture, 8, 31, 60, 25);
            ImageManager.Add(ImageNames.Brick_LeftTop1,  TextureNames.ShieldsTexture, 8, 56, 60, 25);
            ImageManager.Add(ImageNames.Brick_LeftBottom,TextureNames.ShieldsTexture, 8, 205, 60, 25);
            ImageManager.Add(ImageNames.Brick_RightTop0, TextureNames.ShieldsTexture, 196, 31, 60, 25);
            ImageManager.Add(ImageNames.Brick_RightTop1, TextureNames.ShieldsTexture, 196, 56, 60, 25);
            ImageManager.Add(ImageNames.Brick_RightBottom,TextureNames.ShieldsTexture, 196, 229, 60, 25);
           //SpriteBatches
           // SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Aliens);
            SpriteBatchGroup pSBG_Aliens = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Aliens, true);
           // SpriteBatchGroup pSBG_Boxes = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Boxes, true);
            SpriteBatchGroup pSBG_Boxes = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Boxes, false);
            SpriteBatchGroup pSBG_Shield = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Sheilds, true);
            SpriteBatchGroup pSBG_Score = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Score, true);
            SpriteBatchGroup pSBG_UFO = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_UFOs, true);
            SpriteBatchGroup pSBG_PlayerLives = SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_PlayerLives, true);

            //SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Boxes);
            //SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Background);
            //SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_PlayerShip);
          //  SpriteBatchManager.Add(SpriteBatchGroup.Name.SBG_Missiles);


           
            // game Sprites
            SpriteManager.Add(SpriteNames.AlienSpriteCrab01, ImageNames.Crab_0, 50, 300, 45, 33);
            SpriteManager.Add(SpriteNames.AlienSpriteOctopus01, ImageNames.Octopus_0, 50, 300, 49, 33);
            SpriteManager.Add(SpriteNames.AlienSpriteSquid01, ImageNames.Squid_0, 50, 300, 33, 33);
            SpriteManager.Add(SpriteNames.PlayerShipSprite, ImageNames.PlayerShip, 350, 100, 59, 37);
            SpriteManager.Add(SpriteNames.PlayerMissileSprite, ImageNames.PlayerMissile, 350, 150, 12, 22);

            SpriteManager.Add(SpriteNames.Brick, ImageNames.Brick,                          50, 25, 20, 10);
            SpriteManager.Add(SpriteNames.Brick_LeftTop0, ImageNames.Brick_LeftTop0,        50, 25, 20, 10);
            SpriteManager.Add(SpriteNames.Brick_LeftTop1, ImageNames.Brick_LeftTop1,        50, 25, 20, 10);
            SpriteManager.Add(SpriteNames.Brick_LeftBottom, ImageNames.Brick_LeftBottom,    50, 25, 20, 10);
            SpriteManager.Add(SpriteNames.Brick_RightBottom, ImageNames.Brick_RightBottom,  50, 25, 20, 10);
            SpriteManager.Add(SpriteNames.Brick_RightTop0, ImageNames.Brick_RightTop0,      50, 25, 20, 10);
            SpriteManager.Add(SpriteNames.Brick_RightTop1, ImageNames.Brick_RightTop1,      50, 25, 20, 10);

            SpriteManager.Add(SpriteNames.PlayerMissileSprite2, ImageNames.PlayerMissile2, 600, 100, 2, 20);
            SpriteManager.Add(SpriteNames.UFO_Sprite, ImageNames.UFO, 400, 875, 66, 31);
            SpriteManager.Add(SpriteNames.CrossBombSprite, ImageNames.CrossBomb, 500, 875, 11, 33);
            SpriteManager.Add(SpriteNames.SquigglyBombSprite, ImageNames.SquigglyBomb, 550, 875, 12, 33);
            SpriteManager.Add(SpriteNames.LongBrickSprite, ImageNames.LongBrick, 50, 900, 850, 10);
            SpriteManager.Add(SpriteNames.TallBrickSprite, ImageNames.LongBrick, 50, 900, 10, 850);
                                                                                                    
            // Create and animation sprite
            AnimateSprite pAnimateSprite = new AnimateSprite(SpriteNames.AlienSpriteCrab01);
            AnimateSprite pAnimateSprite2 = new AnimateSprite(SpriteNames.AlienSpriteOctopus01);
            AnimateSprite pAnimateSprite3 = new AnimateSprite(SpriteNames.AlienSpriteSquid01);

            // attach several images to cycle thru
            pAnimateSprite.Attach(ImageNames.Crab_0);
            pAnimateSprite.Attach(ImageNames.Crab_1);
            pAnimateSprite2.Attach(ImageNames.Octopus_0);
            pAnimateSprite2.Attach(ImageNames.Octopus_1);
            pAnimateSprite3.Attach(ImageNames.Squid_0);
            pAnimateSprite3.Attach(ImageNames.Squid_1);

            AlienRemoveObserver pARO = new AlienRemoveObserver();
            pAnimateSprite.pAlienRemove = pARO;
            pAnimateSprite2.pAlienRemove = pARO;
            pAnimateSprite3.pAlienRemove = pARO;

            // create a marching sound
            MarchingSound ms = new MarchingSound();
            ms.pAlienRemove = pARO;

            // add AnimateSprite to timer
            TimerManager.Add(TimeEventNames.SpriteAnimation, pAnimateSprite, 1.0f);
            TimerManager.Add(TimeEventNames.SpriteAnimation, pAnimateSprite2, 1.0f);
            TimerManager.Add(TimeEventNames.SpriteAnimation, pAnimateSprite3, 1.0f);
            TimerManager.Add(TimeEventNames.MarchingSound, ms, 1.0f);

            

            // Root GameObject and tree ------------------------------------------------------------

            PCSTree pTree = new PCSTree();
            GameObjManager.SetRootTree(pTree);

            RootGameObject pRootObj = new RootGameObject(GameObjectNames.Root, Index.i0, SpriteNames.NullObject, 0, 0);
            pTree.Insert(pRootObj, null);
           // pTree.dumpTree();

            

            // Missiles: ------------------------------------------------------------------------------

            //  PCSTree pMissileTree = new PCSTree();
           // PCSTree pTree = new PCSTree();
           // GameObjManager.SetRootTree(pTree);

          //  Bomb pRoot = new Bomb(GameObjectNames.Root, Index.i0, SpriteNames.NullObject, 0, 0);
           // pTree.Insert(pRoot, null);

            MissileRoot pMissileRoot = new MissileRoot(GameObjectNames.MissileRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pMissileRoot);
           
            pMissileRoot.SetCollisionColor(0.0f, 0.0f, 1.0f);
            
            pTree.Insert(pMissileRoot, pRootObj);
           // pTree.dumpTree();
            Missile pMissile = new Missile(GameObjectNames.Missile, SpriteNames.PlayerMissileSprite2, 450, 100);
            
            pSBG_Aliens.Attach(pMissile.pFlyweightSprite);
            
            pTree.Insert(pMissile, pMissileRoot);

           // pTree.dumpTree();

            //Shield: ------------------------------------------------------------------------------

            // create the factory 
            ShieldFactory SF = new ShieldFactory(SpriteBatchGroup.Name.SBG_Sheilds, pTree);

            // set the parent for hierarchy inside the factory, grid is root, so parent is null
            SF.setParent(pRootObj);

            // attach to Root  
            ShieldCategory pShieldRoot = SF.Create(ShieldCategory.Type.Root, GameObjectNames.ShieldRoot, Index.i0);

            // load by column
            for (int j = 0; j < 4; j++)
            {
                {
                    SF.setParent(pShieldRoot);
                    ShieldCategory pColumn = SF.Create(ShieldCategory.Type.Column, GameObjectNames.Column, Index.i0);

                    SF.setParent(pColumn);
                    int i = 0;

                    float start_x = 56.0f;
                    float start_y = 200.0f;
                    float off_x = 0;
                    float brickWidth = 20.0f;
                    float brickHeight = 10.0f;


                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 2 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.LeftTop1, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.LeftTop0, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x), start_y + 9 * brickHeight);

                    off_x += brickWidth;
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 2 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 9 * brickHeight);

                    off_x += brickWidth;
                    SF.Create(ShieldCategory.Type.LeftBottom, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 2 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 9 * brickHeight);

                    off_x += brickWidth;
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 9 * brickHeight);

                    off_x += brickWidth;
                    SF.Create(ShieldCategory.Type.RightBottom, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 2 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 9 * brickHeight);

                    off_x += brickWidth;
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 0 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 1 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 2 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 9 * brickHeight);

                    off_x += brickWidth;
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 0 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 1 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 2 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 3 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 4 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 5 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 6 * brickHeight);
                    SF.Create(ShieldCategory.Type.Brick, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 7 * brickHeight);
                    SF.Create(ShieldCategory.Type.RightTop1, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 8 * brickHeight);
                    SF.Create(ShieldCategory.Type.RightTop0, GameObjectNames.ShieldBrick, Index.i0 + i++, j * 224 + (start_x + off_x), start_y + 9 * brickHeight);

                }
            }

            // Aliens -----------------------------------------------------------------------------------------------

            //create Alien Tree
            //PCSTree pAlienTree = new PCSTree();
            

            // create the factory
            AlienFactory AF = new AlienFactory(SpriteBatchGroup.Name.SBG_Aliens, pTree);



            // set the parent 
            // AF.setParent(pRoot);
            AF.setParent(pRootObj);



            // attach to Root  (this is the Grid)
            AlienCategory pGrid = AF.Create(AlienCategory.Type.Grid, GameObjectNames.Grid, Index.i0);



            //create 15 quickly attach to Grid
            for (int k = 0; k < 11; k++)
            {

                AF.setParent(pGrid);
                AlienCategory pColumn = AF.Create(AlienCategory.Type.Column, GameObjectNames.Column, Index.i0 + k);

                AF.setParent(pColumn);

                AF.Create(AlienCategory.Type.Squid, GameObjectNames.Squid, Index.i0 + k, 100.0f + k * 66.0f, 800.0f);
                AF.Create(AlienCategory.Type.Crab, GameObjectNames.Crab, Index.i0 + k, 100.0f + k * 66.0f, 750.0f);
                AF.Create(AlienCategory.Type.Crab, GameObjectNames.Crab, Index.i0 + k, 100.0f + k * 66.0f, 700.0f);

                //AF.Create(AlienCategory.Type.Squid, GameObjectNames.Squid, Index.i0 + k, 100.0f + k * 50.0f, 700.0f);
                AF.Create(AlienCategory.Type.Octopus, GameObjectNames.Octopus, Index.i0 + k, 100.0f + k * 66.0f, 650.0f);
                AF.Create(AlienCategory.Type.Octopus, GameObjectNames.Octopus, Index.i0 + k, 100.0f + k * 66.0f, 600.0f);

            }

           // pTree.dumpTree();
            
            ////look at output
            //pAlienTree.dumpTree();


            //MissileRoot pMissileRoot = new MissileRoot(GameObjectNames.MissileRoot, SpriteNames.NullObject);
            //GameObjManager.Attach(pMissileRoot);

            //pMissileRoot.SetCollisionColor(0.0f, 0.0f, 1.0f);

            //pTree.Insert(pMissileRoot, pRootObj);
            //pTree.dumpTree();
            //Missile pMissile = new Missile(GameObjectNames.Missile, SpriteNames.PlayerMissileSprite, 450, 100);

            //pSBG_Aliens.Attach(pMissile.pFlyweightSprite);

            //pTree.Insert(pMissile, pMissileRoot);

            //pTree.dumpTree();

            // PlayerShip ---------------------------------------------------------------------------------------------

            PlayerShipRoot pPlayerShipRoot = new PlayerShipRoot(GameObjectNames.PlayerShipRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pPlayerShipRoot);

            pPlayerShipRoot.SetCollisionColor(0.0f, 0.0f, 1.0f);
            pTree.Insert(pPlayerShipRoot, pRootObj);

            PlayerShip pPlayerShip = new PlayerShip(GameObjectNames.PlayerShip, SpriteNames.PlayerShipSprite, 400, 100);
            pSBG_Aliens.Attach(pPlayerShip.pFlyweightSprite);
            pTree.Insert(pPlayerShip, pPlayerShipRoot);

            // PlayerLife ------------------------------------------------------------------------------------------
            PlayerLifeRoot pPlayerLifeRoot = new PlayerLifeRoot(GameObjectNames.PlayerLifeRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pPlayerLifeRoot);

            pPlayerShipRoot.SetCollisionColor(0.0f, 0.0f, 1.0f);
            pTree.Insert(pPlayerLifeRoot, pRootObj);


            PlayerLife pPlayerLife = new PlayerLife(GameObjectNames.PlayerLife, SpriteNames.PlayerShipSprite, 70, 25);

            pSBG_PlayerLives.Attach(pPlayerLife.pFlyweightSprite);
            pTree.Insert(pPlayerLife, pPlayerLifeRoot);

            PlayerLife pPlayerLife2 = new PlayerLife(GameObjectNames.PlayerLife2, SpriteNames.PlayerShipSprite, 150, 25);
            pSBG_PlayerLives.Attach(pPlayerLife2.pFlyweightSprite);
            pTree.Insert(pPlayerLife2, pPlayerLifeRoot);
            // UFO -----------------------------------------------------------------------------
            UFO_Root pUFO_Root = new UFO_Root(GameObjectNames.UFO_Root, SpriteNames.NullObject);
            GameObjManager.Attach(pUFO_Root);

            pUFO_Root.SetCollisionColor(0.0f, 0.0f, 1.0f);
            pTree.Insert(pUFO_Root, pRootObj);

            //UFO_FromRight pUFO_FromRight = new UFO_FromRight(GameObjectNames.UFO_FromRight, SpriteNames.NullObject, 450, 875);
            //pSBG_Aliens.Attach(pUFO_FromRight.pFlyweightSprite);
            //pTree.Insert(pUFO_FromRight, pUFO_Root);

            //// ADD A UFO TO TimerManager

            MakeUFO_Fly pMakeUFO_Fly = new MakeUFO_Fly();
            TimerManager.Add(TimeEventNames.UFO_Flight_Time, pMakeUFO_Fly, 1.0f);
            ////// maybe just add Ufo to timer list like missile in Missile remove observer?


           // Bombs-----------------------------------------------------------------------------
            BombRoot pBombRoot = new BombRoot(GameObjectNames.BombRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pBombRoot);

            pBombRoot.SetCollisionColor(0.0f, 0.0f, 1.0f);
            pTree.Insert(pBombRoot, pRootObj);

            CrossBomb pCrossBomb = new CrossBomb(GameObjectNames.CrossBomb, SpriteNames.CrossBombSprite, 200, 600);
            pSBG_Aliens.Attach(pCrossBomb.pFlyweightSprite);
            pTree.Insert(pCrossBomb, pBombRoot);

            // Drop Bombs ---------------------
            // add DropCrossBomb to TimerManger
            //DropBombs pDropBombs = new DropBombs();
            //TimerManager.Add(TimeEventNames.DropCrossBomb, pDropBombs , 1.0f);

            //SquigglyBomb pSquigglyBomb = new SquigglyBomb(GameObjectNames.SquigglyBomb, SpriteNames.SquigglyBombSprite, 600, 875);
            //pSBG_Aliens.Attach(pSquigglyBomb.pFlyweightSprite);
            //pTree.Insert(pSquigglyBomb, pBombRoot);


            // Ceiling ----------------------------------------------------------------------------------
            
            WallRoot pWallRoot = new WallRoot(GameObjectNames.WallRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pWallRoot);

            pWallRoot.SetCollisionColor(0.0f, 0.0f, 1.0f);
            pTree.Insert(pWallRoot, pRootObj);

            Ceiling pCeiling = new Ceiling(GameObjectNames.Ceiling, SpriteNames.LongBrickSprite, 448, 900);
            pSBG_Aliens.Attach(pCeiling.pFlyweightSprite);
            pTree.Insert(pCeiling, pWallRoot);
            
            // Right Wall --------------------------------------------------------------
            WallRoot pWallRoot2 = new WallRoot(GameObjectNames.WallRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pWallRoot2);

            RightWall pRightWall = new RightWall(GameObjectNames.RightWall, SpriteNames.TallBrickSprite, 872, 500);
            
           // pSBG_Aliens.Attach(pRightWall.pFlyweightSprite);
            pTree.Insert(pRightWall, pWallRoot2);

            // Left Wall ---------------------------------------------------------------
            WallRoot pWallRoot3 = new WallRoot(GameObjectNames.WallRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pWallRoot3);

            LeftWall pLeftWall = new LeftWall(GameObjectNames.LeftWall, SpriteNames.TallBrickSprite, 19, 500);
           // pSBG_Aliens.Attach(pLeftWall.pFlyweightSprite);
            pTree.Insert(pLeftWall, pWallRoot3);

            // Floor -----------------------------------------------------------------------
            WallRoot pWallRoot4 = new WallRoot(GameObjectNames.WallRoot, SpriteNames.NullObject);
            GameObjManager.Attach(pWallRoot4);

            Floor pFloor = new Floor(GameObjectNames.Floor, SpriteNames.LongBrickSprite, 448, 75);
            pSBG_Aliens.Attach(pFloor.pFlyweightSprite);
            pTree.Insert(pFloor, pWallRoot4);
           
            // Collision Pairs -------------------------------------------

            ColPair pColPair = ColPairManager.Add(ColPair.Name.Alien_Missile, pMissileRoot, pGrid);// I don't understand why it will not let me remove the missile
            // in GameObjManager.Remove(). it only finds the nodes for MissileRoot and Grid. is there another way to move missile of the active list?

            //attach the listener
           // pColpair.AttachObserverToSubject(new MissileObserver());

            pColPair.AttachObserverToSubject(new SpawnNewMissileObserver());
           // AlienRemoveObserver pARO = new AlienRemoveObserver();
           // pARO.
            pColPair.AttachObserverToSubject(pARO);

            pColPair.AttachObserverToSubject(new MissileRemoveObserver());

            pColPair = ColPairManager.Add(ColPair.Name.Missile_Shield, pMissileRoot, pShieldRoot);

            ////attached listener
            pColPair.AttachObserverToSubject(new SpawnNewMissileObserver());
            pColPair.AttachObserverToSubject(new MissileRemoveObserver());
            pColPair.AttachObserverToSubject(new BrickRemoveObserver());

            // add ceiling missile collision pair
            pColPair = ColPairManager.Add(ColPair.Name.Missile_Ceiling, pMissileRoot, pWallRoot);
            pColPair.AttachObserverToSubject(new SpawnNewMissileObserver());
            pColPair.AttachObserverToSubject(new MissileRemoveObserver());

            // add Rightwall alienGrid collision pair
            pColPair = ColPairManager.Add(ColPair.Name.RightWall_AlienGrid, pWallRoot2, pGrid);
            pColPair.AttachObserverToSubject(new MoveGridToLeftDirectionObserver());

            // add Leftwall aliengrid collision pair
            pColPair = ColPairManager.Add(ColPair.Name.LeftWall_AlienGrid, pWallRoot3, pGrid);
            pColPair.AttachObserverToSubject(new MoveGridToRightDirectionObserver());

            // add CrossBomb shield collision pair
            pColPair = ColPairManager.Add(ColPair.Name.CrossBomb_Shield, pBombRoot, pShieldRoot);
            pColPair.AttachObserverToSubject(new MakeNewCrossBombObserver());
            pColPair.AttachObserverToSubject(new CrossBombRemoveObserver());
            pColPair.AttachObserverToSubject(new BrickRemoveObserver());
           

            // add CrossBomb Floor collision pair
            pColPair = ColPairManager.Add(ColPair.Name.CrossBomb_Floor, pBombRoot, pWallRoot4);
            pColPair.AttachObserverToSubject(new CrossBombRemoveObserver());
            pColPair.AttachObserverToSubject(new MakeNewCrossBombObserver());

            //add UFo right and rightwall collision pair
            pColPair = ColPairManager.Add(ColPair.Name.UFO_RightWall, pWallRoot2, pUFO_Root);
            pColPair.AttachObserverToSubject(new UFO_HitsRightWallObserver());

            // add UFO right and missile collision pair
            pColPair = ColPairManager.Add(ColPair.Name.UFO_Missile, pMissileRoot, pUFO_Root);
            pColPair.AttachObserverToSubject(new UFO_GoRightRemoveObserver());

            // add CrossBomb and PlayerShip collision pair
            pColPair = ColPairManager.Add(ColPair.Name.CrossBomb_PlayerShip, pBombRoot, pPlayerShipRoot);
            
            pColPair.AttachObserverToSubject(new CrossBombRemoveObserver());
            pColPair.AttachObserverToSubject(new MakeNewCrossBombObserver());
           // pColPair.AttachObserverToSubject(new MakeNewShipObserver());
            pColPair.AttachObserverToSubject(new PlayerLifeRemoveObserver());
            pColPair.AttachObserverToSubject(new PlayerShipRemoveObserver());
            pColPair.AttachObserverToSubject(new MakeNewShipObserver());
            
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update(float totalTime)
        {

            // so we can update collision boxes
            DelayedObjectManager.Process();

            TimerManager.Update(totalTime);

            // walk through all objects and push to flyweight
            GameObjManager.Update();
            ColPairManager.Process();
            Scoreboard.ShowScore();
            

            

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            

            SpriteBatchManager.Draw();
           // CollisionSprite pCollisionSprite = CollisionSpriteManager.Find(CollisionSpriteNames.Octopus);
           // pCollisionSprite.Draw();
            Scoreboard pScoreboard = Scoreboard.privInstance();
            
            pScoreboard.PlayerOneScore_Letters.Draw();
            pScoreboard.PlayerTwoScore_Letters.Draw();
            pScoreboard.PlayerHiScore_Letters.Draw();
            pScoreboard.PlayerOneScore_numbers.Draw();
            pScoreboard.PlayerTwoScore_numbers.Draw();
            pScoreboard.PlayerHiScore_numbers.Draw();
            pScoreboard.PlayerLives.Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            //ImageManager.PrintActive();
            //ImageManager.PrintStats();

            //TimerManager.PrintActive();
            //TimerManager.PrintStats();

            TimerManager.Destroy();
            SpriteBatchManager.Destroy();
            SpriteManager.Destroy();
            ImageManager.Destroy();
            TextureManager.Destroy();
            CollisionSpriteBoxManager.Destroy();
            DeathManager.Destroy();
        }


        private void checkInput()
        {

           
        }

    }
}

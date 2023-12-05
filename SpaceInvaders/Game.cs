//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Sprint 4");
            this.SetWidthHeight(672, 768);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //-------------------------------------------------------
            // Load Managers
            //-------------------------------------------------------

            TextureMan.Create(0,1);
            ImageMan.Create(0,1);
            SpriteGameMan.Create(2,1);
            SpriteBatchMan.Create();
            SpriteBoxMan.Create();
            TimerEventMan.Create();
            SpriteGameProxyMan.Create(10, 1);
            GameObjectNodeMan.Create(); 

            //-------------------------------------------------------
            // Load the Textures
            //-------------------------------------------------------

            TextureMan.Add(Texture.Name.HotPink, "HotPink.tga");

           // TextureMan.Add(Texture.Name.Birds, "Birds.tga");
           // TextureMan.Add(Texture.Name.PacMan, "PacMan.tga");
           // TextureMan.Add(Texture.Name.SpaceInvaders, "SpaceInvaders_ROM.tga");
           // TextureMan.Add(Texture.Name.SpaceInvaders, "Aliens.tga");
            TextureMan.Add(Texture.Name.SpaceInvaders, "Invaders_0.tga");
            //-------------------------------------------------------
            // Create Images
            //-------------------------------------------------------

            ImageMan.Add(Image.Name.HotPink, Texture.Name.HotPink, 0, 0, 128, 128);

            // --- Birds ---

            //ImageMan.Add(Image.Name.RedBird, Texture.Name.Birds, 47, 41, 48, 46);
            //ImageMan.Add(Image.Name.YellowBird, Texture.Name.Birds, 124, 34, 60, 56);
            //ImageMan.Add(Image.Name.GreenBird, Texture.Name.Birds, 246, 135, 99, 72);
            //ImageMan.Add(Image.Name.WhiteBird, Texture.Name.Birds, 139, 131, 84, 97);

            //// --- Pacman ---

            //ImageMan.Add(Image.Name.RedGhost, Texture.Name.PacMan, 616, 148, 33, 33);
            //ImageMan.Add(Image.Name.PinkGhost, Texture.Name.PacMan, 663, 148, 33, 33);
            //ImageMan.Add(Image.Name.BlueGhost, Texture.Name.PacMan, 710, 148, 33, 33);
            //ImageMan.Add(Image.Name.OrangeGhost, Texture.Name.PacMan, 757, 148, 33, 33);

            //----Alien----
            ImageMan.Add(Image.Name.SquidA, Texture.Name.SpaceInvaders, 11, 20 , 250, 137);
            ImageMan.Add(Image.Name.SquidB, Texture.Name.SpaceInvaders, 579, 23, 188, 130);
            ImageMan.Add(Image.Name.CrabA, Texture.Name.SpaceInvaders, 312, 175, 172, 122);
            ImageMan.Add(Image.Name.CrabB, Texture.Name.SpaceInvaders, 302, 15, 222, 125);
            ImageMan.Add(Image.Name.OctopusA, Texture.Name.SpaceInvaders, 36, 174, 216, 125);
            ImageMan.Add(Image.Name.OctopusB, Texture.Name.SpaceInvaders, 36, 15, 214, 129);

            //-------------------------------------------------------
            // Create Sprites
            //-------------------------------------------------------

            // --- BoxSprites ---
            //SpriteBoxMan.Add(SpriteBox.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            //SpriteBoxMan.Add(SpriteBox.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            //// --- Birds ---

            //SpriteGameMan.Add(SpriteGame.Name.RedBird, Image.Name.RedBird, 50, 500, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.YellowBird, Image.Name.YellowBird, 300, 400, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.SquidA, Image.Name.GreenBird, 400, 200, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.WhiteBird, Image.Name.WhiteBird, 600, 300, 100, 100);

            //// --- Pacman ---

            //SpriteGameMan.Add(SpriteGame.Name.RedGhost, Image.Name.RedGhost, 100, 300, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.PinkGhost, Image.Name.PinkGhost, 300, 300, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.BlueGhost, Image.Name.BlueGhost, 500, 300, 100, 100);
            //SpriteGameMan.Add(SpriteGame.Name.OrangeGhost, Image.Name.OrangeGhost, 700, 300, 100, 100);


            //----Aliens
            SpriteGameMan.Add(SpriteGame.Name.SquidA, Image.Name.SquidA, 0, 0, 24, 25);
            SpriteGameMan.Add(SpriteGame.Name.SquidB, Image.Name.SquidB, 0, 00, 24, 25);

            SpriteGameMan.Add(SpriteGame.Name.CrabA, Image.Name.CrabA, 0, 0, 32, 25);
            SpriteGameMan.Add(SpriteGame.Name.CrabB, Image.Name.CrabB, 0, 0, 32, 25);

            SpriteGameMan.Add(SpriteGame.Name.OctopusA, Image.Name.OctopusA, 0, 0, 36, 25);
      
            SpriteGameMan.Add(SpriteGame.Name.OctopusB, Image.Name.OctopusB, 0, 0, 36, 25);

            //-------------------------------------------------------
            // Create SpriteBatch
            //-------------------------------------------------------

            //SpriteBatch pSB_PacMan = SpriteBatchMan.Add(SpriteBatch.Name.PacMan);
            // SpriteBatch pSB_Birds = SpriteBatchMan.Add(SpriteBatch.Name.AngryBirds);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Add(SpriteBatch.Name.Aliens, 10);
            //---------------------------------------------------------------------------------------------------------
            // Create Birds
            //---------------------------------------------------------------------------------------------------------

            // create the factory 
            AlienFactory AF = new AlienFactory(SpriteBatch.Name.Aliens);

            // create 55 quickly
            for (int i = 0; i < 11; i++)
            {
                AF.Create(AlienBase.Type.SquidA, 80.0f + i * 50.0f, 600.0f);

                AF.Create(AlienBase.Type.CrabA, 80.0f + i * 50.0f, 500.0f);
                AF.Create(AlienBase.Type.CrabA, 80.0f + i * 50.0f, 550.0f);

                AF.Create(AlienBase.Type.OctopusA, 80.0f + i * 50.0f, 400.0f);
                AF.Create(AlienBase.Type.OctopusA, 80.0f + i * 50.0f, 450.0f);

            }
            GameObjectNodeMan.Update();

            // GameObjectNodeMan.Dump();
            //Create Sample file commands



            // SquidA pSquid = AF.Create(AlienBase.Type.SquidA, 80.0f * 50.0f, 600.0f); 

            //-------Samples-------
            SampleCmd pSmp1 = new SampleCmd("------Late Command------");
            SampleCmd pSmp2 = new SampleCmd("------Late Command------");
            SampleCmd pSmp3 = new SampleCmd("------Late Command------");
            SampleCmd pSmp4 = new SampleCmd("------Late Command------");
            SampleCmd pSmp5 = new SampleCmd("------Late Command------");


            //---------animation---------
            AnimationCmd pAnmSquid = new AnimationCmd(SpriteGame.Name.SquidA);
            AnimationCmd pAnmCrab = new AnimationCmd(SpriteGame.Name.CrabA);
            AnimationCmd pAnmOctopus = new AnimationCmd(SpriteGame.Name.OctopusA);


            //---------Atttach----------
            pAnmSquid.Attach(Image.Name.SquidA);
            pAnmSquid.Attach(Image.Name.SquidB);

            pAnmCrab.Attach(Image.Name.CrabA);
            pAnmCrab.Attach(Image.Name.CrabB);

            pAnmOctopus.Attach(Image.Name.OctopusA);
            pAnmOctopus.Attach(Image.Name.OctopusB);


            //Add Commands to Timer Events Manager

            //----Samples----
          //  TimerEventMan.Dump();
            TimerEventMan.Add(TimerEvent.Name.Sample1, pSmp1, 500.0f);
           // TimerEventMan.Dump();
            TimerEventMan.Add(TimerEvent.Name.Sample2, pSmp2, 510.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample3, pSmp3, 520.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample4, pSmp4, 530.0f);
            TimerEventMan.Add(TimerEvent.Name.Sample5, pSmp5, 540.0f);



            //-----Animation-----
            TimerEventMan.Add(TimerEvent.Name.Animation, pAnmSquid, 0.25f);
            TimerEventMan.Add(TimerEvent.Name.Animation, pAnmCrab, 0.50f);
            TimerEventMan.Add(TimerEvent.Name.Animation, pAnmOctopus, 1.0f);


            //Dump
            TimerEventMan.Dump();


        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {


           // Debug.WriteLine("\n   ------ Print Me here  ------");
            // Fire off the timer events
            TimerEventMan.Update(this.GetTime());
            //TimerEventMan.Dump();
            // walk through all objects and push to proxy
            GameObjectNodeMan.Update();
            //GameObjectNodeMan.Dump();
           

            //SpriteGame pSprite = SpriteGameMan.Find(SpriteGame.Name.SquidA);
            //SpriteGame pSprite2 = SpriteGameMan.Find(SpriteGame.Name.CrabA);
            //SpriteGame pSprite3 = SpriteGameMan.Find(SpriteGame.Name.OctopusA);
            //Debug.Assert(pSprite !=null);
            // pSprite.Update(); 

        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SpriteBatchMan.Draw();

            //// SpriteBox pBoxSprite1 = SpriteBoxMan.Find(SpriteBox.Name.Box1);
            //// SpriteBox pBoxSprite2 = SpriteBoxMan.Find(SpriteBox.Name.Box2);
            //SpriteGame pSprite = SpriteGameMan.Find(SpriteGame.Name.SquidA);
            //SpriteGame pSprite2 = SpriteGameMan.Find(SpriteGame.Name.CrabA);
            //SpriteGame pSprite3 = SpriteGameMan.Find(SpriteGame.Name.OctopusA);


            //SpriteGame pSprite = SpriteGameMan.Find(SpriteGame.Name.SquidA);
            //SpriteGame pSprite2 = SpriteGameMan.Find(SpriteGame.Name.CrabA);
            //SpriteGame pSprite3 = SpriteGameMan.Find(SpriteGame.Name.OctopusA);

            //pSprite.Render();
            //pSprite2.Render();
            //pSprite3.Render();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            GameObjectNodeMan.Destroy();
            SpriteGameProxyMan.Destroy();
            TimerEventMan.Destroy();
            SpriteBoxMan.Destroy();
            SpriteBatchMan.Destroy();
            SpriteGameMan.Destroy();
            ImageMan.Destroy();
            TextureMan.Destroy();
        }

    }
}

// --- End of File ---

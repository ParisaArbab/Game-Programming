//-----------------------------------------------------------------------------
// Copyright 2023, Ed Keenan, all rights reserved.
//----------------------------------------------------------------------------- 

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        public AlienFactory(SpriteBatch.Name spriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
        }


        public void Create(AlienBase.Type type, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienBase.Type.SquidA:
                    pGameObj = new SquidA(SpriteGame.Name.SquidA, posX, posY);
                    break;

                case AlienBase.Type.SquidB:
                    pGameObj = new SquidB(SpriteGame.Name.SquidB, posX, posY);
                    break;

                case AlienBase.Type.CrabA:
                    pGameObj = new CrabA(SpriteGame.Name.CrabA, posX, posY);
                    break;


                case AlienBase.Type.CrabB:
                    pGameObj = new CrabB(SpriteGame.Name.CrabB, posX, posY);
                    break;

                case AlienBase.Type.OctopusA:
                    pGameObj = new OctopusA(SpriteGame.Name.OctopusA, posX, posY);
                    break;


                case AlienBase.Type.OctopusB:
                    pGameObj = new OctopusB(SpriteGame.Name.OctopusB, posX, posY);
                    break;



                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add it to the gameObjectManager
            Debug.Assert(pGameObj != null);
            GameObjectNodeMan.Attach(pGameObj);

            // Attached to Group
            this.pSpriteBatch.Attach(pGameObj);
           // pGameObj.ActivateSprite(this.pSpriteBatch);
           //  return pGameObj;
        }

        // Data: ---------------------

        SpriteBatch pSpriteBatch;
    }
}

// --- End of File ---

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CollisionRect
    {
        public CollisionRect(float _x, float _y, float _width, float _height)
        {
            this.x = _x;
            this.y = _y;
            this.width = _width;
            this.height = _height;
        }

        public CollisionRect(Azul.Rect rect)
        {
            this.x = rect.x;
            this.y = rect.y;
            this.width = rect.w;
            this.height = rect.h;
        }

        public CollisionRect()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.width = 0.0f;
            this.height = 0.0f;
        }

        //static public bool Intersect(CollisionRect ColRectA, CollisionRect ColRectB)
        //{
        //    bool status = false;

        //    float A_minx = ColRectA.x;
        //    float A_maxx = ColRectA.x + ColRectA.width;
        //    float A_miny = ColRectA.y - ColRectA.height;
        //    float A_maxy = ColRectA.y;

        //    float B_minx = ColRectB.x;
        //    float B_maxx = ColRectB.x + ColRectB.width;
        //    float B_miny = ColRectB.y - ColRectB.height;
        //    float B_maxy = ColRectB.y;

        //    // Trivial reject
        //    if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy))
        //    {
        //        status = false;
        //    }
        //    else
        //    {
        //        status = true;
        //    }


        //    return status;
        //}

        static public bool Intersect(CollisionRect ColRectA, CollisionRect ColRectB)
        {
            bool status = false;

            float A_minx = ColRectA.x;
            float A_maxx = ColRectA.x + ColRectA.width;
            //float A_miny = ColRectA.y - ColRectA.height;
            float A_miny = ColRectA.y - ColRectA.height;
            float A_maxy = ColRectA.y;

            float B_minx = ColRectB.x;
            float B_maxx = ColRectB.x + ColRectB.width;
           // float B_miny = ColRectB.y - ColRectB.height;
            float B_miny = ColRectB.y - ColRectB.height;
            float B_maxy = ColRectB.y;

            // Trivial reject
            if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy))
            {
                status = false;
            }
            else
            {
                status = true;
            }


            return status;
        }

        //public CollisionRect Union(CollisionRect ColRectA, CollisionRect ColRectB)
        //{
        //    CollisionRect pColRect = new CollisionRect();
        //    return pColRect;
        //}

        static public CollisionRect Union(CollisionRect ColRectA, CollisionRect ColRectB)
        {
            float minX;
            float minY;
            float maxX;
            float maxY;

            if (ColRectA.x < ColRectB.x)
            {
                minX = ColRectA.x;
            }
            else
            {
                minX = ColRectB.x;
            }

            if ((ColRectA.x + ColRectA.width) > (ColRectB.x + ColRectB.width))
            {
                maxX = (ColRectA.x + ColRectA.width);
            }
            else
            {
                maxX = (ColRectB.x + ColRectB.width);
            }

            if (ColRectA.y > ColRectB.y)
            {
                maxY = ColRectA.y;
            }
            else
            {
                maxY = ColRectB.y;
            }

            if ((ColRectA.y - ColRectA.height) < (ColRectB.y - ColRectB.height))
            {
                minY = (ColRectA.y - ColRectA.height);
            }
            else
            {
                minY = (ColRectB.y - ColRectB.height);
            }

            //// adding my own maxY******************************
            //if ((ColRectA.y + ColRectA.height) > (ColRectB.y + ColRectB.height))
            //{
            //    maxY = (ColRectA.y + ColRectA.height);
            //}
            //else
            //{
            //    maxY = (ColRectB.y + ColRectB.height);
            //}


            //**********************************

            //if (ColRectA.y > ColRectB.y)
            //{
            //    maxY = ColRectA.y;
            //}
            //else
            //{
            //    maxY = ColRectB.y;
            //}

            //// adding my own minY*****************************

            //if (ColRectA.y < ColRectB.y)
            //{
            //    minY = ColRectA.y;
            //}
            //else
            //{
            //    minY = ColRectB.y;
            //}

            //*********************

            //if ((ColRectA.y - ColRectA.height) < (ColRectB.y - ColRectB.height))
            //{
            //    minY = (ColRectA.y - ColRectA.height);
            //}
            //else
            //{
            //    minY = (ColRectB.y - ColRectB.height);
            //}

            //original line of code
            CollisionRect pColRect = new CollisionRect(minX, maxY, (maxX - minX), (maxY - minY));


          // CollisionRect pColRect = new CollisionRect(minX, minY, (maxX - minX), (maxY - minY));
          // CollisionRect pColRect = new CollisionRect(minX, minY, 50, 50);
            return pColRect;
        }

        //data ---------------------
        public float x;
        public float y;
        public float width;
        public float height;

    }
}

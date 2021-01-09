using System;
using System.Collections.Generic;
using System.Text;

namespace Dezmembrari_auto_Csecs_Zalan
{
    class Pizza
    {
        private PizzaType mFlavor;

        public PizzaType Flavor
        {
            get
            {
                return mFlavor;
            }
            set
            {
                mFlavor = value;
            }
        }
        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public Pizza(PizzaType aFlavor) // constructor
        {
            mFlavor = aFlavor;
        }
    }
}
    public enum PizzaType
    { Californian,
    Detroit,
    Margherita,
    Capricciosa,
    Boscaiota}
    
    

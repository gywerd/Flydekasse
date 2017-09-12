using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Flydekasse2017
{
    public class ClassBox
    {

        private decimal _decBoxHeight;
        private decimal _decBoxWidth;
        private decimal _decBoxDepth;

        public ClassBox()
        {

        }


        public decimal decBoxHeight
        {
            get
            {
                return _decBoxHeight;
            }
            set
            {
                if (value != _decBoxHeight)
                {
                    _decBoxHeight = value;
                }

            }
        }

        public decimal decBoxWidth
        {
            get
            {
                return _decBoxWidth;
            }
            set
            {
                if (value != _decBoxWidth)
                {
                    _decBoxWidth = value;
                }

            }
        }

        public decimal decBoxDepth
        {
            get
            {
                return _decBoxDepth;
            }
            set
            {
                if (value != _decBoxDepth)
                {
                    _decBoxDepth = value;
                }

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SwmSuite.Presentation.Common.Ribbon
{
    internal class RibbonComboBoxDesigner
        : RibbonElementWithItemCollectionDesigner
    {
        public override Ribbon Ribbon
        {
            get
            {
                if (Component is RibbonComboBox)
                {
                    return (Component as RibbonComboBox).Owner;
                }
                return null; 
            }
        }

        public override RibbonItemCollection Collection
        {
            get
            {
                if (Component is RibbonComboBox)
                {
                    return (Component as RibbonComboBox).DropDownItems;
                }
                return null; 
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.ComponentModel
{
    public abstract class StringOptionsPropertyConverter : StringConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, but allow free-form entry
            return true;
        }

        protected abstract List<string> GetOptions();


        public override
            System.ComponentModel.TypeConverter.StandardValuesCollection
            GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> strCollection = GetOptions();
            return new StandardValuesCollection(strCollection);
        }

    }
}

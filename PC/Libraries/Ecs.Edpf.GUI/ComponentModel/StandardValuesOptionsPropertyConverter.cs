using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Ecs.Edpf.GUI.ComponentModel
{
    public class StandardValuesOptionsPropertyConverter : StringOptionsPropertyConverter
    {

        private ITypeDescriptorContext _context = null;

        private IStandardValuesOptionsProvider _stdValuesOptionsProvider = null;


        private string _optionsName;

        public StandardValuesOptionsPropertyConverter(string optionsName)
        {
            _optionsName = optionsName;
        }

        private void SetContext(ITypeDescriptorContext context)
        {
            if (_context == null)
            {
                _context = context;
                _stdValuesOptionsProvider = context.Instance as IStandardValuesOptionsProvider;
            }
        }


        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            SetContext(context);
            return base.CreateInstance(context, propertyValues);
        }



        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            SetContext(context);
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            SetContext(context);
            //true will limit to list. false will show the list, but allow free-form entry
            return true;
        }

        protected override List<string> GetOptions()
        {
            List<string> options = new List<string>();

            if (_stdValuesOptionsProvider != null)
            {
                options = _stdValuesOptionsProvider.GetOptions(_optionsName);
                List<string> filteredOptions = _stdValuesOptionsProvider.GetFilteredOptions(_optionsName);
                options = options.Where(str => !filteredOptions.Contains(str)).ToList();
            }

            return options;
        }

    }
}

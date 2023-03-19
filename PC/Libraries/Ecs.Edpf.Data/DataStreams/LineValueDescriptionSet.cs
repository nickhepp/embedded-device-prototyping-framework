using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecs.Edpf.Data.DataStreams
{

    public class LineValueDescriptionSet : List<LineValueDescription>
    {

        public bool GetIsValid()
        {
            // need to have at least one data point
            bool isValid = this.Count > 0;
            // all the items need to be valid
            isValid &= this.All(valDesc => valDesc.GetIsValid());
            // items need to have different names
            isValid &= (
                this.Select(valDesc => valDesc.ValueName.ToLower()).Distinct().ToList().Count == this.Count);

            return isValid;
        }

    }

}

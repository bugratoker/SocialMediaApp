using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Space : BaseEntity
    {
        public string SpaceName { get; set; }
        public Blob Image { get; set; }

    }
}

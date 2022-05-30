using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Entities.Carts
{
    public enum CartStatusEnum
    {
        [Description("Pending")]
        Pending = 1,
        [Description("Finished")]
        Finished = 2
    }
}

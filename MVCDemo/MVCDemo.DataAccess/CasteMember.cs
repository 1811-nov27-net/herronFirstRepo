using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDemo.DataAccess
{
    public class CasteMember
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieCasteMemberJunction> MovieJunctions { get; set; }

    }
}

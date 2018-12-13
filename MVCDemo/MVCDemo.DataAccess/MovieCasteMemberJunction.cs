using System;
using System.Collections.Generic;
using System.Text;

namespace MVCDemo.DataAccess
{
    public class MovieCasteMemberJunction
    {
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual CasteMember Caste { get; set; }
    }
}

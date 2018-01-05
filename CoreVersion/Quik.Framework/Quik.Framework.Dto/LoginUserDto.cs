using System;

namespace Quik.Framework.Dto
{
    public class LoginUserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }
        public string RealName { get; set; }
        public bool IsSuper { get; set; }
        public long SysRoleId { get; set; }

        public long Province { get; set; }
        public long City { get; set; }
        public long County { get; set; }
        public int UserLevel { get; set; }
    }
}

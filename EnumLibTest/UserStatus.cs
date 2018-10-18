using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnumLibTest
{
    public enum UserStatus
    {

        [Description("状态为正常")]
        [Display(Name = "正常2")]
        Active = 1,

        [Display(Name = "不可用")]
        [Description("状态为不可用")]
        Inactive,

        [Display(Name = "已被锁")]
        [Description("状态为已被锁")]
        Locked
    }
}

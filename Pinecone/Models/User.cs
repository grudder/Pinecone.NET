using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinecone.Models
{
    [Table("T_User")]
    [DisplayName("用户")]
    [DisplayColumn("Sn")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "标识", Order = 10)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "序列号", Order = 20)]
        [StringLength(36)]
        public string Sn
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "成员访问次数", Order = 30)]
        public int MemberVisitCount
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "渠道访问次数", Order = 40)]
        public int ChannelVisitCount
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "渠道1访问次数", Order = 50)]
        public int Channel1VisitCount
        {
            get;
            set;
        }
    }
}
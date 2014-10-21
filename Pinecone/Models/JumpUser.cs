using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinecone.Models
{
    [Table("T_Jump_User")]
    [DisplayName("跳转用户")]
    [DisplayColumn("Sn")]
    public class JumpUser
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
        [Display(Name = "链接1访问次数", Order = 40)]
        public int Link1VisitCount
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "链接2访问次数", Order = 50)]
        public int Link2VisitCount
        {
            get;
            set;
        }
    }
}
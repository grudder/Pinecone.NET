using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinecone.Models
{
    [Table("T_Visit_Log")]
    [DisplayName("访问日志")]
    public class VisitLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Display(Name = "用户", Order = 10)]
        public int UserId
        {
            get;
            set;
        }

        [ForeignKey("UserId")]
        public virtual User User
        {
            get;
            set;
        }

        [Display(Name = "访问类型", Order = 20)]
        public string VisitType
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "访问时间", Order = 30)]
        public DateTime VisitTime
        {
            get;
            set;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.DataModel.Base
{
    public class BaseEntity<TKey>
    {
        public BaseEntity()
        {
            ModifiedDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; }
    }
}

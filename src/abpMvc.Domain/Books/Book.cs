using AbpMvc.Authors;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpMvc.Books
{
    public class Book : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Name { get; set; }

        public virtual int Type { get; set; }

        public virtual DateTime? PublishDate { get; set; }

        public virtual float Price { get; set; }
        public Guid? AuthorId { get; set; }

        public Book()
        {

        }

        public Book(Guid id, string name, int type, float price, DateTime? publishDate = null)
        {
            Id = id;
            Check.Length(name, nameof(name), BookConsts.NameMaxLength, BookConsts.NameMinLength);
            if (type < BookConsts.TypeMinLength)
            {
                throw new ArgumentOutOfRangeException(nameof(type), type, "The value of 'type' cannot be lower than " + BookConsts.TypeMinLength);
            }

            if (type > BookConsts.TypeMaxLength)
            {
                throw new ArgumentOutOfRangeException(nameof(type), type, "The value of 'type' cannot be greater than " + BookConsts.TypeMaxLength);
            }

            Name = name;
            Type = type;
            Price = price;
            PublishDate = publishDate;
        }
    }
}
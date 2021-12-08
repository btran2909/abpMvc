using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace AbpMvc.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Name { get; set; }

        public virtual DateTime BirthDate { get; set; }

        [CanBeNull]
        public virtual string ShortBio { get; set; }

        public Author()
        {

        }

        public Author(Guid id, string name, DateTime birthDate, string shortBio)
        {
            Id = id;
            Check.Length(name, nameof(name), AuthorConsts.NameMaxLength, AuthorConsts.NameMinLength);
            Name = name;
            BirthDate = birthDate;
            ShortBio = shortBio;
        }
    }
}
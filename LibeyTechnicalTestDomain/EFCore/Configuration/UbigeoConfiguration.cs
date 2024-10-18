using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {      
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("Ubigeo").HasKey(x => x.UbigeoCode);
        }        
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DadtApi.Models;

namespace DadtApi.Context
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<IapmApplication> IapmApplications { get; set; }
        public virtual DbSet<InformationTechnologyService> InformationTechnologyServices { get; set; }
        public virtual DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        public virtual DbSet<WebObjectMetadatum> WebObjectMetadata { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentCd)
                    .HasName("Department_pkey");

                entity.ToTable("Department", "DADT");

                entity.Property(e => e.DepartmentCd).HasMaxLength(10);

                entity.Property(e => e.ActiveInd).HasMaxLength(1);

                entity.Property(e => e.ChangeAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChangeDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.CreateAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.DepartmentLevel10Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel10Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel11Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel11Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel12Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel12Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel13Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel13Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel14Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel14Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel15Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel15Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel16Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel16Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel17Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel17Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel18Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel18Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel19Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel19Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel1Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel1Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel20Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel20Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel2Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel2Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel3Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel3Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel4Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel4Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel5Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel5Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel6Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel6Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel7Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel7Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel8Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel8Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel9Cd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentLevel9Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.TreeLevelNbr)
                    .HasMaxLength(33)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<IapmApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("applicationsstaging_pkey");

                entity.ToTable("IapmApplication", "DADT");

                entity.Property(e => e.ApplicationId).ValueGeneratedNever();

                entity.Property(e => e.ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.ApplicationAcronymNm)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationBrowserBasedInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.ApplicationClassificationNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationDetailsUrlTxt)
                    .HasMaxLength(45)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationDevelopedByIntelInd).HasMaxLength(1);

                entity.Property(e => e.ApplicationDsc)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.ApplicationHostingTypeNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationLifecycleStatusEndDtm)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.ApplicationLifecycleStatusNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationMobileBasedInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.ApplicationNativeInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.ApplicationNm)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ApplicationOwningDepartmentCd)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ApplicationOwningDepartmentHierarchyTxt)
                    .HasMaxLength(4000)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationOwningDepartmentLevel3Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationOwningDepartmentLevel4Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationOwningDepartmentLevel5Nm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationOwningDepartmentNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationUserBaseNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationValidatedByWwid)
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ApplicationValidationDtm)
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.ApplicationValidationIssueTxt)
                    .HasMaxLength(1000)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.BusinessOrganizationNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ChangeAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChangeDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.CreateAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.DivisionLongNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.GroupLongNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.InformationDataClassificationNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.InformationTechnologyManagedApplicationInd).HasMaxLength(1);

                entity.Property(e => e.InformationTechnologySegmentNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.InformationTechnologyServiceNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.InformationTechnologySupportTierNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.LogicalPlatformGroupNm)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.PaceLayeringNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ProductOwnerEmailtxt)
                    .HasMaxLength(80)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ProductOwnerNm)
                    .HasMaxLength(65)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ProductOwnerWwid)
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ProductTypeNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.SaasSolutionInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.SocialApplicationInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.SuperGroupLongNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.TmModelNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<InformationTechnologyService>(entity =>
            {
                entity.ToTable("InformationTechnologyService", "DADT");

                entity.HasIndex(e => e.InformationTechnologySegmentId, "Ref5626");

                entity.Property(e => e.InformationTechnologyServiceId).ValueGeneratedNever();

                entity.Property(e => e.ChangeAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChangeDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.CreateAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.InformationTechnologyServiceEndDt).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.InformationTechnologyServiceInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::bpchar");

                entity.Property(e => e.InformationTechnologyServiceNm)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.InformationTechnologyServicePhaseCd)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.InformationTechnologyServiceStartDt).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.ServiceDelegateWwid)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.ServiceOwnerWwid)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<SystemConfiguration>(entity =>
            {
                entity.HasKey(e => e.ConfigurationKey)
                    .HasName("SystemConfiguration_pkey");

                entity.ToTable("SystemConfiguration", "DADT");

                entity.Property(e => e.ConfigurationKey).HasMaxLength(150);

                entity.Property(e => e.ActiveInd)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ChangeAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChangeDtm).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ConfigurationDsc)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ConfigurationValue)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CreateAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateDtm).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<WebObjectMetadatum>(entity =>
            {
                entity.HasKey(e => e.WebObjectMetadataId)
                    .HasName("WebObjectMetadata_pkey");

                entity.ToTable("WebObjectMetadata", "DADT");

                entity.Property(e => e.WebObjectMetadataId).ValueGeneratedNever();

                entity.Property(e => e.CertifyInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.ChangeAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChangeDtm).HasColumnType("timestamp without time zone");

                entity.Property(e => e.ClassNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.CreateAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateDtm).HasColumnType("timestamp without time zone");

                entity.Property(e => e.DataLoadApiUrl)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DisableInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.GroupNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.InitialValueTxt)
                    .HasMaxLength(2000)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.LabelExtensionTxt)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.LabelExtensionTxtClassNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.LabelTxt)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.MandatoryInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.MandatoryValidationMessageTxt)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.MinimumLengthMandatoryInd).HasMaxLength(1);

                entity.Property(e => e.MinimumLengthValidationMessageTxt)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.OnDemandDataLoadInd).HasMaxLength(1);

                entity.Property(e => e.PageNm)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.PlaceholderTxt)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ToolTipMandatoryInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");

                entity.Property(e => e.ToolTipMessageTxt)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ValuePresentIndValidationMessageTxt)
                    .HasMaxLength(200)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ValueSingleSelectInd).HasMaxLength(1);

                entity.Property(e => e.VisibilityInd).HasMaxLength(1);

                entity.Property(e => e.WebObjectNm)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.WebObjectType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WizardInd)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'::bpchar");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Wwid)
                    .HasName("Worker_pkey");

                entity.ToTable("Worker", "DADT");

                entity.HasIndex(e => e.CcmailNm, "DADT.Ref3028");

                entity.HasIndex(e => e.Idsid, "DADT.Ref3029");

                entity.HasIndex(e => e.DepartmentCd, "DADT.Ref725");

                entity.Property(e => e.Wwid).HasMaxLength(11);

                entity.Property(e => e.CcmailNm)
                    .HasMaxLength(80)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ChangeAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChangeDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.CorporateEmailTxt)
                    .HasMaxLength(80)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.CostCenterCd)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.CreateAgentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreateDtm).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.DepartmentCd)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DepartmentNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.DivisionLongNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.FirstNm)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FullNm)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.GroupLongNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.Idsid)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ManagerFullNm)
                    .HasMaxLength(65)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.ManagerWwid)
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.NickNm)
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.PersonStatusTypeCd).HasMaxLength(1);

                entity.Property(e => e.SuperGroupCd)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.SuperGroupLongNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.WorkLocationBuildingNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.WorkLocationCountryNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.WorkLocationSiteNm)
                    .HasMaxLength(150)
                    .HasDefaultValueSql("NULL::character varying");

                entity.HasOne(d => d.DepartmentCdNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.DepartmentCd)
                    .HasConstraintName("RefDepartment25");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

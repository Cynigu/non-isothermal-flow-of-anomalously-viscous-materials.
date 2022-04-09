﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgramSystem.Data.Repository;

#nullable disable

namespace ProgramSystem.Data.Repository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220409220202_migr2")]
    partial class migr2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("ProgramSystem.Data.Models.CanalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Canals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Канал1"
                        });
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.MaterialEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Полипропилен"
                        });
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.ParameterEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeParameter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitOfMeasId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UnitOfMeasId");

                    b.ToTable("Parameters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ширина, W",
                            TypeParameter = "Геометрические параметры канала",
                            UnitOfMeasId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Длина, H",
                            TypeParameter = "Геометрические параметры канала",
                            UnitOfMeasId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Глубина, L",
                            TypeParameter = "Геометрические параметры канала",
                            UnitOfMeasId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Плотность, ρ",
                            TypeParameter = "Параметры свойств материала",
                            UnitOfMeasId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Удельная теплоемкость, c",
                            TypeParameter = "Параметры свойств материала",
                            UnitOfMeasId = 3
                        },
                        new
                        {
                            Id = 6,
                            Name = "Температура плавления, T0",
                            TypeParameter = "Параметры свойств материала",
                            UnitOfMeasId = 4
                        },
                        new
                        {
                            Id = 7,
                            Name = "Скорость крышки, Vu",
                            TypeParameter = "Режимные параметры процессаа",
                            UnitOfMeasId = 5
                        },
                        new
                        {
                            Id = 8,
                            Name = "Температура крышки, Tu",
                            TypeParameter = "Режимные параметры процесса",
                            UnitOfMeasId = 4
                        },
                        new
                        {
                            Id = 9,
                            Name = "Коэффициент консистенции материала при температуре приведения, μ0",
                            TypeParameter = "Эмпирические коэффициенты математической модели",
                            UnitOfMeasId = 6
                        },
                        new
                        {
                            Id = 10,
                            Name = "Температурный коэффициент вязкости материала, b",
                            TypeParameter = "Эмпирические коэффициенты математической модели",
                            UnitOfMeasId = 7
                        },
                        new
                        {
                            Id = 11,
                            Name = "Температура приведения, Tr",
                            TypeParameter = "Эмпирические коэффициенты математической модели",
                            UnitOfMeasId = 4
                        },
                        new
                        {
                            Id = 12,
                            Name = "Индекс течения материала, n",
                            TypeParameter = "Эмпирические коэффициенты математической модели",
                            UnitOfMeasId = 9
                        },
                        new
                        {
                            Id = 13,
                            Name = "Коэффициент теплоотдачи от крышки канала к материалу, Tu",
                            TypeParameter = "Эмпирические коэффициенты математической модели",
                            UnitOfMeasId = 8
                        });
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.ParameterMaterialCanalEntity", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParameterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CanalId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("MaterialId", "ParameterId", "CanalId");

                    b.HasIndex("CanalId");

                    b.HasIndex("ParameterId");

                    b.ToTable("ParameterValues");

                    b.HasData(
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 1,
                            CanalId = 1,
                            Value = 0.2f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 2,
                            CanalId = 1,
                            Value = 0.003f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 3,
                            CanalId = 1,
                            Value = 7.5f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 4,
                            CanalId = 1,
                            Value = 900f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 5,
                            CanalId = 1,
                            Value = 2230f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 6,
                            CanalId = 1,
                            Value = 172f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 7,
                            CanalId = 1,
                            Value = 1.5f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 8,
                            CanalId = 1,
                            Value = 180f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 9,
                            CanalId = 1,
                            Value = 1500f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 10,
                            CanalId = 1,
                            Value = 0.014f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 11,
                            CanalId = 1,
                            Value = 185f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 12,
                            CanalId = 1,
                            Value = 0.38f
                        },
                        new
                        {
                            MaterialId = 1,
                            ParameterId = 13,
                            CanalId = 1,
                            Value = 1500f
                        });
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.UnitOfMeasEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UnitsOfMeas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "м"
                        },
                        new
                        {
                            Id = 2,
                            Name = "кг/м^3"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Дж/(кг·°С)"
                        },
                        new
                        {
                            Id = 4,
                            Name = "°С"
                        },
                        new
                        {
                            Id = 5,
                            Name = "м/с"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Па·с^n"
                        },
                        new
                        {
                            Id = 7,
                            Name = "1/°С"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Вт/(м2·°С)"
                        },
                        new
                        {
                            Id = 9,
                            Name = "-"
                        });
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            Password = "admin",
                            Role = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Login = "researcher",
                            Password = "researcher",
                            Role = "researcher"
                        });
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.ParameterEntity", b =>
                {
                    b.HasOne("ProgramSystem.Data.Models.UnitOfMeasEntity", "UnitOfMeas")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnitOfMeas");
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.ParameterMaterialCanalEntity", b =>
                {
                    b.HasOne("ProgramSystem.Data.Models.CanalEntity", "Canal")
                        .WithMany("ParameterMaterialCanal")
                        .HasForeignKey("CanalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgramSystem.Data.Models.MaterialEntity", "Material")
                        .WithMany("ParameterMaterialCanal")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgramSystem.Data.Models.ParameterEntity", "Parameter")
                        .WithMany("ParameterMaterialCanal")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Canal");

                    b.Navigation("Material");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.CanalEntity", b =>
                {
                    b.Navigation("ParameterMaterialCanal");
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.MaterialEntity", b =>
                {
                    b.Navigation("ParameterMaterialCanal");
                });

            modelBuilder.Entity("ProgramSystem.Data.Models.ParameterEntity", b =>
                {
                    b.Navigation("ParameterMaterialCanal");
                });
#pragma warning restore 612, 618
        }
    }
}

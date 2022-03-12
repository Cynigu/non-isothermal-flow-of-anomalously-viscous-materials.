using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Data.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ParameterMaterialCanalEntity> ParameterValues { get; set; } = null!;
        public DbSet<UnitOfMeasEntity> UnitsOfMeas { get; set; } = null!;
        public DbSet<ParameterEntity> Parameters { get; set; } = null!;
        public DbSet<MaterialEntity> Materials { get; set; } = null!;
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<CanalEntity> Canals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity { Id = 1, Login="admin", Password="admin", Role="admin"});
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity { Id = 2, Login = "researcher", Password = "researcher", Role = "researcher" });

            // Единицы измерения
            var unitOfMeasMeter = new UnitOfMeasEntity() {Id = 1, Name = "м"};
            var unitOfMeasKgMeter = new UnitOfMeasEntity() { Id = 2, Name = "кг/м^3" };
            var unitOfMeasDgKgC = new UnitOfMeasEntity() { Id = 3, Name = "Дж/(кг·°С)" };
            var unitOfMeasC = new UnitOfMeasEntity() { Id = 4, Name = "°С" };
            var unitOfMeasMC = new UnitOfMeasEntity() { Id = 5, Name = "м/с" };
            var unitOfMeasPaC = new UnitOfMeasEntity() { Id = 6, Name = "Па·с^n" };
            var unitOfMeasOneOnC = new UnitOfMeasEntity() { Id = 7, Name = "1/°С" };
            var unitOfMeasBtMC = new UnitOfMeasEntity() { Id = 8, Name = "Вт/(м2·°С)" };

            modelBuilder.Entity<UnitOfMeasEntity>().HasData(unitOfMeasMeter, unitOfMeasKgMeter, unitOfMeasDgKgC, unitOfMeasC, 
                unitOfMeasMC, unitOfMeasPaC, unitOfMeasOneOnC, unitOfMeasBtMC, new UnitOfMeasEntity(){Id=9, Name = "-"});
            modelBuilder.Entity<MaterialEntity>().HasData(new List<MaterialEntity>()
            {
                new(){Id = 1, Name = "Полипропилен"}
            });
            modelBuilder.Entity<CanalEntity>().HasData(new List<CanalEntity>()
            {
                new(){Id = 1, Name = "Канал1"}
            });

            modelBuilder.Entity<ParameterEntity>().HasData(
                new(){Id = 1, UnitOfMeasId = 1, Name = "Ширина, W", TypeParameter = "Геометрические параметры канала"},
                new(){Id = 2, UnitOfMeasId = 1, Name = "Длина, H", TypeParameter = "Геометрические параметры канала"}, 
                new(){Id = 3, UnitOfMeasId = 1, Name = "Глубина, L", TypeParameter = "Геометрические параметры канала"}, 
                new(){Id = 4, UnitOfMeasId = 2, Name = "Плотность, ρ", TypeParameter = "Параметры свойств материала"},
                new(){Id = 5, UnitOfMeasId = 3, Name = "Удельная теплоемкость, c", TypeParameter = "Параметры свойств материала"}, 
                new(){Id = 6, UnitOfMeasId = 4, Name = "Температура плавления, T0", TypeParameter = "Параметры свойств материала"}, 
                new(){Id = 7, UnitOfMeasId = 5, Name = "Скорость крышки, Vu", TypeParameter = "Режимные параметры процессаа"}, 
                new(){Id = 8, UnitOfMeasId = 4, Name = "Температура крышки, Tu", TypeParameter = "Режимные параметры процесса"}, 
                new(){Id = 9, UnitOfMeasId = 6, Name = "Коэффициент консистенции материала при температуре приведения, μ0", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
                new(){Id = 10, UnitOfMeasId = 7, Name = "Температурный коэффициент вязкости материала, b", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
                new(){Id = 11, UnitOfMeasId = 4, Name = "Температура приведения, Tr", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
                new(){Id = 12, UnitOfMeasId = 9, Name = "Индекс течения материала, n", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
                new(){Id = 13, UnitOfMeasId = 8, Name = "Коэффициент теплоотдачи от крышки канала к материалу, Tu", TypeParameter = "Эмпирические коэффициенты математической модели"});

            modelBuilder.Entity<ParameterMaterialCanalEntity>().HasData(
                new(){CanalId = 1, MaterialId = 1, ParameterId = 1, Value = 0.2f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 2, Value = 0.003f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 3, Value = 7.5f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 4, Value = 900f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 5, Value = 2230f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 6, Value = 172f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 7, Value = 1.5f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 8, Value = 180f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 9, Value = 1500f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 10, Value = 0.014f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 11, Value = 185f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 12, Value = 0.38f}, 
                new(){CanalId = 1, MaterialId = 1, ParameterId = 13, Value = 1500f});

            // Ключи
            modelBuilder.Entity<ParameterMaterialCanalEntity>()
                .HasKey(t => new { t.MaterialId, t.ParameterId, t.CanalId });

            modelBuilder.Entity<ParameterMaterialCanalEntity>()
                .HasOne(pt => pt.Material)
                .WithMany(p => p.ParameterMaterialCanal)
                .HasForeignKey(pt => pt.MaterialId);

            modelBuilder.Entity<ParameterMaterialCanalEntity>()
                .HasOne(pt => pt.Parameter)
                .WithMany(t => t.ParameterMaterialCanal)
                .HasForeignKey(pt => pt.ParameterId);

            modelBuilder.Entity<ParameterMaterialCanalEntity>()
                .HasOne(pt => pt.Canal)
                .WithMany(t => t.ParameterMaterialCanal)
                .HasForeignKey(pt => pt.CanalId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
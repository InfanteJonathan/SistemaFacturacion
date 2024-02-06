using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaFacturacion.DATA.Models;

public partial class SisFactContext : DbContext
{
    public SisFactContext()
    {
    }

    public SisFactContext(DbContextOptions<SisFactContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FamiliaProducto> FamiliaProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=INFANTE;Database=SIS_FACT;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.IdItem).HasName("PK__DetalleF__51E842628417FA0F");

            entity.ToTable("DetalleFactura");

            entity.Property(e => e.IdItem)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Precio]*[Cantidad])", false)
                .HasColumnType("decimal(21, 2)");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK__DetalleFa__IdFac__531856C7");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetalleFa__idPro__540C7B00");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__Factura__50E7BAF1BF5CE5CD");

            entity.ToTable("Factura");

            entity.HasIndex(e => e.NumeroFactura, "UQ__Factura__CF12F9A600D71F16").IsUnique();

            entity.Property(e => e.Igv)
                .HasComputedColumnSql("([Subtotal]*[PorcentajeIGV])", false)
                .HasColumnType("decimal(15, 4)")
                .HasColumnName("IGV");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PorcentajeIgv)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("PorcentajeIGV");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RucCliente)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total)
                .HasComputedColumnSql("([SubTotal]+[SubTotal]*[PorcentajeIGV])", false)
                .HasColumnType("decimal(16, 4)");
        });

        modelBuilder.Entity<FamiliaProducto>(entity =>
        {
            entity.HasKey(e => e.IdFamilia).HasName("PK__FamiliaP__751F80CF1CFA381E");

            entity.ToTable("FamiliaProducto");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210B9FB5B16");

            entity.ToTable("Producto");

            entity.HasIndex(e => e.Codigo, "UQ__Producto__06370DAC77BC7116").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Codigo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Imagen)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdFamiliaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdFamilia)
                .HasConstraintName("FK__Producto__IdFami__489AC854");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__usuario__1788CC4C21672D48");

            entity.ToTable("usuario");

            entity.Property(e => e.Contrasenia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using DSR_MAGALU_DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSR_MAGALU_DATA.Context.MappingTables
{
    public class ClienteMapping: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Tabela
            builder.ToTable("Cliente");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Propriedades
            builder.Property(x => x.NomeClienteRazaoSocial)
                .IsRequired()
                .HasColumnName("nome_razao_social")
                .HasMaxLength(150);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(150);

            builder.Property(x => x.Telefone)
                .IsRequired()
                .HasColumnName("telefone")
                .HasMaxLength(11);

            builder.Property(x => x.DataCadastro)
                .IsRequired()
                .HasColumnName("data_cadastro");

            builder.Property(x => x.TipoPessoa)
                .IsRequired()
                .HasColumnName("tipo_pessoa");

            builder.Property(x => x.Documento)
                .IsRequired()
                .HasColumnName("documento")
                .HasMaxLength(14);

            builder.Property(x => x.InscricaoEstadual)
                .HasColumnName("inscricao_estadual")
                .HasMaxLength(12);

            builder.Property(x => x.Isento)
                .HasColumnName("isento");

            builder.Property(x => x.Genero)
                .IsRequired()
                .HasColumnName("genero");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnName("data_nascimento");

            builder.Property(x => x.Bloqueado)
                .IsRequired()
                .HasColumnName("bloqueado");

            builder.Property(x => x.Senha)
                .HasColumnName("senha")
                .HasMaxLength(250);

            // Índices
            builder.HasIndex(x => x.Documento, "IX_Cliente_Documento")
                .IsUnique();

            builder.HasIndex(x => x.InscricaoEstadual, "IX_Cliente_InscricaoEstadual")
                .IsUnique();
        }
    }
}

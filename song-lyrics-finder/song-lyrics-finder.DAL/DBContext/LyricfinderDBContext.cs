using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using song_lyrics_finder.MODEL;

namespace song_lyrics_finder.DAL.DBContext;

public partial class LyricfinderDBContext : DbContext
{
    public LyricfinderDBContext()
    {
    }

    public LyricfinderDBContext(DbContextOptions<LyricfinderDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSong> UserSongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\danli\\OneDrive\\Documentos\\personal\\projects\\backend-song-lyrics-finder\\song-lyrics-finder\\song-lyrics-finder.DAL\\Database\\LyricFinderDB.mdf; Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Song__A5309984ED2CD6FE");

            entity.ToTable("Song");

            entity.HasIndex(e => e.SongApiId, "UQ__Song__E95567F714FE5E2A").IsUnique();

            entity.Property(e => e.SongId).HasColumnName("song_Id");
            entity.Property(e => e.SongApiId).HasColumnName("song_api_Id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BF3327132C2DFB");

            entity.ToTable("User");

            entity.HasIndex(e => e.Nickname, "UQ__User__5CF1C59BBEEF7216").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__AB6E61649FFE03D0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<UserSong>(entity =>
        {
            entity.HasKey(e => e.UserSongId).HasName("PK__User_Son__B04F129E69BCFE0B");

            entity.ToTable("User_Song");

            entity.Property(e => e.UserSongId).HasColumnName("user_song_Id");
            entity.Property(e => e.SongId).HasColumnName("song_Id");
            entity.Property(e => e.UserId).HasColumnName("user_Id");

            entity.HasOne(d => d.Song).WithMany(p => p.UserSongs)
                .HasForeignKey(d => d.SongId)
                .HasConstraintName("FK__User_Song__song___3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.UserSongs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__User_Song__user___3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

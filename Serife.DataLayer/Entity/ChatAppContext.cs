using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Serife.DataLayer;

namespace Serife.DataLayer.Entity
{
    public partial class ChatAppContext : DbContext
    {
        public ChatAppContext()
        {
        }

        public ChatAppContext(DbContextOptions<ChatAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Complain> Complains { get; set; } = null!;
        public virtual DbSet<ComplainStatus> ComplainStatuses { get; set; } = null!;
        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<FriendStatus> FriendStatuses { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupMember> GroupMembers { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ChatApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complain>(entity =>
            {
                entity.ToTable("Complain");

                entity.Property(e => e.ComplainId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ComplainID");

                entity.Property(e => e.ComplainDate).HasColumnType("datetime");

                entity.Property(e => e.ComplainStatusId).HasColumnName("ComplainStatusID");

                entity.Property(e => e.ComplainantUserId).HasColumnName("ComplainantUserID");

                entity.Property(e => e.ComplainedOfUserId).HasColumnName("ComplainedOfUserID");

                entity.Property(e => e.MessageReferenceId).HasColumnName("MessageReferenceID");

                entity.HasOne(d => d.ComplainNavigation)
                    .WithOne(p => p.ComplainComplainNavigation)
                    .HasForeignKey<Complain>(d => d.ComplainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplainedOf_UserID");

                entity.HasOne(d => d.ComplainStatus)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.ComplainStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComplainStatusID");

                entity.HasOne(d => d.ComplainantUser)
                    .WithMany(p => p.ComplainComplainantUsers)
                    .HasForeignKey(d => d.ComplainantUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Complainand_UserID");

                entity.HasOne(d => d.MessageReference)
                    .WithMany(p => p.Complains)
                    .HasForeignKey(d => d.MessageReferenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageReferenceID");
            });

            modelBuilder.Entity<ComplainStatus>(entity =>
            {
                entity.ToTable("ComplainStatus");

                entity.Property(e => e.ComplainStatusId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ComplainStatusID");

                entity.Property(e => e.ComplainDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("Friend");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.FriendStatusId).HasColumnName("FriendStatusID");

                entity.Property(e => e.RequestedDate).HasColumnType("datetime");

                entity.Property(e => e.RequestedUserId).HasColumnName("RequestedUserID");

                entity.Property(e => e.RequesterUserId).HasColumnName("RequesterUserID");

                entity.HasOne(d => d.FriendStatus)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.FriendStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendStatusID");

                entity.HasOne(d => d.RequestedUser)
                    .WithMany(p => p.FriendRequestedUsers)
                    .HasForeignKey(d => d.RequestedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestedUserID");

                entity.HasOne(d => d.RequesterUser)
                    .WithMany(p => p.FriendRequesterUsers)
                    .HasForeignKey(d => d.RequesterUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequesterUserID");
            });

            modelBuilder.Entity<FriendStatus>(entity =>
            {
                entity.ToTable("FriendStatus");

                entity.Property(e => e.FriendStatusId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FriendStatusID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreaterUserId).HasColumnName("CreaterUserID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupProfilePhoto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreaterUser)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CreaterUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_CreaterUserID");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.ToTable("GroupMember");

                entity.Property(e => e.GroupMemberId).HasColumnName("GroupMemberID");

                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.AddedUserId).HasColumnName("AddedUserID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.AddedUser)
                    .WithMany(p => p.GroupMemberAddedUsers)
                    .HasForeignKey(d => d.AddedUserId)
                    .HasConstraintName("FK_GroupMember_AddedUserID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMember_GroupID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMemberUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMember_UserID");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.MessageContent).HasColumnType("text");

                entity.Property(e => e.ReadDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverId).HasColumnName("RecieverID");

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Message_GroupID");

                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.MessageRecievers)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK_Message_RecieverID");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_SenderID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserId, "UK_Email")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UK_Username")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePhoto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

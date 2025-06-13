using Microsoft.EntityFrameworkCore;
using Kolokwium2.Models;

namespace Kolokwium2.Data;


public class EventsDbContext :DbContext
{
    public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<EventTag> EventTags { get; set; }
    public DbSet<EventParticipant> EventParticipants { get; set; }

    protected override void OneModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTag>()
            .HasKey(et => new { et.EventId, et.TagId });
        modelBuilder.Entity<EventTag()
            .HasOne(et=>et.Event)
            .WithMany(e=>e.EventTags)
            .HasForeignKey(et=>et.EventId);
        modelBuilder.Entity<EventTag>()
            .HasOne(et=>et.Event)
            .WithMany(t=>t.EventTags)
            .HasForeignKey(et=>et.EventId);
        modelBuilder.Entity<EventParticipants>()
            .HasKey(et => new { ep.EventId, ep.UserId });
        modelBuilder.Entity<EventParticipants>()
            .HasOne(et=>et.Event)
            .WithMany(e=>e.EventParticipants)
            .HasForeignKey(et=>et.EventId);
        modelBuilder.Entity<EventParticipants>()
            .HasOne(ep => ep.User)
            .WithMany(u => u.EventParticipants)
            .HasForeignKey(ep => ep.UserId);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Organizer)
            .WithMany()
            .HasForeignKey(e => e.OrganizerId);
    }
}
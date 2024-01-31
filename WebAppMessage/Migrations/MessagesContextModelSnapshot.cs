﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAppMessage;

#nullable disable

namespace WebAppMessage.Migrations
{
    [DbContext(typeof(MessagesContext))]
    partial class MessagesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAppMessage.Model.MessagesDB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsReceived")
                        .HasColumnType("boolean");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id")
                        .HasName("message_pkey");

                    b.ToTable("messages", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

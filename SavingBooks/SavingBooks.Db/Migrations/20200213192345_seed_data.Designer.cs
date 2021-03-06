﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20200213192345_seed_data")]
    partial class seed_data
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DB.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 14,
                            Description = "This short novel is perfect for EFL learners. It has modern themes and typical teenage issues that people around the world have experienced. There are very few cultural notes in this, which means you don’t need much background information. The sentences are short and easy to understand. The vocabulary is also very easy. You should be able to read this book without difficulty.",
                            Name = "The Outsiders – S.E. Hinton",
                            PageAmount = 234,
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1967)
                        },
                        new
                        {
                            BookId = 13,
                            Description = "The great thing about “The House On Mango Street” is that it’s an interesting read. It’s written from the point of view of the writer. You can really feel what the protagonist (the main character) feels. The sentences are really short so it’s also easy to understand. There are a few challenging words and a little bit of descriptive language, but you can usually understand them with the context. Another great thing about this is book is that it gives you a deep understanding of a different culture.",
                            Name = "The House On Mango Street – Sandra Cisneros",
                            PageAmount = 103,
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1983)
                        },
                        new
                        {
                            BookId = 12,
                            Description = "This story takes place in the present, which means the writer writes using simple grammar. All sentences are short and the vocabulary is relatively easy. The interesting grammar and short paragraphs make this a quick and easy book for ESL learners. This is an award-winning book and on the NY Times best books list, so it’s worth a read. This book deals with some heavy issues. If you’re looking for something light and happy to read over the summer vacation, you should not read this book.",
                            Name = "Thirteen Reasons Why – Jay Asher",
                            PageAmount = 288,
                            PublicationDate = new DateTime(2007, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            BookId = 11,
                            Description = "Almost everyone knows the story of “Peter Pan” which is why this is an easy read. Being familiar with a story already helps the reader to understand the text better. This book is aimed at children, but it continues to be enjoyed by adults around the world too.",
                            Name = "Peter Pan – J.M. Barrie",
                            PageAmount = 132,
                            PublicationDate = new DateTime(1904, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            BookId = 10,
                            Description = "This is a famous classic. Almost all native English speakers will have read this book at some point in school. So, if you ever find yourself in a conversation about literature and books, this is a good one to talk about. At some points it has a little bit of difficult vocabulary, however, it is short and you won’t have too much trouble being able to finish it.",
                            Name = "The Old Man and the Sea – Ernest Hemmingway",
                            PageAmount = 127,
                            PublicationDate = new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

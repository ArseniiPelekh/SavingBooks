using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Description", "Name", "PageAmount", "PublicationDate" },
                values: new object[,]
                {
                    { 14, "This short novel is perfect for EFL learners. It has modern themes and typical teenage issues that people around the world have experienced. There are very few cultural notes in this, which means you don’t need much background information. The sentences are short and easy to understand. The vocabulary is also very easy. You should be able to read this book without difficulty.", "The Outsiders – S.E. Hinton", 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1967) },
                    { 13, "The great thing about “The House On Mango Street” is that it’s an interesting read. It’s written from the point of view of the writer. You can really feel what the protagonist (the main character) feels. The sentences are really short so it’s also easy to understand. There are a few challenging words and a little bit of descriptive language, but you can usually understand them with the context. Another great thing about this is book is that it gives you a deep understanding of a different culture.", "The House On Mango Street – Sandra Cisneros", 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1983) },
                    { 12, "This story takes place in the present, which means the writer writes using simple grammar. All sentences are short and the vocabulary is relatively easy. The interesting grammar and short paragraphs make this a quick and easy book for ESL learners. This is an award-winning book and on the NY Times best books list, so it’s worth a read. This book deals with some heavy issues. If you’re looking for something light and happy to read over the summer vacation, you should not read this book.", "Thirteen Reasons Why – Jay Asher", 288, new DateTime(2007, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Almost everyone knows the story of “Peter Pan” which is why this is an easy read. Being familiar with a story already helps the reader to understand the text better. This book is aimed at children, but it continues to be enjoyed by adults around the world too.", "Peter Pan – J.M. Barrie", 132, new DateTime(1904, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "This is a famous classic. Almost all native English speakers will have read this book at some point in school. So, if you ever find yourself in a conversation about literature and books, this is a good one to talk about. At some points it has a little bit of difficult vocabulary, however, it is short and you won’t have too much trouble being able to finish it.", "The Old Man and the Sea – Ernest Hemmingway", 127, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14);
        }
    }
}

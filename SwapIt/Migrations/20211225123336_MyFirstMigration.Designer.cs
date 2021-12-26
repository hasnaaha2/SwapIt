﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwapIt.Models;

namespace SwapIt.Migrations
{
    [DbContext(typeof(ApplicationDB))]
    [Migration("20211225123336_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SwapIt.Models.Cart", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint")
                        .HasColumnName("quantity");

                    b.HasKey("UserId", "ProductId")
                        .HasName("PK__Cart__FDCE10D04066243B");

                    b.HasIndex("ProductId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("SwapIt.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryImage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category_image");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SwapIt.Models.CategoryDepartment", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("department_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("department_name");

                    b.HasKey("DepartmentId")
                        .HasName("PK__Category__C22324221289DFF8");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryDepartment");
                });

            modelBuilder.Entity("SwapIt.Models.Chat", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("message_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("from_id");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("date")
                        .HasColumnName("message_date");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message_text");

                    b.Property<TimeSpan>("MessageTime")
                        .HasColumnType("time")
                        .HasColumnName("message_time");

                    b.Property<string>("ToId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("to_id");

                    b.HasKey("MessageId")
                        .HasName("PK__Chat__0BBF6EE60384159D");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("SwapIt.Models.Creditcard", b =>
                {
                    b.Property<string>("CreditCardNumber")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("credit_card_number");

                    b.Property<string>("CreditCardExpireddate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("credit_card_expireddate");

                    b.Property<string>("CreditCardName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("credit_card_name");

                    b.Property<string>("CreditCardPassword")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .HasColumnName("credit_card_password")
                        .IsFixedLength(true);

                    b.HasKey("CreditCardNumber")
                        .HasName("PK__Creditca__252A27B11EDAB5BE");

                    b.ToTable("Creditcard");
                });

            modelBuilder.Entity("SwapIt.Models.Favourite", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("UserId", "ProductId")
                        .HasName("PK__Favourit__FDCE10D0A0C99F24");

                    b.HasIndex("ProductId");

                    b.ToTable("Favourite");
                });

            modelBuilder.Entity("SwapIt.Models.OrderInformation", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK__OrderInf__022945F6A4F3950A");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderInformation");
                });

            modelBuilder.Entity("SwapIt.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("department_id");

                    b.Property<bool?>("Forsell")
                        .HasColumnType("bit")
                        .HasColumnName("forsell");

                    b.Property<bool?>("Forswap")
                        .HasColumnType("bit")
                        .HasColumnName("forswap");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("text")
                        .HasColumnName("product_description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("product_name");

                    b.Property<short>("ProductPrice")
                        .HasColumnType("smallint")
                        .HasColumnName("product_price");

                    b.Property<short>("ProductQuantity")
                        .HasColumnType("smallint")
                        .HasColumnName("product_quantity");

                    b.Property<string>("ProductSize")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("product_size");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("ProductId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SwapIt.Models.ProductImage", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("ProductImage1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("product_image");

                    b.HasKey("ProductId", "ProductImage1")
                        .HasName("PK__ProductI__2B90AE2090A7DA7C");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("SwapIt.Models.ProductReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("review_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("from_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("date")
                        .HasColumnName("review_date");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("review_text");

                    b.Property<TimeSpan>("ReviewTime")
                        .HasColumnType("time")
                        .HasColumnName("review_time");

                    b.HasKey("ReviewId")
                        .HasName("PK__ProductR__60883D90CDCD92DD");

                    b.HasIndex("FromId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductReview");
                });

            modelBuilder.Entity("SwapIt.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SwapIt.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("city");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("county");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("street");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserImage")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("user_image");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SwapIt.Models.UserFollowing", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<string>("FollowingId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("following_id");

                    b.HasKey("UserId", "FollowingId")
                        .HasName("PK__UserFoll__3731838785EAFA86");

                    b.HasIndex("FollowingId");

                    b.ToTable("UserFollowing");
                });

            modelBuilder.Entity("SwapIt.Models.UserOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("order_status");

                    b.Property<TimeSpan>("OrderTime")
                        .HasColumnType("time")
                        .HasColumnName("order_time");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("order_type");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.HasKey("OrderId")
                        .HasName("PK__UserOrde__465962292573C486");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrder");
                });

            modelBuilder.Entity("SwapIt.Models.UserRating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("rating_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("from_id");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint")
                        .HasColumnName("rating");

                    b.Property<string>("ToId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("to_id");

                    b.HasKey("RatingId")
                        .HasName("PK__UserRati__D35B278B961C59B2");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("UserRating");
                });

            modelBuilder.Entity("SwapIt.Models.UserReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("review_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("from_id");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("date")
                        .HasColumnName("review_date");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("review_text");

                    b.Property<TimeSpan>("ReviewTime")
                        .HasColumnType("time")
                        .HasColumnName("review_time");

                    b.Property<string>("ToId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("to_id");

                    b.HasKey("ReviewId")
                        .HasName("PK__UserRevi__60883D90B322FA52");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("UserReview");
                });

            modelBuilder.Entity("SwapIt.Models.UsersAndCard", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_id");

                    b.Property<string>("CreditCardNumber")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("credit_card_number");

                    b.HasKey("UserId", "CreditCardNumber")
                        .HasName("PK__UsersAnd__BBEC957436E08C0A");

                    b.HasIndex("CreditCardNumber");

                    b.ToTable("UsersAndCards");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SwapIt.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SwapIt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SwapIt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("SwapIt.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwapIt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SwapIt.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwapIt.Models.Cart", b =>
                {
                    b.HasOne("SwapIt.Models.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Cart__product_id__6E01572D")
                        .IsRequired();

                    b.HasOne("SwapIt.Models.User", "User")
                        .WithMany("Carts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Cart__user_id__6D0D32F4")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwapIt.Models.CategoryDepartment", b =>
                {
                    b.HasOne("SwapIt.Models.Category", "Category")
                        .WithMany("CategoryDepartments")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__CategoryD__categ__5441852A")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SwapIt.Models.Chat", b =>
                {
                    b.HasOne("SwapIt.Models.User", "From")
                        .WithMany("ChatFroms")
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK__Chat__from_id__693CA210");

                    b.HasOne("SwapIt.Models.User", "To")
                        .WithMany("ChatTos")
                        .HasForeignKey("ToId")
                        .HasConstraintName("FK__Chat__to_id__6A30C649");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("SwapIt.Models.Favourite", b =>
                {
                    b.HasOne("SwapIt.Models.Product", "Product")
                        .WithMany("Favourites")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Favourite__produ__71D1E811")
                        .IsRequired();

                    b.HasOne("SwapIt.Models.User", "User")
                        .WithMany("Favourites")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Favourite__user___70DDC3D8")
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwapIt.Models.OrderInformation", b =>
                {
                    b.HasOne("SwapIt.Models.UserOrder", "Order")
                        .WithMany("OrderInformations")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderInfo__order__7B5B524B")
                        .IsRequired();

                    b.HasOne("SwapIt.Models.Product", "Product")
                        .WithMany("OrderInformations")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderInfo__produ__7C4F7684")
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SwapIt.Models.Product", b =>
                {
                    b.HasOne("SwapIt.Models.CategoryDepartment", "Department")
                        .WithMany("Products")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Product__departm__5812160E")
                        .IsRequired();

                    b.HasOne("SwapIt.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Product__user_id__571DF1D5");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwapIt.Models.ProductImage", b =>
                {
                    b.HasOne("SwapIt.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ProductIm__produ__5AEE82B9")
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SwapIt.Models.ProductReview", b =>
                {
                    b.HasOne("SwapIt.Models.User", "From")
                        .WithMany("ProductReviews")
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK__ProductRe__from___5DCAEF64");

                    b.HasOne("SwapIt.Models.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ProductRe__produ__5EBF139D")
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SwapIt.Models.UserFollowing", b =>
                {
                    b.HasOne("SwapIt.Models.User", "Following")
                        .WithMany("UserFollowingFollowings")
                        .HasForeignKey("FollowingId")
                        .HasConstraintName("FK__UserFollo__follo__75A278F5")
                        .IsRequired();

                    b.HasOne("SwapIt.Models.User", "User")
                        .WithMany("UserFollowingUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UserFollo__user___74AE54BC")
                        .IsRequired();

                    b.Navigation("Following");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwapIt.Models.UserOrder", b =>
                {
                    b.HasOne("SwapIt.Models.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UserOrder__user___787EE5A0");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwapIt.Models.UserRating", b =>
                {
                    b.HasOne("SwapIt.Models.User", "From")
                        .WithMany("UserRatingFroms")
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK__UserRatin__from___656C112C");

                    b.HasOne("SwapIt.Models.User", "To")
                        .WithMany("UserRatingTos")
                        .HasForeignKey("ToId")
                        .HasConstraintName("FK__UserRatin__to_id__66603565");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("SwapIt.Models.UserReview", b =>
                {
                    b.HasOne("SwapIt.Models.User", "From")
                        .WithMany("UserReviewFroms")
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK__UserRevie__from___619B8048");

                    b.HasOne("SwapIt.Models.User", "To")
                        .WithMany("UserReviewTos")
                        .HasForeignKey("ToId")
                        .HasConstraintName("FK__UserRevie__to_id__628FA481");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("SwapIt.Models.UsersAndCard", b =>
                {
                    b.HasOne("SwapIt.Models.Creditcard", "CreditCardNumberNavigation")
                        .WithMany("UsersAndCards")
                        .HasForeignKey("CreditCardNumber")
                        .HasConstraintName("FK__UsersAndC__credi__4F7CD00D")
                        .IsRequired();

                    b.HasOne("SwapIt.Models.User", "User")
                        .WithMany("UsersAndCards")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UsersAndC__user___4E88ABD4")
                        .IsRequired();

                    b.Navigation("CreditCardNumberNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SwapIt.Models.Category", b =>
                {
                    b.Navigation("CategoryDepartments");
                });

            modelBuilder.Entity("SwapIt.Models.CategoryDepartment", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SwapIt.Models.Creditcard", b =>
                {
                    b.Navigation("UsersAndCards");
                });

            modelBuilder.Entity("SwapIt.Models.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Favourites");

                    b.Navigation("OrderInformations");

                    b.Navigation("ProductImages");

                    b.Navigation("ProductReviews");
                });

            modelBuilder.Entity("SwapIt.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("ChatFroms");

                    b.Navigation("ChatTos");

                    b.Navigation("Favourites");

                    b.Navigation("ProductReviews");

                    b.Navigation("Products");

                    b.Navigation("UserFollowingFollowings");

                    b.Navigation("UserFollowingUsers");

                    b.Navigation("UserOrders");

                    b.Navigation("UserRatingFroms");

                    b.Navigation("UserRatingTos");

                    b.Navigation("UserReviewFroms");

                    b.Navigation("UserReviewTos");

                    b.Navigation("UsersAndCards");
                });

            modelBuilder.Entity("SwapIt.Models.UserOrder", b =>
                {
                    b.Navigation("OrderInformations");
                });
#pragma warning restore 612, 618
        }
    }
}

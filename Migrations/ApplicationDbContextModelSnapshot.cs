﻿// <auto-generated />
using System;
using ApiScrabble.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiCookingRecipe.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiScrabble.Entities.Food", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("foods");
                });

            modelBuilder.Entity("ApiScrabble.Entities.Opinion", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("grade")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("recipe_id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("user_id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("recipe_id");

                    b.HasIndex("userid");

                    b.ToTable("opinions");
                });

            modelBuilder.Entity("ApiScrabble.Entities.Recipe", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("nb_people")
                        .HasColumnType("int");

                    b.Property<int?>("preparation_time")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("user_id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("recipes");
                });

            modelBuilder.Entity("ApiScrabble.Entities.RecipeStep", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("position")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("recipe_id")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.HasIndex("recipe_id");

                    b.ToTable("recipeSteps");
                });

            modelBuilder.Entity("ApiScrabble.Entities.RecipeStepFood", b =>
                {
                    b.Property<int?>("recipe_step_id")
                        .HasColumnType("int");

                    b.Property<int?>("food_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<float?>("quantity")
                        .HasColumnType("float");

                    b.Property<int?>("unit_measure_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("recipe_step_id", "food_id");

                    b.HasIndex("food_id");

                    b.HasIndex("unit_measure_id");

                    b.ToTable("recipeStepFoods");
                });

            modelBuilder.Entity("ApiScrabble.Entities.UnitMeasure", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("abreviation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.ToTable("unitMeasures");
                });

            modelBuilder.Entity("ApiScrabble.Entities.User", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ApiScrabble.Entities.Opinion", b =>
                {
                    b.HasOne("ApiScrabble.Entities.Recipe", "recipe")
                        .WithMany("opinions")
                        .HasForeignKey("recipe_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiScrabble.Entities.User", "user")
                        .WithMany("opinions")
                        .HasForeignKey("userid");

                    b.Navigation("recipe");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ApiScrabble.Entities.Recipe", b =>
                {
                    b.HasOne("ApiScrabble.Entities.User", "user")
                        .WithMany("recipes")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ApiScrabble.Entities.RecipeStep", b =>
                {
                    b.HasOne("ApiScrabble.Entities.Recipe", "recipe")
                        .WithMany("recipeSteps")
                        .HasForeignKey("recipe_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("recipe");
                });

            modelBuilder.Entity("ApiScrabble.Entities.RecipeStepFood", b =>
                {
                    b.HasOne("ApiScrabble.Entities.Food", "food")
                        .WithMany("recipeStepFoods")
                        .HasForeignKey("food_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiScrabble.Entities.RecipeStep", "recipe_step")
                        .WithMany("recipeStepFoods")
                        .HasForeignKey("recipe_step_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiScrabble.Entities.UnitMeasure", "unit_measure")
                        .WithMany("recipeStepFoods")
                        .HasForeignKey("unit_measure_id");

                    b.Navigation("food");

                    b.Navigation("recipe_step");

                    b.Navigation("unit_measure");
                });

            modelBuilder.Entity("ApiScrabble.Entities.Food", b =>
                {
                    b.Navigation("recipeStepFoods");
                });

            modelBuilder.Entity("ApiScrabble.Entities.Recipe", b =>
                {
                    b.Navigation("opinions");

                    b.Navigation("recipeSteps");
                });

            modelBuilder.Entity("ApiScrabble.Entities.RecipeStep", b =>
                {
                    b.Navigation("recipeStepFoods");
                });

            modelBuilder.Entity("ApiScrabble.Entities.UnitMeasure", b =>
                {
                    b.Navigation("recipeStepFoods");
                });

            modelBuilder.Entity("ApiScrabble.Entities.User", b =>
                {
                    b.Navigation("opinions");

                    b.Navigation("recipes");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿using BackendProject.App.Categories.Dtos;
using BackendProject.App.Categories.Entities;
using BackendProject.App.Categories.Services.IServices;
using BackendProject.App.Categories.ValueObjects;
using BackendProject.Shared.Abstractions;
using BackendProject.Shared.Abstractions.LanguagedCRUD.Commands.Edit;

namespace BackendProject.App.Categories.Commands.Edit;

public class EditCategoryCommandHandler(ICategoryService service, IUnitOfWork unitOfWork)
    : BaseLanguagedEditCommandHandler<Category, CategoryId, CategoryForm, CategoryDto, EditCategoryCommand>
        (service, unitOfWork);
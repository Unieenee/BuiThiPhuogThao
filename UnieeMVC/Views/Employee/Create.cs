@model UnieeMVC.Models.Person

@{
    ViewData["Title"] = "Create";
}

<h6><b>Create new Person</b></h6>
<form asp-action="Upload" enctype="multipart/form-data">
    <div class="row form-control">
        <label for="file" class="col-sm-2">Upload Excel File: </label>
        <input type="file" name="file" class="col-sm-4" required />
        <input type="submit" value="Upload" class="btn btn-success col-sm-1" />
    </div>
</form>
<hr />
<div class="row">
    <div class="col-md-4">
        <form asp-action="Create">
            <div asp-validation-summary="ModelOnly" class="text-danger"></div>
            <div class="form-group">
                <label asp-for="PersonId" class="control-label"></label>
                <input asp-for="PersonId" class="form-control" />
                <span asp-validation-for="PersonId" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="FullName" class="control-label"></label>
                <input asp-for="FullName" class="form-control" />
                <span asp-validation-for="FullName" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Address" class="control-label"></label>
                <input asp-for="Address" class="form-control" />
                <span asp-validation-for="Address" class="text-danger"></span>
            </div>
            <div class="form-group">
                <input type="submit" value="Create" class="btn btn-primary" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action="Index">Back to List</a>
</div>

@section Scripts {
    @{
        await Html.RenderPartialAsync("_ValidationScriptsPartial");
    }
 }
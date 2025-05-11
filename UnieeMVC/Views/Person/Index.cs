@model IEnumerable<UnieeMVC.Models.Person>

@{
    ViewData["Title"] = "Index";
}

<div class="d-flex justify-content-between w3-small">
    <b>Person List</b>
    <a class="btn btn-success" asp-action="Create">Add new +</a>
</div>
<hr />
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.PersonId)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.FullName)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Address)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Model)
        {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.PersonId)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.FullName)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => item.Address)
                </td>
                <td>
                    <a asp-action="Edit" asp-route-id="@item.PersonId">Edit</a> |
                    <a asp-action="Details" asp-route-id="@item.PersonId">Details</a> |
                    <a asp-action="Delete" asp-route-id="@item.PersonId">Delete</a>
                </td>
            </tr>
        }
    </tbody>
</table>
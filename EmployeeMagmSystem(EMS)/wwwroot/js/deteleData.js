let deleteId = null;

function openDeleteModal(id, name) {
    deleteId = id;
    document.getElementById("deleteMessage").innerText =
        `You’re going to delete “${name}”. Are you sure?`;
    document.getElementById("deleteModal").style.display = "flex";
}

function closeDeleteModal() {
    document.getElementById("deleteModal").style.display = "none";
    deleteId = null;
}

document.addEventListener("DOMContentLoaded", function () {
    const confirmBtn = document.getElementById("confirmDeleteBtn");

    confirmBtn.addEventListener("click", function () {
        if (deleteId) {
            document.getElementById("deleteForm_" + deleteId).submit();
        }
    });

    // Close modal when clicking outside
    window.onclick = function (event) {
        const modal = document.getElementById("deleteModal");
        if (event.target === modal) {
            closeDeleteModal();
        }
    };
});


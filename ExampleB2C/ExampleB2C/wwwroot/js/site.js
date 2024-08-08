// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const dropZone = document.getElementById('drop-zone');
const stagingArea = document.getElementById('stagingArea');
const uploadButton = document.getElementById('upload-button');
let filesArray = [];

// Add event listeners to the drop zone
dropZone.addEventListener('dragover', (event) => {
    event.preventDefault();
    dropZone.classList.add('hover');
});

dropZone.addEventListener('dragleave', () => {
    dropZone.classList.remove('hover');
});

dropZone.addEventListener('drop', (event) => {
    event.preventDefault();
    dropZone.classList.remove('hover');
    filesArray = Array.from(event.dataTransfer.files);
    updateStagingArea();
    dropZone.style.display = 'none'; // Hide the drop zone after files have been added
});

// Add click event to the drop zone to allow users to select files using the file picker
dropZone.addEventListener('click', () => {
    const input = document.createElement('input');
    input.type = 'file';
    input.multiple = true;
    input.onchange = (event) => {
        filesArray = Array.from(event.target.files);
        updateStagingArea();
        dropZone.style.display = 'none'; // Hide the drop zone after files have been added
    };
    input.click();
});

// Update the staging area with the selected files
function updateStagingArea() {
    stagingArea.innerHTML = '';

    filesArray.forEach((file, index) => {
        const fileDiv = document.createElement('div');
        fileDiv.classList.add('mb-1');

        const fileName = document.createElement('span');
        fileName.textContent = file.name;

        const removeButton = document.createElement('button');
        removeButton.textContent = 'Remove';
        removeButton.classList.add('btn', 'btn-danger', 'btn-sm', 'ml-2');
        removeButton.addEventListener('click', () => {
            removeFile(index);
        });

        fileDiv.appendChild(fileName);
        fileDiv.appendChild(removeButton);
        stagingArea.appendChild(fileDiv);
    });
}

// Remove a file from the staging area
function removeFile(index) {
    filesArray.splice(index, 1);
    updateStagingArea();

    // Show the drop zone again if all files have been removed
    if (filesArray.length === 0) {
        dropZone.style.display = 'block';
    }
}

// Upload the files when the upload button is clicked
uploadButton.addEventListener('click', () => {
    const formData = new FormData();
    filesArray.forEach((file) => {
        formData.append('docfiles', file);
    });

    // Send the form data to the server using AJAX
    fetch('/Home/CreateUploadDoc', {
        method: 'POST',
        body: formData,
    })
        .then((response) => {
            // Always redirect to the uploadedDocsView page
            window.location.href = '/Home/UploadedDocsView';
        })
        .catch((error) => console.error(error));
});

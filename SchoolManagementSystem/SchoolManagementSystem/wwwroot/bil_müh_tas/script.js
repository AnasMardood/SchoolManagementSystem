const baseUrl = "https://example.com/api"; // استبدل بعنوان الـ API الفعلي

// جلب بيانات المواد الدراسية من API
function fetchMaterials() {
    const apiUrl = `${baseUrl}/Materials`;
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
            return response.json();
        })
        .then(data => updateMaterialsTable(data))
        .catch(error => console.error("Error fetching materials:", error));
}

// تحديث جدول المواد الدراسية
function updateMaterialsTable(data) {
    const tableBody = document.querySelector("#materials-table tbody");
    tableBody.innerHTML = ""; // تفريغ الجدول
    data.forEach((material, index) => {
        const row = `
            <tr>
                <td>${index + 1}</td>
                <td>${material.lessonsName}</td>
                <td>${material.creditHours}</td>
                <td>${material.classID}</td>
                <td>${material.advisorName}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });
}

// جلب بيانات علامات الطلاب من API
function fetchStudentMarks() {
    const apiUrl = `${baseUrl}/StudentMark`;
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
            return response.json();
        })
        .then(data => updateStudentMarksTable(data))
        .catch(error => console.error("Error fetching student marks:", error));
}

// تحديث جدول علامات الطلاب
function updateStudentMarksTable(data) {
    const tableBody = document.querySelector("#student-marks-table tbody");
    tableBody.innerHTML = ""; // تفريغ الجدول
    data.forEach((mark, index) => {
        const row = `
            <tr>
                <td>${index + 1}</td>
                <td>${mark.studentName}</td>
                <td>${mark.subject}</td>
                <td>${mark.grade}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });
}

// تحميل البيانات عند تحميل الصفحة
document.addEventListener("DOMContentLoaded", () => {
    fetchMaterials(); // جلب بيانات المواد الدراسية افتراضيًا
    fetchStudentMarks(); // جلب بيانات علامات الطلاب افتراضيًا
});

  // إظهار الصفحة المطلوبة
  const studentMarksPage = document.getElementById("student-marks-page");
  const academicSchedulePage = document.getElementById("academic-schedule-page");

  document.getElementById("student-marks-btn").addEventListener("click", () => {
      studentMarksPage.style.display = "block";
      academicSchedulePage.style.display = "none";
  });

  document.getElementById("academic-schedule-btn").addEventListener("click", () => {
      studentMarksPage.style.display = "none";
      academicSchedulePage.style.display = "block";
  });

  // جلب بيانات علامات الطلاب
  function fetchStudentMarks(year) {
      const apiUrl = `https://example.com/api/student-marks?year=${year}`; // استبدل بالرابط الفعلي

      fetch(apiUrl)
          .then(response => {
              if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
              return response.json();
          })
          .then(data => updateStudentTable(data))
          .catch(error => console.error("Error fetching student marks:", error));
  }

  // تحديث جدول علامات الطلاب
  function updateStudentTable(data) {
      const tableBody = document.querySelector("#student-table tbody");
      tableBody.innerHTML = ""; // تنظيف الجدول

      data.forEach((row, index) => {
          const tr = document.createElement("tr");
          tr.innerHTML = `
              <td>${index + 1}</td>
              <td>${row.name}</td>
              <td>${row.hours}</td>
              <td>${row.minGrade}</td>
              <td>${row.maxGrade}</td>
          `;
          tableBody.appendChild(tr);
      });
  }

  // جلب بيانات الجدول الأكاديمي
  function fetchAcademicData() {
      const apiUrl = "https://example.com/api/academic-schedule"; // استبدل بالرابط الفعلي

      fetch(apiUrl)
          .then(response => {
              if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
              return response.json();
          })
          .then(data => updateAcademicTable(data))
          .catch(error => console.error("Error fetching academic data:", error));
  }

  // تحديث الجدول الأكاديمي
  function updateAcademicTable(data) {
      const tableBody = document.querySelector(".Akadamik-table tbody");
      tableBody.innerHTML = ""; // تنظيف الجدول

      data.forEach(row => {
          const tr = document.createElement("tr");
          tr.innerHTML = `
              <td>${row.name}</td>
              <td><input type="datetime-local" value="${row.startDate}"></td>
              <td><input type="datetime-local" value="${row.endDate}"></td>
          `;
          tableBody.appendChild(tr);
      });
  }

  // إرسال البيانات المعدلة للجدول الأكاديمي إلى الباك إند
  function sendUpdatedData() {
      const tableRows = document.querySelectorAll(".Akadamik-table tbody tr");
      const updatedData = Array.from(tableRows).map(row => {
          const cells = row.querySelectorAll("td");
          return {
              name: cells[0].textContent.trim(),
              startDate: cells[1].querySelector("input").value,
              endDate: cells[2].querySelector("input").value,
          };
      });

      const apiUrl = "https://example.com/api/update-academic-schedule"; // استبدل بالرابط الفعلي

      fetch(apiUrl, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(updatedData),
      })
          .then(response => {
              if (!response.ok) throw new Error(`HTTP error! status: ${response.status}`);
              return response.json();
          })
          .then(data => {
              console.log("Data updated successfully:", data);
              alert("تم حفظ التغييرات بنجاح.");
          })
          .catch(error => {
              console.error("Error updating academic data:", error);
              alert("حدث خطأ أثناء حفظ البيانات.");
          });
  }

  // عند تغيير السنة
  document.getElementById("year-select").addEventListener("change", (e) => {
      fetchStudentMarks(e.target.value);
  });

  // عند تحميل الصفحة
  document.addEventListener("DOMContentLoaded", () => {
      // الصفحة الافتراضية
      studentMarksPage.style.display = "block";
      academicSchedulePage.style.display = "none";

      // جلب البيانات الافتراضية
      fetchStudentMarks("year1");
      fetchAcademicData();

      // ربط زر الحفظ
      document.getElementById("save-button").addEventListener("click", sendUpdatedData);
  });
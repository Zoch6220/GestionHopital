# ProjectFinal: Hospital Admission Management System

## Screenshots

### Login Window
![Login](https://github.com/user-attachments/assets/bf5221fe-f7e5-4e56-ab7d-c9a17454efdb)

### Admission Window
![Admission1](https://github.com/user-attachments/assets/d13e5889-b940-4436-a3ad-ce1d8ab4df10)
![Admission2](https://github.com/user-attachments/assets/c8297771-89d6-41c3-811d-044ab10cfc6e)

### Discharge Window
![Discharge](https://github.com/user-attachments/assets/1b35b3fe-077b-4681-9b45-ee7f29a62170)

---

# Documentation: `FenetreAdmission` Class in C#

## Overview
The `FenetreAdmission` class in the `ProjetHopital` namespace handles the logic for managing admissions in a hospital system. It interacts with the hospital database via Entity Framework Core to manage patient records, admissions, and medical services. The class provides methods for creating and searching for patients, validating input, handling admissions, and interacting with various UI components.

## Class: `FenetreAdmission`

### Properties
- **db**  
  - **Type**: `HopitalContext`  
  - **Description**: Instance of the `HopitalContext` class used for interacting with the database.

### Constructor
- **FenetreAdmission()**  
  - **Description**: Default constructor that initializes the `FenetreAdmission` window and its associated components.

### Methods
1. **Window_Loaded(object sender, RoutedEventArgs e)**  
   - **Description**: Triggered when the window is loaded. Initializes the database context and loads the department, bed, doctor, and insurance lists into their respective UI components.

2. **btnFind_Click(object sender, RoutedEventArgs e)**  
   - **Description**: Called when the "Search" button is clicked. Attempts to find a patient in the database using the Social Security Number (SSN). If the patient is found, their information is displayed; otherwise, the option to create a new patient is provided.

3. **btnCree_Click(object sender, RoutedEventArgs e)**  
   - **Description**: Triggered when a new patient record is created. Validates input fields (SSN format, postal code, phone, etc.), creates a `Patient` object, and saves it in the database.

4. **btn_admin_Click(object sender, RoutedEventArgs e)**  
   - **Description**: Handles patient admission. Verifies the patient’s existence, saves admission details (including scheduled surgery if applicable), and marks the selected bed as occupied.

5. **btn_annuler_Click(object sender, RoutedEventArgs e)**  
   - **Description**: Resets all fields in the admission form.

6. **EffaceTout()**  
   - **Description**: Clears all fields in the window and reloads department, bed, doctor, and insurance lists.

7. **cboxDep_SelectionChanged(object sender, SelectionChangedEventArgs e)**  
   - **Description**: Triggered when the department selection changes. Updates the list of available beds in the selected department.

8. **btnRetour_Click(object sender, RoutedEventArgs e)**  
   - **Description**: Closes the current window and opens the `FenetrePrepose` window.

9. **LoadDepartement()**  
   - **Description**: Loads the list of departments into the `cboxDep` ComboBox.

10. **LoadLit()**  
    - **Description**: Loads the list of unoccupied beds and associates each bed with its type.

11. **LoadMedecin()**  
    - **Description**: Loads the list of doctors into the `cboxMedecin` ComboBox.

12. **LoadAssurance()**  
    - **Description**: Loads the list of insurance providers into the `cboxAssurance` ComboBox.

13. **CheckAge(Patient patient)**  
    - **Description**: Checks the patient's age. If the patient is 16 years or younger, the pediatric department is automatically selected, and the department selection is disabled.

14. **CheckEmpty()**  
    - **Description**: Checks if all required fields are filled. Returns `false` if any mandatory field is empty.

15. **TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)**  
    - **Description**: Prevents the user from entering numbers in text fields intended for names (first name, last name, etc.).

16. **btnUpdate_Click(object sender, RoutedEventArgs e)**  
    - **Description**: Updates the patient's information in the database.

17. **Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)**  
    - **Description**: Handles the window closing event. Opens the `FenetrePrepose` window when `FenetreAdmission` is closed.

---

### Notes
- This class uses Entity Framework Core for database interactions and WPF for managing the user interface.



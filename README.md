#Welcome to the Mohio technical Test 1
----
This test contains a small patient application that has several issues.

Please fix them and execute each method below.

Rules
----
1. The entire solution must be written in C# .net5
2. Please modify the solution anyway you prefer. 
   1. You can modify classes, rename and add methods, change property types, add projects 
   1. Use libraries or frameworks (must be .net based)
3. Write tests

Show your skills

Good luck 

When you have finished the solution please do a pull request to original repository (push only the necessary files)

## App process
1. Get patient by usre id(Patient Info and Immunisations)
2. Get available Immunisation list
2. Add Immunisation to Patient(Set Immunisation properties)
3. Remove Existing Immunisaiton from Patient(Set Immunisation properties)
4. Clone Patient  then Merge to another patient(Because patient may change practices)
5. Get total patient done the immunisation with Outcome Status is "Given from the last month
6. Patient info to string


## Improvement
1. As there is no real DB, so using cutom defined functions to creat dummy data as lists, so syntax and logic are different in the project
2. Should add check existence of patient and/or immunisation by id in controller, but has limited time, the project is just an quick example
3. DId not implement unit test for all test cases, again just a demo
4. Should have proper atrributes in Patient and Immunisation classes
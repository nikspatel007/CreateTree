# Initial Problem

Parameters:

1. Can be solved in any language 
2. Deliver a working runnable solution.
3. Style and approach is completely up to the developer.

Given the string:
```
"(id,created,employee(id,firstname,employeeType(id), lastname),location)"
```

Output the following:
```
id
created
employee
- id
- firstname
- employeeType
-- id
- lastname
location
```

# Bonus (output in alphabetical order):

```
created
employee
- employeeType
-- id
- firstname
- id
- lastname
id
location
```

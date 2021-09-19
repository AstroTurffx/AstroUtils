# Read Only Attribute
Makes the property uneditable in the inspector.

### Example
```c#
public float notReadOnly;
[ReadOnly] public float readOnly;
```
![Read Only Attribute Example](https://github.com/AstroTurffx/AstroUtils/tree/main/Documentation/ExampleImages/ReadOnlyAttribute.png?raw=true)


# Fold Attribute
Adds the property to a specified foldout group.

### Parameters

#### `name`
Name of the foldout group.

#### `continuous`
Toggle to fold variables below it.
##### Default: `false`

### Example
```c#
[Fold("Group 1", true)]
public float testValue1;
public float testValue2;

[Fold("Group 2", false)]
public float testValue3;
public float testValue4;
```
![Fold Attribute Example](https://github.com/AstroTurffx/AstroUtils/tree/main/Documentation/ExampleImages/FoldAttribute.png?raw=true)
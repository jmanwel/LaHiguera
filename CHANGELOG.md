# La Higuera Changelog

## V2.0.0

### Commits

See the full commit list [here](https://github.com/jmanwel/LaHiguera/compare/1.0.0...release/2.0.0)

### Update Instructions

To update from version v1.0.0 to v2.0.0 you must run these scripts in order with python:

```
cd Scripts
python3 01-migration_to_new_db_structure.py
python3 02-delete_unnecesary_tables.py
python3 03-fields_typo_changes.py
python3 04-fields_typo_changes_colposcopia.py
python3 05-new_fields.py
```

### For run the file_manager.py script

Please install these libraries:

'''
cryptography
googleapiclient
tabulate
'''
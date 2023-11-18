# MNSPlusImporter

This is a basic Windows Forms Program that makes it easy to create new MNS+ users and generates Information-Sheets containing their credentials.

## Usage

You need the [MNS+ Import sheet](https://mnsplus.bildung-rp.de/fileadmin/user_upload/mns.bildung-rp.de/downloads/Import-MNSplus.xls) and a CSV File containing the Student data.

Student data has to be formatted as following:
```csv
vorname, nachname, username, klasse, geburtstag
xxx, yyy, xxxyyy, zz, aa/bb/cc
...
```

Then just open the Program, it's pretty intuitive.

When it's done, your import sheet will be changed to contain the students you gave in your input file, with a secure password set, and a `pdf` containing info-sheets to give out.

The import sheet can be used directly to create the users in MNS+

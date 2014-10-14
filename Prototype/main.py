#!/bin/sh
if [ -z "$1" ]
then
    echo "No file specified"
    exit 1
fi

# Change '/opt/sublime_text/sublime_text' to the path of your executable for desired IDE.
/usr/bin/atom "`wine winepath -u "$1"`:$2:$3"
# Note that the 'wine winepath', which translates Windows path name to Unix, is the natively installed 'wine'.

echo "Opening '$1' on line '$2' column '$3' with Sublime Text"
exit 0

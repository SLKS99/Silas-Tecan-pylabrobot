<<<<<<< HEAD
=======
# SiLA2 Connector for Fluent
This repository contains a console application that exports the functionality of the FluentControl API as SiLA2 Server. 
This allows to call into the FluentControl API using other programming languages by means of a SiLA2 client. For convenience, the repository also already contains a ready-made Python client.

**The code in this repository can be used free of charge, but Tecan does not give warranties. For details, please consult the License description.**

## Requirements
This project references the FluentControl API from its default install location and therefore, FluentControl needs to be installed in order to build the SiLA2 connector. All other dependencies can be downloaded from package managers.

To use the Python libraries, the following tools are required:
* Python 3.7
* pip 19.3.1

## Cloning
Clone the repository either with HTTPs or SSH (choose the appropriate link in the clone button)
```bash
git clone https://gitlab.com/tecan/fluent-sila2-connector.git
```

## Getting started

### Creating a virtual environment:
```bash
pip install virtualenv
virtualenv path\to\virtualenv
```

### Activate the virtual environment:
```bash
path\to\virtualenv\Scripts\activate
```

### With virtualenv activated:
```bash
pip install sila2lib
```

Next, navigate into the tecan folder and type:
```bash
setup.py install
```

If the setup is successful you will be able to use the python client in any python-script by just importing it:
```python
from tecan import Fluent
```

To start the server just install it via the windows installer and start SilaFluentServer.exe
Now you can connect the python by initializing a Fluent-Object in your script:

```python
fluent = Fluent(string server-ip, int port)
```

and start fluent from your script:
```python
fluent.start_fluent()
```

To login with UMS you can add username and password like this:
```python
fluent.start_fluent(username=”abc”, password=”xyz”)
```


## Issues and Bugs
If you see an issue please feel free to file a bug on the project [list of issues](https://gitlab.com/tecan/fluent-sila2-connector/issues)

## License
This code is licensed under the [New BSD License](https://choosealicense.com/licenses/bsd-3-clause/)
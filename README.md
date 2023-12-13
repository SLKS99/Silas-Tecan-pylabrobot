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
pip install sila2
```

Next, navigate into the Python folder and type:
```bash
python setup.py install
```

If the setup is successful you will be able to use the python client in any python-script by just importing it:
```python
from tecan import Fluent
```

To start the server just install it via the windows installer (in the Binaries folder). Note: The installation will succeed in under 1 sec and without confirmation. Next, start the SiLAServer: 
```cmd
C:\Program Files (x86)\SilaFluentServerSetup\Files\SilaFluentServer.exe
```

Now you can connect python by initializing a Fluent-Object in your script:

```python
fluent = Fluent("127.0.0.1", 50052)
```

or, if you do not have SSL certificates you may choose to switch off secured connection (do not do this in production environment!):
```python
fluent = Fluent("127.0.0.1", 50052, insecure=True)
```

and start fluent from your script:
```python
fluent.start_fluent()
```

As an alternative to the above, we now also support discovery. This means, the following will also work:
```python
fluent = Fluent.discover(10)
```

To login with UMS you can add username and password like this:
```python
fluent.start_fluent(username=”abc”, password=”xyz”)
```


## Issues and Bugs
If you see an issue please feel free to file a bug on the project [list of issues](https://gitlab.com/tecan/fluent-sila2-connector/issues)

## License
This code is licensed under the [New BSD License](https://choosealicense.com/licenses/bsd-3-clause/). This means, the code in this repository can be used free of charge, but also without warranties.
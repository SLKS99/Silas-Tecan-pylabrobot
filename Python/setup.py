'''setup.py'''

try:
    from setuptools import setup
except ImportError:
    from distutils.core import setup # pylint:disable=no-name-in-module, import-error

import tecan
import pip
from optparse import Option
options = Option("--workaround")
options.skip_requirements_regex = None
reqs_file = './requirements.txt'
pipmajor = int(pip.__version__[0:pip.__version__.index(".")])

# Hack for old pip versions
if pipmajor >= 10:
    # Versions greater or equal to 10.x don't rely on pip.req.parse_requirements
    install_reqs = list(val.strip() for val in open(reqs_file))
    reqs = install_reqs
elif pipmajor == 1:
    # Versions 1.x rely on pip.req.parse_requirements
    # but don't require a "session" parameter
    from pip.req import parse_requirements # pylint:disable=no-name-in-module, import-error
    install_reqs = parse_requirements(reqs_file, options=options)
    reqs = [str(ir.req) for ir in install_reqs]
else:
    # Versions greater than 1.x but smaller than 10.x rely on pip.req.parse_requirements
    # and requires a "session" parameter
    from pip.req import parse_requirements # pylint:disable=no-name-in-module, import-error
    from pip.download import PipSession  # pylint:disable=no-name-in-module, import-error
    options.isolated_mode = False
    install_reqs = parse_requirements(  # pylint:disable=unexpected-keyword-arg
        reqs_file,
        session=PipSession,
        options=options
    )
    reqs = [str(ir.req) for ir in install_reqs]

config = {
    'description': 'Python Client for Tecan instruments',
    'author': 'Tecan Trading AG',
    'url': 'http://www.tecan.com',
    'author_email': 'swdev.support@tecan.com',
    'version': tecan.__version__,
    'install_requires': reqs,
    'packages': ['tecan', 'tecan.__SilaFluentController', 'tecan.__SilaFluentController.SilaFluentController', 
    'tecan.__SilaFluentController.SilaFluentController.gRPC', 'tecan.__SilaFluentController.meta'],
    'package_data': {
    },
    'scripts': [],
    'name': 'tecan',
    'include_package_data': True,
    'python_requires': '>=3.6',
}

setup(**config)

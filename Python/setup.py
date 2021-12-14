from os.path import dirname, join

from setuptools import find_packages, setup

base_dir = dirname(__file__)
package_dir = "src"
name = "tecan"

test_requirements = [
    "pytest",
    "pytest-cov",  # pytest: code coverage
]
code_quality_requirements = [
    "flake8",  # style checker
]

setup(
    name=name,
    version="0.2.0",
    author="Tecan Trading AG",
    author_email="swdev.support@tecan.com",
    description="Python interface for FluentControl",
    long_description=open(join(dirname(__file__), "..", "README.md"), encoding="utf-8").read(),
    long_description_content_type="text/markdown",
    url="https://gitlab.com/tecan/fluent-sila2-connector",
    project_urls={
        "Source": "https://gitlab.com/tecan/fluent-sila2-connector",
        "Bug Reports": "https://gitlab.com/tecan/fluent-sila2-connector/-/issues",
    },
    classifiers=[
        "Intended Audience :: Developers",
        "Intended Audience :: Science/Research",
        "Intended Audience :: Healthcare Industry",
        "License :: OSI Approved :: MIT License",
        "Operating System :: OS Independent",
        "Programming Language :: Python :: 3",
    ],
    packages=find_packages(where=package_dir),
    package_dir={"": package_dir},
    install_requires=[
        "sila2",
    ],
    python_requires=">=3.7",
    extras_require=dict(
        tests=test_requirements,
        dev=test_requirements + code_quality_requirements,
    ),
    include_package_data=True,
)

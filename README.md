# Veilig
> Veilig - Encrypted Pastes

Veilig is a minimalistic, NOJS encrypted paste webapp which supports password based encryption and auto destruction of paste after a single view.

![Index](https://raw.githubusercontent.com/smnbhw/Veilig/master/Readme%20Assets/Index.png)

![Unlock](https://github.com/smnbhw/Veilig/raw/master/Readme%20Assets/Unlock.png)

## Installation

OS X, Linux & Windows:
(git clone and run the following commands in the cloned directory)

```sh
dotnet restore
dotnet run
```

## Docker Instruction

Clone this git repository and inside the cloned directory, run the following commands to create a docker container:

```sh
docker build --tag veilig:latest .
docker run -d --name veilig -p 8080:80 veilig
```

Visit http://localhost:8080/ to access the WebApp.

## Usage Example

- Create a paste in the Index and encrypt a password.
- Once done, hit Submit and wait for the server to send the unique paste URL.
- Copy and share it and the first one to visit the link can unlock it with the given password.
- Once unlocked, the paste is purged from the server database.

## Development Setup

Make sure to have .NET Core SDK installed on your machine. Git clone this repository and run the following in the cloned directory.

```sh
dotnet restore
```

## Meta

Distributed under the GNU GPLv3 license. See ``LICENSE.txt`` for more information.

[https://github.com/smnbhw/Veilig.git](https://github.com/smnbhw/Veilig.git)

## Contributing

1. Fork it (<https://github.com/yourname/yourproject/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request

<!-- Markdown link & img dfn's -->
[npm-image]: https://img.shields.io/npm/v/datadog-metrics.svg?style=flat-square
[npm-url]: https://npmjs.org/package/datadog-metrics
[npm-downloads]: https://img.shields.io/npm/dm/datadog-metrics.svg?style=flat-square
[travis-image]: https://img.shields.io/travis/dbader/node-datadog-metrics/master.svg?style=flat-square
[travis-url]: https://travis-ci.org/dbader/node-datadog-metrics
[wiki]: https://github.com/yourname/yourproject/wiki

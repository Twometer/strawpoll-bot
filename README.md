# strawpoll-bot
Voting bot for Strawpoll

## Usage
```
Syntax: strawpoll-bot.exe <poll> <choiceIdx> <voteCount> <proxyList>

Poll: Link to the poll or the poll id
ChoiceIdx: Zero-based index of the choice
VoteCount: Number of votes to generate
ProxyList: Path to a proxy list (Optional)
```

You will need a proxy list if the poll creator disallowed multiple votes on one IP address.
Just google "proxy list" and you'll find lots of them

## Proxy list format
A text file with contents like the following:

```
<ip address>:<port>
```

One proxy per line

## Disclaimer
I am not responsible for anything you do with this tool.

## In case the Strawpoll creators see this
Adding a captcha would be a good idea :-)
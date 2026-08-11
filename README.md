

# Jellyfin Ignore Plugin

This plugin allows for the exclusion of files based on the specifications outlined in the `.jellyfinignore` file.

## Usage

Place a `.jellyfinignore` file in your media library directory. It supports standard `.gitignore` syntax, including comments (`#`), negation (`!`), and wildcard patterns. For example:

```gitignore
# Ignore all sample files
*sample*

# Except for specific samples
!sample_keep.mkv
```

## Manifest

`https://raw.githubusercontent.com/arition/jellyfin-plugin-ignore/master/manifest.json`

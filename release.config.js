module.exports = {
    branches: ['master'],
    plugins: [
      '@semantic-release/commit-analyzer',
      '@semantic-release/release-notes-generator',
      ['@semantic-release/changelog', {
        changelogFile: 'CHANGELOG.md'
      }],
      ['@semantic-release/exec', {
        prepareCmd: 'sed -i "s#<Version>.*</Version>#<Version>${nextRelease.version}</Version>#" ./Sample.Semantic.Versioning/Sample.Semantic.Versioning.csproj'
      }],
      ['@semantic-release/git', {
        assets: ['CHANGELOG.md', 'Sample.Semantic.Versioning/Sample.Semantic.Versioning.csproj'],
        message: 'chore(release): ${nextRelease.version} [skip ci]\n\n${nextRelease.notes}'
      }],
      '@semantic-release/github'
    ],
    verifyConditions: [
      '@semantic-release/github',
      {
        path: '@semantic-release/exec',
        cmd: 'echo $GH_TOKEN' // Ensure GH_TOKEN is available
      }
    ]
  }

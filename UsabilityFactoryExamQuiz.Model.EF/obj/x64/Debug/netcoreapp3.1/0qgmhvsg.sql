IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Questions] (
    [Id] uniqueidentifier NOT NULL,
    [Text] nvarchar(max) NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Answers] (
    [Id] uniqueidentifier NOT NULL,
    [Text] nvarchar(max) NULL,
    [QuestionEntityId] uniqueidentifier NULL,
    CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Questions_QuestionEntityId] FOREIGN KEY ([QuestionEntityId]) REFERENCES [Questions] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [AnswerAttachments] (
    [Id] uniqueidentifier NOT NULL,
    [AnswerId] uniqueidentifier NOT NULL,
    [Created] datetime2 NOT NULL,
    [FileName] nvarchar(max) NOT NULL,
    [MimeType] nvarchar(max) NOT NULL,
    [Size] int NOT NULL,
    [AnswerEntityId] uniqueidentifier NULL,
    CONSTRAINT [PK_AnswerAttachments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AnswerAttachments_Answers_AnswerEntityId] FOREIGN KEY ([AnswerEntityId]) REFERENCES [Answers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [AnswerEvents] (
    [Id] uniqueidentifier NOT NULL,
    [AnswerId] uniqueidentifier NOT NULL,
    [Value] nvarchar(max) NULL,
    [Type] int NOT NULL,
    [ClientTime] datetime2 NOT NULL,
    [AnswerEntityId] uniqueidentifier NULL,
    CONSTRAINT [PK_AnswerEvents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AnswerEvents_Answers_AnswerEntityId] FOREIGN KEY ([AnswerEntityId]) REFERENCES [Answers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_AnswerAttachments_AnswerEntityId] ON [AnswerAttachments] ([AnswerEntityId]);
GO

CREATE INDEX [IX_AnswerAttachments_AnswerId] ON [AnswerAttachments] ([AnswerId]);
GO

CREATE UNIQUE INDEX [IX_AnswerAttachments_Id] ON [AnswerAttachments] ([Id]);
GO

CREATE INDEX [IX_AnswerEvents_AnswerEntityId] ON [AnswerEvents] ([AnswerEntityId]);
GO

CREATE INDEX [IX_AnswerEvents_AnswerId] ON [AnswerEvents] ([AnswerId]);
GO

CREATE UNIQUE INDEX [IX_AnswerEvents_Id] ON [AnswerEvents] ([Id]);
GO

CREATE UNIQUE INDEX [IX_Answers_Id] ON [Answers] ([Id]);
GO

CREATE INDEX [IX_Answers_QuestionEntityId] ON [Answers] ([QuestionEntityId]);
GO

CREATE UNIQUE INDEX [IX_Questions_Id] ON [Questions] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210225184444_Questionaire', N'5.0.3');
GO

COMMIT;
GO


------------------------------------------------------------------------
-- Table..: Reminder
-- Purpose: This table stores reminders. Reminders can be attached to
--          Events or Todo List items.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Reminder
(
    ReminderId                      INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime                      DATETIME    NOT NULL,
    ModifyTime                      DATETIME    NOT NULL,

    TimeAmount                      INTEGER     NOT NULL,
    TimeUnit                        INTEGER     NOT NULL,

    NotifyViaTray                   BOOLEAN     NOT NULL,
    NotifyViaAudio                  BOOLEAN     NOT NULL,
    NotifyViaEmail                  BOOLEAN     NOT NULL,
    NotifyViaText                   BOOLEAN     NOT NULL,

    NotifyTrayMessage               TEXT            NULL,
    NotifyAudioFile                 TEXT            NULL,
    NotifyEmailAddress              TEXT            NULL,
    NotifyPhoneNumber               TEXT            NULL,
    NotifyCarrierListId             INTEGER         NULL
);

CREATE UNIQUE INDEX idx_Reminder_ReminderId ON Reminder(ReminderId);

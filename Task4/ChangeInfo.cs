using System;

namespace Task4
{
    public record ChangeInfo(ChangeType Type, DateTime Date, string OriginalPath, string BackupPath);
}